﻿// <auto-generated />
using System;
using Capitulo03.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Capitulo03.Migrations
{
    [DbContext(typeof(IESContext))]
    [Migration("20240118211929_Instituicao")]
    partial class Instituicao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Capitulo03.Models.Departamento", b =>
                {
                    b.Property<long?>("DepartamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long?>("DepartamentoId"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("DepartamentoId");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("Capitulo03.Models.Instituicao", b =>
                {
                    b.Property<long?>("InstituicaoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long?>("InstituicaoID"));

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("InstituicaoID");

                    b.ToTable("Instituicoes");
                });
#pragma warning restore 612, 618
        }
    }
}
