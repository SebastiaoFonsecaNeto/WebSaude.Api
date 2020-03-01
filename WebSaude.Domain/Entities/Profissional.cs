using System.Collections.Generic;

namespace WebSaude.Domain.Entities
{
    public class Profissional
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int? IdCbo { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public int? IdCelularOperadora { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public bool? Ativo { get; set; }
        public string Observacao { get; set; }
        public string Foto { get; set; }

        public ProfissionalAcesso Acesso { get; set; }
        public List<ProfissionalUnidade> Unidades { get; set; }
    }
}
