using Depot.Business.Interfaces;
using Depot.Business.Interfaces.Services;
using Depot.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Depot.Business.Services
{
    public class ColaboradorService : BaseService, IColaboradorService
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorService(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }
        public Task Adicionar(Colaborador colaborador)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Colaborador colaborador)
        {
            throw new NotImplementedException();
        }

        public async Task AutenticaUsuario(Colaborador colaborador)
        {

            try
            {

                var Colaboradores = await _colaboradorRepository.ObterColaboradores();

               
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
