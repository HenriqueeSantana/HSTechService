namespace HSTechService
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public string CpfCnpj { get; set; } = "";
        public string Telefone { get; set; } = "";
        public string WhatsApp { get; set; } = "";
        public string Email { get; set; } = "";
        public string Endereco { get; set; } = "";
        public string Numero { get; set; } = "";
        public string Bairro { get; set; } = "";
        public string Cidade { get; set; } = "";
        public string DataCadastro { get; set; } = "";

        public string EnderecoCompleto
        {
            get
            {
                var partes = new List<string>();

                if (Endereco.Length > 0)
                    partes.Add(Numero.Length > 0 ? $"{Endereco}, {Numero}" : Endereco);

                if (Bairro.Length > 0)
                    partes.Add(Bairro);

                return string.Join(" - ", partes);
            }
        }
    }
}