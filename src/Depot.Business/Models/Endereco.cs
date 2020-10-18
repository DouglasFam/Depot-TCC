using System;
using System.Collections.Generic;
using System.Text;

namespace Depot.Business.Models
{
    public class Endereco : Entity
    {
        public int? FornecedorId { get; set; }

        public int? EstoqueId { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Cep { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        /*EF Relation */

        public Fornecedor Fornecedor { get; set; }

        public Estoque Estoque { get; set; }
    }
}
