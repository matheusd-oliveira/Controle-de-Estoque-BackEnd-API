using ControleDeEstoqueApi.Domain.Models;
using ControleDeEstoqueApi.Domain.Models.Agents;
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
        public DbSet<Fabricante> Fabricante { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<VendaPagamento> VendaPagamentos { get; set; } // Tabela de junção.

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

        // Configuração das tabelas.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Criação e configuração das FK's do Model Estoque 
            // Criando chave estrangeira e passando referência de tabela e coluna. Estoque --> Produto. 
            // Estoque | cod_prod ---> Produto | cod_prod
            modelBuilder.Entity<Estoque>()
                .HasOne(e => e.Produto)
                .WithOne(p => p.Estoque)
                .HasForeignKey<Estoque>(e => e.cod_prod)
                .HasPrincipalKey<Produto>(p => p.cod_prod);

            // Criando chave estrangeira e passando referência de tabela e coluna. Estoque --> Fabricante. 
            // Estoque | nome_fab ---> Fabricante | nome_fab
            modelBuilder.Entity<Estoque>()
                .HasOne(e => e.Fabricante)
                .WithMany(f => f.Estoque)
                .HasForeignKey(e => e.nome_fab)
                .HasPrincipalKey(f => f.nome_fab);

            // Criando chave estrangeira e passando referência de tabela e coluna. Estoque --> Fornecedor. 
            // Estoque | nome_fant ---> Fornecedor | nome_fant
            modelBuilder.Entity<Estoque>()
                .HasOne(e => e.Fornecedor)
                .WithMany(f => f.Estoque)
                .HasForeignKey(e => e.nome_fant)
                .HasPrincipalKey(f => f.nome_fant);

            // Criando chave estrangeira e passando referência de tabela e coluna. Estoque --> Funcionario. 
            // Estoque | cod_func ---> Funcionario | cod_func
            modelBuilder.Entity<Estoque>()
                .HasOne(e => e.Funcionario)
                .WithMany(f => f.Estoque)
                .HasForeignKey(e => e.cod_func)
                .HasPrincipalKey(f => f.cod_func);
            #endregion

            #region Criação e configuração das FK's do Model Fornecedor
            modelBuilder.Entity<Fornecedor>()
                .HasOne(fornc => fornc.Funcionario)
                .WithOne(func => func.Fornecedor)
                .HasForeignKey<Fornecedor>(fornc => fornc.cod_func)
                .HasPrincipalKey<Funcionario>(func => func.cod_func);
            #endregion

            #region Criação e configuração das FK's do Model Fabricante
            modelBuilder.Entity<Fabricante>()
                .HasOne(fab => fab.Funcionario)
                .WithOne(func => func.Fabricante)
                .HasForeignKey<Fabricante>(fab => fab.cod_func)
                .HasPrincipalKey<Funcionario>(func => func.cod_func);
            #endregion

            #region Criação e configuração das FK's do Model Item Venda
            modelBuilder.Entity<Item_Venda>()
                .HasOne(item => item.Produto)
                .WithOne(p => p.Item_Venda)
                .HasForeignKey<Item_Venda>(item => item.cod_prod)
                .HasPrincipalKey<Produto>(p => p.cod_prod);

            modelBuilder.Entity<Item_Venda>()
               .HasOne(item => item.Venda)
               .WithMany(v => v.Item_Venda)
               .HasForeignKey(item => item.cod_venda)
               .HasPrincipalKey(v => v.cod_venda);
            #endregion

            #region Criação e configuração das FK's do Model Produto
            modelBuilder.Entity<Produto>()
                .HasOne(p => p.Fabricante)
                .WithMany(fab => fab.Produto)
                .HasForeignKey(p => p.cod_fab)
                .HasPrincipalKey(fab => fab.cod_fab);

            modelBuilder.Entity<Produto>()
                .HasOne(p => p.Fornecedor)
                .WithMany(fornc => fornc.Produto)
                .HasForeignKey(p => p.cod_fornc)
                .HasPrincipalKey(fornc => fornc.cod_fornc);

            #endregion

            #region Criação e configuração das FK's do Model Venda 
            modelBuilder.Entity<Venda>()
                .HasOne(v => v.Funcionario)
                .WithMany(func => func.Venda)
                .HasForeignKey(v => v.cod_func)
                .HasPrincipalKey(func => func.cod_func);

            modelBuilder.Entity<Venda>()
                .HasMany(v => v.VendaPagamentos)
                .WithOne(vp => vp.Venda)
                .HasForeignKey(vp => vp.id_venda);
            #endregion

            #region Criação e configuração das FK's do Model Pagamento
            modelBuilder.Entity<Pagamento>(entity =>
            {
                // Configuração para a propriedade de navegação
                entity.HasMany(p => p.VendaPagamentos)
                      .WithOne(vp => vp.Pagamento)
                      .HasForeignKey(vp => vp.id_pagamento); // Novamente, opcional, mas útil para clareza
            });
            #endregion
           
            #region Criação e configuração das FK's do Model VendaPagamento
            modelBuilder.Entity<VendaPagamento>().HasKey(vp => new { vp.id_venda, vp.id_pagamento });

            modelBuilder.Entity<VendaPagamento>()
                .HasOne<Venda>(vp => vp.Venda)
                .WithMany(v => v.VendaPagamentos)
                .HasForeignKey(vp => vp.id_venda);

            modelBuilder.Entity<VendaPagamento>()
                .HasOne<Pagamento>(vp => vp.Pagamento)
                .WithMany(v => v.VendaPagamentos)
                .HasForeignKey(vp => vp.id_pagamento);
            #endregion
        
        }
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
