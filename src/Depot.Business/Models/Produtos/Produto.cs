using System;
using System.Collections.Generic;
using System.Text;

namespace Depot.Business.Models
{
    public class Produto : Entity
    {
        public int EstoqueId { get; set; }
        public int GrupoId { get; set; }
        public int FornecedorId { get; set; }    
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public int Quantidade { get; set; }


        /*EF Relations */
        public Estoque Estoque { get; set; }
        public Grupo Grupo { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public IList<HistoricoProduto> HistoricoProduto { get; set; }
    }
}
