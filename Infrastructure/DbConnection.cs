using ControleDeEstoqueApi.Domain.Models;
using ControleDeEstoqueApi.Domain.Models.Agents;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Intrinsics.X86;

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
            // HasOne(...)      = esta entidade aponta para um único registro
            // WithMany(...)    = o outro lado tem uma coleção
            // WithOne(...)     = o outro lado tem apenas um registro
            // HasForeignKey<T> = a FK está na entidade T

            #region Criação e configuração das FK's do Model Produto
            modelBuilder.Entity<Produto>()
                .HasOne(p => p.Fabricante)
                .WithMany(fab => fab.Produto)
                .HasForeignKey(p => p.FabricanteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Produto>()
                .HasOne(p => p.Estoque)
                .WithOne(e => e.Produto)
                .HasForeignKey<Estoque>(e => e.ProdutoId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region Criação e configuração das FK's do Model Item_Venda
            modelBuilder.Entity<Item_Venda>()
                .HasOne(i => i.Venda)
                .WithMany(v => v.Item_Venda)
                .HasForeignKey(i => i.VendaId)
                .OnDelete(DeleteBehavior.Cascade); // Se deletar a venda, os itens relacionados também serão deletados.

            modelBuilder.Entity<Item_Venda>()
                .HasOne(i => i.Produto)
                .WithMany(p => p.Item_Venda)
                .HasForeignKey(i => i.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Criação e configuração das FK's do Model Estoque 
            // Criando chave estrangeira e passando referência de tabela e coluna. Estoque --> Produto. 
            // Estoque | ProdutoId ---> Produto | Id
            //modelBuilder.Entity<Estoque>()
            //    .HasOne(e => e.Produto)
            //    .WithOne(p => p.Estoque)
            //    .HasForeignKey<Estoque>(e => e.ProdutoId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Estoque>()
            //    .HasIndex(e => e.ProdutoId)
            //    .IsUnique();
            #endregion

            #region Criação e configuração das FK's do Model Fornecedor
            modelBuilder.Entity<Fornecedor>()
                .HasOne(fornc => fornc.Funcionario)
                .WithOne(func => func.Fornecedor)
                .HasForeignKey<Fornecedor>(fornc => fornc.FuncionarioId);
            #endregion

            #region Criação e configuração das FK's do Model Fabricante
            modelBuilder.Entity<Fabricante>()
                .HasOne(fab => fab.Funcionario)
                .WithOne(func => func.Fabricante)
                .HasForeignKey<Fabricante>(fab => fab.FuncionarioId);
            #endregion

            #region Criação e configuração das FK's do Model Venda 
            modelBuilder.Entity<Venda>()
                .HasOne(v => v.Funcionario)
                .WithMany(func => func.Venda)
                .HasForeignKey(v => v.FuncionarioId);

            modelBuilder.Entity<Venda>()
                .HasMany(v => v.VendaPagamentos)
                .WithOne(vp => vp.Venda)
                .HasForeignKey(vp => vp.VendaId);
            #endregion

            #region Criação e configuração das FK's do Model VendaPagamento
            //modelBuilder.Entity<VendaPagamento>().HasKey(vp => new { vp.VendaId, vp.PagamentoId});

            modelBuilder.Entity<VendaPagamento>()
                .HasOne(vp => vp.Venda)
                .WithMany(v => v.VendaPagamentos)
                .HasForeignKey(vp => vp.VendaId);

            modelBuilder.Entity<VendaPagamento>()
                .HasOne(vp => vp.Pagamento)
                .WithMany(p => p.VendaPagamentos)
                .HasForeignKey(vp => vp.PagamentoId);
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
