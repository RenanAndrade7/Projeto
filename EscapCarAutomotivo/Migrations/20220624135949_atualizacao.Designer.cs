﻿// <auto-generated />
using System;
using EscapCarAutomotivo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EscapCarAutomotivo.Migrations
{
    [DbContext(typeof(EscapCarAutomotivoContext))]
    [Migration("20220624135949_atualizacao")]
    partial class atualizacao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EscapCarAutomotivo.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cpf");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("EscapCarAutomotivo.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.Property<double>("Valor");

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("EscapCarAutomotivo.Models.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amortecedor");

                    b.Property<double>("Bandeja");

                    b.Property<int?>("ClienteId");

                    b.Property<DateTime>("Data");

                    b.Property<double>("KitAmortecedor");

                    b.Property<double>("Resultado");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Venda");
                });

            modelBuilder.Entity("EscapCarAutomotivo.Models.Venda", b =>
                {
                    b.HasOne("EscapCarAutomotivo.Models.Cliente", "Cliente")
                        .WithMany("Vendas")
                        .HasForeignKey("ClienteId");
                });
#pragma warning restore 612, 618
        }
    }
}
