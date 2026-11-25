namespace HSTechService
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            using var instanciaUnica = new Mutex(true, "HSTechService_InstanciaUnica", out bool primeira);

            ApplicationConfiguration.Initialize();

            if (!primeira)
            {
                MessageBox.Show("O HSTechService já está aberto.", "HSTechService",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Database.Inicializar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Não foi possível abrir o banco de dados.\n\n" + ex.Message +
                    "\n\nPasta dos dados:\n" + Database.Pasta,
                    "HSTechService", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var login = new FormLogin())
            {
                if (login.ShowDialog() != DialogResult.OK)
                    return;
            }

            Application.Run(new FormPrincipal());
        }
    }
}