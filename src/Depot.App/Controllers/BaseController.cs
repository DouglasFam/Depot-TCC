using Depot.Business.Interfaces;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Depot.App.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly INotificador _notificador;
        public BaseController(INotificador notificador)
        {
            _notificador = notificador;
        }
        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            //imprime o erro na camada de apresentação

        }
        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }
      
    }
}
