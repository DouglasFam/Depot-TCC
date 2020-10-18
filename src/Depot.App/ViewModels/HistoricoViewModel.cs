using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Depot.App.ViewModels
{
    public class HistoricoViewModel
    {
       [Key]
        public int Id { get; set; }

        [DisplayName("Movimentação Produto")]
        public int TipoMovimento { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataMovimento { get; set; }

        [HiddenInput]
        public int ColaboradorId { get; set; }

        [HiddenInput]
        public int AutorizadorId { get; set; }

        [HiddenInput]
        public int RetiranteId { get; set; }

        [HiddenInput]
        public int DepositanteId { get; set; }


        /* EF Relations */
        public IEnumerable<HistoricoProdutoViewModel> HistoricoProduto { get; set; }

     [NotMapped]
        public IEnumerable<ColaboradorViewModel> Colaborador { get; set; }
    }
}
