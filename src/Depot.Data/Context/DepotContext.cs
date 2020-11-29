using Depot.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Depot.Data.Context
{
    public class DepotContext : DbContext
    {
        public DepotContext(DbContextOptions options) : base(options) {   }

        public DbSet<Acao> Acoes { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<HistoricoProduto> HistoricoProdutos { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Produto> Produtos { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seta variavel varchar para não entrar como Max no banco
            foreach (var property in modelBuilder
                .Model
                .GetEntityTypes()
                .SelectMany(
                e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }

            //pega as entidades mapeadas no Db Context e registra
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DepotContext).Assembly);

            //Desabilita Cascade delete
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }



    }
}
