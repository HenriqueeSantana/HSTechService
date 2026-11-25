namespace HSTechService
{
    public class Loja
    {
        public const string NomePadrao = "HSTechService";
        public const string SubtituloPadrao = "Assistência Técnica em Informática";

        public string Nome { get; set; } = NomePadrao;
        public string Subtitulo { get; set; } = SubtituloPadrao;
        public string Cnpj { get; set; } = "";
        public string Telefone { get; set; } = "";
        public string WhatsApp { get; set; } = "";
        public string Email { get; set; } = "";
        public string Endereco { get; set; } = "";
        public string LogoBase64 { get; set; } = "";
    }
}