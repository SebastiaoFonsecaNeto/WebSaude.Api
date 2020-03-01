﻿namespace WebSaude.Domain.Entities
{
    public class Unidade
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
    }
}
