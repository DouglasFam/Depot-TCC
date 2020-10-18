using System;
using System.Collections.Generic;
using System.Text;

namespace Depot.Business.Models
{
   public class Historico : Entity
    {
        public TipoMovimento TipoMovimento { get; set; }

        public DateTime DataMovimento { get; set; }

        public int ColaboradorId { get; set; }

        public int AutorizadorId { get; set; }

        public int RetiranteId { get; set; }

        public int DepositanteId { get; set; }


        /* EF Relations */
        public IEnumerable<HistoricoProduto> HistoricoProduto { get; set; }

        public Colaborador Colaborador { get; set; }
    }
}
