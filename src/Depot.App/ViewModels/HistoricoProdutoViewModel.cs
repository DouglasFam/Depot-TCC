using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Depot.App.ViewModels
{
    public class HistoricoProdutoViewModel
    {
        [Key]
        public int Id { get; set; }

        [HiddenInput]
        public int ProdutoId { get; set; }

        public ProdutoViewModel Produto { get; set; }

        [HiddenInput]
        public int HistoricoId { get; set; }

        public HistoricoViewModel Historico { get; set; }
    }
}
