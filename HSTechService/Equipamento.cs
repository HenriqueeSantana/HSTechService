namespace HSTechService
{
    public class Equipamento
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
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
    }
}