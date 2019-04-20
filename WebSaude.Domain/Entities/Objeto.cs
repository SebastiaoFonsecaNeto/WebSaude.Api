using System.Collections.Generic;

namespace WebSaude.Domain.Entities
{
    public class Objeto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Url { get; set; }
        public string Icone { get; set; }

        public List<ObjetoFilho> Itens { get; set; }
    }
}
