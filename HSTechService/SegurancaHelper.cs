using System.Security.Cryptography;

namespace HSTechService
{
    public static class SegurancaHelper
    {
        private const int Iteracoes = 100000;
        private const int TamanhoHash = 32;
        private const int TamanhoSalt = 16;
        private const string AlfabetoChave = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";

        public static string GerarSalt()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(TamanhoSalt));
        }

        public static string GerarHash(string senha, string salt)
        {
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                senha,
                Convert.FromBase64String(salt),
                Iteracoes,
                HashAlgorithmName.SHA256,
                TamanhoHash);

            return Convert.ToBase64String(hash);
        }

        public static bool Verificar(string senha, string salt, string hashSalvo)
        {
            byte[] calculado = Convert.FromBase64String(GerarHash(senha, salt));
            byte[] esperado = Convert.FromBase64String(hashSalvo);
            return CryptographicOperations.FixedTimeEquals(calculado, esperado);
        }

        public static string GerarChaveRecuperacao()
        {
            var caracteres = new char[16];

            for (int i = 0; i < caracteres.Length; i++)
                caracteres[i] = AlfabetoChave[RandomNumberGenerator.GetInt32(AlfabetoChave.Length)];

            string bruta = new string(caracteres);
            return $"{bruta[..4]}-{bruta[4..8]}-{bruta[8..12]}-{bruta[12..]}";
        }

        public static string NormalizarChave(string chave)
        {
            return new string(chave.Where(char.IsLetterOrDigit).ToArray()).ToUpperInvariant();
        }

        public static void MostrarChaveRecuperacao(IWin32Window? dono, string chave)
        {
            try
            {
                Clipboard.SetText(chave);
            }
            catch
            {
                // Se a área de transferência estiver ocupada, a chave continua sendo mostrada na tela.
            }

            MessageBox.Show(dono,
                "Esta é a sua chave de recuperação de senha:\n\n" + chave + "\n\n" +
                "Ela foi copiada para a área de transferência. Anote em local seguro ou imprima: " +
                "é a única forma de redefinir a senha caso você a esqueça.\n\n" +
                "Esta chave não será mostrada novamente.",
                "Chave de recuperação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}