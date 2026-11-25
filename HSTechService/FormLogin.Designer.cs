namespace HSTechService
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlEsquerdo = new Panel();
            picLogo = new PictureBox();
            lblLogo = new Label();
            lblMarca = new Label();
            pnlTraco = new Panel();
            lblLema = new Label();
            lblCriador = new Label();
            pnlDireito = new Panel();
            btnFechar = new Button();
            lblBoasVindas = new Label();
            lblSubtitulo = new Label();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblSenha = new Label();
            txtSenha = new TextBox();
            lblConfirmar = new Label();
            txtConfirmar = new TextBox();
            lblAviso = new Label();
            btnEntrar = new Button();
            linkEsqueci = new LinkLabel();
            pnlEsquerdo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            pnlDireito.SuspendLayout();
            SuspendLayout();
            //
            // pnlEsquerdo
            //
            pnlEsquerdo.BackColor = Color.FromArgb(10, 25, 47);
            pnlEsquerdo.Controls.Add(picLogo);
            pnlEsquerdo.Controls.Add(lblLogo);
            pnlEsquerdo.Controls.Add(lblMarca);
            pnlEsquerdo.Controls.Add(pnlTraco);
            pnlEsquerdo.Controls.Add(lblLema);
            pnlEsquerdo.Controls.Add(lblCriador);
            pnlEsquerdo.Dock = DockStyle.Left;
            pnlEsquerdo.Location = new Point(1, 1);
            pnlEsquerdo.Name = "pnlEsquerdo";
            pnlEsquerdo.Size = new Size(320, 468);
            pnlEsquerdo.TabIndex = 0;
            pnlEsquerdo.MouseDown += ArrastarJanela;
            //
            // picLogo
            //
            picLogo.BackColor = Color.Transparent;
            picLogo.Location = new Point(30, 72);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(260, 139);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 5;
            picLogo.TabStop = false;
            picLogo.Visible = false;
            picLogo.MouseDown += ArrastarJanela;
            //
            // lblLogo
            //
            lblLogo.BackColor = Color.FromArgb(37, 99, 235);
            lblLogo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(40, 90);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(68, 68);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "HS";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            lblLogo.MouseDown += ArrastarJanela;
            //
            // lblMarca
            //
            lblMarca.AutoSize = true;
            lblMarca.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblMarca.ForeColor = Color.White;
            lblMarca.Location = new Point(36, 172);
            lblMarca.Name = "lblMarca";
            lblMarca.TabIndex = 1;
            lblMarca.Text = "HSTechService";
            lblMarca.MouseDown += ArrastarJanela;
            //
            // pnlTraco
            //
            pnlTraco.BackColor = Color.FromArgb(37, 99, 235);
            pnlTraco.Location = new Point(40, 224);
            pnlTraco.Name = "pnlTraco";
            pnlTraco.Size = new Size(48, 4);
            pnlTraco.TabIndex = 2;
            //
            // lblLema
            //
            lblLema.Font = new Font("Segoe UI", 10F);
            lblLema.ForeColor = Color.FromArgb(180, 195, 220);
            lblLema.Location = new Point(40, 242);
            lblLema.Name = "lblLema";
            lblLema.Size = new Size(240, 70);
            lblLema.TabIndex = 3;
            lblLema.Text = "Sistema de ordens de serviço para assistência técnica.";
            lblLema.MouseDown += ArrastarJanela;
            //
            // lblCriador
            //
            lblCriador.Font = new Font("Segoe UI", 8.5F);
            lblCriador.ForeColor = Color.FromArgb(120, 140, 175);
            lblCriador.Location = new Point(40, 428);
            lblCriador.Name = "lblCriador";
            lblCriador.Size = new Size(250, 20);
            lblCriador.TabIndex = 4;
            lblCriador.Text = "Desenvolvido por Henrique Santana";
            lblCriador.MouseDown += ArrastarJanela;
            //
            // pnlDireito
            //
            pnlDireito.BackColor = Color.White;
            pnlDireito.Controls.Add(btnFechar);
            pnlDireito.Controls.Add(lblBoasVindas);
            pnlDireito.Controls.Add(lblSubtitulo);
            pnlDireito.Controls.Add(lblUsuario);
            pnlDireito.Controls.Add(txtUsuario);
            pnlDireito.Controls.Add(lblSenha);
            pnlDireito.Controls.Add(txtSenha);
            pnlDireito.Controls.Add(lblConfirmar);
            pnlDireito.Controls.Add(txtConfirmar);
            pnlDireito.Controls.Add(lblAviso);
            pnlDireito.Controls.Add(btnEntrar);
            pnlDireito.Controls.Add(linkEsqueci);
            pnlDireito.Dock = DockStyle.Fill;
            pnlDireito.Location = new Point(321, 1);
            pnlDireito.Name = "pnlDireito";
            pnlDireito.Size = new Size(458, 468);
            pnlDireito.TabIndex = 1;
            pnlDireito.MouseDown += ArrastarJanela;
            //
            // btnFechar
            //
            btnFechar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFechar.DialogResult = DialogResult.Cancel;
            btnFechar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnFechar.Location = new Point(414, 6);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(38, 30);
            btnFechar.TabIndex = 9;
            btnFechar.TabStop = false;
            btnFechar.Text = "X";
            btnFechar.UseVisualStyleBackColor = true;
            //
            // lblBoasVindas
            //
            lblBoasVindas.AutoSize = true;
            lblBoasVindas.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblBoasVindas.Location = new Point(48, 60);
            lblBoasVindas.Name = "lblBoasVindas";
            lblBoasVindas.TabIndex = 0;
            lblBoasVindas.Text = "Bem-vindo";
            //
            // lblSubtitulo
            //
            lblSubtitulo.ForeColor = Color.FromArgb(107, 114, 128);
            lblSubtitulo.Location = new Point(52, 108);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(356, 36);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Entre com sua senha para acessar o sistema.";
            //
            // lblUsuario
            //
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(52, 155);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.TabIndex = 2;
            lblUsuario.Text = "Usuário";
            //
            // txtUsuario
            //
            txtUsuario.Font = new Font("Segoe UI", 11F);
            txtUsuario.Location = new Point(52, 177);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.ReadOnly = true;
            txtUsuario.Size = new Size(356, 27);
            txtUsuario.TabIndex = 3;
            txtUsuario.TabStop = false;
            txtUsuario.Text = "admin";
            //
            // lblSenha
            //
            lblSenha.AutoSize = true;
            lblSenha.Location = new Point(52, 220);
            lblSenha.Name = "lblSenha";
            lblSenha.TabIndex = 4;
            lblSenha.Text = "Senha";
            //
            // txtSenha
            //
            txtSenha.Font = new Font("Segoe UI", 11F);
            txtSenha.Location = new Point(52, 242);
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(356, 27);
            txtSenha.TabIndex = 0;
            txtSenha.UseSystemPasswordChar = true;
            //
            // lblConfirmar
            //
            lblConfirmar.AutoSize = true;
            lblConfirmar.Location = new Point(52, 285);
            lblConfirmar.Name = "lblConfirmar";
            lblConfirmar.TabIndex = 6;
            lblConfirmar.Text = "Confirmar senha";
            lblConfirmar.Visible = false;
            //
            // txtConfirmar
            //
            txtConfirmar.Font = new Font("Segoe UI", 11F);
            txtConfirmar.Location = new Point(52, 307);
            txtConfirmar.Name = "txtConfirmar";
            txtConfirmar.Size = new Size(356, 27);
            txtConfirmar.TabIndex = 1;
            txtConfirmar.UseSystemPasswordChar = true;
            txtConfirmar.Visible = false;
            //
            // lblAviso
            //
            lblAviso.ForeColor = Color.FromArgb(220, 38, 38);
            lblAviso.Location = new Point(52, 345);
            lblAviso.Name = "lblAviso";
            lblAviso.Size = new Size(356, 22);
            lblAviso.TabIndex = 8;
            //
            // btnEntrar
            //
            btnEntrar.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnEntrar.Location = new Point(52, 375);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(356, 42);
            btnEntrar.TabIndex = 2;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = true;
            btnEntrar.Click += btnEntrar_Click;
            //
            // linkEsqueci
            //
            linkEsqueci.ActiveLinkColor = Color.FromArgb(29, 78, 216);
            linkEsqueci.AutoSize = true;
            linkEsqueci.Cursor = Cursors.Hand;
            linkEsqueci.LinkBehavior = LinkBehavior.HoverUnderline;
            linkEsqueci.LinkColor = Color.FromArgb(37, 99, 235);
            linkEsqueci.Location = new Point(52, 425);
            linkEsqueci.Name = "linkEsqueci";
            linkEsqueci.TabIndex = 3;
            linkEsqueci.TabStop = true;
            linkEsqueci.Text = "Esqueci minha senha";
            linkEsqueci.Visible = false;
            linkEsqueci.LinkClicked += linkEsqueci_LinkClicked;
            //
            // FormLogin
            //
            AcceptButton = btnEntrar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnFechar;
            ClientSize = new Size(780, 470);
            Controls.Add(pnlDireito);
            Controls.Add(pnlEsquerdo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormLogin";
            Padding = new Padding(1);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HSTechService - Login";
            Load += FormLogin_Load;
            pnlEsquerdo.ResumeLayout(false);
            pnlEsquerdo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            pnlDireito.ResumeLayout(false);
            pnlDireito.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlEsquerdo;
        private PictureBox picLogo;
        private Label lblLogo;
        private Label lblMarca;
        private Panel pnlTraco;
        private Label lblLema;
        private Label lblCriador;
        private Panel pnlDireito;
        private Button btnFechar;
        private Label lblBoasVindas;
        private Label lblSubtitulo;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblSenha;
        private TextBox txtSenha;
        private Label lblConfirmar;
        private TextBox txtConfirmar;
        private Label lblAviso;
        private Button btnEntrar;
        private LinkLabel linkEsqueci;
    }
}