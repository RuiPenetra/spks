using EI.SI;
using SPKS___Server;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Servidor
{

    public class Program
    {
        // PORTO A UTILIZAR NAS COMUNICAÇÕES
        private const int PORT = 10000;

        public static RSACryptoServiceProvider rSA_Servidor;

        public static string publickey;
        public static string bothkeys;

        
        static void Main(string[] args)
        {
            // RECEBE AS COMUNICAÇÕES E FICA A ESCUTA
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, PORT);
            TcpListener listener = new TcpListener(endpoint);
            listener.Start();

            Console.WriteLine("<APP Servidor iniciada>");

            // TOTAL DE CLIENTES ATIVOS
            int clientCounter = 0;

 
            //Gerar chave
            rSA_Servidor = new RSACryptoServiceProvider();


            // PARA SEMPRE ATÉ MORRER....
            while (true)
            {
                // ACEITA A LIGAÇÃO
                TcpClient client = listener.AcceptTcpClient();



                // INCREMENTA O CONTADOR DE CLIENTES
                clientCounter++;

                Console.WriteLine("<{0} clientes ligados>", clientCounter);


                // INSTANCIA UM NOVO OBJETO PARA TRATAR DAS RESPOSTAS DO CLIENTE
                ClientHandler clientHandler = new ClientHandler(client, clientCounter, rSA_Servidor);

                // INICIA A THREAD DESSE OBJETO PARA RESPONDER AO CLIENTE
                clientHandler.Handle();

                // DEPOIS VOLTA A ESTAR À ESCUTA DE NOVOS CLIENTES
            }
        }


        //lista de salas
        public static List<Sala> listaSalas = new List<Sala>();
        public List<Sala> ListaDeSalas()
        {
            // retorna a lista atual de salas
            return listaSalas;
        }

        public void AdicionarSala(Sala nova_sala)
        {
            listaSalas.Add(nova_sala);
        }

        public void AdicionarCliente(int id_sala)
        {
            listaSalas[id_sala].adicionarCliente();
        }

        public void RemoverCliente(int id_sala)
        {
            listaSalas[id_sala].numeroClientes--;
        }

        public int VerificarMensagensNovas(int id_sala)
        {
            int chat_alterado = listaSalas[id_sala].chat_alterado;

            // se o chat ainda tem alguem que nao leu as mensagens novas
            // remove essa pessoa, porque a seguir a esta verificacao 
            // ela vai chamar o pedir dados

            if (chat_alterado > 0)
            {
                listaSalas[id_sala].chat_alterado--;
            }

            return chat_alterado;
        }

        public void ExistemMensagensNovas(int id_sala)
        {
            listaSalas[id_sala].chat_alterado = 2;
        }

    }

    class ClientHandler
    {
        //CLASSE PARA AS THREADS
        //objetivo : criar a thread do cliente e tratar de toda a comunicaçao com o mesmo 


        NetworkStream networkStream;
        ProtocolSI protocolSI;

        private TcpClient client;
        private int clientID;
        int IdSala;
        string nickname;
        const string NAOACERTOU = "Não Acertou";
        const string MARCOU = "Marcou";
        const string DEFENDEU = "Defendeu";
        public List<Sala> listSalas;
        public string chavepublicaServidor;
        public string chavesPublicaPrivadaServidor;

        //para encriptação 
        string chavePublicaCliente;
        AesCryptoServiceProvider aes;
        RSACryptoServiceProvider rsaEncrypt;
        byte[] key;
        byte[] IV;


        // para a password
        const int SALTSIZE = 8;
        public const int NUMBER_OF_ITERATIONS = 1000;

        public static Program ClassePrincipalServidor = new Program();

        // para a bd
        SqlConnection conn = null;

        // para a hash para validação de dados (integridade)
        SHA512 sha512;

        byte[] hash_recebida = null;
        byte[] hash_cifrada = null;
        byte[] hash = null;
        byte[] dados_recebidos;

        public ClientHandler(TcpClient client, int clientID, RSACryptoServiceProvider rSA_Servidor)
        {
            // CONSTRUTOR QUE RECEBE O ID DO CLIENTE E A LIGAÇÃO TCP
            this.client = client;
            this.listSalas = ClassePrincipalServidor.ListaDeSalas();
            this.clientID = clientID;
            this.chavepublicaServidor = rSA_Servidor.ToXmlString(false);  // Chave Pública
            this.chavesPublicaPrivadaServidor = rSA_Servidor.ToXmlString(true); // Chave Privada + Pública
        }

        public void Handle()
        {
            // MÉTODO PARA CRIAR A THREAD

            // CRIA A THREAD E DIZ-LHE QUE MÉTODO USAR
            Thread thread = new Thread(threadHandler);

            // INICIA A THREAD
            thread.Start();
        }

        private void threadHandler()
        {
            // OBTEM O STREAM DE COMUNICAÇÃO COM O CLIENTE
            networkStream = this.client.GetStream();

            // INICIA O PROTOCOLO SI
            protocolSI = new ProtocolSI();

            // para a hash para validação de dados (integridade)
            sha512 = SHA512.Create();

            byte[] ack;
            string ficheiro_sala = "";
            StreamWriter streamWriter;

            // directoria do projeto (Servidor/)
           string directoriaProjeto = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;

            // ENQUANTO NÃO RECEBE UMA MSG DO TIPO EOT 
            while (protocolSI.GetCmdType() != ProtocolSICmdType.EOT)
            {
                // RECEBE AS MENSAGENS DO CLIENTE
                int bytesRead = networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);

                // VERIFICA O TIPO DE MENSAGEM RECEBIDO
                switch (protocolSI.GetCmdType())
                {

                    //enviar chaves 
                    case ProtocolSICmdType.USER_OPTION_1:


                        //guardar chave do cliente
                        this.chavePublicaCliente = protocolSI.GetStringFromData();

                        Enviar_ACK();

                        //criar chave simetrica 
                        aes = new AesCryptoServiceProvider();

                        //guardar chave e vetor da chave simetrica 
                        this.key = aes.Key;
                        this.IV = aes.IV;

                        // cifrar com a chave publica do cliente
                        string keycifrada = cifrarComChavePublica(this.key, this.chavePublicaCliente);
                        string ivcifrado = cifrarComChavePublica(this.IV, this.chavePublicaCliente);

                        // enviar chave simetrica para o cliente
                        //chave
                        byte[] enviarKey = protocolSI.Make(ProtocolSICmdType.SECRET_KEY, Convert.FromBase64String(keycifrada));
                        networkStream.Write(enviarKey, 0, enviarKey.Length);


                        // se o cliente respondeu ACK, continua a enviar coisas
                        if (Receber_ACK())
                        {
                            //enviar vetor
                            byte[] enviarIV = protocolSI.Make(ProtocolSICmdType.IV, Convert.FromBase64String(ivcifrado));
                            networkStream.Write(enviarIV, 0, enviarIV.Length);

                            if (Receber_ACK())
                            {
                                //cifrar a chave publica com a chave simetrica
                                byte[] chavePublica = Encoding.UTF8.GetBytes(chavepublicaServidor);
                                byte[] chavePublicaCifrada = cifrarComChaveSimetrica(chavePublica);

                                //enviar para o cliente
                                byte[] enviarChavePublicaCifrada = protocolSI.Make(ProtocolSICmdType.SYM_CIPHER_DATA, chavePublicaCifrada);
                                networkStream.Write(enviarChavePublicaCifrada, 0, enviarChavePublicaCifrada.Length);

                                if (!Receber_ACK())
                                {
                                    Enviar_NACK(); // algo correu mal
                                }


                            }
                            else
                            {
                                Enviar_NACK(); // algo correu mal
                            }

                        }
                        else
                        {
                            Enviar_NACK(); // algo correu mal
                        }

                        break;

                    // login
                    case ProtocolSICmdType.USER_OPTION_2:

                        dados_recebidos = protocolSI.GetData();

                        byte[] dados_login_bytes = decifrarComChaveSimetrica(dados_recebidos);

                        string dados_login = emString(dados_login_bytes);

                        // separar dados
                        string[] split_dados_login = Regex.Split(dados_login, "_Ø_"); // username_Ø_password

                        string user = split_dados_login[0];
                        string pass = split_dados_login[1];

                        Enviar_ACK();

                        // recebe a hash, decifra-a e envia ACK
                        hash_recebida = Receber_Hash();

                        // integridade
                        if (Integridade_Valida(hash_recebida, dados_login_bytes))
                        {
                            // caso login com sucesso, manda o OK e guarda o username
                            if (VerifyLogin(user, pass))
                            {
                                this.nickname = user;
                                Enviar_ACK();
                            }
                            else
                            {
                                Enviar_NACK();
                            }
                        }
                        else
                        {
                            Enviar_NACK();
                        }

                        break;

                    // registo
                    case ProtocolSICmdType.USER_OPTION_3:

                        dados_recebidos = protocolSI.GetData();

                        byte[] dados_bytes = decifrarComChaveSimetrica(dados_recebidos);

                        string dados = emString(dados_bytes);


                        Enviar_ACK();

                        // separar dados
                        string[] split_dados = Regex.Split(dados, "_Ø_"); // username_Ø_password

                        //guarda a password e passa para bytes
                        string username = split_dados[0];
                        byte[] password = Encoding.UTF8.GetBytes(split_dados[1]);

                        //gera o salt e "salga" a password
                        byte[] salt = GenerateSalt(SALTSIZE);
                        byte[] passwordSalt = GenerateSaltedHash(password, salt);

                        // recebe a hash, decifra-a e envia ACK
                        hash_recebida = Receber_Hash();


                        if (Integridade_Valida(hash_recebida, dados_bytes))
                        {
                            // caso registe com sucesso, manda o OK
                            if (Register(username, passwordSalt, salt))
                            {
                                Console.WriteLine("Novo registo de utilizador: " + username);
                                Enviar_ACK();
                            }
                            else
                            {
                                Enviar_NACK();
                            }
                        }
                        else
                        {
                            Enviar_NACK();
                        }
                        break;

                    // sala
                    case ProtocolSICmdType.USER_OPTION_4:

                        //receber dados
                        dados_recebidos = protocolSI.GetData();

                        //decifrar dados

                        byte[] nome_sala_bytes = decifrarComChaveSimetrica(dados_recebidos);

                        string nome_sala = emString(nome_sala_bytes);


                        //enviar ack
                        Enviar_ACK();

                        //receber hash, decifrar e enviar ack
                        hash_recebida = Receber_Hash();


                        if (Integridade_Valida(hash_recebida, nome_sala_bytes))
                        {
                            // remove caracteres especiais do nome da sala
                            // e constroi o caminho da directoria
                            ficheiro_sala = directoriaProjeto + "/Salas/" + CleanInput(nome_sala) + ".txt";

                            IdSala = getIdSala(listSalas, nome_sala);

                            //verificar se a sala ja existe 
                            if (File.Exists(ficheiro_sala) && IdSala > -1)
                            {
                                //Verifica se esta disponivel
                                if (listSalas[IdSala].numeroClientes >= 2) //Caso nao esteja disponivel
                                {
                                    //dizer que nao ta ok
                                    Enviar_NACK();

                                    Console.WriteLine("Cliente: " + nickname + " tentou entrar na sala " + nome_sala + " ");
                                    Console.WriteLine("<O cliente {0} desconectou-se!>", clientID);

                                    // FECHA AS COMUNICAÇOES COM O CLIENTE
                                    networkStream.Close();
                                    client.Close();

                                    return;
                                }
                                else
                                {
                                    //Adiciona o cliente
                                    ClassePrincipalServidor.AdicionarCliente(IdSala);
                                    if (listSalas[IdSala].nickname1 == null)
                                    {
                                        listSalas[IdSala].nickname1 = nickname;
                                    }
                                    else
                                    {
                                        listSalas[IdSala].nickname2 = nickname;
                                    }
                                    // colocar a sinalização de que ha msgs novas para o novo cliente ler
                                    ClassePrincipalServidor.ExistemMensagensNovas(IdSala);

                                    // avisar sala de que entrou

                                    streamWriter = new StreamWriter(ficheiro_sala, true); // append true
                                    streamWriter.WriteLine(nickname + " entrou. ");
                                    streamWriter.Dispose();

                                }

                                Enviar_ACK();
                                if (listSalas[IdSala].Atac == null)
                                {
                                    listSalas[IdSala].Atac = nickname;
                                    enviarCliente("Ataque");
                                }
                                else
                                {
                                    listSalas[IdSala].Defensor = nickname;
                                    enviarCliente("Defesa");
                                }
                            }
                            else
                            {
                                //Criar sala(ficheiro);
                                // guarda o nome da sala no cliente
                                Sala Sala = new Sala(nome_sala);

                                streamWriter = new StreamWriter(ficheiro_sala, false); // append false

                                streamWriter.WriteLine("Chat Iniciado");

                                // avisar sala de que entrou
                                streamWriter.WriteLine(nickname + " entrou. ");
                                streamWriter.Dispose();



                                // cria nova sala na lista geral
                                ClassePrincipalServidor.AdicionarSala(Sala);

                                // atualiza a lista local
                                this.listSalas = ClassePrincipalServidor.ListaDeSalas();

                                IdSala = listSalas.LastIndexOf(Sala);



                                Enviar_ACK();

                                listSalas[IdSala].nickname1 = nickname;
                                listSalas[IdSala].Atac = nickname;
                                enviarCliente("Ataque");


                                Console.WriteLine("Sala criada: " + Sala.nome + " ");
                                Console.WriteLine("Total de salas: " + listSalas.Count() + " ");

                            }
                            break;
                        }
                        else
                        {
                            Enviar_NACK();
                        }
                        break;


                    //resposta ao pedido de dados do cliente
                    case ProtocolSICmdType.USER_OPTION_5:

                        //receber dados
                        dados_recebidos = protocolSI.GetData();

                        //passar para bytes
                        byte[] dados_Bytes = decifrarComChaveSimetrica(dados_recebidos);

                        //decifrar dados
                        int lenghtClienteTem = Int32.Parse(emString(dados_Bytes));

                        //enviar ack
                        Enviar_ACK();

                        //receber hash e  enviar ack
                        hash_recebida = Receber_Hash();


                        //  verificar a integridade
                        if (Integridade_Valida(hash_recebida, dados_Bytes))
                        {
                            Enviar_ACK();

                            // vai buscar o ficheiro da sala para ler
                            ficheiro_sala = directoriaProjeto + "/Salas/" + CleanInput(listSalas[IdSala].nome) + ".txt";

                            string response = File.ReadAllText(ficheiro_sala);

                            response = response.Substring(lenghtClienteTem);

                            // LIMPA A VARIAVEL AUXILIAR
                            string stringChunk = "";

                            // TAMANHO PARA LER DE CADA VEZ (USAR COMO MÁX 64 CARACTERES)
                            int chunkSize = 60;

                            // VAI BUSCAR O TAMANHO DA RESPOSTA
                            int stringLength = response.Length;

                            // variavel para o pacote
                            byte[] packet;


                            //packet = protocolSI.Make(ProtocolSICmdType.ACK, stringLength);
                            //networkStream.Write(packet, 0, packet.Length);

                            Console.WriteLine("  -> " + stringLength);

                            // PERCORRE A RESPOSTA E VAI DIVIDINDO EM PEDAÇOS PEQUENOS (CHUNKS)
                            for (int i = 0; i < response.Length; i = i + chunkSize)
                            {
                                // CASE SEJA O ÚLTIMO CHUNK
                                if (chunkSize > stringLength)
                                {

                                    // ENVIA TUDO O QUE FALTA
                                    stringChunk = response.Substring(i);

                                }

                                // CASO SEJA UM CHUNK NORMAL
                                else
                                {
                                    // DECREMENTA O TOTAL DE CARACTERES JÁ LIDOS
                                    stringLength = stringLength - chunkSize;

                                    // OBTEM ESSE CHUNK
                                    stringChunk = response.Substring(i, chunkSize);
                                }

                                //cifrar e enviar 
                                byte[] chunckCifrado = cifrarComChaveSimetrica(Encoding.UTF8.GetBytes(stringChunk));

                                // CRIA A MENSAGEM DO TIPO DATA UTILIZANDO O PROTOCOLO SI 
                                packet = protocolSI.Make(ProtocolSICmdType.DATA, chunckCifrado);

                                // ENVIA A RESPOSTA PARA O CLIENTE (WRITE)
                                networkStream.Write(packet, 0, packet.Length);
                            }

                            Console.WriteLine("  -> " + nickname + " atualizou os dados");

                            // CRIA O EOF PARA ENVIAR PARA O CLIENTE
                            byte[] eof = protocolSI.Make(ProtocolSICmdType.EOF);

                            // ENVIA A RESPOSTA PARA O CLIENTE (WRITE)
                            networkStream.Write(eof, 0, eof.Length);

                            Console.WriteLine("  -> " + nickname + " EOF ");


                            // Receber ACK, se o cliente recebeu tudo, continua
                            if (Receber_ACK())
                            {

                                // enviar hash de tudo
                                byte[] hashing = CriarHash_Assinar_Cifrar(Encoding.UTF8.GetBytes(response));

                                // CRIA A MENSAGEM DO TIPO NORMAL (para enviar a hash) UTILIZANDO O PROTOCOLO SI
                                packet = protocolSI.Make(ProtocolSICmdType.NORMAL, hashing);

                                //escreve na stream
                                networkStream.Write(packet, 0, packet.Length);

                                if (!Receber_ACK()) // nao recebeu hash
                                {
                                    Console.WriteLine("  -> " + nickname + "não recebeu hash ");

                                }

                            }

                        }
                        else
                        {
                            Enviar_NACK();
                        }

                        break;

                    // saber se existem novas msgs
                    case ProtocolSICmdType.USER_OPTION_6:

                        if (ClassePrincipalServidor.VerificarMensagensNovas(IdSala) > 0)
                        {
                            // CRIA O ACK PARA ENVIAR PARA O CLIENTE para ele verificar as novas msgs
                            Enviar_ACK();
                            Console.WriteLine("  -> " + nickname + " precisa de novos dados");

                        }
                        else
                        {
                            Enviar_NACK(); // nao necessita de atualizar
                        }
                        break;
                    case ProtocolSICmdType.USER_OPTION_7:
                        //receber dados
                        dados_recebidos = protocolSI.GetData();
                        byte[] msg = decifrarComChaveSimetrica(dados_recebidos);
                        string pos = emString(msg);

                        //enviar ack
                        Enviar_ACK();

                        //receber hash e  enviar ack
                        hash_recebida = Receber_Hash();


                        //  verificar a integridade
                        if (Integridade_Valida(hash_recebida, msg))
                        {
                            if (nickname == listSalas[IdSala].Atac)
                            {
                                listSalas[IdSala].PosAtac = pos;
                                Console.Write("Estou a atacar na pos:" + pos);
                            }
                            else
                            {
                                listSalas[IdSala].PosDefensor = pos;
                                Console.Write("Estou a defender na pos:" + pos);

                            }

                        }
                        else
                        {
                            Enviar_NACK();
                        }
                        break;
                    case ProtocolSICmdType.USER_OPTION_8:

                        if (listSalas[IdSala].PosAtac == null || listSalas[IdSala].PosDefensor == null)
                        {
                            Enviar_NACK();
                            break;
                        }

                        Enviar_ACK();

                        if (listSalas[IdSala].PosAtac == listSalas[IdSala].PosDefensor)
                        {
                            if (nickname == listSalas[IdSala].Atac)
                            {

                                enviarCliente(NAOACERTOU);
                                listSalas[IdSala].msg++;
                            }
                            else
                            {
                                enviarCliente(DEFENDEU);
                                listSalas[IdSala].msg++;
                                listSalas[IdSala].adicionarPontos(nickname);

                            }
                        }
                        else
                        {
                            if (nickname == listSalas[IdSala].Atac)
                            {
                                enviarCliente(MARCOU);
                                listSalas[IdSala].msg++;
                                listSalas[IdSala].adicionarPontos(nickname);

                            }
                            else
                            {
                                enviarCliente(NAOACERTOU);
                                listSalas[IdSala].msg++;

                            }
                        }

                        if (listSalas[IdSala].msg == 2)
                        {

                            listSalas[IdSala].msg = 0;
                            listSalas[IdSala].PosAtac = null;
                            listSalas[IdSala].PosDefensor = null;
                            listSalas[IdSala].trocarFuncoes();
                            listSalas[IdSala].QuantosJogaram++;
                            if (listSalas[IdSala].QuantosJogaram == 5)
                            {
                                listSalas[IdSala].QuantosJogaram = 0;
                                listSalas[IdSala].PontosJogador1 = 0;
                                listSalas[IdSala].PontosJogador2 = 0;

                            }

                        }

                        break;


                    // SE FOR DO TIPO DATA É UMA MENSAGEM PARA MOSTRAR
                    case ProtocolSICmdType.DATA:

                        //receber dados
                        dados_recebidos = protocolSI.GetData();

                        //decifrar dados
                        byte[] mensagemBytes = decifrarComChaveSimetrica(dados_recebidos);

                        // passar para string
                        string mensagem = emString(mensagemBytes);

                        //enviar ack
                        Enviar_ACK();

                        //receber hash e  enviar hack
                        hash_recebida = Receber_Hash();


                        // integridade
                        if (Integridade_Valida(hash_recebida, mensagemBytes))
                        {
                            // mensagens normais
                            //Console.WriteLine("  (" + nickname + "): " + protocolSI.GetStringFromData());
                            streamWriter = new StreamWriter(ficheiro_sala, true); // append true
                            streamWriter.WriteLine(nickname + " disse: " + mensagem);
                            streamWriter.Dispose();

                            // colocar a sinalização de que ha msgs novas
                            ClassePrincipalServidor.ExistemMensagensNovas(IdSala);

                            Enviar_ACK();

                        }
                        else
                        {
                            Enviar_NACK();
                        }

                        break;

                    // SE FOR DO TIPO EOT É PARA FECHAR A COMUNICAÇÃO
                    case ProtocolSICmdType.EOT:
                        Console.WriteLine("<O cliente {0} desconectou-se!>", clientID);

                        // avisar sala
                        if (!ficheiro_sala.Equals(""))
                        {
                            streamWriter = new StreamWriter(ficheiro_sala, true); // append true
                            streamWriter.WriteLine(nickname + " desligou-se. ");
                            streamWriter.Dispose();
                            // colocar a sinalização de que ha msgs novas
                            ClassePrincipalServidor.ExistemMensagensNovas(IdSala);

                            // remover utilizador da sala
                            ClassePrincipalServidor.RemoverCliente(IdSala);

                            // atualiza a lista local
                            this.listSalas[IdSala].numeroClientes--;
                        }

                        Enviar_ACK();

                        break;
                }

            }

            // FECHA AS COMUNICAÇOES COM O CLIENTE
            networkStream.Dispose();
            client.Dispose();
        }

        //Funções

        private void Enviar_ACK()
        {
            // enviar o ACK em como recebeu os dados
            byte[] ack = protocolSI.Make(ProtocolSICmdType.ACK);
            networkStream.Write(ack, 0, ack.Length);
        }
        private void Enviar_NACK()
        {
            // enviar o ACK em como recebeu os dados
            byte[] ack = protocolSI.Make(ProtocolSICmdType.NACK);
            networkStream.Write(ack, 0, ack.Length);
        }

        private bool Receber_ACK()
        {

            int bytesRead = networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);

            // VERIFICA O TIPO DE MENSAGEM RECEBIDO
            if (protocolSI.GetCmdType() == ProtocolSICmdType.ACK)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        private byte[] Receber_Hash()
        {
            // receber a hash
            networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);

            if (protocolSI.GetCmdType() == ProtocolSICmdType.NORMAL)
            {
                // ler hash
                hash_recebida = protocolSI.GetData();

                // decifra-la com chave simetrica
                byte[] hash_recebida_decifrada = decifrarComChaveSimetrica(hash_recebida);

                Enviar_ACK();

                return hash_recebida_decifrada;
            }

            return null;
        }

        private bool Integridade_Valida(byte[] hash_recebida, byte[] dados_bytes)
        {

            // criar hash dos dados recebidos
            byte[] hash = sha512.ComputeHash(dados_bytes);

            //verificar integridade
            bool resultado = rsaEncrypt.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA512"), hash_recebida);


            return resultado;

        }

        private static byte[] GenerateSalt(int size)
        {
            //Generate a cryptographic random number.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            return buff;
        }

        private static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(plainText, salt, NUMBER_OF_ITERATIONS);
            return rfc2898.GetBytes(32);
        }

        private void conexao_baseDados()
        {
            // Configurar ligação à Base de Dados
            string directoriaProjeto = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            conn = new SqlConnection();
            conn.ConnectionString = String.Format("Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + directoriaProjeto + "\\Users.mdf;Integrated Security=True;");

            // Abrir ligação à Base de Dados
            conn.Open();
        }

        private bool Register(string username, byte[] saltedPasswordHash, byte[] salt)
        {

            try
            {
                conexao_baseDados();


                // Declaração dos parâmetros do comando SQL
                SqlParameter paramUsername = new SqlParameter("@username", username);
                SqlParameter paramPassHash = new SqlParameter("@password", saltedPasswordHash);
                SqlParameter paramSalt = new SqlParameter("@salt", salt);

                String sql;
                SqlCommand cmd;


                // verificar se o utilizador já existe

                // Declaração do comando SQL
                sql = "SELECT * FROM utilizadores WHERE username = @username";
                cmd = new SqlCommand();
                cmd.CommandText = sql;

                // Introduzir valor ao parâmentro registado no comando SQL
                cmd.Parameters.Add(paramUsername);

                // Associar ligação à Base de Dados ao comando a ser executado
                cmd.Connection = conn;

                // Executar comando SQL
                SqlDataReader reader_verificar = cmd.ExecuteReader();


                if (reader_verificar.HasRows) // ja existe
                {
                    conn.Dispose();

                    return false;
                }
                else
                {
                    reader_verificar.Close();


                    // Declaração do comando SQL
                    sql = "INSERT INTO utilizadores (username, salt, password) VALUES (@username,@salt,@password)";


                    // Prepara comando SQL para ser executado na Base de Dados
                    //cmd = new SqlCommand(sql, conn);
                    cmd.CommandText = sql;

                    // Introduzir valores aos parâmentros registados no comando SQL
                    //cmd.Parameters.Add(paramUsername);
                    cmd.Parameters.Add(paramPassHash);
                    cmd.Parameters.Add(paramSalt);

                    // Executar comando SQL
                    int lines = cmd.ExecuteNonQuery();

                    // Fechar ligação
                    conn.Close();

                    if (lines == 0)
                    {
                        // Se forem devolvidas 0 linhas alteradas então não foi executado com sucesso                    
                        Console.WriteLine("Error while inserting an user");
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while inserting an user:" + e.Message);
                return false;
            }
        }

        private bool VerifyLogin(string username, string password)
        {

            try
            {
                conexao_baseDados();

                // Declaração do comando SQL
                String sql = "SELECT * FROM utilizadores WHERE username = @username";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;

                // Declaração dos parâmetros do comando SQL
                SqlParameter param = new SqlParameter("@username", username);

                // Introduzir valor ao parâmentro registado no comando SQL
                cmd.Parameters.Add(param);

                // Associar ligação à Base de Dados ao comando a ser executado
                cmd.Connection = conn;

                // Executar comando SQL
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    Console.WriteLine("Error while trying to access an user");
                    return false;
                    //throw new Exception("Error while trying to access an user");
                }

                // Ler resultado da pesquisa
                reader.Read();

                // Obter Hash (password + salt)
                byte[] saltedPasswordHashStored = (byte[])reader["password"];

                // Obter salt
                byte[] saltStored = (byte[])reader["salt"];

                conn.Close();



                //verificar se a password na base de dados é igual

                byte[] password_bytes = Encoding.UTF8.GetBytes(password);
                byte[] saltedhash = GenerateSaltedHash(password_bytes, saltStored);

                return saltedPasswordHashStored.SequenceEqual(saltedhash);

            }
            catch (Exception e)
            {
                Console.WriteLine("<O cliente {0} desconectou-se!>", clientID);
                return false;
            }
        }

        static string CleanInput(string strIn)
        {
            /* funcao para remover caracteres especiais de uma string
         * 
         * fonte: https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-strip-invalid-characters-from-a-string
         * */

            // Replace invalid characters with empty strings.
            try
            {
                return Regex.Replace(strIn, @"[^a-zA-Z0-9]", "",
                                     RegexOptions.None, TimeSpan.FromSeconds(1.5));
            }
            // If we timeout when replacing invalid characters, 
            // we should return Empty.
            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
        }

        public int getIdSala(List<Sala> salas, string nomeSala)
        {
            //objetivo: devolve o id da sala atravez do nome
            int id = salas.FindIndex(lista => lista.nome == nomeSala);

            return id;
        }

        private byte[] cifrarComChaveSimetrica(byte[] msgEmBytes)
        {
            // Criar variável para colocar o conteúdo da msg decifrada
            byte[] msgCifradaEmBytes;

            // Aplicar o algoritmo criptografico           
            using (MemoryStream ms = new System.IO.MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(msgEmBytes, 0, msgEmBytes.Length);
                    cs.Dispose();
                }
                msgCifradaEmBytes = ms.ToArray();
            }
            return msgCifradaEmBytes;
        }

        public string cifrarComChavePublica(byte[] dados, string chavePublica)
        {
            rsaEncrypt = new RSACryptoServiceProvider();

            // cifrar com a publica
            rsaEncrypt.FromXmlString(chavePublica);

            // - Cifrar os dados e guardá-los numa variável
            byte[] dadosEnc = rsaEncrypt.Encrypt(dados, true);

            // - Devolver os dados em Base64
            return Convert.ToBase64String(dadosEnc);
        }

        // criar a hash dos dados, assinar com privada, cifrar com simetrica
        private byte[] CriarHash_Assinar_Cifrar(byte[] msg)
        {

            // criar hash da msg enviada
            byte[] hashing = sha512.ComputeHash(msg);

            // do servidor
            rsaEncrypt.FromXmlString(chavesPublicaPrivadaServidor);

            // assinar a hash
            byte[] signature = rsaEncrypt.SignHash(hashing, CryptoConfig.MapNameToOID("SHA512"));


            // repor do cliente
            rsaEncrypt.FromXmlString(chavePublicaCliente);

            // cifrar com chave simétrica e devolver
            return cifrarComChaveSimetrica(signature);
        }


        private byte[] decifrarComChaveSimetrica(byte[] msgCifradaEmBytes)
        {
            // 1º - Criar variável para colocar o conteúdo da msg decifrada
            byte[] msgDecifradaEmBytes = new byte[msgCifradaEmBytes.Length];
            int bytesLidos = 0;


            // 2º - Aplicar o algoritmo criptografico

            using (MemoryStream ms = new MemoryStream(msgCifradaEmBytes))
            {
                using (CryptoStream cstream = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    bytesLidos = cstream.Read(msgDecifradaEmBytes, 0, msgDecifradaEmBytes.Length);
                }
            }


            byte[] msg_bytesLidos = new byte[bytesLidos];

            // enviar sem bytes vazios, para que depois na integridade a comparação seja igual
            Array.Copy(msgDecifradaEmBytes, 0, msg_bytesLidos, 0, bytesLidos);

            return msg_bytesLidos;

        }


        private string emString(byte[] msgEmBytes)
        {

            string result = Encoding.UTF8.GetString(msgEmBytes, 0, msgEmBytes.Length);

            // remover bytes vazios
            result = result.Replace("\0", string.Empty);

            return result;

        }

        private void randFuncoes(string nick1, string nick2)
        {
            Random rand = new Random();
            string[] nicks = { nick1, nick2 };
            int index = rand.Next(nicks.Length);
            listSalas[IdSala].Atac = nicks[index];
            if (index == 0)
            {
                listSalas[IdSala].Defensor = nicks[1];
            }
            else
            {
                listSalas[IdSala].Defensor = nicks[0];
            }
        }

        private void enviarCliente(string texto)
        {
            byte[] est = cifrarComChaveSimetrica(Encoding.UTF8.GetBytes(texto));
            byte[] packet = protocolSI.Make(ProtocolSICmdType.DATA, est);
            networkStream.Write(packet, 0, packet.Length);
            Console.Write("\n" + texto);
        }

    }
}
