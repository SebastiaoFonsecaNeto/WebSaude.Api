using System.Collections.Generic;

namespace WebSaude.Domain.Entities
{
    public class Permissao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public List<PermissaoItem> Itens { get; set; }
    }
}
