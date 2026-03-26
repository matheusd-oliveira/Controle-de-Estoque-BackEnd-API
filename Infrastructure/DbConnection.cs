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
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<VendaPagamento> VendaPagamentos { get; set; } // Tabela de junção.

        // Conexão realizada para o Postgres LOCAL
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Server=localhost; User Id=postgres; Password=1234; Port=5432; Database=BancoTeste;");

        // Configuração das tabelas.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Criação e configuração das FK's do Model Produto
            modelBuilder.Entity<Produto>()
                .HasOne(p => p.Fabricante)
                .WithMany(forn => forn.Produto)
                .HasForeignKey(p => p.FabricanteId);         
            #endregion

            #region Criação e configuração das FK's do Model Estoque 
            // Criando chave estrangeira e passando referência de tabela e coluna. Estoque --> Produto. 
            // Estoque | ProdutoId ---> Produto | Id
            modelBuilder.Entity<Estoque>()
                .HasOne(e => e.Produto)
                .WithOne(p => p.Estoque)
                .HasForeignKey<Estoque>(e => e.ProdutoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Estoque>()
                .HasIndex(e => e.ProdutoId)
                .IsUnique();
            #endregion

            #region Criação e configuração das FK's do Model Fornecedor
            modelBuilder.Entity<Fornecedor>()
                .HasOne(fornc => fornc.Funcionario)
                .WithOne(func => func.Fornecedor)
                .HasForeignKey<Fornecedor>(fornc => fornc.codigo_do_funcionario)
                .HasPrincipalKey<Funcionario>(func => func.codigo_do_funcionario);
            #endregion

            #region Criação e configuração das FK's do Model Fabricante
            modelBuilder.Entity<Fabricante>()
                .HasOne(fab => fab.Funcionario)
                .WithOne(func => func.Fabricante)
                .HasForeignKey<Fabricante>(fab => fab.codigo_do_funcionario)
                .HasPrincipalKey<Funcionario>(func => func.codigo_do_funcionario);
            #endregion

            #region Criação e configuração das FK's do Model Venda 
            modelBuilder.Entity<Venda>()
                .HasOne(v => v.Funcionario)
                .WithMany(func => func.Venda)
                .HasForeignKey(v => v.codigo_do_funcionario)
                .HasPrincipalKey(func => func.codigo_do_funcionario);

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
