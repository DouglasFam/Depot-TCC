﻿using Depot.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Depot.Business.Interfaces
{
  public interface IEstoqueRepository : IRepository<Estoque>
    {
        Task<IEnumerable<Estoque>> ObterEstoquePorRegiao(string pRegiao);

        Task<Estoque> ObterEstoqueProduto(int produtoId);

        Task<Estoque> ObterEstoquePorId(int estoqueId);

        Task<Estoque> ObterEstoqueEndereco(int estoqueId);


    }
}
