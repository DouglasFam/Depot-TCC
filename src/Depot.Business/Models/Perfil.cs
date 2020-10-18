using System;
using System.Collections.Generic;
using System.Text;

namespace Depot.Business.Models
{
    public class Perfil : Entity
    {
        public string NomePerfil { get; set; }

        //public IEnumerable<Colaborador> Colaboradores { get; set; }
        public Colaborador Colaborador { get; set; }

    }
}
