using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Depot.Business.Models
{
    public class Colaborador : Entity
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public int PerfilId { get; set; }

        /*EF Relations */

        
        public Perfil Perfil { get; set; }

     //   public IEnumerable<Perfil> Perfis { get; set; }

        public IEnumerable<HistoricoProduto> HistoricoProdutos { get; set; }
    }
}
