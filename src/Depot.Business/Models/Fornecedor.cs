using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Depot.Business.Models
{
    public class Fornecedor : Entity
    {
        public int EnderecoId { get; set; }
        public string Nome { get; set; }

        public string CNPJ { get; set; }      

        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        /* EF Relations */
        public Endereco Endereco { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }

    }
}
