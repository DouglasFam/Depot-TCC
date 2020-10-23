using Depot.Business.Interfaces;
using Depot.Business.Interfaces.Services;
using Depot.Business.Models;
using Depot.Business.Models.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depot.Business.Services
{
    public class ColaboradorService : BaseService, IColaboradorService
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorService(IColaboradorRepository colaboradorRepository,
                                   INotificador notificador) : base(notificador)
        {
            _colaboradorRepository = colaboradorRepository;
        }
        public async Task Adicionar(Colaborador colaborador)
        {
            if (!ExecutarValidacao(new ColaboradorValidation(), colaborador)) return;

            await _colaboradorRepository.Adicionar(colaborador);
        }

        public async Task Atualizar(Colaborador colaborador)
        {
            if (!ExecutarValidacao(new ColaboradorValidation(), colaborador)) return;

            await _colaboradorRepository.Atualizar(colaborador);
        }

        public async Task AutenticaUsuario(Colaborador colaborador)
        {
            try
            {
                if(_colaboradorRepository.Buscar(c => c.Login == colaborador.Login && c.Senha == colaborador.Senha).Result.Any())
                {
                
                }

               
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
