using EI.SI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPKS___Cliente
{
    public partial class Form_registar : Form
    {
        const string username = "Username";
        const string password = "Password";
        const string confpassword = "Confirmação da password";

        public Form_registar()
        {
            InitializeComponent();
        }

        private void bt_registar_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] msg = Encoding.UTF8.GetBytes(tb_username.Text + "_Ø_" + tb_password.Text);


                //verificar se a resposta do servidor é OK
                if (EnviarDadosServidor(ProtocolSICmdType.USER_OPTION_2, msg) == 1 && LerRespostaServidor())
                {
                    ParentForm.Hide();

                    Form_Autenticar.nickname = tb_username.Text;

                    Form_Jogo form = new Form_Jogo();
                    form.ShowDialog();

                    /*FormPrincipal form = new FormPrincipal(TextBoxUsername);
                    form.ShowDialog();*/

                }
                else // ou se a resposta é NOK
                {

                    lb_validar.Visible = true;
                }

            }
            catch (SocketException)
            {

                MessageBox.Show("Não foi possivel conectar ao servidor tente outra vez");
                return;

            }
        }

        private void Form_registar_Load(object sender, EventArgs e)
        {

        }
    }
}
