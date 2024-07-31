using Microsoft.EntityFrameworkCore.Migrations;

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
                name: "estoque",
                columns: table => new
                {
                    idestoque = table.Column<int>(name: "id_estoque", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    codfunc = table.Column<int>(name: "cod_func", type: "INTEGER", nullable: false),
                    codprod = table.Column<int>(name: "cod_prod", type: "INTEGER", nullable: false),
                    nomeprod = table.Column<string>(name: "nome_prod", type: "TEXT", maxLength: 250, nullable: false),
                    nomefant = table.Column<string>(name: "nome_fant", type: "TEXT", nullable: false),
                    nomefab = table.Column<string>(name: "nome_fab", type: "TEXT", nullable: false),
                    quantidade = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estoque", x => x.idestoque);
                });

            migrationBuilder.CreateTable(
                name: "item_venda",
                columns: table => new
                {
                    iditemvenda = table.Column<int>(name: "id_item_venda", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    codigoitemvenda = table.Column<int>(name: "codigo_item_venda", type: "INTEGER", nullable: false),
                    codprod = table.Column<int>(name: "cod_prod", type: "INTEGER", nullable: false),
                    codfunc = table.Column<int>(name: "cod_func", type: "INTEGER", nullable: false),
                    codvenda = table.Column<int>(name: "cod_venda", type: "INTEGER", nullable: false),
                    quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    valorunitario = table.Column<decimal>(name: "valor_unitario", type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_venda", x => x.iditemvenda);
                });

            migrationBuilder.CreateTable(
                name: "pagamento",
                columns: table => new
                {
                    idpagamento = table.Column<int>(name: "id_pagamento", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nomepagmt = table.Column<string>(name: "nome_pagmt", type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pagamento", x => x.idpagamento);
                });

            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    idproduto = table.Column<int>(name: "id_produto", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    codprod = table.Column<int>(name: "cod_prod", type: "INTEGER", nullable: false),
                    codfab = table.Column<int>(name: "cod_fab", type: "INTEGER", nullable: false),
                    codfornc = table.Column<int>(name: "cod_fornc", type: "INTEGER", nullable: false),
                    nomeprod = table.Column<string>(name: "nome_prod", type: "TEXT", maxLength: 250, nullable: false),
                    valorcompra = table.Column<decimal>(name: "valor_compra", type: "TEXT", nullable: false),
                    valorvenda = table.Column<decimal>(name: "valor_venda", type: "TEXT", nullable: false),
                    descricao = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    quantidademin = table.Column<int>(name: "quantidade_min", type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.idproduto);
                });

            migrationBuilder.CreateIndex(
                name: "IX_item_venda_codigo_item_venda",
                table: "item_venda",
                column: "codigo_item_venda",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pagamento_nome_pagmt",
                table: "pagamento",
                column: "nome_pagmt",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_produto_cod_prod",
                table: "produto",
                column: "cod_prod",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "estoque");

            migrationBuilder.DropTable(
                name: "item_venda");

            migrationBuilder.DropTable(
                name: "pagamento");

            migrationBuilder.DropTable(
                name: "produto");
        }
    }
}
