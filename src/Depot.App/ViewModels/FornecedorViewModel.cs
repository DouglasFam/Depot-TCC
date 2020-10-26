using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Depot.App.ViewModels
{
    public class FornecedorViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(18, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string Documento { get; set; }

        public EnderecoViewModel Endereco { get; set; }

        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        /* EF Relations */
        [NotMapped]
        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}
