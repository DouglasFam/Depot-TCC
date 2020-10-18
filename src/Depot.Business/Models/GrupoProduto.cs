using System;
using System.Collections.Generic;
using System.Text;

namespace Depot.Business.Models
{
    public class GrupoProduto : Entity
    {
        public string Grupo { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }
    }
}
