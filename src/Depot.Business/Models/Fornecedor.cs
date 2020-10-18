using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Depot.Business.Models
{
    public class Fornecedor : Entity
    {
        public string Nome { get; set; }

        public string Documento { get; set; }      

        public Endereco Endereco { get; set; }

        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        /* EF Relations */
        public IEnumerable<Produto> Produtos { get; set; }

    }
}
