using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSaude.Domain.Entities;

namespace WebSaude.Api.Models
{
    public class LoginModel
    {
        public int Id { get; set; }

        public string Token { get; set; }

        public static LoginModel Create(Profissional profissional)
        {
            return profissional == null ? null : new LoginModel
            {
                Id = profissional.Id,
                Token = profissional.Acesso?.Token
            };
        }
    }
}
