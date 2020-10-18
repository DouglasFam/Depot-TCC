using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Depot.App.ViewModels
{
    public class GrupoProdutoViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Grupo { get; set; }

        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}
