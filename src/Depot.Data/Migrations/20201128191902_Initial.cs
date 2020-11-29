using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Depot.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "acoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_acoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Logradouro = table.Column<string>(type: "varchar(200)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(50)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(100)", nullable: true),
                    Cep = table.Column<string>(type: "varchar(8)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "grupos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "perfis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "estoques",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EnderecoId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estoques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_estoques_enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "fornecedores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EnderecoId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    CNPJ = table.Column<string>(type: "varchar(14)", nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fornecedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_fornecedores_enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "colaboradores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(100)", nullable: false),
                    PerfilId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colaboradores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_colaboradores_perfis_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "perfis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "produtos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EstoqueId = table.Column<int>(nullable: false),
                    GrupoId = table.Column<int>(nullable: false),
                    FornecedorId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    Ativo = table.Column<ulong>(type: "bit", nullable: false),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_produtos_estoques_EstoqueId",
                        column: x => x.EstoqueId,
                        principalTable: "estoques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_produtos_fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "fornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_produtos_grupos_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "historicoprodutos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AcaoId = table.Column<int>(nullable: false),
                    ColaboradorId = table.Column<int>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: false),
                    EstoqueId = table.Column<int>(type: "Int", nullable: false),
                    FornecedorId = table.Column<int>(type: "Int", nullable: false),
                    GrupoId = table.Column<int>(type: "Int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Quantidade = table.Column<int>(type: "Int", nullable: false),
                    Ativo = table.Column<ulong>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historicoprodutos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_historicoprodutos_acoes_AcaoId",
                        column: x => x.AcaoId,
                        principalTable: "acoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_historicoprodutos_colaboradores_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_historicoprodutos_produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_colaboradores_PerfilId",
                table: "colaboradores",
                column: "PerfilId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_estoques_EnderecoId",
                table: "estoques",
                column: "EnderecoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fornecedores_EnderecoId",
                table: "fornecedores",
                column: "EnderecoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_historicoprodutos_AcaoId",
                table: "historicoprodutos",
                column: "AcaoId");

            migrationBuilder.CreateIndex(
                name: "IX_historicoprodutos_ColaboradorId",
                table: "historicoprodutos",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_historicoprodutos_ProdutoId",
                table: "historicoprodutos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_produtos_EstoqueId",
                table: "produtos",
                column: "EstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_produtos_FornecedorId",
                table: "produtos",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_produtos_GrupoId",
                table: "produtos",
                column: "GrupoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "historicoprodutos");

            migrationBuilder.DropTable(
                name: "acoes");

            migrationBuilder.DropTable(
                name: "colaboradores");

            migrationBuilder.DropTable(
                name: "produtos");

            migrationBuilder.DropTable(
                name: "perfis");

            migrationBuilder.DropTable(
                name: "estoques");

            migrationBuilder.DropTable(
                name: "fornecedores");

            migrationBuilder.DropTable(
                name: "grupos");

            migrationBuilder.DropTable(
                name: "enderecos");
        }
    }
}
