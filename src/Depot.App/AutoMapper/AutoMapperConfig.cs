using AutoMapper;
using Depot.App.ViewModels;
using Depot.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Depot.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Colaborador, ColaboradorViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Estoque, EstoqueViewModel>().ReverseMap();
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Grupo, GrupoViewModel>().ReverseMap();
            CreateMap<HistoricoProduto, HistoricoProdutoViewModel>().ReverseMap();
            CreateMap<Acao, AcaoViewModel>().ReverseMap();
            CreateMap<Perfil, PerfilViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }
    }
}
