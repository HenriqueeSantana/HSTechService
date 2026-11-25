namespace HSTechService
{
    partial class FormLoja
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
            lblTitulo = new Label();
            lblDescricao = new Label();
            picLogo = new PictureBox();
            btnEscolherLogo = new Button();
            btnRemoverLogo = new Button();
            lblLogoDica = new Label();
            lblNome = new Label();
            txtNome = new TextBox();
            lblSubtitulo = new Label();
            txtSubtitulo = new TextBox();
            lblCnpj = new Label();
            txtCnpj = new TextBox();
            lblTelefone = new Label();
            txtTelefone = new TextBox();
            lblWhatsApp = new Label();
            txtWhatsApp = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblEndereco = new Label();
            txtEndereco = new TextBox();
            lblAviso = new Label();
            btnSalvar = new Button();
            btnCancelar = new Button();
            dlgLogo = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(30, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Dados da loja";
            //
            // lblDescricao
            //
            lblDescricao.ForeColor = Color.FromArgb(107, 114, 128);
            lblDescricao.Location = new Point(32, 58);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(456, 20);
            lblDescricao.TabIndex = 1;
            lblDescricao.Text = "Estes dados aparecem no cabeçalho da OS impressa.";
            //
            // picLogo
            //
            picLogo.BackColor = Color.White;
            picLogo.BorderStyle = BorderStyle.FixedSingle;
            picLogo.Location = new Point(32, 92);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(200, 107);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 2;
            picLogo.TabStop = false;
            //
            // btnEscolherLogo
            //
            btnEscolherLogo.Location = new Point(252, 92);
            btnEscolherLogo.Name = "btnEscolherLogo";
            btnEscolherLogo.Size = new Size(190, 36);
            btnEscolherLogo.TabIndex = 0;
            btnEscolherLogo.Text = "Escolher logo...";
            btnEscolherLogo.UseVisualStyleBackColor = true;
            btnEscolherLogo.Click += btnEscolherLogo_Click;
            //
            // btnRemoverLogo
            //
            btnRemoverLogo.Location = new Point(252, 135);
            btnRemoverLogo.Name = "btnRemoverLogo";
            btnRemoverLogo.Size = new Size(190, 36);
            btnRemoverLogo.TabIndex = 1;
            btnRemoverLogo.Text = "Usar logo padrão";
            btnRemoverLogo.UseVisualStyleBackColor = true;
            btnRemoverLogo.Click += btnRemoverLogo_Click;
            //
            // lblLogoDica
            //
            lblLogoDica.ForeColor = Color.FromArgb(107, 114, 128);
            lblLogoDica.Location = new Point(252, 177);
            lblLogoDica.Name = "lblLogoDica";
            lblLogoDica.Size = new Size(236, 34);
            lblLogoDica.TabIndex = 5;
            lblLogoDica.Text = "PNG ou JPG. Fundo transparente fica melhor na impressão.";
            //
            // lblNome
            //
            lblNome.AutoSize = true;
            lblNome.Location = new Point(32, 226);
            lblNome.Name = "lblNome";
            lblNome.TabIndex = 6;
            lblNome.Text = "Nome da loja";
            //
            // txtNome
            //
            txtNome.Location = new Point(32, 246);
            txtNome.MaxLength = 60;
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(456, 23);
            txtNome.TabIndex = 2;
            //
            // lblSubtitulo
            //
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Location = new Point(32, 281);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.TabIndex = 8;
            lblSubtitulo.Text = "Descrição (abaixo do nome)";
            //
            // txtSubtitulo
            //
            txtSubtitulo.Location = new Point(32, 301);
            txtSubtitulo.MaxLength = 80;
            txtSubtitulo.Name = "txtSubtitulo";
            txtSubtitulo.Size = new Size(456, 23);
            txtSubtitulo.TabIndex = 3;
            //
            // lblCnpj
            //
            lblCnpj.AutoSize = true;
            lblCnpj.Location = new Point(32, 336);
            lblCnpj.Name = "lblCnpj";
            lblCnpj.TabIndex = 10;
            lblCnpj.Text = "CNPJ";
            //
            // txtCnpj
            //
            txtCnpj.Location = new Point(32, 356);
            txtCnpj.MaxLength = 20;
            txtCnpj.Name = "txtCnpj";
            txtCnpj.Size = new Size(220, 23);
            txtCnpj.TabIndex = 4;
            //
            // lblTelefone
            //
            lblTelefone.AutoSize = true;
            lblTelefone.Location = new Point(268, 336);
            lblTelefone.Name = "lblTelefone";
            lblTelefone.TabIndex = 12;
            lblTelefone.Text = "Telefone";
            //
            // txtTelefone
            //
            txtTelefone.Location = new Point(268, 356);
            txtTelefone.MaxLength = 20;
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(220, 23);
            txtTelefone.TabIndex = 5;
            //
            // lblWhatsApp
            //
            lblWhatsApp.AutoSize = true;
            lblWhatsApp.Location = new Point(32, 391);
            lblWhatsApp.Name = "lblWhatsApp";
            lblWhatsApp.TabIndex = 14;
            lblWhatsApp.Text = "WhatsApp";
            //
            // txtWhatsApp
            //
            txtWhatsApp.Location = new Point(32, 411);
            txtWhatsApp.MaxLength = 20;
            txtWhatsApp.Name = "txtWhatsApp";
            txtWhatsApp.Size = new Size(220, 23);
            txtWhatsApp.TabIndex = 6;
            //
            // lblEmail
            //
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(268, 391);
            lblEmail.Name = "lblEmail";
            lblEmail.TabIndex = 16;
            lblEmail.Text = "E-mail";
            //
            // txtEmail
            //
            txtEmail.Location = new Point(268, 411);
            txtEmail.MaxLength = 80;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(220, 23);
            txtEmail.TabIndex = 7;
            //
            // lblEndereco
            //
            lblEndereco.AutoSize = true;
            lblEndereco.Location = new Point(32, 446);
            lblEndereco.Name = "lblEndereco";
            lblEndereco.TabIndex = 18;
            lblEndereco.Text = "Endereço";
            //
            // txtEndereco
            //
            txtEndereco.Location = new Point(32, 466);
            txtEndereco.MaxLength = 120;
            txtEndereco.Name = "txtEndereco";
            txtEndereco.Size = new Size(456, 23);
            txtEndereco.TabIndex = 8;
            //
            // lblAviso
            //
            lblAviso.ForeColor = Color.FromArgb(220, 38, 38);
            lblAviso.Location = new Point(32, 500);
            lblAviso.Name = "lblAviso";
            lblAviso.Size = new Size(456, 22);
            lblAviso.TabIndex = 20;
            //
            // btnSalvar
            //
            btnSalvar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSalvar.Location = new Point(32, 530);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(222, 40);
            btnSalvar.TabIndex = 9;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            //
            // btnCancelar
            //
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(266, 530);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(222, 40);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            //
            // dlgLogo
            //
            dlgLogo.CheckFileExists = true;
            dlgLogo.Filter = "Imagens (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp";
            dlgLogo.Title = "Selecionar a logo da loja";
            //
            // FormLoja
            //
            AcceptButton = btnSalvar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(520, 596);
            Controls.Add(lblTitulo);
            Controls.Add(lblDescricao);
            Controls.Add(picLogo);
            Controls.Add(btnEscolherLogo);
            Controls.Add(btnRemoverLogo);
            Controls.Add(lblLogoDica);
            Controls.Add(lblNome);
            Controls.Add(txtNome);
            Controls.Add(lblSubtitulo);
            Controls.Add(txtSubtitulo);
            Controls.Add(lblCnpj);
            Controls.Add(txtCnpj);
            Controls.Add(lblTelefone);
            Controls.Add(txtTelefone);
            Controls.Add(lblWhatsApp);
            Controls.Add(txtWhatsApp);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblEndereco);
            Controls.Add(txtEndereco);
            Controls.Add(lblAviso);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLoja";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Dados da loja";
            Load += FormLoja_Load;
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitulo;
        private Label lblDescricao;
        private PictureBox picLogo;
        private Button btnEscolherLogo;
        private Button btnRemoverLogo;
        private Label lblLogoDica;
        private Label lblNome;
        private TextBox txtNome;
        private Label lblSubtitulo;
        private TextBox txtSubtitulo;
        private Label lblCnpj;
        private TextBox txtCnpj;
        private Label lblTelefone;
        private TextBox txtTelefone;
        private Label lblWhatsApp;
        private TextBox txtWhatsApp;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblEndereco;
        private TextBox txtEndereco;
        private Label lblAviso;
        private Button btnSalvar;
        private Button btnCancelar;
        private OpenFileDialog dlgLogo;
    }
}