namespace HSTechService
{
    public partial class FormLoja : Form
    {
        private string logoBase64 = "";

        public FormLoja()
        {
            InitializeComponent();
            Tema.Aplicar(this);

            Secundario(btnEscolherLogo);
            Secundario(btnRemoverLogo);
            Secundario(btnCancelar);

            FormClosed += (s, e) => picLogo.Image?.Dispose();
        }

        private static void Secundario(Button botao)
        {
            botao.BackColor = Tema.Branco;
            botao.ForeColor = Tema.Azul;
            botao.FlatAppearance.BorderColor = Tema.Cinza;
            botao.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 237, 241);
        }

        private void FormLoja_Load(object? sender, EventArgs e)
        {
            try
            {
                var loja = LojaRepository.Carregar();

                txtNome.Text = loja.Nome;
                txtSubtitulo.Text = loja.Subtitulo;
                txtCnpj.Text = loja.Cnpj;
                txtTelefone.Text = loja.Telefone;
                txtWhatsApp.Text = loja.WhatsApp;
                txtEmail.Text = loja.Email;
                txtEndereco.Text = loja.Endereco;
                logoBase64 = loja.LogoBase64;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados da loja: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            AtualizarPreview();
            txtNome.Focus();
        }

        private void AtualizarPreview()
        {
            var anterior = picLogo.Image;
            picLogo.Image = LogoHelper.DeBase64(logoBase64) ?? LogoHelper.CarregarMarca();
            anterior?.Dispose();
        }

        private void btnEscolherLogo_Click(object? sender, EventArgs e)
        {
            if (dlgLogo.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                using var imagem = Image.FromFile(dlgLogo.FileName);
                logoBase64 = LogoHelper.ParaBase64(imagem, 600);
                Aviso("");
                AtualizarPreview();
            }
            catch
            {
                Aviso("Não foi possível abrir essa imagem.");
            }
        }

        private void btnRemoverLogo_Click(object? sender, EventArgs e)
        {
            logoBase64 = "";
            AtualizarPreview();
        }

        private void btnSalvar_Click(object? sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();

            if (nome.Length == 0)
            {
                Aviso("Informe o nome da loja.");
                txtNome.Focus();
                return;
            }

            var loja = new Loja
            {
                Nome = nome,
                Subtitulo = txtSubtitulo.Text.Trim(),
                Cnpj = txtCnpj.Text.Trim(),
                Telefone = txtTelefone.Text.Trim(),
                WhatsApp = txtWhatsApp.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Endereco = txtEndereco.Text.Trim(),
                LogoBase64 = logoBase64
            };

            try
            {
                LojaRepository.Salvar(loja);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar os dados da loja: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void Aviso(string mensagem)
        {
            lblAviso.Text = mensagem;
        }
    }
}