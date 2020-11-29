using Depot.Business.Interfaces;
using Depot.Business.Interfaces.Services;
using Depot.Business.Models;
using Depot.Business.Models.Validations;
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

        public async Task<int> AutenticaUsuario(string email, string senha)
        {
         
            try
            {
                if(_colaboradorRepository.Buscar(c => c.Email != email && c.Senha != senha).Any())
                {
                    Notificar("Login não econtrado!");
                    
                }

                Colaborador AutenticaCol = new Colaborador();

                AutenticaCol = await _colaboradorRepository.AutenticarColaborador(email, senha);


                return AutenticaCol.Id;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            _colaboradorRepository?.Dispose();
        }

        public async Task Remover(int id)
        {
         await  _colaboradorRepository.Remover(id);
         
        }
    }
}
