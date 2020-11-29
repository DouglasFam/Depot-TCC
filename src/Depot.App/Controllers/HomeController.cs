using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Depot.App.ViewModels;
using Microsoft.AspNetCore.Http;
using Depot.Business.Interfaces;
using AutoMapper;
using Depot.Business.Interfaces.Services;
using Newtonsoft.Json;
using Depot.Business.Models;
using System;

namespace Depot.App.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IColaboradorService _colaboradorService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger,
                               IColaboradorRepository colaboradorRepository,
                               IColaboradorService colaboradorService,
                                IMapper mapper,
                                INotificador notificador) : base(notificador)
        {
            _logger = logger;
            _colaboradorRepository = colaboradorRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            //var verificaPerfil = JsonConvert.DeserializeObject<Colaborador>(HttpContext.Session.GetString("SessionColaborador"));
            //var colaboradorViewModel = await _colaboradorRepository.ObterPorId(verificaPerfil.Id);


            return View();
        }

        public async Task<IActionResult> Login(string email, string password)
        {
           if (email != null || password != null)
            {
              
               
               var  autenticaColaborador =  await _colaboradorRepository.AutenticarColaborador(email, password);

                if (autenticaColaborador == null) throw new Exception("Login inválido!");

                Colaborador ConsultaCol = new Colaborador();

                ConsultaCol.Id = autenticaColaborador.Id;
                ConsultaCol.Email = email;
                ConsultaCol.Senha = password;
                ConsultaCol.Nome = autenticaColaborador.Nome;
                ConsultaCol.PerfilId = autenticaColaborador.PerfilId;


                

                HttpContext.Session.SetString("SessionColaborador", JsonConvert.SerializeObject(ConsultaCol));

                return RedirectToAction("Index", "Home", new { area = "" });

            }
       

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Errors(int id)
        {
            var modelErro = new ErrorViewModel();

            if (id == 500)
            {
                modelErro.Mensagem = "Ocorreu um erro! Tente novamente mais tarde ou contate nosso suporte.";
                modelErro.Titulo = "Ocorreu um erro!";
                modelErro.ErroCode = id;
            }
            else if(id == 400)
            {
                modelErro.Mensagem = "A Página que está procurando não existe! <br />Em caso de dúvidas entre em contato com nosso suporte";
                modelErro.Titulo = "Ops! Página não encontrada.";
                modelErro.ErroCode = id;
            } else if(id == 403)
            {
                modelErro.Mensagem = "Você não tem permissão para fazer isto.";
                modelErro.Titulo = "Acesso Negado";
                modelErro.ErroCode = id;
            }
            else
            {
                return StatusCode(500);
            }

            return View("Error", modelErro);
        }
    }
}
