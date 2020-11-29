using System;
using System.Collections.Generic;
using System.Text;

namespace Depot.Business.Models
{
    public class Estoque : Entity
    {
        public int EnderecoId { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        /* EF RELATIONS */
        public Endereco Endereco { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
