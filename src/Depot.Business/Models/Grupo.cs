using System;
using System.Collections.Generic;
using System.Text;

namespace Depot.Business.Models
{
    public class Grupo : Entity
    {
        public string Nome { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }
    }
}
