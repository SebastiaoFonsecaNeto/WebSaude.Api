namespace WebSaude.Domain.Entities
{
    public class ProfissionalUnidade
    {
        public int Id { get; set; }
        public int IdProfissional { get; set; }
        public int IdUnidade { get; set; }  
        
        public Unidade Unidade { get; set; }
    }
}
