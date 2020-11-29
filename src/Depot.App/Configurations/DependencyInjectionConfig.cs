using Depot.Business.Interfaces;
using Depot.Business.Interfaces.Services;
using Depot.Business.Notifications;
using Depot.Business.Services;
using Depot.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Depot.App.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services) 
        {
            //Repository
            services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IEstoqueRepository, EstoqueRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IGrupoRepository, GrupoRepository>();
            services.AddScoped<IHistoricoProdutoRepository, HistoricoProdutoRepository>();
            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IAcaoRepository, AcaoRepository>();

            //Services
            services.AddScoped<IColaboradorService, ColaboradorService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped <IEstoqueService, EstoqueService>();
         

            //Config
            services.AddScoped<INotificador, Notificador>();
            return services;

        }
    }
}
