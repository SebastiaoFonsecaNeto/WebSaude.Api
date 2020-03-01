namespace WebSaude.Domain.Entities
{
    public class PermissaoItem
    {
        public int Id { get; set; }
        public int IdPermissao { get; set; }
        public int IdObjeto { get; set; }
        public bool Incluir { get; set; }
        public bool Excluir { get; set; }
        public bool Alterar { get; set; }

        public Objeto Objeto { get; set; }
    }
}
