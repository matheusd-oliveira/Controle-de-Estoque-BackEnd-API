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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          =>optionsBuilder.UseNpgsql(
         "Server=controle-estoque.cdmowgqow0s1.us-east-1.rds.amazonaws.com;" +
         "Port=5432; Database=postgres;" +
         "User Id=postgres;" +
         "Password=Senha123;");
    }
}
