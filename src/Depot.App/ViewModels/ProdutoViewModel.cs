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
    public class ProdutoViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        /*FK */

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Fornecedor")]
        public int FornecedorId { get; set; }



        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Estoque")]
        public int EstoqueId { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Grupo")]
        public int GrupoId { get; set; }

        /*EF Relations */
        public FornecedorViewModel Fornecedor { get; set; }

        public IEnumerable<FornecedorViewModel> Fornecedores { get; set; }

       [NotMapped]
        public EstoqueViewModel Estoque { get; set; }
    [NotMapped]
        public IEnumerable<EstoqueViewModel> Estoques { get; set; }
       [NotMapped]
        public GrupoProdutoViewModel GrupoProduto { get; set; }
       [NotMapped]
        public IEnumerable<GrupoProdutoViewModel> GrupoProdutos { get; set; }
        [NotMapped]
        public IEnumerable<HistoricoProdutoViewModel> HistoricoProduto { get; set; }
    }
}
