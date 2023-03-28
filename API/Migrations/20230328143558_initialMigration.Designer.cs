﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bancodigital_api.Data;

#nullable disable

namespace bancodigital_api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230328143558_initialMigration")]
    partial class initialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("bancodigital_api.Models.Conta", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("conta")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("saldo")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Contas");
                });

            modelBuilder.Entity("bancodigital_api.Models.Movimentacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Contaid")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataMovimentacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Valor")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Contaid");

                    b.ToTable("Movimentacoes");
                });

            modelBuilder.Entity("bancodigital_api.Models.Movimentacao", b =>
                {
                    b.HasOne("bancodigital_api.Models.Conta", "Conta")
                        .WithMany("movimentacoes")
                        .HasForeignKey("Contaid");

                    b.Navigation("Conta");
                });

            modelBuilder.Entity("bancodigital_api.Models.Conta", b =>
                {
                    b.Navigation("movimentacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
