namespace SPKS___Cliente
{
    partial class Form_Autenticar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Autenticar));
            this.bt_abr_login = new System.Windows.Forms.Button();
            this.bt_abr_registar = new System.Windows.Forms.Button();
            this.painel_geral = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.painel_login = new System.Windows.Forms.Panel();
            this.bt_login = new System.Windows.Forms.Button();
            this.lb_l_validar = new System.Windows.Forms.Label();
            this.lb_password = new System.Windows.Forms.Label();
            this.lb_username = new System.Windows.Forms.Label();
            this.tb_l_password = new System.Windows.Forms.TextBox();
            this.tb_l_username = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.painel_registar = new System.Windows.Forms.Panel();
            this.lb_r_validar = new System.Windows.Forms.Label();
            this.tb_r_conf_password = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bt_registar = new System.Windows.Forms.Button();
            this.tb_r_password = new System.Windows.Forms.MaskedTextBox();
            this.tb_r_username = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bt_fechar = new System.Windows.Forms.Button();
            this.bt_barra = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.painel_geral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.painel_login.SuspendLayout();
            this.painel_registar.SuspendLayout();
            this.bt_barra.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_abr_login
            // 
            this.bt_abr_login.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bt_abr_login.Location = new System.Drawing.Point(24, 68);
            this.bt_abr_login.Name = "bt_abr_login";
            this.bt_abr_login.Size = new System.Drawing.Size(253, 45);
            this.bt_abr_login.TabIndex = 16;
            this.bt_abr_login.Text = "LOGIN";
            this.bt_abr_login.UseVisualStyleBackColor = false;
            this.bt_abr_login.Click += new System.EventHandler(this.bt_abr_login_Click);
            // 
            // bt_abr_registar
            // 
            this.bt_abr_registar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bt_abr_registar.Location = new System.Drawing.Point(283, 68);
            this.bt_abr_registar.Name = "bt_abr_registar";
            this.bt_abr_registar.Size = new System.Drawing.Size(249, 45);
            this.bt_abr_registar.TabIndex = 17;
            this.bt_abr_registar.Text = "REGISTAR";
            this.bt_abr_registar.UseVisualStyleBackColor = false;
            this.bt_abr_registar.Click += new System.EventHandler(this.bt_abr_registar_Click);
            // 
            // painel_geral
            // 
            this.painel_geral.BackColor = System.Drawing.Color.WhiteSmoke;
            this.painel_geral.Controls.Add(this.pictureBox1);
            this.painel_geral.Controls.Add(this.painel_login);
            this.painel_geral.Controls.Add(this.painel_registar);
            this.painel_geral.Location = new System.Drawing.Point(24, 130);
            this.painel_geral.Name = "painel_geral";
            this.painel_geral.Size = new System.Drawing.Size(510, 307);
            this.painel_geral.TabIndex = 19;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(271, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(221, 244);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // painel_login
            // 
            this.painel_login.BackColor = System.Drawing.Color.WhiteSmoke;
            this.painel_login.Controls.Add(this.bt_login);
            this.painel_login.Controls.Add(this.lb_l_validar);
            this.painel_login.Controls.Add(this.lb_password);
            this.painel_login.Controls.Add(this.lb_username);
            this.painel_login.Controls.Add(this.tb_l_password);
            this.painel_login.Controls.Add(this.tb_l_username);
            this.painel_login.Controls.Add(this.label1);
            this.painel_login.Location = new System.Drawing.Point(19, 17);
            this.painel_login.Name = "painel_login";
            this.painel_login.Size = new System.Drawing.Size(234, 267);
            this.painel_login.TabIndex = 24;
            // 
            // bt_login
            // 
            this.bt_login.Location = new System.Drawing.Point(51, 225);
            this.bt_login.Name = "bt_login";
            this.bt_login.Size = new System.Drawing.Size(144, 33);
            this.bt_login.TabIndex = 11;
            this.bt_login.Text = "Login";
            this.bt_login.UseVisualStyleBackColor = true;
            this.bt_login.Click += new System.EventHandler(this.bt_login_Click);
            // 
            // lb_l_validar
            // 
            this.lb_l_validar.AutoSize = true;
            this.lb_l_validar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_l_validar.ForeColor = System.Drawing.Color.Red;
            this.lb_l_validar.Location = new System.Drawing.Point(37, 185);
            this.lb_l_validar.Name = "lb_l_validar";
            this.lb_l_validar.Size = new System.Drawing.Size(181, 18);
            this.lb_l_validar.TabIndex = 14;
            this.lb_l_validar.Text = "DADOS INCORRETOS";
            this.lb_l_validar.Visible = false;
            // 
            // lb_password
            // 
            this.lb_password.AutoSize = true;
            this.lb_password.Location = new System.Drawing.Point(26, 134);
            this.lb_password.Name = "lb_password";
            this.lb_password.Size = new System.Drawing.Size(59, 13);
            this.lb_password.TabIndex = 9;
            this.lb_password.Text = "Password :";
            // 
            // lb_username
            // 
            this.lb_username.AutoSize = true;
            this.lb_username.Location = new System.Drawing.Point(24, 91);
            this.lb_username.Name = "lb_username";
            this.lb_username.Size = new System.Drawing.Size(61, 13);
            this.lb_username.TabIndex = 8;
            this.lb_username.Text = "Username :";
            // 
            // tb_l_password
            // 
            this.tb_l_password.Location = new System.Drawing.Point(91, 131);
            this.tb_l_password.Name = "tb_l_password";
            this.tb_l_password.Size = new System.Drawing.Size(117, 20);
            this.tb_l_password.TabIndex = 13;
            this.tb_l_password.UseSystemPasswordChar = true;
            // 
            // tb_l_username
            // 
            this.tb_l_username.Location = new System.Drawing.Point(91, 91);
            this.tb_l_username.Name = "tb_l_username";
            this.tb_l_username.Size = new System.Drawing.Size(117, 20);
            this.tb_l_username.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "LOGIN";
            // 
            // painel_registar
            // 
            this.painel_registar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.painel_registar.Controls.Add(this.lb_r_validar);
            this.painel_registar.Controls.Add(this.tb_r_conf_password);
            this.painel_registar.Controls.Add(this.label3);
            this.painel_registar.Controls.Add(this.label4);
            this.painel_registar.Controls.Add(this.bt_registar);
            this.painel_registar.Controls.Add(this.tb_r_password);
            this.painel_registar.Controls.Add(this.tb_r_username);
            this.painel_registar.Controls.Add(this.label5);
            this.painel_registar.Controls.Add(this.label6);
            this.painel_registar.Location = new System.Drawing.Point(19, 17);
            this.painel_registar.Name = "painel_registar";
            this.painel_registar.Size = new System.Drawing.Size(246, 270);
            this.painel_registar.TabIndex = 20;
            this.painel_registar.Visible = false;
            this.painel_registar.Paint += new System.Windows.Forms.PaintEventHandler(this.painel_registar_Paint);
            // 
            // lb_r_validar
            // 
            this.lb_r_validar.AutoSize = true;
            this.lb_r_validar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_r_validar.ForeColor = System.Drawing.Color.Red;
            this.lb_r_validar.Location = new System.Drawing.Point(89, 182);
            this.lb_r_validar.Name = "lb_r_validar";
            this.lb_r_validar.Size = new System.Drawing.Size(75, 18);
            this.lb_r_validar.TabIndex = 23;
            this.lb_r_validar.Text = "VALIDAR";
            this.lb_r_validar.Visible = false;
            // 
            // tb_r_conf_password
            // 
            this.tb_r_conf_password.Location = new System.Drawing.Point(106, 146);
            this.tb_r_conf_password.Name = "tb_r_conf_password";
            this.tb_r_conf_password.Size = new System.Drawing.Size(117, 20);
            this.tb_r_conf_password.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Conf. Password :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(70, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 24);
            this.label4.TabIndex = 20;
            this.label4.Text = "REGISTAR";
            // 
            // bt_registar
            // 
            this.bt_registar.Location = new System.Drawing.Point(55, 223);
            this.bt_registar.Name = "bt_registar";
            this.bt_registar.Size = new System.Drawing.Size(144, 33);
            this.bt_registar.TabIndex = 19;
            this.bt_registar.Text = "Registar";
            this.bt_registar.UseVisualStyleBackColor = true;
            this.bt_registar.Click += new System.EventHandler(this.bt_registar_Click);
            // 
            // tb_r_password
            // 
            this.tb_r_password.Location = new System.Drawing.Point(106, 110);
            this.tb_r_password.Name = "tb_r_password";
            this.tb_r_password.Size = new System.Drawing.Size(117, 20);
            this.tb_r_password.TabIndex = 18;
            // 
            // tb_r_username
            // 
            this.tb_r_username.Location = new System.Drawing.Point(106, 76);
            this.tb_r_username.Name = "tb_r_username";
            this.tb_r_username.Size = new System.Drawing.Size(117, 20);
            this.tb_r_username.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Password :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Username :";
            // 
            // bt_fechar
            // 
            this.bt_fechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_fechar.Image = ((System.Drawing.Image)(resources.GetObject("bt_fechar.Image")));
            this.bt_fechar.Location = new System.Drawing.Point(519, 3);
            this.bt_fechar.Name = "bt_fechar";
            this.bt_fechar.Size = new System.Drawing.Size(47, 47);
            this.bt_fechar.TabIndex = 21;
            this.bt_fechar.UseVisualStyleBackColor = true;
            this.bt_fechar.Click += new System.EventHandler(this.Bt_fechar_Click);
            // 
            // bt_barra
            // 
            this.bt_barra.BackColor = System.Drawing.SystemColors.ControlText;
            this.bt_barra.Controls.Add(this.bt_fechar);
            this.bt_barra.Controls.Add(this.button1);
            this.bt_barra.Location = new System.Drawing.Point(-4, -1);
            this.bt_barra.Name = "bt_barra";
            this.bt_barra.Size = new System.Drawing.Size(578, 53);
            this.bt_barra.TabIndex = 22;
            this.bt_barra.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bt_barra_MouseDown);
            this.bt_barra.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bt_barra_MouseMove);
            this.bt_barra.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bt_barra_MouseUp);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(1004, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 47);
            this.button1.TabIndex = 22;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Form_Autenticar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(565, 529);
            this.Controls.Add(this.bt_barra);
            this.Controls.Add(this.painel_geral);
            this.Controls.Add(this.bt_abr_registar);
            this.Controls.Add(this.bt_abr_login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Autenticar";
            this.Text = "Autenticação";
            this.painel_geral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.painel_login.ResumeLayout(false);
            this.painel_login.PerformLayout();
            this.painel_registar.ResumeLayout(false);
            this.painel_registar.PerformLayout();
            this.bt_barra.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bt_abr_login;
        private System.Windows.Forms.Button bt_abr_registar;
        private System.Windows.Forms.Panel painel_geral;
        private System.Windows.Forms.Label lb_l_validar;
        private System.Windows.Forms.TextBox tb_l_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_login;
        private System.Windows.Forms.TextBox tb_l_username;
        private System.Windows.Forms.Label lb_password;
        private System.Windows.Forms.Label lb_username;
        private System.Windows.Forms.Panel painel_registar;
        private System.Windows.Forms.Label lb_r_validar;
        private System.Windows.Forms.MaskedTextBox tb_r_conf_password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bt_registar;
        private System.Windows.Forms.MaskedTextBox tb_r_password;
        private System.Windows.Forms.TextBox tb_r_username;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel painel_login;
        private System.Windows.Forms.Button bt_fechar;
        private System.Windows.Forms.Panel bt_barra;
        private System.Windows.Forms.Button button1;
    }
}