using System;
using System.Collections.Generic;
using System.Text;

namespace Depot.Business.Models
{
    public class Acao : Entity
    {
        public string Nome { get; set; }


        /*EF RELATIONS */
        public IEnumerable<HistoricoProduto> HistoricoProdutos { get; set; }
    }
}
