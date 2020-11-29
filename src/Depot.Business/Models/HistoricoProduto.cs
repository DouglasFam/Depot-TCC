using System;

namespace Depot.Business.Models
{
    public class HistoricoProduto : Entity
    {
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

        #region Auditavel        
        public DateTime DataCriacao { get; set; }
        #endregion 

        #region  EF RELATIONS 
        public Acao Acao { get; set; }
        public Colaborador Colaborador { get; set; }
        public Produto Produto { get; set; }
        #endregion

        internal HistoricoProduto()
        {

        }

        public HistoricoProduto(Produto produto, int colaboradorId, int acaoId)
        {
            this.AcaoId = acaoId;
            this.ProdutoId = produto.Id;
            //TODO
            this.ColaboradorId = colaboradorId;
            this.EstoqueId = produto.EstoqueId;
            this.FornecedorId = produto.FornecedorId;
            this.GrupoId = produto.GrupoId;
            this.Nome = produto.Nome;
            this.Descricao = produto.Descricao;
            this.Quantidade = produto.Quantidade;
            this.Ativo = produto.Ativo;
            this.DataCriacao = DateTime.Now;
        }
    }
}
