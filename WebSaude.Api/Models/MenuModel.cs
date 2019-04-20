using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSaude.Domain.Entities;

namespace WebSaude.Api.Models
{
    public class MenuModel
    {
        public string Title { get; set; }

        public string Icon { get; set; }

        public string Link { get; set; }

        public List<MenuModel> Children { get; set; }

        public static MenuModel Create(Objeto objeto)
        {
            return objeto == null ? null : new MenuModel
            {
                Title = string.IsNullOrWhiteSpace(objeto.Descricao) ? null : objeto.Descricao,
                Icon = string.IsNullOrWhiteSpace(objeto.Icone) ? null : objeto.Icone,
                Link = string.IsNullOrWhiteSpace(objeto.Url) ? null : objeto.Url,
                Children = objeto.Itens.Any() ? CreateList(objeto.Itens) : null
            };
        }

        public static MenuModel Create(ObjetoFilho objetoFilho)
        {
            return objetoFilho == null ? null : new MenuModel
            {
                Title = string.IsNullOrWhiteSpace(objetoFilho.Objeto?.Descricao) ? null : objetoFilho.Objeto?.Descricao,
                Link = string.IsNullOrWhiteSpace(objetoFilho.Objeto?.Url) ? null : objetoFilho.Objeto?.Url
            };
        }

        public static List<MenuModel> CreateList(List<ObjetoFilho> objetosFilhos)
        {
            return objetosFilhos.Select(Create).ToList();
        }

        public static List<MenuModel> CreateList(List<PermissaoItem> permissao)
        {
            return permissao.Where(p=> !string.IsNullOrWhiteSpace(p.Objeto.Icone)).OrderBy(p=>p.Id).Select(p => Create(p.Objeto)).ToList();
        }
    }
}
