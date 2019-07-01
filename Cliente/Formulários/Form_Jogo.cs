using EI.SI;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SPKS___Cliente
{
    public partial class Form_Jogo : Form
    {

        // PORTO A UTILIZAR NAS COMUNICAÇÕES
        private const int ipPort = 10000;

        // para refresh do chat
        private Timer temporizador;

        int pontosMeus = 0;
        int pontosAdversario = 0;
        string funAtual;
        int QJogaram = 0;

        //Para mover form
        bool togMoveForm;
        int MvalX;
        int MvalY;

        public Form_Jogo()
        {
            InitializeComponent();

            //atualizar as labels do chat
            lb_nick.Text = Form_Autenticar.nickname;
            painel_esperar.Location = new Point(339, 188);
            painel_esperar.BringToFront();
            //bt_novoJogo.Location = new Point(248, 145);
           bt_novoJogo.BringToFront();
            tb_enviarMensagem.Enabled = true;

            lb_defende.Visible = false;
            lb_atacar.Visible = false;
            labelResult.Visible = false;
            labelResultado.Visible = false;

            labelEscolha.BringToFront();
        }

        private void lerChat()
        {
           textBoxChat.Text = File.ReadAllText(Sala(lb_nomesalas.Text));
        }   
               
        //Verificações
        private void verificarMensagensNovas()
        {
            //objetivo: efetuar o pedido para o servidor dizer se tem novas msgs ou nao

            try
            {

                if (Form_Autenticar.networkStream.CanWrite)
                {

                    // CRIA A MENSAGEM DO TIPO DATA UTILIZANDO O PROTOCOLO SI
                    byte[] packet = Form_Autenticar.protocolSI.Make(ProtocolSICmdType.USER_OPTION_6);
                    Form_Autenticar.networkStream.Write(packet, 0, packet.Length);

                    // VERIFICA O TIPO DE MENSAGEM (DO SERVIDOR)
                    if (Form_Autenticar.LerRespostaServidor())
                    {
                        // SE FOR DO TIPO NACK é porque nao é preciso atualizar
                        // ACK é preciso, existem novas msgs
                        pedirDados();

                    }

                }

            }
            catch (SocketException)
            {

                MessageBox.Show("Não foi possivel conectar ao servidor");
                backFormEntrada();
                return;

            }

        }
        private void backFormEntrada()
        {
            //objetivo: voltar ao formLogin 
            this.Close();
            Form_Autenticar form = new Form_Autenticar();
            form.Show();
        }          
        
        private void buttonEnviarMensagem_Click(object sender, EventArgs e)
        {
            byte[] msg = Encoding.UTF8.GetBytes(tb_enviarMensagem.Text);

            //para nao enviar mensagens sem nada
            if (msg.Length == 0)
            {
                return;
            }

            // LIMPA A CAIXA DE TEXTO
             tb_enviarMensagem.Text = "";


            //verificaçoes
            if (Form_Autenticar.EnviarDadosServidor(ProtocolSICmdType.DATA, msg) == 0)
            {
                MessageBox.Show("Comunicação falhou");
                return;
            }
            if (!Form_Autenticar.LerRespostaServidor())
            {
                MessageBox.Show("Integridade inválida");
                return;

            }
        }

        private void Temporizador_Tick(object sender, EventArgs e)
        {
            //objetivo: verificar se existem mensagens novas a cada tick do temporizador (2 segundos)
            //se sim , prosegue para a atualizaçao das textboxs das salas
            verificarJogadas();
            verificarMensagensNovas();

            lerChat();
        }

        private string Sala(string sala)
        {
            string Project = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            string Solution = Directory.GetParent(Project).FullName;
            return Solution + "/Server/Salas/" + sala + ".txt";
        }

        #region LAYOUT
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            togMoveForm = true;
            MvalX = e.X;
            MvalY = e.Y;

        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (togMoveForm == true)
            {
                SetDesktopLocation(MousePosition.X - MvalX, MousePosition.Y - MvalY);
            }
        }

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            togMoveForm = false;
        }

        #endregion

        private void btn_sala_Click(object sender, EventArgs e)
        {
            string nomeSala = tb_sala.Text;
            byte[] msg = Encoding.UTF8.GetBytes(nomeSala);

            if (Form_Autenticar.EnviarDadosServidor(ProtocolSICmdType.USER_OPTION_4, msg) == 1 && Form_Autenticar.LerRespostaServidor())
            {
                tb_sala.ResetText();
                bt_enviarMensagem.Enabled = true;
                painel_baliza.Enabled = true;
                labelEscolha.Visible = false;
                labelResult.Visible = true;
                labelResultado.Visible = true;

                tb_sala.Visible = false;
                bt_sala.Visible = false;

                string funcao = receberDadosServidor();
                layoutFuncao(funcao);
                funAtual = funcao;

                // saber se é o unico jogador para 
                //# painel_esperar.Visible = true;
                painel_esperar.BringToFront();

                pedirDados();

                //iniciar o contador para verificar se ha mensagens novas de 2 em 2 segundos
                InitTimer();

                // colocar automaticamente o cursor na caixa e mostra o form
                ActiveControl = tb_enviarMensagem;
                this.Show();
                
                lb_nomesalas.Text = nomeSala;

            }
            else // voltar ao form de entrada
            {
                MessageBox.Show("A sala não está disponível");
            }
        }

        public void InitTimer()
        {
            //objetivo: cria e inicia o temporizador

            /*
             código adaptado de: https://stackoverflow.com/questions/6169288/execute-specified-function-every-x-seconds
            */
            Temporizador = new Timer();
            Temporizador.Tick += new EventHandler(Temporizador_Tick);
            Temporizador.Interval = 2000; // in miliseconds -  2 segundos
            Temporizador.Start();
        }

        private void pedirDados()
            {
                //objetivo: efetuar o pedido de dados do cliente ao servidor

                // VARIAVEL PARA RECEBER OS DADOS           
                StringBuilder textAux = new StringBuilder();

                //para saber quanto temos na text box atualmente 
                byte[] lengthEmBytes = Encoding.UTF8.GetBytes(tb_sala.TextLength.ToString());

                //verificaçoes
                if (Form_Autenticar.EnviarDadosServidor(ProtocolSICmdType.USER_OPTION_5, lengthEmBytes) == 0)
                {
                    MessageBox.Show("Comunicação falhou");
                    return;
                }
                if (!Form_Autenticar.LerRespostaServidor())
                {
                    MessageBox.Show("Integridade inválida");
                    return;

                }

                //  ENQUANTO  HOUVER  COISAS  PARA  RECEBER  (OS  DADOS  PODEM  TER  SIDO  DIVIDIDOS  PARA  SEREM  ENVIADOS)
                while (true)
                {
                    try
                    {
                    //le da stream
                    Form_Autenticar.networkStream.Read(Form_Autenticar.protocolSI.Buffer, 0, Form_Autenticar.protocolSI.Buffer.Length);

                        // SE FOR O FIM DA RESPOSTA 
                        if (Form_Autenticar.protocolSI.GetCmdType() == ProtocolSICmdType.EOF)
                        {
                            // SAI FORA DO WHILE
                            break;
                        }
                        // SENÃO, E se a comunicação for do tipo data
                        else if (Form_Autenticar.protocolSI.GetCmdType() == ProtocolSICmdType.DATA)
                        {
                            // RECEBE, DECIFRA, ESCREVE OS DADOS PARA A STRING
                            textAux.Append(Convert.ToBase64String(Form_Autenticar.decifrarDadosServidor()));
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Erro ao atualizar conversas");
                        break;
                    }


                }

            Form_Autenticar.Enviar_ACK();

                byte[] dadosDecifrados = Convert.FromBase64String(textAux.ToString());

                //receber hash, decifrar e enviar ack
                byte[] hash_recebida = Form_Autenticar.Receber_Hash();

                if (Form_Autenticar.Integridade_Valida(hash_recebida, dadosDecifrados) == false) return;


                // ATUALIZA O TEXTO DA TEXTBOX
                tb_sala.AppendText(Encoding.UTF8.GetString(dadosDecifrados));



            }
                
        static public string receberDadosServidor()
        {
            Form_Autenticar.networkStream.Read(Form_Autenticar.protocolSI.Buffer, 0, Form_Autenticar.protocolSI.Buffer.Length);
            byte[] fun = Form_Autenticar.decifrarDadosServidor();
            
            return Form_Autenticar.emString(fun);
        }    


        #region JOGO

        #region ALVOS
        private void bt_posicao1_Click(object sender, EventArgs e)
        {
            painel_baliza.Enabled = false;
            byte[] msg = Encoding.UTF8.GetBytes("1");
            Form_Autenticar.EnviarDadosServidor(ProtocolSICmdType.USER_OPTION_7, msg);
            painel_esperar.Visible = true;
        }

        private void bt_posicao2_Click(object sender, EventArgs e)
        {
            painel_baliza.Enabled = false;
            byte[] msg = Encoding.UTF8.GetBytes("2");
            Form_Autenticar.EnviarDadosServidor(ProtocolSICmdType.USER_OPTION_7, msg);
            painel_esperar.Visible = true;
        }

        private void bt_posicao3_Click(object sender, EventArgs e)
        {
            painel_baliza.Enabled = false;
            byte[] msg = Encoding.UTF8.GetBytes("3");
            Form_Autenticar.EnviarDadosServidor(ProtocolSICmdType.USER_OPTION_7, msg);
            painel_esperar.Visible = true;
        }

        private void bt_posicao4_Click(object sender, EventArgs e)
        {
            painel_baliza.Enabled = false;
            byte[] msg = Encoding.UTF8.GetBytes("4");
            Form_Autenticar.EnviarDadosServidor(ProtocolSICmdType.USER_OPTION_7, msg);
            painel_esperar.Visible = true;
        }

        private void bt_posicao5_Click(object sender, EventArgs e)
        {
            painel_baliza.Enabled = false;
            byte[] msg = Encoding.UTF8.GetBytes("5");
            Form_Autenticar.EnviarDadosServidor(ProtocolSICmdType.USER_OPTION_7, msg);
            painel_esperar.Visible = true;
        }

        private void bt_posicao6_Click(object sender, EventArgs e)
        {
            painel_baliza.Enabled = false;
            byte[] msg = Encoding.UTF8.GetBytes("6");
            Form_Autenticar.EnviarDadosServidor(ProtocolSICmdType.USER_OPTION_7, msg);
            painel_esperar.Visible = true;
        }
        #endregion

        private void bt_novoJogo_Click(object sender, EventArgs e)
        {
            painel_baliza.Enabled = true;
            painel_estado.Location=new Point(250 ,90);
            painel_estado.Visible = false;
            bt_novoJogo.Hide();
            QJogaram = 0;
            pontosMeus = 0;
            pontosAdversario = 0;
            labelResultado.Text = "0 - 0";
            lb_estado.Text = "";
        }

        public void layoutFuncao(string funcao)
        {
            if (funcao == "Ataque")
            {
                img_luvas.Visible = false;
                //imBola.Visible = true;
                lb_atacar.Visible = true;
                lb_defende.Visible = false;
            }
            else
            {
                img_luvas.Visible = true;
                lb_atacar.Visible = false;
                lb_defende.Visible = true;
            }
        }

        private void verificarJogadas()
        {
            if (Form_Autenticar.networkStream.CanWrite)
            {
                byte[] packet = Form_Autenticar.protocolSI.Make(ProtocolSICmdType.USER_OPTION_8);
                Form_Autenticar.networkStream.Write(packet, 0, packet.Length);
                if (Form_Autenticar.LerRespostaServidor())
                {

                    string estado = receberDadosServidor();
                    QJogaram++;
                    painel_baliza.Enabled = true;
                    painel_esperar.Hide();

                    lb_estado.Text = estado;
                    atualizarPontuacao(estado);
                    string Funcao = trocarFuncao(funAtual);
                    layoutFuncao(Funcao);


                    if (QJogaram == 5 || pontosMeus >= 3 || pontosAdversario >= 3)
                    {
                        painel_baliza.Enabled = false;
                        bt_novoJogo.Visible = true;

                        if (pontosMeus > pontosAdversario)
                        {
                            painel_estado.Visible = true;
                            painel_estado.Location = new Point(121, 120);
                            painel_estado.BringToFront();
                            lb_tipo.Text = "Parabéns ganhou";
                        }
                        else
                        {

                            painel_estado.Visible = true;
                            painel_estado.Location = new Point(121, 120);
                            painel_estado.BringToFront();
                            lb_tipo.Text = "Você perdeu";
                        }
                    }
                }
            }
            
        }

        public string trocarFuncao(string funcao)
        {
            if (funcao == "Ataque")
            {
                funAtual = "Defesa";
            }
            else
            {
                funAtual = "Ataque";
            }

            return funAtual;
        }

        public void atualizarPontuacao(string estado)
        {
            if (estado == "Não Acertou")
            {
                pontosAdversario++;
            }
            else
            {
                pontosMeus++;
            }
            labelResultado.Text = pontosMeus + " - " + pontosAdversario;

        }

        #endregion

        #region CLOSE
        private void Form_Jogo_Click(object sender, EventArgs e)
        {
            this.ActiveControl = tb_enviarMensagem;
        }

        private void Bt_fechar_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void Form_Jogo_FormClosed(object sender, FormClosedEventArgs e)
        {
            //objetivo: terminar a comunicaçao quando o form é fechado        

            // criar pacote de término de sessao
            byte[] packet = Form_Autenticar.protocolSI.Make(ProtocolSICmdType.EOT);

            // enviar msg
            Form_Autenticar.networkStream.Write(packet, 0, packet.Length);

            // ACK -> confirmação (acknowledge)
            while (Form_Autenticar.protocolSI.GetCmdType() != ProtocolSICmdType.ACK)
            { // ve a ultima msg recebida e estrai o ultimo tipo de msg

                Form_Autenticar.networkStream.Read(Form_Autenticar.protocolSI.Buffer, 0, Form_Autenticar.protocolSI.Buffer.Length);
            }
            // libertar recursos
            Form_Autenticar.tcpClient.Dispose();
            Form_Autenticar.networkStream.Dispose();
        }
        #endregion

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void painel_esperar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            painel_esperar.Hide();
        }

        private void bt_novoJogo_Click_1(object sender, EventArgs e)
        {

            painel_baliza.Enabled = true;
            painel_estado.Location = new Point(250, 90);
            painel_estado.Visible = false;
            bt_novoJogo.Hide();
            QJogaram = 0;
            pontosMeus = 0;
            pontosAdversario = 0;
            labelResultado.Text = "0 - 0";
            lb_estado.Text = "";

        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
