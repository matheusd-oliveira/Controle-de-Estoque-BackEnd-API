using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ControleDeEstoqueApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "funcionario",
                columns: table => new
                {
                    idfuncionario = table.Column<int>(name: "id_funcionario", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    codfunc = table.Column<int>(name: "cod_func", type: "integer", nullable: false),
                    cargo = table.Column<int>(type: "integer", nullable: false),
                    salario = table.Column<decimal>(type: "numeric", nullable: false),
                    endereco = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    telefone = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    cpf = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    login = table.Column<string>(type: "text", nullable: false),
                    senha = table.Column<string>(type: "text", nullable: false),
                    datanasc = table.Column<string>(name: "data_nasc", type: "character varying(250)", maxLength: 250, nullable: false),
                    situacao = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionario", x => x.idfuncionario);
                    table.UniqueConstraint("AK_funcionario_cod_func", x => x.codfunc);
                    table.UniqueConstraint("AK_funcionario_cpf", x => x.cpf);
                });

            migrationBuilder.CreateTable(
                name: "pagamento",
                columns: table => new
                {
                    idpagamento = table.Column<int>(name: "id_pagamento", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomepagmt = table.Column<string>(name: "nome_pagmt", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pagamento", x => x.idpagamento);
                    table.UniqueConstraint("AK_pagamento_nome_pagmt", x => x.nomepagmt);
                });

            migrationBuilder.CreateTable(
                name: "fabricante",
                columns: table => new
                {
                    idfabricante = table.Column<int>(name: "id_fabricante", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codfab = table.Column<int>(name: "cod_fab", type: "integer", nullable: false),
                    codfunc = table.Column<int>(name: "cod_func", type: "integer", nullable: false),
                    nomefab = table.Column<string>(name: "nome_fab", type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fabricante", x => x.idfabricante);
                    table.UniqueConstraint("AK_fabricante_cod_fab", x => x.codfab);
                    table.UniqueConstraint("AK_fabricante_nome_fab", x => x.nomefab);
                    table.ForeignKey(
                        name: "FK_fabricante_funcionario_cod_func",
                        column: x => x.codfunc,
                        principalTable: "funcionario",
                        principalColumn: "cod_func",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fornecedor",
                columns: table => new
                {
                    codfornc = table.Column<int>(name: "cod_fornc", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codfunc = table.Column<int>(name: "cod_func", type: "integer", nullable: false),
                    nomefant = table.Column<string>(name: "nome_fant", type: "text", nullable: false),
                    cnpj = table.Column<string>(type: "text", nullable: false),
                    endereco = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    site = table.Column<string>(type: "text", nullable: false),
                    telefone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    tempoentrega = table.Column<string>(name: "tempo_entrega", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fornecedor", x => x.codfornc);
                    table.UniqueConstraint("AK_fornecedor_nome_fant", x => x.nomefant);
                    table.UniqueConstraint("AK_fornecedor_cnpj", x => x.cnpj);
                    table.ForeignKey(
                        name: "FK_fornecedor_funcionario_cod_func",
                        column: x => x.codfunc,
                        principalTable: "funcionario",
                        principalColumn: "cod_func",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "venda",
                columns: table => new
                {
                    idvenda = table.Column<int>(name: "id_venda", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codvenda = table.Column<int>(name: "cod_venda", type: "integer", nullable: false),
                    codfunc = table.Column<int>(name: "cod_func", type: "integer", nullable: false),
                    valortotal = table.Column<double>(name: "valor_total", type: "double precision", nullable: false),
                    datavenda = table.Column<DateTime>(name: "data_venda", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_venda", x => x.idvenda);
                    table.UniqueConstraint("AK_venda_cod_venda", x => x.codvenda);
                    table.ForeignKey(
                        name: "FK_venda_funcionario_cod_func",
                        column: x => x.codfunc,
                        principalTable: "funcionario",
                        principalColumn: "cod_func",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    idproduto = table.Column<int>(name: "id_produto", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codprod = table.Column<int>(name: "cod_prod", type: "integer", nullable: false),
                    codfab = table.Column<int>(name: "cod_fab", type: "integer", nullable: false),
                    codfornc = table.Column<int>(name: "cod_fornc", type: "integer", nullable: false),
                    nomeprod = table.Column<string>(name: "nome_prod", type: "character varying(250)", maxLength: 250, nullable: false),
                    valorcompra = table.Column<decimal>(name: "valor_compra", type: "numeric", nullable: false),
                    valorvenda = table.Column<decimal>(name: "valor_venda", type: "numeric", nullable: false),
                    descricao = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    quantidademin = table.Column<int>(name: "quantidade_min", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.idproduto);
                    table.UniqueConstraint("AK_produto_cod_prod", x => x.codprod);
                    table.ForeignKey(
                        name: "FK_produto_fabricante_cod_fab",
                        column: x => x.codfab,
                        principalTable: "fabricante",
                        principalColumn: "cod_fab",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_produto_fornecedor_cod_fornc",
                        column: x => x.codfornc,
                        principalTable: "fornecedor",
                        principalColumn: "cod_fornc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendaPagamentos",
                columns: table => new
                {
                    idvenda = table.Column<int>(name: "id_venda", type: "integer", nullable: false),
                    idpagamento = table.Column<int>(name: "id_pagamento", type: "integer", nullable: false),
                    valorpagamento = table.Column<double>(name: "valor_pagamento", type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendaPagamentos", x => new { x.idvenda, x.idpagamento });
                    table.ForeignKey(
                        name: "FK_VendaPagamentos_pagamento_id_pagamento",
                        column: x => x.idpagamento,
                        principalTable: "pagamento",
                        principalColumn: "id_pagamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendaPagamentos_venda_id_venda",
                        column: x => x.idvenda,
                        principalTable: "venda",
                        principalColumn: "id_venda",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "estoque",
                columns: table => new
                {
                    idestoque = table.Column<int>(name: "id_estoque", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codfunc = table.Column<int>(name: "cod_func", type: "integer", nullable: false),
                    codprod = table.Column<int>(name: "cod_prod", type: "integer", nullable: false),
                    nomeprod = table.Column<string>(name: "nome_prod", type: "character varying(250)", maxLength: 250, nullable: false),
                    nomefant = table.Column<string>(name: "nome_fant", type: "text", nullable: false),
                    nomefab = table.Column<string>(name: "nome_fab", type: "character varying(255)", nullable: false),
                    quantidade = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estoque", x => x.idestoque);
                    table.ForeignKey(
                        name: "FK_estoque_fabricante_nome_fab",
                        column: x => x.nomefab,
                        principalTable: "fabricante",
                        principalColumn: "nome_fab",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_estoque_fornecedor_nome_fant",
                        column: x => x.nomefant,
                        principalTable: "fornecedor",
                        principalColumn: "nome_fant",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_estoque_funcionario_cod_func",
                        column: x => x.codfunc,
                        principalTable: "funcionario",
                        principalColumn: "cod_func",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_estoque_produto_cod_prod",
                        column: x => x.codprod,
                        principalTable: "produto",
                        principalColumn: "cod_prod",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "item_venda",
                columns: table => new
                {
                    iditemvenda = table.Column<int>(name: "id_item_venda", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codprod = table.Column<int>(name: "cod_prod", type: "integer", nullable: false),
                    codvenda = table.Column<int>(name: "cod_venda", type: "integer", nullable: false),
                    quantidade = table.Column<int>(type: "integer", nullable: false),
                    valorunitario = table.Column<decimal>(name: "valor_unitario", type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_venda", x => x.iditemvenda);
                    table.ForeignKey(
                        name: "FK_item_venda_produto_cod_prod",
                        column: x => x.codprod,
                        principalTable: "produto",
                        principalColumn: "cod_prod",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_item_venda_venda_cod_venda",
                        column: x => x.codvenda,
                        principalTable: "venda",
                        principalColumn: "cod_venda",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VendaPagamentos_id_pagamento",
                table: "VendaPagamentos",
                column: "id_pagamento");

            migrationBuilder.CreateIndex(
                name: "IX_estoque_cod_func",
                table: "estoque",
                column: "cod_func");

            migrationBuilder.CreateIndex(
                name: "IX_estoque_cod_prod",
                table: "estoque",
                column: "cod_prod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_estoque_nome_fab",
                table: "estoque",
                column: "nome_fab");

            migrationBuilder.CreateIndex(
                name: "IX_estoque_nome_fant",
                table: "estoque",
                column: "nome_fant");

            migrationBuilder.CreateIndex(
                name: "IX_fabricante_cod_fab",
                table: "fabricante",
                column: "cod_fab",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fabricante_cod_func",
                table: "fabricante",
                column: "cod_func",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fabricante_nome_fab",
                table: "fabricante",
                column: "nome_fab",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fornecedor_cnpj",
                table: "fornecedor",
                column: "cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fornecedor_cod_func",
                table: "fornecedor",
                column: "cod_func",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fornecedor_nome_fant",
                table: "fornecedor",
                column: "nome_fant",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_funcionario_cod_func",
                table: "funcionario",
                column: "cod_func",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_funcionario_cpf",
                table: "funcionario",
                column: "cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_item_venda_cod_prod",
                table: "item_venda",
                column: "cod_prod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_item_venda_cod_venda",
                table: "item_venda",
                column: "cod_venda");

            migrationBuilder.CreateIndex(
                name: "IX_pagamento_nome_pagmt",
                table: "pagamento",
                column: "nome_pagmt",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_produto_cod_fab",
                table: "produto",
                column: "cod_fab");

            migrationBuilder.CreateIndex(
                name: "IX_produto_cod_fornc",
                table: "produto",
                column: "cod_fornc");

            migrationBuilder.CreateIndex(
                name: "IX_produto_cod_prod",
                table: "produto",
                column: "cod_prod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_venda_cod_func",
                table: "venda",
                column: "cod_func");

            migrationBuilder.CreateIndex(
                name: "IX_venda_cod_venda",
                table: "venda",
                column: "cod_venda",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VendaPagamentos");

            migrationBuilder.DropTable(
                name: "estoque");

            migrationBuilder.DropTable(
                name: "item_venda");

            migrationBuilder.DropTable(
                name: "pagamento");

            migrationBuilder.DropTable(
                name: "produto");

            migrationBuilder.DropTable(
                name: "venda");

            migrationBuilder.DropTable(
                name: "fabricante");

            migrationBuilder.DropTable(
                name: "fornecedor");

            migrationBuilder.DropTable(
                name: "funcionario");
        }
    }
}
