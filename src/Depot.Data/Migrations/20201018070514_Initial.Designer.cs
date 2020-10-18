﻿// <auto-generated />
using System;
using Depot.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Depot.Data.Migrations
{
    [DbContext(typeof(DepotContext))]
    [Migration("20201018070514_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Depot.Business.Models.Colaborador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("PerfilId")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("PerfilId")
                        .IsUnique();

                    b.ToTable("Colaboradores");
                });

            modelBuilder.Entity("Depot.Business.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Cidade")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Estado")
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("EstoqueId")
                        .HasColumnType("int");

                    b.Property<int?>("FornecedorId")
                        .HasColumnType("int");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("EstoqueId")
                        .IsUnique();

                    b.HasIndex("FornecedorId")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Depot.Business.Models.Estoque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NomeEstoque")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Regiao")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.HasKey("Id");

                    b.ToTable("Estoques");
                });

            modelBuilder.Entity("Depot.Business.Models.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("Depot.Business.Models.GrupoProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Grupo")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Grupos");
                });

            modelBuilder.Entity("Depot.Business.Models.Historico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AutorizadorId")
                        .HasColumnType("int");

                    b.Property<int>("ColaboradorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataMovimento")
                        .HasColumnType("datetime");

                    b.Property<int>("DepositanteId")
                        .HasColumnType("int");

                    b.Property<int>("RetiranteId")
                        .HasColumnType("int");

                    b.Property<int>("TipoMovimento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ColaboradorId");

                    b.ToTable("Historicos");
                });

            modelBuilder.Entity("Depot.Business.Models.HistoricoProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("HistoricoId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HistoricoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("HistoricoProdutos");
                });

            modelBuilder.Entity("Depot.Business.Models.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NomePerfil")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Perfis");
                });

            modelBuilder.Entity("Depot.Business.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<ulong>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<int>("EstoqueId")
                        .HasColumnType("int");

                    b.Property<int>("FornecedorId")
                        .HasColumnType("int");

                    b.Property<int>("GrupoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("EstoqueId");

                    b.HasIndex("FornecedorId");

                    b.HasIndex("GrupoId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Depot.Business.Models.Colaborador", b =>
                {
                    b.HasOne("Depot.Business.Models.Perfil", "Perfil")
                        .WithOne("Colaborador")
                        .HasForeignKey("Depot.Business.Models.Colaborador", "PerfilId")
                        .IsRequired();
                });

            modelBuilder.Entity("Depot.Business.Models.Endereco", b =>
                {
                    b.HasOne("Depot.Business.Models.Estoque", "Estoque")
                        .WithOne("Endereco")
                        .HasForeignKey("Depot.Business.Models.Endereco", "EstoqueId");

                    b.HasOne("Depot.Business.Models.Fornecedor", "Fornecedor")
                        .WithOne("Endereco")
                        .HasForeignKey("Depot.Business.Models.Endereco", "FornecedorId");
                });

            modelBuilder.Entity("Depot.Business.Models.Historico", b =>
                {
                    b.HasOne("Depot.Business.Models.Colaborador", "Colaborador")
                        .WithMany("Historicos")
                        .HasForeignKey("ColaboradorId")
                        .IsRequired();
                });

            modelBuilder.Entity("Depot.Business.Models.HistoricoProduto", b =>
                {
                    b.HasOne("Depot.Business.Models.Historico", "Historico")
                        .WithMany("HistoricoProduto")
                        .HasForeignKey("HistoricoId")
                        .IsRequired();

                    b.HasOne("Depot.Business.Models.Produto", "Produto")
                        .WithMany("HistoricoProduto")
                        .HasForeignKey("ProdutoId")
                        .IsRequired();
                });

            modelBuilder.Entity("Depot.Business.Models.Produto", b =>
                {
                    b.HasOne("Depot.Business.Models.Estoque", "Estoque")
                        .WithMany("Produtos")
                        .HasForeignKey("EstoqueId")
                        .IsRequired();

                    b.HasOne("Depot.Business.Models.Fornecedor", "Fornecedor")
                        .WithMany("Produtos")
                        .HasForeignKey("FornecedorId")
                        .IsRequired();

                    b.HasOne("Depot.Business.Models.GrupoProduto", "GrupoProduto")
                        .WithMany("Produtos")
                        .HasForeignKey("GrupoId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}