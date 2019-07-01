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
    public partial class Form_login : Form
    {
        const string username = "Username";
        const string password = "Password";

        public Form_login()
        {
            InitializeComponent();
        }

        private void bt_login_Click(object sender, EventArgs e)
        {
                try
                {
                    byte[] msg = Encoding.UTF8.GetBytes(tb_username.Text + "_Ø_" + tb_password.Text);


                    //verificar se a resposta do servidor é OK
                    if (Form_Autenticar.EnviarDadosServidor(ProtocolSICmdType.USER_OPTION_2, msg) == 1 && Form_Autenticar.LerRespostaServidor())
                    {
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
    }
}
