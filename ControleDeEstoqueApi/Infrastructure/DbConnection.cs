using ControleDeEstoqueApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace ControleDeEstoqueApi.Infrastructure
{
    public class DbConnection : DbContext
    {
        public DbSet<Pagamento> Pagamento { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<Item_Venda> Item_Venda { get; set; }

        /// <summary>
        /// Configuração POSTGRES AMAZON AWS
        /// </summary>
        /// <param name="optionsBuilder"></param>
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //  => optionsBuilder.UseNpgsql(
        // "Server=controle-estoque.cdmowgqow0s1.us-east-1.rds.amazonaws.com;" +
        // "Port=5432; Database=postgres;" +
        // "User Id=postgres;" +
        // "Password=Senha123;");

        // Conexão realizada para o Postgres LOCAL
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Server=localhost; User Id=postgres; Password=1234; Port=5432; Database=BancoTeste;");

        /// <summary>
        /// Configuração SQLITE
        /// </summary>
        /// <param name="optionsBuilder"></param>
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=BancoTeste.sqlite");

        //}
    }
}
