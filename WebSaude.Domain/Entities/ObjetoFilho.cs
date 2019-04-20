namespace WebSaude.Domain.Entities
{
    public class ObjetoFilho
    {
        public int Id { get; set; }
        public int IdObjetoFilho { get; set; }
        public int IdObjetoPai { get; set; }

        public Objeto Objeto { get; set; }
    }
}
