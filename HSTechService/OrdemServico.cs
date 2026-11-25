using System.Globalization;

namespace HSTechService
{
    public class OrdemServico
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int EquipamentoId { get; set; }
        public string ClienteNome { get; set; } = "";
        public string CpfCnpj { get; set; } = "";
        public string Telefone { get; set; } = "";
        public string WhatsApp { get; set; } = "";
        public string Endereco { get; set; } = "";
        public string NumeroEndereco { get; set; } = "";
        public string Bairro { get; set; } = "";
        public string Cidade { get; set; } = "";
        public string DataEntrada { get; set; } = "";
        public string DataEntrega { get; set; } = "";
        public string Status { get; set; } = "";
        public string DefeitoRelatado { get; set; } = "";
        public string Laudo { get; set; } = "";
        public double Valor { get; set; }
        public string Tipo { get; set; } = "";
        public string Marca { get; set; } = "";
        public string Modelo { get; set; } = "";
        public string NumeroSerie { get; set; } = "";
        public string Senha { get; set; } = "";
        public string Processador { get; set; } = "";
        public string Memoria { get; set; } = "";
        public string Armazenamento { get; set; } = "";
        public string Acessorios { get; set; } = "";
        public string Observacoes { get; set; } = "";

        public string Numero => Id.ToString("D5");

        public string DataEntradaFormatada => Formatar(DataEntrada);

        public string DataEntregaFormatada => Formatar(DataEntrega);

        public string EquipamentoResumo
        {
            get
            {
                var partes = new[] { Tipo, Marca, Modelo }.Where(p => p.Length > 0);
                return string.Join(" ", partes);
            }
        }

        public string EnderecoCompleto
        {
            get
            {
                var partes = new List<string>();

                if (Endereco.Length > 0)
                    partes.Add(NumeroEndereco.Length > 0 ? $"{Endereco}, {NumeroEndereco}" : Endereco);

                if (Bairro.Length > 0)
                    partes.Add(Bairro);

                if (Cidade.Length > 0)
                    partes.Add(Cidade);

                return string.Join(" - ", partes);
            }
        }

        private static string Formatar(string data)
        {
            if (DateTime.TryParseExact(data, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out var dt))
                return dt.ToString("dd/MM/yyyy HH:mm");

            return data;
        }
    }
}