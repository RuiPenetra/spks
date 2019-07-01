namespace SPKS___Cliente
{
    partial class Form_registar
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lb_validar = new System.Windows.Forms.Label();
            this.tb_conf_password = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_registar = new System.Windows.Forms.Button();
            this.tb_password = new System.Windows.Forms.MaskedTextBox();
            this.tb_username = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.lb_validar);
            this.panel2.Controls.Add(this.tb_conf_password);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.bt_registar);
            this.panel2.Controls.Add(this.tb_password);
            this.panel2.Controls.Add(this.tb_username);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(13, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(295, 317);
            this.panel2.TabIndex = 18;
            // 
            // lb_validar
            // 
            this.lb_validar.AutoSize = true;
            this.lb_validar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_validar.ForeColor = System.Drawing.Color.Red;
            this.lb_validar.Location = new System.Drawing.Point(120, 205);
            this.lb_validar.Name = "lb_validar";
            this.lb_validar.Size = new System.Drawing.Size(75, 18);
            this.lb_validar.TabIndex = 23;
            this.lb_validar.Text = "VALIDAR";
            this.lb_validar.Visible = false;
            // 
            // tb_conf_password
            // 
            this.tb_conf_password.Location = new System.Drawing.Point(135, 161);
            this.tb_conf_password.Name = "tb_conf_password";
            this.tb_conf_password.Size = new System.Drawing.Size(117, 20);
            this.tb_conf_password.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Conf. Password :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(99, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 24);
            this.label3.TabIndex = 20;
            this.label3.Text = "REGISTAR";
            // 
            // bt_registar
            // 
            this.bt_registar.Location = new System.Drawing.Point(85, 243);
            this.bt_registar.Name = "bt_registar";
            this.bt_registar.Size = new System.Drawing.Size(144, 33);
            this.bt_registar.TabIndex = 19;
            this.bt_registar.Text = "Registar";
            this.bt_registar.UseVisualStyleBackColor = true;
            this.bt_registar.Click += new System.EventHandler(this.bt_registar_Click);
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(135, 125);
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(117, 20);
            this.tb_password.TabIndex = 18;
            // 
            // tb_username
            // 
            this.tb_username.Location = new System.Drawing.Point(135, 91);
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(117, 20);
            this.tb_username.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Password :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(68, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Username :";
            // 
            // Form_registar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 358);
            this.Controls.Add(this.panel2);
            this.Name = "Form_registar";
            this.Text = "Registar";
            this.Load += new System.EventHandler(this.Form_registar_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lb_validar;
        private System.Windows.Forms.MaskedTextBox tb_conf_password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bt_registar;
        private System.Windows.Forms.MaskedTextBox tb_password;
        private System.Windows.Forms.TextBox tb_username;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}