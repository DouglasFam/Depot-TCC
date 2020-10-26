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
            services.AddScoped<IGrupoProdutoRepository, GrupoProdutoRepository>();
            services.AddScoped<IHistoricoRepository, HistoricoRepository>();
            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            //Services
            services.AddScoped<IColaboradorService, ColaboradorService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IFornecedorService, FornecedorService>();
         

            //Config
            services.AddScoped<INotificador, Notificador>();
            return services;

        }
    }
}
