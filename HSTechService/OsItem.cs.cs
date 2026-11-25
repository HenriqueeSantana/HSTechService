namespace HSTechService
{
    public class OsItem
    {
        public int Id { get; set; }
        public int OsId { get; set; }
        public string Descricao { get; set; } = "";
        public int Quantidade { get; set; } = 1;

        public string Texto => $"{Quantidade}x  {Descricao}";

        public override string ToString()
        {
            return Texto;
        }
    }
}