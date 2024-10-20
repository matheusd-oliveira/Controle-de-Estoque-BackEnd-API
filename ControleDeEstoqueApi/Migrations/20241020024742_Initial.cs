using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ControleDeEstoqueApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    nomedofuncionario = table.Column<string>(name: "nome_do_funcionario", type: "character varying(250)", maxLength: 250, nullable: false),
                    codigodofuncionario = table.Column<int>(name: "codigo_do_funcionario", type: "integer", nullable: false),
                    cargo = table.Column<int>(type: "integer", nullable: false),
                    salario = table.Column<decimal>(type: "numeric", nullable: false),
                    endereco = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    telefone = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    cpf = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    login = table.Column<string>(type: "text", nullable: false),
                    senha = table.Column<string>(type: "text", nullable: false),
                    datanascimento = table.Column<string>(name: "data_nascimento", type: "character varying(250)", maxLength: 250, nullable: false),
                    situacao = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionario", x => x.idfuncionario);
                    table.UniqueConstraint("AK_funcionario_codigo_do_funcionario", x => x.codigodofuncionario);
                });

            migrationBuilder.CreateTable(
                name: "pagamento",
                columns: table => new
                {
                    idpagamento = table.Column<int>(name: "id_pagamento", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomedopagamento = table.Column<string>(name: "nome_do_pagamento", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pagamento", x => x.idpagamento);
                });

            migrationBuilder.CreateTable(
                name: "fabricante",
                columns: table => new
                {
                    idfabricante = table.Column<int>(name: "id_fabricante", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codigodofabricante = table.Column<int>(name: "codigo_do_fabricante", type: "integer", nullable: false),
                    codigodofuncionario = table.Column<int>(name: "codigo_do_funcionario", type: "integer", nullable: false),
                    nomedofabricante = table.Column<string>(name: "nome_do_fabricante", type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fabricante", x => x.idfabricante);
                    table.UniqueConstraint("AK_fabricante_codigo_do_fabricante", x => x.codigodofabricante);
                    table.UniqueConstraint("AK_fabricante_nome_do_fabricante", x => x.nomedofabricante);
                    table.ForeignKey(
                        name: "FK_fabricante_funcionario_codigo_do_funcionario",
                        column: x => x.codigodofuncionario,
                        principalTable: "funcionario",
                        principalColumn: "codigo_do_funcionario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fornecedor",
                columns: table => new
                {
                    idfornecedor = table.Column<int>(name: "id_fornecedor", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codigodofornecedor = table.Column<int>(name: "codigo_do_fornecedor", type: "integer", nullable: false),
                    codigodofuncionario = table.Column<int>(name: "codigo_do_funcionario", type: "integer", nullable: false),
                    nomefantasiadofornecedor = table.Column<string>(name: "nome_fantasia_do_fornecedor", type: "text", nullable: false),
                    cnpj = table.Column<string>(type: "text", nullable: false),
                    endereco = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    site = table.Column<string>(type: "text", nullable: false),
                    telefone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    tempodeentrega = table.Column<string>(name: "tempo_de_entrega", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fornecedor", x => x.idfornecedor);
                    table.UniqueConstraint("AK_fornecedor_codigo_do_fornecedor", x => x.codigodofornecedor);
                    table.UniqueConstraint("AK_fornecedor_nome_fantasia_do_fornecedor", x => x.nomefantasiadofornecedor);
                    table.ForeignKey(
                        name: "FK_fornecedor_funcionario_codigo_do_funcionario",
                        column: x => x.codigodofuncionario,
                        principalTable: "funcionario",
                        principalColumn: "codigo_do_funcionario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "venda",
                columns: table => new
                {
                    idvenda = table.Column<int>(name: "id_venda", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codigodavenda = table.Column<int>(name: "codigo_da_venda", type: "integer", nullable: false),
                    codigodofuncionario = table.Column<int>(name: "codigo_do_funcionario", type: "integer", nullable: false),
                    valortotaldavenda = table.Column<double>(name: "valor_total_da_venda", type: "double precision", nullable: false),
                    datadavenda = table.Column<DateTime>(name: "data_da_venda", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_venda", x => x.idvenda);
                    table.UniqueConstraint("AK_venda_codigo_da_venda", x => x.codigodavenda);
                    table.ForeignKey(
                        name: "FK_venda_funcionario_codigo_do_funcionario",
                        column: x => x.codigodofuncionario,
                        principalTable: "funcionario",
                        principalColumn: "codigo_do_funcionario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    idproduto = table.Column<int>(name: "id_produto", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codigodoproduto = table.Column<int>(name: "codigo_do_produto", type: "integer", nullable: false),
                    codigodofabricante = table.Column<int>(name: "codigo_do_fabricante", type: "integer", nullable: false),
                    codigodofornecedor = table.Column<int>(name: "codigo_do_fornecedor", type: "integer", nullable: false),
                    nomedoproduto = table.Column<string>(name: "nome_do_produto", type: "character varying(250)", maxLength: 250, nullable: false),
                    valordecompra = table.Column<decimal>(name: "valor_de_compra", type: "numeric", nullable: false),
                    valordevenda = table.Column<decimal>(name: "valor_de_venda", type: "numeric", nullable: false),
                    descricaodoproduto = table.Column<string>(name: "descricao_do_produto", type: "character varying(250)", maxLength: 250, nullable: false),
                    quantidademinimaparacompra = table.Column<int>(name: "quantidade_minima_para_compra", type: "integer", nullable: false),
                    datadocadastrodoproduto = table.Column<DateTime>(name: "data_do_cadastro_do_produto", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.idproduto);
                    table.UniqueConstraint("AK_produto_codigo_do_produto", x => x.codigodoproduto);
                    table.ForeignKey(
                        name: "FK_produto_fabricante_codigo_do_fabricante",
                        column: x => x.codigodofabricante,
                        principalTable: "fabricante",
                        principalColumn: "codigo_do_fabricante",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_produto_fornecedor_codigo_do_fornecedor",
                        column: x => x.codigodofornecedor,
                        principalTable: "fornecedor",
                        principalColumn: "codigo_do_fornecedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendaPagamentos",
                columns: table => new
                {
                    idvenda = table.Column<int>(name: "id_venda", type: "integer", nullable: false),
                    idpagamento = table.Column<int>(name: "id_pagamento", type: "integer", nullable: false),
                    valordopagamento = table.Column<double>(name: "valor_do_pagamento", type: "double precision", nullable: false)
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
                    codigodofuncionario = table.Column<int>(name: "codigo_do_funcionario", type: "integer", nullable: false),
                    codigodoproduto = table.Column<int>(name: "codigo_do_produto", type: "integer", nullable: false),
                    nomedoproduto = table.Column<string>(name: "nome_do_produto", type: "character varying(250)", maxLength: 250, nullable: false),
                    nomefantasiadofornecedor = table.Column<string>(name: "nome_fantasia_do_fornecedor", type: "text", nullable: false),
                    nomedofabricante = table.Column<string>(name: "nome_do_fabricante", type: "character varying(255)", nullable: false),
                    quantidadedoproduto = table.Column<int>(name: "quantidade_do_produto", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estoque", x => x.idestoque);
                    table.ForeignKey(
                        name: "FK_estoque_fabricante_nome_do_fabricante",
                        column: x => x.nomedofabricante,
                        principalTable: "fabricante",
                        principalColumn: "nome_do_fabricante",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_estoque_fornecedor_nome_fantasia_do_fornecedor",
                        column: x => x.nomefantasiadofornecedor,
                        principalTable: "fornecedor",
                        principalColumn: "nome_fantasia_do_fornecedor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_estoque_funcionario_codigo_do_funcionario",
                        column: x => x.codigodofuncionario,
                        principalTable: "funcionario",
                        principalColumn: "codigo_do_funcionario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_estoque_produto_codigo_do_produto",
                        column: x => x.codigodoproduto,
                        principalTable: "produto",
                        principalColumn: "codigo_do_produto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "item_venda",
                columns: table => new
                {
                    iditemvenda = table.Column<int>(name: "id_item_venda", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codigodoproduto = table.Column<int>(name: "codigo_do_produto", type: "integer", nullable: false),
                    codigodavenda = table.Column<int>(name: "codigo_da_venda", type: "integer", nullable: false),
                    quantidadedoproduto = table.Column<int>(name: "quantidade_do_produto", type: "integer", nullable: false),
                    valorunitario = table.Column<decimal>(name: "valor_unitario", type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_venda", x => x.iditemvenda);
                    table.ForeignKey(
                        name: "FK_item_venda_produto_codigo_do_produto",
                        column: x => x.codigodoproduto,
                        principalTable: "produto",
                        principalColumn: "codigo_do_produto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_item_venda_venda_codigo_da_venda",
                        column: x => x.codigodavenda,
                        principalTable: "venda",
                        principalColumn: "codigo_da_venda",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VendaPagamentos_id_pagamento",
                table: "VendaPagamentos",
                column: "id_pagamento");

            migrationBuilder.CreateIndex(
                name: "IX_estoque_codigo_do_funcionario",
                table: "estoque",
                column: "codigo_do_funcionario");

            migrationBuilder.CreateIndex(
                name: "IX_estoque_codigo_do_produto",
                table: "estoque",
                column: "codigo_do_produto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_estoque_nome_do_fabricante",
                table: "estoque",
                column: "nome_do_fabricante");

            migrationBuilder.CreateIndex(
                name: "IX_estoque_nome_fantasia_do_fornecedor",
                table: "estoque",
                column: "nome_fantasia_do_fornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_fabricante_codigo_do_fabricante",
                table: "fabricante",
                column: "codigo_do_fabricante",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fabricante_codigo_do_funcionario",
                table: "fabricante",
                column: "codigo_do_funcionario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fabricante_nome_do_fabricante",
                table: "fabricante",
                column: "nome_do_fabricante",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fornecedor_cnpj",
                table: "fornecedor",
                column: "cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fornecedor_codigo_do_fornecedor",
                table: "fornecedor",
                column: "codigo_do_fornecedor",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fornecedor_codigo_do_funcionario",
                table: "fornecedor",
                column: "codigo_do_funcionario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fornecedor_nome_fantasia_do_fornecedor",
                table: "fornecedor",
                column: "nome_fantasia_do_fornecedor",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_funcionario_codigo_do_funcionario",
                table: "funcionario",
                column: "codigo_do_funcionario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_funcionario_cpf",
                table: "funcionario",
                column: "cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_item_venda_codigo_da_venda",
                table: "item_venda",
                column: "codigo_da_venda");

            migrationBuilder.CreateIndex(
                name: "IX_item_venda_codigo_do_produto",
                table: "item_venda",
                column: "codigo_do_produto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pagamento_nome_do_pagamento",
                table: "pagamento",
                column: "nome_do_pagamento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_produto_codigo_do_fabricante",
                table: "produto",
                column: "codigo_do_fabricante");

            migrationBuilder.CreateIndex(
                name: "IX_produto_codigo_do_fornecedor",
                table: "produto",
                column: "codigo_do_fornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_produto_codigo_do_produto",
                table: "produto",
                column: "codigo_do_produto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_venda_codigo_da_venda",
                table: "venda",
                column: "codigo_da_venda",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_venda_codigo_do_funcionario",
                table: "venda",
                column: "codigo_do_funcionario");
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
