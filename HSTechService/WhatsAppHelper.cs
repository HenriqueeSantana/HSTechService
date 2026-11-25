using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace HSTechService
{
    public static class WhatsAppHelper
    {
        private static readonly CultureInfo PtBr = new("pt-BR");

        // Aceita números com DDD (10 ou 11 dígitos) e já com o 55 (12 ou 13 dígitos).
        public static string? NormalizarNumero(string telefone)
        {
            string digitos = new string(telefone.Where(char.IsDigit).ToArray()).TrimStart('0');

            if (digitos.Length == 10 || digitos.Length == 11)
                return "55" + digitos;

            if ((digitos.Length == 12 || digitos.Length == 13) && digitos.StartsWith("55"))
                return digitos;

            return null;
        }

        public static string MontarMensagem(OrdemServico os, Loja loja)
        {
            string primeiroNome = os.ClienteNome
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .FirstOrDefault() ?? os.ClienteNome;

            string equipamento = os.EquipamentoResumo.Length > 0 ? os.EquipamentoResumo : "equipamento";
            string referencia = $"{equipamento} (OS nº {os.Numero})";

            var sb = new StringBuilder();
            sb.Append($"Olá, {primeiroNome}! Aqui é da {loja.Nome}.\n\n");

            switch (os.Status)
            {
                case "Pronto":
                    sb.Append($"O seu {referencia} está pronto para retirada.");
                    if (os.Valor > 0)
                        sb.Append($"\nValor: R$ {os.Valor.ToString("N2", PtBr)}.");
                    sb.Append("\nLembre-se de trazer o comprovante da OS.");
                    break;

                case "Em análise":
                    sb.Append($"O seu {referencia} está em análise pelo nosso técnico. Assim que tivermos o diagnóstico, avisaremos você.");
                    break;

                case "Aguardando peça":
                    sb.Append($"O seu {referencia} está aguardando a chegada de uma peça. Avisaremos assim que o serviço for retomado.");
                    break;

                case "Entregue":
                    sb.Append($"A OS nº {os.Numero} foi finalizada e o equipamento foi entregue. Obrigado pela confiança!");
                    break;

                default:
                    sb.Append($"Recebemos o seu {referencia}. Em breve nosso técnico fará a análise.");
                    break;
            }

            if (loja.Telefone.Length > 0)
                sb.Append($"\n\nDúvidas: {loja.Telefone}");

            return sb.ToString();
        }

        public static void Avisar(IWin32Window? dono, OrdemServico os)
        {
            string? numero = NormalizarNumero(os.WhatsApp) ?? NormalizarNumero(os.Telefone);

            if (numero == null)
            {
                MessageBox.Show(dono,
                    "O cliente não tem um WhatsApp ou telefone válido cadastrado.\n\n" +
                    "Informe o número com DDD no cadastro do cliente, por exemplo: (11) 91234-5678.",
                    "WhatsApp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var loja = LojaRepository.Carregar();
                string url = $"https://wa.me/{numero}?text={Uri.EscapeDataString(MontarMensagem(os, loja))}";

                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show(dono, "Não foi possível abrir o WhatsApp: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}