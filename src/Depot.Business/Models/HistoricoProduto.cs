using System;
using System.Collections.Generic;
using System.Text;

namespace Depot.Business.Models
{
    public class HistoricoProduto : Entity
    {
        public int ProdutoId { get; set; }

        public Produto Produto { get; set; }

        public int HistoricoId { get; set; }

        public Historico Historico { get; set; }
    }
}
