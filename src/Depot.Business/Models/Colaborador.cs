using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Depot.Business.Models
{
    public class Colaborador : Entity
    {
        public string Nome { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public int PerfilId { get; set; }

        /*EF Relations */

        
        public Perfil Perfil { get; set; }

        public IEnumerable<Historico> Historicos { get; set; }
    }
}
