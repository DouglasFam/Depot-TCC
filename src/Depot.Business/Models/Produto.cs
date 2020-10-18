using System;
using System.Collections.Generic;
using System.Text;

namespace Depot.Business.Models
{
    public class Produto : Entity
    {
        public int FornecedorId { get; set; }

        public int EstoqueId { get; set; }

        public int GrupoId { get; set; }

        public string Nome { get; set; }


        public string Descricao { get; set; }


        public DateTime DataCadastro { get; set; }


        public bool Ativo { get; set; }

        /*EF Relations */
        public Fornecedor Fornecedor { get; set; }

        public Estoque Estoque { get; set; }

        public GrupoProduto GrupoProduto { get; set; }

        public IEnumerable<HistoricoProduto> HistoricoProduto { get; set; }
    }
}
