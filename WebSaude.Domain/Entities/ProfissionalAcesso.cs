using System;

namespace WebSaude.Domain.Entities
{
    public class ProfissionalAcesso
    {
        public int IdProfissional { get; set; }
        public string Senha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public bool Domingo { get; set; }
        public bool Segunda { get; set; }
        public bool Terca { get; set; }
        public bool Quarta { get; set; }
        public bool Quinta { get; set; }
        public bool Sexta { get; set; }
        public bool Sabado { get; set; }
        public DateTime Ultimo { get; set; }
        public int Ip { get; set; }
        public int QuantidadeMinuto { get; set; }
        public string Token { get; set; }
        public int IdPermissao { get; set; }

        public Permissao Permissao { get; set; }
    }
}
