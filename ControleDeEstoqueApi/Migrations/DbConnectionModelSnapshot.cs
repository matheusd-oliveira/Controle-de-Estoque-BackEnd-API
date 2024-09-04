﻿// <auto-generated />
using System;
using ControleDeEstoqueApi.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ControleDeEstoqueApi.Migrations
{
    [DbContext(typeof(DbConnection))]
    partial class DbConnectionModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ControleDeEstoqueApi.Domain.Models.Agents.Funcionario", b =>
                {
                    b.Property<int>("id_funcionario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id_funcionario"));

                    b.Property<int>("cargo")
                        .HasColumnType("integer");

                    b.Property<int>("cod_func")
                        .HasColumnType("integer");

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("data_nasc")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("endereco")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<decimal>("salario")
                        .HasColumnType("numeric");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("situacao")
                        .HasColumnType("boolean");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("id_funcionario");

                    b.HasIndex("cod_func")
                        .IsUnique();

                    b.HasIndex("cpf")
                        .IsUnique();

                    b.ToTable("funcionario");
                });

            modelBuilder.Entity("ControleDeEstoqueApi.Domain.Models.Estoque", b =>
                {
                    b.Property<int>("id_estoque")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id_estoque"));

                    b.Property<int>("cod_func")
                        .HasColumnType("integer");

                    b.Property<int>("cod_prod")
                        .HasColumnType("integer");

                    b.Property<string>("nome_fab")
                        .IsRequired()
                        .HasColumnType("character varying(255)");

                    b.Property<string>("nome_fant")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("nome_prod")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<int>("quantidade")
                        .HasColumnType("integer");

                    b.HasKey("id_estoque");

                    b.HasIndex("cod_func");

                    b.HasIndex("cod_prod")
                        .IsUnique();

                    b.HasIndex("nome_fab");

                    b.HasIndex("nome_fant");

                    b.ToTable("estoque");
                });

            modelBuilder.Entity("ControleDeEstoqueApi.Domain.Models.Fabricante", b =>
                {
                    b.Property<int>("id_fabricante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id_fabricante"));

                    b.Property<int>("cod_fab")
                        .HasColumnType("integer");

                    b.Property<int>("cod_func")
                        .HasColumnType("integer");

                    b.Property<string>("nome_fab")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("id_fabricante");

                    b.HasIndex("cod_fab")
                        .IsUnique();

                    b.HasIndex("cod_func")
                        .IsUnique();

                    b.HasIndex("nome_fab")
                        .IsUnique();

                    b.ToTable("fabricante");
                });

            modelBuilder.Entity("ControleDeEstoqueApi.Domain.Models.Fornecedor", b =>
                {
                    b.Property<int>("cod_fornc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("cod_fornc"));

                    b.Property<string>("cnpj")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("cod_func")
                        .HasColumnType("integer");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("endereco")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("nome_fant")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("site")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("tempo_entrega")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("cod_fornc");

                    b.HasIndex("cnpj")
                        .IsUnique();

                    b.HasIndex("cod_func")
                        .IsUnique();

                    b.HasIndex("nome_fant")
                        .IsUnique();

                    b.ToTable("fornecedor");
                });

            modelBuilder.Entity("ControleDeEstoqueApi.Domain.Models.Item_Venda", b =>
                {
                    b.Property<int>("id_item_venda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id_item_venda"));

                    b.Property<int>("cod_prod")
                        .HasColumnType("integer");

                    b.Property<int>("cod_venda")
                        .HasColumnType("integer");

                    b.Property<int>("quantidade")
                        .HasColumnType("integer");

                    b.Property<decimal>("valor_unitario")
                        .HasColumnType("numeric");

                    b.HasKey("id_item_venda");

                    b.HasIndex("cod_prod")
                        .IsUnique();

                    b.HasIndex("cod_venda");

                    b.ToTable("item_venda");
                });

            modelBuilder.Entity("ControleDeEstoqueApi.Domain.Models.Pagamento", b =>
                {
                    b.Property<int>("id_pagamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id_pagamento"));

                    b.Property<string>("nome_pagmt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id_pagamento");

                    b.HasIndex("nome_pagmt")
                        .IsUnique();

                    b.ToTable("pagamento");
                });

            modelBuilder.Entity("ControleDeEstoqueApi.Domain.Models.Produto", b =>
                {
                    b.Property<int>("id_produto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id_produto"));

                    b.Property<int>("cod_fab")
                        .HasColumnType("integer");

                    b.Property<int>("cod_fornc")
                        .HasColumnType("integer");

                    b.Property<int>("cod_prod")
                        .HasColumnType("integer");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("nome_prod")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<int>("quantidade_min")
                        .HasColumnType("integer");

                    b.Property<decimal>("valor_compra")
                        .HasColumnType("numeric");

                    b.Property<decimal>("valor_venda")
                        .HasColumnType("numeric");

                    b.HasKey("id_produto");

                    b.HasIndex("cod_fab");

                    b.HasIndex("cod_fornc");

                    b.HasIndex("cod_prod")
                        .IsUnique();

                    b.ToTable("produto");
                });

            modelBuilder.Entity("ControleDeEstoqueApi.Domain.Models.Venda", b =>
                {
                    b.Property<int>("id_venda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id_venda"));

                    b.Property<int>("cod_func")
                        .HasColumnType("integer");

                    b.Property<int>("cod_venda")
                        .HasColumnType("integer");

                    b.Property<DateTime>("data_venda")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("valor_total")
                        .HasColumnType("double precision");

                    b.HasKey("id_venda");

                    b.HasIndex("cod_func");

                    b.HasIndex("cod_venda")
                        .IsUnique();

                    b.ToTable("venda");
                });

            modelBuilder.Entity("ControleDeEstoqueApi.Domain.Models.VendaPagamento", b =>
                {
                    b.Property<int>("id_venda")
                        .HasColumnType("integer");

                    b.Property<int>("id_pagamento")
                        .HasColumnType("integer");

                    b.Property<double>("valor_pagamento")
                        .HasColumnType("double precision");

                    b.HasKey("id_venda", "id_pagamento");

                    b.HasIndex("id_pagamento");

                    b.ToTable("VendaPagamentos");
                });

            modelBuilder.Entity("ControleDeEstoqueApi.Domain.Models.Estoque", b =>
                {
                    b.HasOne("ControleDeEstoqueApi.Domain.Models.Agents.Funcionario", "Funcionario")
                        .WithMany("Estoque")
                        .HasForeignKey("cod_func")
                        .HasPrincipalKey("cod_func")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleDeEstoqueApi.Domain.Models.Produto", "Produto")
                        .WithOne("Estoque")
                        .HasForeignKey("ControleDeEstoqueApi.Domain.Models.Estoque", "cod_prod")
                        .HasPrincipalKey("ControleDeEstoqueApi.Domain.Models.Produto", "cod_prod")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleDeEstoqueApi.Domain.Models.Fabricante", "Fabricante")
                        .WithMany("Estoque")
                        .HasForeignKey("nome_fab")
                        .HasPrincipalKey("nome_fab")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleDeEstoqueApi.Domain.Models.Fornecedor", "Fornecedor")
                        .WithMany("Estoque")
                        .HasForeignKey("nome_fant")
                        .HasPrincipalKey("nome_fant")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fabricante");

                    b.Navigation("Fornecedor");

                    b.Navigation("Funcionario");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("ControleDeEstoqueApi.Domain.Models.Fabricante", b =>
                {
                    b.HasOne("ControleDeEstoqueApi.Domain.Models.Agents.Funcionario", "Funcionario")
                        .WithOne("Fabricante")
                        .HasForeignKey("ControleDeEstoqueApi.Domain.Models.Fabricante", "cod_func")
                        .HasPrincipalKey("ControleDeEstoqueApi.Domain.Models.Agents.Funcionario", "cod_func")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("ControleDeEstoqueApi.Domain.Models.Fornecedor", b =>
                {
                    b.HasOne("ControleDeEstoqueApi.Domain.Models.Agents.Funcionario", "Funcionario")
                        .WithOne("Fornecedor")
                        .HasForeignKey("ControleDeEstoqueApi.Domain.Models.Fornecedor", "cod_func")
                        .HasPrincipalKey("ControleDeEstoqueApi.Domain.Models.Agents.Funcionario", "cod_func")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("ControleDeEstoqueApi.Domain.Models.Item_Venda", b =>
                {
                    b.HasOne("ControleDeEstoqueApi.Domain.Models.Produto", "Produto")
                        .WithOne("Item_Venda")
                        .HasForeignKey("ControleDeEstoqueApi.Domain.Models.Item_Venda", "cod_prod")
                        .HasPrincipalKey("ControleDeEstoqueApi.Domain.Models.Produto", "cod_prod")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleDeEstoqueApi.Domain.Models.Venda", "Venda")
                        .WithMany("Item_Venda")
                        .HasForeignKey("cod_venda")
                        .HasPrincipalKey("cod_venda")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("ControleDeEstoqueApi.Domain.Models.Produto", b =>
                {
                    b.HasOne("ControleDeEstoqueApi.Domain.Models.Fabricante", "Fabricante")
                        .WithMany("Produto")
                        .HasForeignKey("cod_fab")
                        .HasPrincipalKey("cod_fab")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleDeEstoqueApi.Domain.Models.Fornecedor", "Fornecedor")
                        .WithMany("Produto")
                        .HasForeignKey("cod_fornc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fabricante");

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("ControleDeEstoqueApi.Domain.Models.Venda", b =>
                {
                    b.HasOne("ControleDeEstoqueApi.Domain.Models.Agents.Funcionario", "Funcionario")
                        .WithMany("Venda")
                        .HasForeignKey("cod_func")
                        .HasPrincipalKey("cod_func")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("ControleDeEstoqueApi.Domain.Models.VendaPagamento", b =>
                {
                    b.HasOne("ControleDeEstoqueApi.Domain.Models.Pagamento", "Pagamento")
                        .WithMany("VendaPagamentos")
                        .HasForeignKey("id_pagamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleDeEstoqueApi.Domain.Models.Venda", "Venda")
                        .WithMany("VendaPagamentos")
                        .HasForeignKey("id_venda")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pagamento");

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("ControleDeEstoqueApi.Domain.Models.Agents.Funcionario", b =>
                {
                    b.Navigation("Estoque");

                    b.Navigation("Fabricante")
                        .IsRequired();

                    b.Navigation("Fornecedor")
                        .IsRequired();

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("ControleDeEstoqueApi.Domain.Models.Fabricante", b =>
                {
                    b.Navigation("Estoque");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("ControleDeEstoqueApi.Domain.Models.Fornecedor", b =>
                {
                    b.Navigation("Estoque");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("ControleDeEstoqueApi.Domain.Models.Pagamento", b =>
                {
                    b.Navigation("VendaPagamentos");
                });

            modelBuilder.Entity("ControleDeEstoqueApi.Domain.Models.Produto", b =>
                {
                    b.Navigation("Estoque")
                        .IsRequired();

                    b.Navigation("Item_Venda")
                        .IsRequired();
                });

            modelBuilder.Entity("ControleDeEstoqueApi.Domain.Models.Venda", b =>
                {
                    b.Navigation("Item_Venda");

                    b.Navigation("VendaPagamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
