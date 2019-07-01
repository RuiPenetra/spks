namespace SPKS___Cliente
{
    partial class Form_login
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
            this.lb_validar = new System.Windows.Forms.Label();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_login = new System.Windows.Forms.Button();
            this.tb_username = new System.Windows.Forms.TextBox();
            this.lb_password = new System.Windows.Forms.Label();
            this.lb_username = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_validar
            // 
            this.lb_validar.AutoSize = true;
            this.lb_validar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_validar.ForeColor = System.Drawing.Color.Red;
            this.lb_validar.Location = new System.Drawing.Point(63, 203);
            this.lb_validar.Name = "lb_validar";
            this.lb_validar.Size = new System.Drawing.Size(181, 18);
            this.lb_validar.TabIndex = 14;
            this.lb_validar.Text = "DADOS INCORRETOS";
            this.lb_validar.Visible = false;
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(117, 149);
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(117, 20);
            this.tb_password.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(110, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "LOGIN";
            // 
            // bt_login
            // 
            this.bt_login.Location = new System.Drawing.Point(77, 243);
            this.bt_login.Name = "bt_login";
            this.bt_login.Size = new System.Drawing.Size(144, 33);
            this.bt_login.TabIndex = 11;
            this.bt_login.Text = "Login";
            this.bt_login.UseVisualStyleBackColor = true;
            this.bt_login.Click += new System.EventHandler(this.bt_login_Click);
            // 
            // tb_username
            // 
            this.tb_username.Location = new System.Drawing.Point(117, 109);
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(117, 20);
            this.tb_username.TabIndex = 10;
            // 
            // lb_password
            // 
            this.lb_password.AutoSize = true;
            this.lb_password.Location = new System.Drawing.Point(52, 152);
            this.lb_password.Name = "lb_password";
            this.lb_password.Size = new System.Drawing.Size(59, 13);
            this.lb_password.TabIndex = 9;
            this.lb_password.Text = "Password :";
            // 
            // lb_username
            // 
            this.lb_username.AutoSize = true;
            this.lb_username.Location = new System.Drawing.Point(50, 109);
            this.lb_username.Name = "lb_username";
            this.lb_username.Size = new System.Drawing.Size(61, 13);
            this.lb_username.TabIndex = 8;
            this.lb_username.Text = "Username :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.lb_validar);
            this.panel1.Controls.Add(this.tb_password);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.bt_login);
            this.panel1.Controls.Add(this.tb_username);
            this.panel1.Controls.Add(this.lb_password);
            this.panel1.Controls.Add(this.lb_username);
            this.panel1.Location = new System.Drawing.Point(12, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 317);
            this.panel1.TabIndex = 1;
            // 
            // Form_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 358);
            this.Controls.Add(this.panel1);
            this.Name = "Form_login";
            this.Text = "Form_login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lb_validar;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_login;
        private System.Windows.Forms.TextBox tb_username;
        private System.Windows.Forms.Label lb_password;
        private System.Windows.Forms.Label lb_username;
        private System.Windows.Forms.Panel panel1;
    }
}