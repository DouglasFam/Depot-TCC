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
    public class EstoqueViewModel
    {
        [Key]
        public int Id { get; set; }    

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
 
        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        /* EF RELATIONS */

        public EnderecoViewModel Endereco { get; set; }

        [HiddenInput]
        public int EnderecoId { get; set; }

        [NotMapped]
        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}
