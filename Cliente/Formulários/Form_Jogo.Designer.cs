namespace SPKS___Cliente
{
    partial class Form_Jogo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Jogo));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_nick = new System.Windows.Forms.Label();
            this.tb_enviarMensagem = new System.Windows.Forms.TextBox();
            this.textBoxChat = new System.Windows.Forms.TextBox();
            this.bt_enviarMensagem = new System.Windows.Forms.Button();
            this.tb_sala = new System.Windows.Forms.TextBox();
            this.labelSala = new System.Windows.Forms.Label();
            this.Temporizador = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_fechar = new System.Windows.Forms.Button();
            this.bt_sala = new System.Windows.Forms.Button();
            this.lb_defende = new System.Windows.Forms.Label();
            this.bt_posicao4 = new System.Windows.Forms.Button();
            this.bt_posicao1 = new System.Windows.Forms.Button();
            this.bt_posicao2 = new System.Windows.Forms.Button();
            this.bt_posicao5 = new System.Windows.Forms.Button();
            this.bt_posicao6 = new System.Windows.Forms.Button();
            this.bt_posicao3 = new System.Windows.Forms.Button();
            this.labelEscolha = new System.Windows.Forms.Label();
            this.lb_nomesalas = new System.Windows.Forms.Label();
            this.lb_atacar = new System.Windows.Forms.Label();
            this.img_luvas = new System.Windows.Forms.PictureBox();
            this.lb_estado = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.painel_esperar = new System.Windows.Forms.Panel();
            this.labelAguarde = new System.Windows.Forms.Label();
            this.painel_estado = new System.Windows.Forms.Panel();
            this.bt_novoJogo = new System.Windows.Forms.Button();
            this.lb_tipo = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.img_novo_jogo = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelResult = new System.Windows.Forms.Label();
            this.labelResultado = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.painel_baliza = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.bt_close = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_luvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.painel_esperar.SuspendLayout();
            this.painel_estado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_novo_jogo)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.painel_baliza)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lb_nick);
            this.groupBox1.Controls.Add(this.tb_enviarMensagem);
            this.groupBox1.Controls.Add(this.textBoxChat);
            this.groupBox1.Controls.Add(this.bt_enviarMensagem);
            this.groupBox1.Location = new System.Drawing.Point(728, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 537);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lb_nick
            // 
            this.lb_nick.AutoSize = true;
            this.lb_nick.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nick.Location = new System.Drawing.Point(8, 419);
            this.lb_nick.Name = "lb_nick";
            this.lb_nick.Size = new System.Drawing.Size(35, 18);
            this.lb_nick.TabIndex = 48;
            this.lb_nick.Text = "nick";
            // 
            // tb_enviarMensagem
            // 
            this.tb_enviarMensagem.Enabled = false;
            this.tb_enviarMensagem.Location = new System.Drawing.Point(11, 440);
            this.tb_enviarMensagem.Name = "tb_enviarMensagem";
            this.tb_enviarMensagem.Size = new System.Drawing.Size(285, 20);
            this.tb_enviarMensagem.TabIndex = 8;
            // 
            // textBoxChat
            // 
            this.textBoxChat.BackColor = System.Drawing.Color.White;
            this.textBoxChat.Location = new System.Drawing.Point(11, 24);
            this.textBoxChat.Multiline = true;
            this.textBoxChat.Name = "textBoxChat";
            this.textBoxChat.ReadOnly = true;
            this.textBoxChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxChat.Size = new System.Drawing.Size(285, 392);
            this.textBoxChat.TabIndex = 9;
            // 
            // bt_enviarMensagem
            // 
            this.bt_enviarMensagem.Enabled = false;
            this.bt_enviarMensagem.Location = new System.Drawing.Point(11, 481);
            this.bt_enviarMensagem.Name = "bt_enviarMensagem";
            this.bt_enviarMensagem.Size = new System.Drawing.Size(290, 25);
            this.bt_enviarMensagem.TabIndex = 7;
            this.bt_enviarMensagem.Text = "Enviar Mensagem";
            this.bt_enviarMensagem.UseVisualStyleBackColor = true;
            this.bt_enviarMensagem.Click += new System.EventHandler(this.buttonEnviarMensagem_Click);
            // 
            // tb_sala
            // 
            this.tb_sala.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_sala.Location = new System.Drawing.Point(127, 93);
            this.tb_sala.Name = "tb_sala";
            this.tb_sala.Size = new System.Drawing.Size(216, 31);
            this.tb_sala.TabIndex = 11;
            // 
            // labelSala
            // 
            this.labelSala.AutoSize = true;
            this.labelSala.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSala.Location = new System.Drawing.Point(46, 96);
            this.labelSala.Name = "labelSala";
            this.labelSala.Size = new System.Drawing.Size(61, 25);
            this.labelSala.TabIndex = 10;
            this.labelSala.Text = "Sala:";
            // 
            // Temporizador
            // 
            this.Temporizador.Interval = 500;
            this.Temporizador.Tick += new System.EventHandler(this.Temporizador_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel1.Controls.Add(this.bt_close);
            this.panel1.Controls.Add(this.bt_fechar);
            this.panel1.Location = new System.Drawing.Point(1, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1054, 49);
            this.panel1.TabIndex = 15;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseUp);
            // 
            // bt_fechar
            // 
            this.bt_fechar.BackColor = System.Drawing.Color.Transparent;
            this.bt_fechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_fechar.Image = ((System.Drawing.Image)(resources.GetObject("bt_fechar.Image")));
            this.bt_fechar.Location = new System.Drawing.Point(1410, 3);
            this.bt_fechar.Name = "bt_fechar";
            this.bt_fechar.Size = new System.Drawing.Size(47, 47);
            this.bt_fechar.TabIndex = 22;
            this.bt_fechar.UseVisualStyleBackColor = false;
            this.bt_fechar.Click += new System.EventHandler(this.Bt_fechar_Click);
            // 
            // bt_sala
            // 
            this.bt_sala.Location = new System.Drawing.Point(357, 93);
            this.bt_sala.Name = "bt_sala";
            this.bt_sala.Size = new System.Drawing.Size(75, 31);
            this.bt_sala.TabIndex = 30;
            this.bt_sala.Text = "Entrar";
            this.bt_sala.UseVisualStyleBackColor = true;
            this.bt_sala.Click += new System.EventHandler(this.btn_sala_Click);
            // 
            // lb_defende
            // 
            this.lb_defende.AutoSize = true;
            this.lb_defende.BackColor = System.Drawing.Color.Transparent;
            this.lb_defende.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_defende.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_defende.ForeColor = System.Drawing.Color.Maroon;
            this.lb_defende.Location = new System.Drawing.Point(290, 132);
            this.lb_defende.Name = "lb_defende";
            this.lb_defende.Size = new System.Drawing.Size(100, 25);
            this.lb_defende.TabIndex = 41;
            this.lb_defende.Text = "Defende";
            this.lb_defende.UseWaitCursor = true;
            this.lb_defende.Visible = false;
            // 
            // bt_posicao4
            // 
            this.bt_posicao4.BackColor = System.Drawing.Color.Transparent;
            this.bt_posicao4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_posicao4.BackgroundImage")));
            this.bt_posicao4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bt_posicao4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_posicao4.Location = new System.Drawing.Point(509, 313);
            this.bt_posicao4.Name = "bt_posicao4";
            this.bt_posicao4.Size = new System.Drawing.Size(75, 82);
            this.bt_posicao4.TabIndex = 40;
            this.bt_posicao4.UseVisualStyleBackColor = false;
            this.bt_posicao4.Click += new System.EventHandler(this.bt_posicao4_Click);
            // 
            // bt_posicao1
            // 
            this.bt_posicao1.BackColor = System.Drawing.Color.Transparent;
            this.bt_posicao1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_posicao1.BackgroundImage")));
            this.bt_posicao1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bt_posicao1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_posicao1.Location = new System.Drawing.Point(298, 217);
            this.bt_posicao1.Name = "bt_posicao1";
            this.bt_posicao1.Size = new System.Drawing.Size(80, 81);
            this.bt_posicao1.TabIndex = 39;
            this.bt_posicao1.UseVisualStyleBackColor = false;
            this.bt_posicao1.Click += new System.EventHandler(this.bt_posicao1_Click);
            // 
            // bt_posicao2
            // 
            this.bt_posicao2.BackColor = System.Drawing.Color.Transparent;
            this.bt_posicao2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_posicao2.BackgroundImage")));
            this.bt_posicao2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bt_posicao2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_posicao2.Location = new System.Drawing.Point(298, 313);
            this.bt_posicao2.Name = "bt_posicao2";
            this.bt_posicao2.Size = new System.Drawing.Size(80, 77);
            this.bt_posicao2.TabIndex = 38;
            this.bt_posicao2.UseVisualStyleBackColor = false;
            this.bt_posicao2.Click += new System.EventHandler(this.bt_posicao2_Click);
            // 
            // bt_posicao5
            // 
            this.bt_posicao5.BackColor = System.Drawing.Color.Transparent;
            this.bt_posicao5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_posicao5.BackgroundImage")));
            this.bt_posicao5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bt_posicao5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_posicao5.Location = new System.Drawing.Point(102, 303);
            this.bt_posicao5.Name = "bt_posicao5";
            this.bt_posicao5.Size = new System.Drawing.Size(84, 87);
            this.bt_posicao5.TabIndex = 35;
            this.bt_posicao5.UseVisualStyleBackColor = false;
            this.bt_posicao5.Click += new System.EventHandler(this.bt_posicao5_Click);
            // 
            // bt_posicao6
            // 
            this.bt_posicao6.BackColor = System.Drawing.Color.Transparent;
            this.bt_posicao6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_posicao6.BackgroundImage")));
            this.bt_posicao6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bt_posicao6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_posicao6.Location = new System.Drawing.Point(102, 215);
            this.bt_posicao6.Name = "bt_posicao6";
            this.bt_posicao6.Size = new System.Drawing.Size(82, 82);
            this.bt_posicao6.TabIndex = 37;
            this.bt_posicao6.UseVisualStyleBackColor = false;
            this.bt_posicao6.Click += new System.EventHandler(this.bt_posicao6_Click);
            // 
            // bt_posicao3
            // 
            this.bt_posicao3.BackColor = System.Drawing.Color.Transparent;
            this.bt_posicao3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_posicao3.BackgroundImage")));
            this.bt_posicao3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bt_posicao3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_posicao3.Location = new System.Drawing.Point(509, 217);
            this.bt_posicao3.Name = "bt_posicao3";
            this.bt_posicao3.Size = new System.Drawing.Size(75, 81);
            this.bt_posicao3.TabIndex = 36;
            this.bt_posicao3.UseVisualStyleBackColor = false;
            this.bt_posicao3.Click += new System.EventHandler(this.bt_posicao3_Click);
            // 
            // labelEscolha
            // 
            this.labelEscolha.AutoSize = true;
            this.labelEscolha.BackColor = System.Drawing.Color.White;
            this.labelEscolha.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEscolha.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelEscolha.Location = new System.Drawing.Point(68, 62);
            this.labelEscolha.Name = "labelEscolha";
            this.labelEscolha.Size = new System.Drawing.Size(364, 25);
            this.labelEscolha.TabIndex = 42;
            this.labelEscolha.Text = "Insira o nome da sala onde deseja entrar";
            // 
            // lb_nomesalas
            // 
            this.lb_nomesalas.AutoSize = true;
            this.lb_nomesalas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nomesalas.Location = new System.Drawing.Point(170, 96);
            this.lb_nomesalas.Name = "lb_nomesalas";
            this.lb_nomesalas.Size = new System.Drawing.Size(111, 20);
            this.lb_nomesalas.TabIndex = 45;
            this.lb_nomesalas.Text = "NOME SALA";
            // 
            // lb_atacar
            // 
            this.lb_atacar.AutoSize = true;
            this.lb_atacar.BackColor = System.Drawing.Color.Transparent;
            this.lb_atacar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_atacar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_atacar.ForeColor = System.Drawing.Color.Maroon;
            this.lb_atacar.Location = new System.Drawing.Point(298, 132);
            this.lb_atacar.Name = "lb_atacar";
            this.lb_atacar.Size = new System.Drawing.Size(80, 25);
            this.lb_atacar.TabIndex = 46;
            this.lb_atacar.Text = "Atacar";
            this.lb_atacar.UseWaitCursor = true;
            // 
            // img_luvas
            // 
            this.img_luvas.Image = ((System.Drawing.Image)(resources.GetObject("img_luvas.Image")));
            this.img_luvas.Location = new System.Drawing.Point(3, 327);
            this.img_luvas.Name = "img_luvas";
            this.img_luvas.Size = new System.Drawing.Size(101, 91);
            this.img_luvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_luvas.TabIndex = 47;
            this.img_luvas.TabStop = false;
            // 
            // lb_estado
            // 
            this.lb_estado.AutoSize = true;
            this.lb_estado.BackColor = System.Drawing.Color.Transparent;
            this.lb_estado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_estado.ForeColor = System.Drawing.Color.Maroon;
            this.lb_estado.Location = new System.Drawing.Point(575, 19);
            this.lb_estado.Name = "lb_estado";
            this.lb_estado.Size = new System.Drawing.Size(85, 25);
            this.lb_estado.TabIndex = 48;
            this.lb_estado.Text = "Estado";
            this.lb_estado.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(34, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(259, 242);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 34;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.UseWaitCursor = true;
            // 
            // painel_esperar
            // 
            this.painel_esperar.BackColor = System.Drawing.Color.Transparent;
            this.painel_esperar.Controls.Add(this.labelAguarde);
            this.painel_esperar.Controls.Add(this.pictureBox2);
            this.painel_esperar.ForeColor = System.Drawing.Color.Transparent;
            this.painel_esperar.Location = new System.Drawing.Point(425, 82);
            this.painel_esperar.Name = "painel_esperar";
            this.painel_esperar.Size = new System.Drawing.Size(315, 258);
            this.painel_esperar.TabIndex = 51;
            this.painel_esperar.UseWaitCursor = true;
            this.painel_esperar.Visible = false;
            this.painel_esperar.Paint += new System.Windows.Forms.PaintEventHandler(this.painel_esperar_Paint);
            // 
            // labelAguarde
            // 
            this.labelAguarde.BackColor = System.Drawing.Color.Transparent;
            this.labelAguarde.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelAguarde.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAguarde.ForeColor = System.Drawing.Color.DarkRed;
            this.labelAguarde.Location = new System.Drawing.Point(3, 195);
            this.labelAguarde.Name = "labelAguarde";
            this.labelAguarde.Size = new System.Drawing.Size(314, 79);
            this.labelAguarde.TabIndex = 35;
            this.labelAguarde.Text = "Aguarde pelo outro Jogador";
            this.labelAguarde.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelAguarde.UseWaitCursor = true;
            // 
            // painel_estado
            // 
            this.painel_estado.BackColor = System.Drawing.Color.White;
            this.painel_estado.Controls.Add(this.bt_novoJogo);
            this.painel_estado.Controls.Add(this.lb_tipo);
            this.painel_estado.Controls.Add(this.pictureBox5);
            this.painel_estado.ForeColor = System.Drawing.Color.Transparent;
            this.painel_estado.Location = new System.Drawing.Point(102, 74);
            this.painel_estado.Name = "painel_estado";
            this.painel_estado.Size = new System.Drawing.Size(504, 447);
            this.painel_estado.TabIndex = 54;
            this.painel_estado.UseWaitCursor = true;
            this.painel_estado.Visible = false;
            // 
            // bt_novoJogo
            // 
            this.bt_novoJogo.BackColor = System.Drawing.Color.SteelBlue;
            this.bt_novoJogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_novoJogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_novoJogo.Location = new System.Drawing.Point(159, 384);
            this.bt_novoJogo.Name = "bt_novoJogo";
            this.bt_novoJogo.Size = new System.Drawing.Size(178, 60);
            this.bt_novoJogo.TabIndex = 53;
            this.bt_novoJogo.Text = "Novo Jogo";
            this.bt_novoJogo.UseVisualStyleBackColor = false;
            this.bt_novoJogo.UseWaitCursor = true;
            this.bt_novoJogo.Click += new System.EventHandler(this.bt_novoJogo_Click_1);
            // 
            // lb_tipo
            // 
            this.lb_tipo.BackColor = System.Drawing.Color.Transparent;
            this.lb_tipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_tipo.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tipo.ForeColor = System.Drawing.Color.DarkRed;
            this.lb_tipo.Location = new System.Drawing.Point(124, 310);
            this.lb_tipo.Name = "lb_tipo";
            this.lb_tipo.Size = new System.Drawing.Size(255, 79);
            this.lb_tipo.TabIndex = 35;
            this.lb_tipo.Text = "VENCEDOR";
            this.lb_tipo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_tipo.UseWaitCursor = true;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(-15, 3);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(549, 386);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 34;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.UseWaitCursor = true;
            // 
            // img_novo_jogo
            // 
            this.img_novo_jogo.Image = ((System.Drawing.Image)(resources.GetObject("img_novo_jogo.Image")));
            this.img_novo_jogo.Location = new System.Drawing.Point(261, 202);
            this.img_novo_jogo.Name = "img_novo_jogo";
            this.img_novo_jogo.Size = new System.Drawing.Size(208, 193);
            this.img_novo_jogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_novo_jogo.TabIndex = 34;
            this.img_novo_jogo.TabStop = false;
            this.img_novo_jogo.UseWaitCursor = true;
            this.img_novo_jogo.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.img_luvas);
            this.panel2.Controls.Add(this.lb_estado);
            this.panel2.Controls.Add(this.painel_estado);
            this.panel2.Controls.Add(this.labelResult);
            this.panel2.Controls.Add(this.lb_defende);
            this.panel2.Controls.Add(this.bt_posicao5);
            this.panel2.Controls.Add(this.labelResultado);
            this.panel2.Controls.Add(this.bt_posicao6);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.lb_atacar);
            this.panel2.Controls.Add(this.bt_posicao3);
            this.panel2.Controls.Add(this.bt_posicao2);
            this.panel2.Controls.Add(this.bt_posicao1);
            this.panel2.Controls.Add(this.bt_posicao4);
            this.panel2.Controls.Add(this.painel_baliza);
            this.panel2.Controls.Add(this.img_novo_jogo);
            this.panel2.Location = new System.Drawing.Point(27, 130);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(691, 567);
            this.panel2.TabIndex = 56;
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.BackColor = System.Drawing.Color.Transparent;
            this.labelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelResult.Location = new System.Drawing.Point(243, 5);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(182, 39);
            this.labelResult.TabIndex = 44;
            this.labelResult.Text = "Resultado";
            // 
            // labelResultado
            // 
            this.labelResultado.AutoSize = true;
            this.labelResultado.BackColor = System.Drawing.Color.Transparent;
            this.labelResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResultado.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelResultado.Location = new System.Drawing.Point(288, 59);
            this.labelResultado.Name = "labelResultado";
            this.labelResultado.Size = new System.Drawing.Size(90, 39);
            this.labelResultado.TabIndex = 43;
            this.labelResultado.Text = "0 - 0";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(384, 47);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(60, 61);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 34;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(222, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // painel_baliza
            // 
            this.painel_baliza.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("painel_baliza.BackgroundImage")));
            this.painel_baliza.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.painel_baliza.Enabled = false;
            this.painel_baliza.Location = new System.Drawing.Point(2, 3);
            this.painel_baliza.Name = "painel_baliza";
            this.painel_baliza.Size = new System.Drawing.Size(686, 504);
            this.painel_baliza.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.painel_baliza.TabIndex = 5;
            this.painel_baliza.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(867, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 57;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bt_close
            // 
            this.bt_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_close.Image = ((System.Drawing.Image)(resources.GetObject("bt_close.Image")));
            this.bt_close.Location = new System.Drawing.Point(1004, 0);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(47, 47);
            this.bt_close.TabIndex = 54;
            this.bt_close.UseVisualStyleBackColor = true;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
            // 
            // Form_Jogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Silver;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1197, 788);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelEscolha);
            this.Controls.Add(this.bt_sala);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelSala);
            this.Controls.Add(this.tb_sala);
            this.Controls.Add(this.lb_nomesalas);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.painel_esperar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Jogo";
            this.Text = "Super Penalty Kick Secured - SPKS";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Jogo_FormClosed);
            this.Click += new System.EventHandler(this.Form_Jogo_Click);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.img_luvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.painel_esperar.ResumeLayout(false);
            this.painel_estado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_novo_jogo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.painel_baliza)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_enviarMensagem;
        private System.Windows.Forms.Button bt_enviarMensagem;
        private System.Windows.Forms.TextBox textBoxChat;
        private System.Windows.Forms.TextBox tb_sala;
        private System.Windows.Forms.Label labelSala;
        private System.Windows.Forms.Timer Temporizador;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bt_fechar;
        private System.Windows.Forms.Button bt_sala;
        private System.Windows.Forms.Label lb_defende;
        private System.Windows.Forms.Button bt_posicao4;
        private System.Windows.Forms.Button bt_posicao1;
        private System.Windows.Forms.Button bt_posicao2;
        private System.Windows.Forms.Button bt_posicao5;
        private System.Windows.Forms.Button bt_posicao6;
        private System.Windows.Forms.Button bt_posicao3;
        private System.Windows.Forms.Label labelEscolha;
        private System.Windows.Forms.Label lb_nomesalas;
        private System.Windows.Forms.Label lb_atacar;
        private System.Windows.Forms.Label lb_nick;
        private System.Windows.Forms.PictureBox img_luvas;
        private System.Windows.Forms.Label lb_estado;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel painel_esperar;
        private System.Windows.Forms.Label labelAguarde;
        private System.Windows.Forms.Panel painel_estado;
        private System.Windows.Forms.Button bt_novoJogo;
        private System.Windows.Forms.Label lb_tipo;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox img_novo_jogo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Label labelResultado;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox painel_baliza;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bt_close;
    }
}

