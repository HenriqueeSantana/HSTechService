using System.Runtime.InteropServices;

namespace HSTechService
{
    public partial class FormLogin : Form
    {
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        private bool primeiroAcesso;

        public FormLogin()
        {
            InitializeComponent();
            Tema.Aplicar(this);
            BackColor = Tema.Cinza;
            FormClosed += (s, e) => picLogo.Image?.Dispose();
        }

        private void ArrastarJanela(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }

        private void FormLogin_Load(object? sender, EventArgs e)
        {
            var marca = LogoHelper.CarregarMarca();
            if (marca != null)
            {
                picLogo.Image = marca;
                picLogo.Visible = true;
                lblLogo.Visible = false;
                lblMarca.Visible = false;
            }

            primeiroAcesso = !UsuarioRepository.ExisteAdmin();

            if (primeiroAcesso)
            {
                lblSubtitulo.Text = "Primeiro acesso: defina a senha do administrador.";
                lblConfirmar.Visible = true;
                txtConfirmar.Visible = true;
                btnEntrar.Text = "Criar senha e entrar";
            }
            else
            {
                lblAviso.Top = 290;
                btnEntrar.Top = 322;

                linkEsqueci.Visible = true;
                linkEsqueci.Top = btnEntrar.Bottom + 12;
                linkEsqueci.Left = btnEntrar.Left + (btnEntrar.Width - linkEsqueci.Width) / 2;
            }

            txtSenha.Focus();
        }

        private void btnEntrar_Click(object? sender, EventArgs e)
        {
            string senha = txtSenha.Text;

            if (primeiroAcesso)
            {
                CriarPrimeiroAcesso(senha);
                return;
            }

            try
            {
                var resultado = UsuarioRepository.Autenticar("admin", senha,
                    out int restantes, out TimeSpan bloqueio);

                switch (resultado)
                {
                    case ResultadoLogin.Sucesso:
                        DialogResult = DialogResult.OK;
                        return;

                    case ResultadoLogin.Bloqueado:
                        Aviso($"Acesso bloqueado. Tente novamente em {Math.Ceiling(bloqueio.TotalMinutes):0} minuto(s).");
                        break;

                    default:
                        Aviso($"Senha incorreta. Restam {restantes} tentativa(s).");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao validar o acesso: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtSenha.Clear();
            txtSenha.Focus();
        }

        private void CriarPrimeiroAcesso(string senha)
        {
            if (senha.Length < 6)
            {
                Aviso("A senha deve ter pelo menos 6 caracteres.");
                return;
            }

            if (senha != txtConfirmar.Text)
            {
                Aviso("As senhas não conferem.");
                return;
            }

            string chave;

            try
            {
                chave = UsuarioRepository.CriarAdmin(senha);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar o administrador: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SegurancaHelper.MostrarChaveRecuperacao(this, chave);
            DialogResult = DialogResult.OK;
        }

        private void linkEsqueci_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            using var formulario = new FormSenha(ModoSenha.Recuperar);

            if (formulario.ShowDialog(this) == DialogResult.OK)
            {
                txtSenha.Clear();
                Aviso("");
                txtSenha.Focus();
            }
        }

        private void Aviso(string mensagem)
        {
            lblAviso.Text = mensagem;
        }
    }
}