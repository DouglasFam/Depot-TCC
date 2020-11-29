using System;
using System.Collections.Generic;
using System.Text;

namespace Depot.Business.Models
{
    public class Perfil : Entity
    {
        public string Nome { get; set; }

        public Colaborador Colaborador { get; set; }

    }
}
