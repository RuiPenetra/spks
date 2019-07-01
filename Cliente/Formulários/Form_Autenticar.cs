using EI.SI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPKS___Cliente
{
    public partial class Form_Autenticar : Form
    {
        //LAYOUT
        bool togMoveForm;
        int MvalX;
        int MvalY;

        // PORTO A UTILIZAR NAS COMUNICAÇÕES
        private const int ipPort = 10000;

        // PARA DEPOIS FAZER UMA COMUNICAÇÃO
        public static NetworkStream networkStream;
        public static ProtocolSI protocolSI;
        public static TcpClient tcpClient;
        public static IPEndPoint endpoint;

        //NICKNAME
        public static string nickname;

        //PARA ENCRIPTAR
        static RSACryptoServiceProvider rSA;
        static AesCryptoServiceProvider aes;

        //PARA HASH
        static SHA512 sha512;

        //PARA GUARDAR AS CHAVES
        static string publickey;
        static string bothkeys;
        static string chavePublicaServidor;

        //PARA GUARDAR OS DADOS
        static byte[] dadosDecifrados;

        public Form_Autenticar()
        {
            InitializeComponent();

            //PARA A ENCRIPATAÇÃO
            aes = new AesCryptoServiceProvider();

            //PARA A HASH PARA VALIDAÇÃO DE DADOS (INTEGRIDADE)
            sha512 = SHA512.Create();

            //INICIA O CLIENTE TCP
            endpoint = new IPEndPoint(IPAddress.Loopback, ipPort);
            tcpClient = new TcpClient();


            try
            {
                //LIGA-SE AO SERVIDOR
                tcpClient.Connect(endpoint);

                //OBTEM A STREAM DE COMUNICAÇÃO
                networkStream = tcpClient.GetStream();

                //INICIA O PROTOCOLO SI PARA TRATAR DAS MENSAGENS
                protocolSI = new ProtocolSI();

                //CRIAR AS CHAVES
                rSA = new RSACryptoServiceProvider();

                //GUARDAR AS CHAVES
                publickey = rSA.ToXmlString(false); //Chave Pública
                bothkeys = rSA.ToXmlString(true);// Chave Privada + Pública

                //1 - CONVERTER OS DADOS PARA BYTE[]
                byte[] chavePublica = Encoding.UTF8.GetBytes(publickey);

                //ENVIAR PARA O SERVIDOR

                if (EnviarChaveServidor(ProtocolSICmdType.USER_OPTION_1, chavePublica) == 1)
                {
                    int i;

                    for (i = 1; i <= 3; i++)
                    {
                        //esperar pela chave simetrica
                        networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);

                        switch (protocolSI.GetCmdType())
                        {
                            case ProtocolSICmdType.SECRET_KEY:

                                //receber chave simetrica
                                aes.Key = rSA.Decrypt(protocolSI.GetData(), true);
                                Enviar_ACK();
                                break;

                            case ProtocolSICmdType.IV:

                                //receber vetor da chave simetrica
                                aes.IV = rSA.Decrypt(protocolSI.GetData(), true);
                                Enviar_ACK();
                                break;

                            case ProtocolSICmdType.SYM_CIPHER_DATA:

                                // receber a publica do servidor cifrada
                                byte[] chavePublicaServidorEncriptada = protocolSI.GetData();

                                //decifrar chave publica
                                chavePublicaServidor = emString(decifrarComChaveSimetrica(chavePublicaServidorEncriptada));

                                Enviar_ACK();

                                break;

                            case ProtocolSICmdType.NACK:
                                MessageBox.Show("Ocorreu um erro. Por favor reinicie a aplicação! ");
                                break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possivel conectar ao servidor. Tente outra vez! ");
                    return;
                }
            }
            catch (SocketException)
            {
                MessageBox.Show("Não foi possivel conectar ao servidor. Tente outra vez! ");
                return;
            }
        }

        public static string emString(byte[] msgEmBytes)
        {

            string result = Encoding.UTF8.GetString(msgEmBytes, 0, msgEmBytes.Length);

            // remover bytes vazios
            result = result.Replace("\0", string.Empty);

            return result;
        }


        public int EnviarChaveServidor(ProtocolSICmdType protocolSICmdType, byte[] msg)
        {
            int ok = 0;

            try
            {
                // CRIA A MENSAGEM DO TIPO DATA UTILIZANDO O PROTOCOLO SI
                byte[] packet = protocolSI.Make(protocolSICmdType, msg);

                //escreve na stream
                networkStream.Write(packet, 0, packet.Length);

                if (LerRespostaServidor())
                {
                    ok = 1; // recebe ack 
                }
            }
            catch (SocketException)
            {
                MessageBox.Show("Não foi possivel conectar ao servidor. funcao");
                return ok;
            }
            return ok;
        }
        public static byte[] decifrarDadosServidor()
        {
            //RECEBER DADOS
            byte[] dados_recebidos = protocolSI.GetData();

            //DECIFRAR DADOS
            dadosDecifrados = decifrarComChaveSimetrica(dados_recebidos);

            return dadosDecifrados;

        }

        #region LOGIN

        #endregion

        #region REGISTAR

        #endregion

        private void bt_login_Click(object sender, EventArgs e)
        {
            if (false)//TextboxErros())
            {
                return;
            }
            else
            {

                try
                {


                    byte[] msg = Encoding.UTF8.GetBytes(tb_l_username.Text + "_Ø_" + tb_l_password.Text);


                    //verificar se a resposta do servidor é OK
                    if (EnviarDadosServidor(ProtocolSICmdType.USER_OPTION_2, msg) == 1 && LerRespostaServidor())
                    {
                        this.Hide();

                        nickname = tb_l_username.Text;

                        Form_Jogo frm = new Form_Jogo();
                        frm.Show();
                        /*FormPrincipal form = new FormPrincipal(TextBoxUsername);
                        form.ShowDialog();*/

                    }
                    else // ou se a resposta é NOK
                    {

                        lb_l_validar.Visible = true;
                    }

                }
                catch (SocketException)
                {

                    MessageBox.Show("Não foi possivel conectar ao servidor tente outra vez");
                    return;

                }

            }

        }

        private void Bt_fechar_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        #region LAYOUT
        private void bt_barra_MouseDown(object sender, MouseEventArgs e)
        {
            togMoveForm = true;
            MvalX = e.X;
            MvalY = e.Y;
        }

        private void bt_barra_MouseMove(object sender, MouseEventArgs e)
        {
            if (togMoveForm == true)
            {
                SetDesktopLocation(MousePosition.X - MvalX, MousePosition.Y - MvalY);
            }
        }

        private void bt_barra_MouseUp(object sender, MouseEventArgs e)
        {
            togMoveForm = false;
        }

        #endregion

        private void bt_abr_login_Click(object sender, EventArgs e)
        {
            painel_registar.Visible = false;
            painel_login.Visible = true;


        }

        private void bt_abr_registar_Click(object sender, EventArgs e)
        {
            painel_login.Visible = false;
            painel_registar.Visible = true;
        }

        private void painel_registar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bt_registar_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            if (false)
            {
                this.UseWaitCursor = false;
                bt_registar.UseWaitCursor = false;
                return;

            }
            else
            {

                try
                {


                    byte[] msg = Encoding.UTF8.GetBytes(tb_r_username.Text + "_Ø_" + tb_r_password.Text);
                    Console.WriteLine("msg");

                    //verificar se a resposta do servidor é OK
                    if (EnviarDadosServidor(ProtocolSICmdType.USER_OPTION_3, msg) == 1 && LerRespostaServidor())
                    {

                        tb_r_username.Text = "";
                        tb_r_password.Text = "";
                        tb_r_conf_password.Text = "";

                    }
                    else // ou se a resposta é NOK
                    {
                        lb_r_validar.Visible = true;
                    }

                }
                catch (SocketException)
                {

                    MessageBox.Show("Não foi possivel conectar ao servidor tente outra vez");
                    this.UseWaitCursor = false;
                    return;

                }

            }
            this.UseWaitCursor = false;




        }
        private static byte[] cifrarComChaveSimetrica(byte[] msgEmBytes)
        {
            // Criar variável para colocar o conteúdo da msg decifrada
            byte[] msgCifradaEmBytes;

            // Aplicar o algoritmo criptografico           
            using (MemoryStream ms = new System.IO.MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(msgEmBytes, 0, msgEmBytes.Length);
                }

                msgCifradaEmBytes = ms.ToArray();
            }
            return msgCifradaEmBytes;
        }

        private static byte[] decifrarComChaveSimetrica(byte[] msgCifradaEmBytes)
        {
            // 1º - Criar variável para colocar o conteúdo da msg decifrada
            byte[] msgDecifradaEmBytes = new byte[msgCifradaEmBytes.Length];
            int bytesLidos = 0;

            // 2º - Aplicar o algoritmo criptografico

            using (MemoryStream ms = new MemoryStream(msgCifradaEmBytes))
            {
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                {

                    bytesLidos = cs.Read(msgDecifradaEmBytes, 0, msgDecifradaEmBytes.Length);
                }
            }

            byte[] msg_bytesLidos = new byte[bytesLidos];

            // enviar sem bytes vazios, para que depois na integridade a comparação seja igual
            Array.Copy(msgDecifradaEmBytes, 0, msg_bytesLidos, 0, bytesLidos);


            return msg_bytesLidos;
        }

        private static byte[] CriarHash_Assinar_Cifrar(byte[] msg)
        {

            // criar hash da msg enviada
            byte[] hashing = sha512.ComputeHash(msg);


            // assinar a hash
            byte[] signature = rSA.SignHash(hashing, CryptoConfig.MapNameToOID("SHA512"));


            // cifrar com chave simétrica e devolver
            return cifrarComChaveSimetrica(signature);
        }
        public static int EnviarDadosServidor(ProtocolSICmdType protocolSICmdType, byte[] msg)
        {
            int resposta = 0; // 0 ou 1 se estiver ok

            try
            {
                // cifrar msg
                byte[] msg_cifrada = cifrarComChaveSimetrica(msg);

                // CRIA A MENSAGEM DO TIPO DEFINIDO UTILIZANDO O PROTOCOLO SI
                byte[] packet = protocolSI.Make(protocolSICmdType, msg_cifrada);

                //escreve na stream
                networkStream.Write(packet, 0, packet.Length);

                // saber se recebeu dados (ACK)
                if (LerRespostaServidor())
                {
                    byte[] hashing = CriarHash_Assinar_Cifrar(msg);

                    // CRIA A MENSAGEM DO TIPO NORMAL (para enviar a hash) UTILIZANDO O PROTOCOLO SI
                    packet = protocolSI.Make(ProtocolSICmdType.NORMAL, hashing);

                    //escreve na stream
                    networkStream.Write(packet, 0, packet.Length);

                    // saber se recebeu o hash (ACK) 
                    if (LerRespostaServidor())
                    {
                        resposta = 1;
                    }
                }
            }
            catch (SocketException)
            {
                MessageBox.Show("Não foi possivel conectar ao servidor");
                return resposta;
            }
            return resposta;
        }
        public static bool LerRespostaServidor() // apenas ACK ou NACK
        {
            bool resposta = false;
            try
            {

                //le da stream
                networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);

                // VERIFICA O TIPO DE MENSAGEM (DO SERVIDOR)
                switch (protocolSI.GetCmdType())
                {
                    // SE FOR DO TIPO ACK É PORQUE está tudo válido
                    // e se for NACK algo está inválido

                    case ProtocolSICmdType.NACK:
                        resposta = false;
                        break;

                    case ProtocolSICmdType.ACK:
                        resposta = true;
                        break;

                }
            }
            catch (SocketException)
            {
                MessageBox.Show("Não foi possivel conectar ao servidor");
                return resposta;
            }
            return resposta;
        }
        public static byte[] Receber_Hash()
        {
            // receber a hash
            networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);

            if (protocolSI.GetCmdType() == ProtocolSICmdType.NORMAL)
            {
                // ler hash
                byte[] hash_recebida = protocolSI.GetData();

                // decifra-la com chave simetrica
                byte[] hash_recebida_decifrada = decifrarComChaveSimetrica(hash_recebida);

                Enviar_ACK();

                return hash_recebida_decifrada;
            }

            return null;
        }

        public static bool Integridade_Valida(byte[] hash_recebida, byte[] dados_bytes)
        {

            // criar hash dos dados recebidos
            byte[] hash = sha512.ComputeHash(dados_bytes);

            // conferir com a chave do servidor
            rSA.FromXmlString(chavePublicaServidor);


            //verificar integridade
            bool resultado = rSA.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA512"), hash_recebida);

            // repor a chave do cliente na variável
            rSA.FromXmlString(bothkeys);

            return resultado;

        }

        public static void Enviar_ACK()
        {
            // enviar o ACK em como recebeu os dados
            byte[] ack = protocolSI.Make(ProtocolSICmdType.ACK);
            networkStream.Write(ack, 0, ack.Length);
        }
        public static void Enviar_NACK()
        {
            // enviar o ACK em como recebeu os dados
            byte[] ack = protocolSI.Make(ProtocolSICmdType.NACK);
            networkStream.Write(ack, 0, ack.Length);
        }

        //Funções

    }

}



