using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Depot.App.ViewModels
{
    public class HistoricoProdutoViewModel
    {
        [Key]
        public int Id { get; set; }

        public int AcaoId { get; set; }
        public int ColaboradorId { get; set; }
        public int ProdutoId { get; set; }

        /*Event source */
        public int EstoqueId { get; set; }
        public int FornecedorId { get; set; }
        public int GrupoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }


        /* EF RELATIONS */
        [NotMapped]
        public AcaoViewModel Acao { get; set; }
        [NotMapped]
        public List<AcaoViewModel> Acoes { get; set; }
        [NotMapped]
        public ColaboradorViewModel Colaborador { get; set; }
        [NotMapped]
        public List<ColaboradorViewModel> Colaboradores { get; set; }
        [NotMapped]
        public ProdutoViewModel Produto { get; set; }
        [NotMapped]
        public List<ProdutoViewModel> Produtos { get; set; }

    }
}
