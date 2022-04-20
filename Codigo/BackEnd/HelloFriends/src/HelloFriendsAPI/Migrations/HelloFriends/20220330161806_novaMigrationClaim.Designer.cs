﻿// <auto-generated />
using System;
using HelloFriendsAPI.Repositorys.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HelloFriendsAPI.Migrations.HelloFriends
{
    [DbContext(typeof(HelloFriendsContext))]
    [Migration("20220330161806_novaMigrationClaim")]
    partial class novaMigrationClaim
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HelloFriendsAPI.Model.Aluno", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataAniversario");

                    b.Property<string>("Email");

                    b.Property<string>("Imagem");

                    b.Property<string>("NomeCompleto");

                    b.Property<string>("NomeResponsavel");

                    b.Property<string>("Situacao");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("HelloFriendsAPI.Model.CompletaFrase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Enunciado");

                    b.Property<string>("Imagem");

                    b.Property<long>("ModuloId");

                    b.Property<string>("PalavrasChaves");

                    b.Property<string>("Titulo");

                    b.HasKey("Id");

                    b.HasIndex("ModuloId");

                    b.ToTable("CompletaFrase");
                });

            modelBuilder.Entity("HelloFriendsAPI.Model.CompletaTexto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Enunciado");

                    b.Property<string>("Imagem");

                    b.Property<long>("ModuloId");

                    b.Property<string>("PalavrasChaves");

                    b.Property<string>("Titulo");

                    b.HasKey("Id");

                    b.HasIndex("ModuloId");

                    b.ToTable("CompletaTexto");
                });

            modelBuilder.Entity("HelloFriendsAPI.Model.Modulo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Imagem");

                    b.Property<string>("NomeModulo");

                    b.HasKey("Id");

                    b.ToTable("Modulo");
                });

            modelBuilder.Entity("HelloFriendsAPI.Model.OpcaoCerta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AlternativaA");

                    b.Property<string>("AlternativaB");

                    b.Property<string>("AlternativaC");

                    b.Property<string>("AlternativaCerta")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<string>("AlternativaD");

                    b.Property<string>("Imagem");

                    b.Property<long>("ModuloId");

                    b.Property<string>("Pergunta");

                    b.Property<string>("Texto");

                    b.Property<string>("Titulo");

                    b.Property<string>("Video");

                    b.HasKey("Id");

                    b.HasIndex("ModuloId");

                    b.ToTable("OpcaoCerta");
                });

            modelBuilder.Entity("HelloFriendsAPI.Model.CompletaFrase", b =>
                {
                    b.HasOne("HelloFriendsAPI.Model.Modulo", "Modulo")
                        .WithMany()
                        .HasForeignKey("ModuloId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HelloFriendsAPI.Model.CompletaTexto", b =>
                {
                    b.HasOne("HelloFriendsAPI.Model.Modulo", "Modulo")
                        .WithMany()
                        .HasForeignKey("ModuloId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HelloFriendsAPI.Model.OpcaoCerta", b =>
                {
                    b.HasOne("HelloFriendsAPI.Model.Modulo", "Modulo")
                        .WithMany()
                        .HasForeignKey("ModuloId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
