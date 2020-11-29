using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Depot.App.ViewModels
{
    public class AcaoViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }


        /*EF RELATIONS */
        [NotMapped]
        public HistoricoProdutoViewModel HistoricoProduto { get; set; }
        [NotMapped]
        public List<HistoricoProdutoViewModel> HistoricoProdutos { get; set; }
    }
}
