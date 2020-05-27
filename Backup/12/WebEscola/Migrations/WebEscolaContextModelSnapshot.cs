﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebEscola.Data;

namespace WebEscola.Migrations
{
    [DbContext(typeof(WebEscolaContext))]
    partial class WebEscolaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebEscola.Models.Aluno", b =>
                {
                    b.Property<int>("AlunoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("AlunoID");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("WebEscola.Models.Curso", b =>
                {
                    b.Property<int>("CursoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Credito")
                        .HasColumnType("int");

                    b.Property<int>("DepartamentoID")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("CursoID");

                    b.HasIndex("DepartamentoID");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("WebEscola.Models.CursoInstrutor", b =>
                {
                    b.Property<int>("CursoInstrutorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CursoID")
                        .HasColumnType("int");

                    b.Property<int?>("InstrutorID")
                        .HasColumnType("int");

                    b.HasKey("CursoInstrutorID");

                    b.HasIndex("CursoID");

                    b.HasIndex("InstrutorID");

                    b.ToTable("CursoInstrutor");
                });

            modelBuilder.Entity("WebEscola.Models.Departamento", b =>
                {
                    b.Property<int>("DepartamentoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Inicio")
                        .HasColumnType("datetime2");

                    b.Property<int?>("InstrutorID")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<decimal>("Orcamento")
                        .HasColumnType("money");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("DepartamentoID");

                    b.HasIndex("InstrutorID");

                    b.ToTable("Departamento");
                });

            modelBuilder.Entity("WebEscola.Models.Escritorio", b =>
                {
                    b.Property<int>("EscritorioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InstrutorID")
                        .HasColumnType("int");

                    b.Property<string>("Localizacao")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("EscritorioID");

                    b.HasIndex("InstrutorID")
                        .IsUnique();

                    b.ToTable("Escritorio");
                });

            modelBuilder.Entity("WebEscola.Models.Instrutor", b =>
                {
                    b.Property<int>("InstrutorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Contratacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("InstrutorID");

                    b.ToTable("Instrutor");
                });

            modelBuilder.Entity("WebEscola.Models.Matricula", b =>
                {
                    b.Property<int>("MatriculaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlunoID")
                        .HasColumnType("int");

                    b.Property<int>("CursoID")
                        .HasColumnType("int");

                    b.HasKey("MatriculaID");

                    b.HasIndex("AlunoID");

                    b.HasIndex("CursoID");

                    b.ToTable("Matricula");
                });

            modelBuilder.Entity("WebEscola.Models.Curso", b =>
                {
                    b.HasOne("WebEscola.Models.Departamento", "Departamento")
                        .WithMany("Cursos")
                        .HasForeignKey("DepartamentoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebEscola.Models.CursoInstrutor", b =>
                {
                    b.HasOne("WebEscola.Models.Curso", "Curso")
                        .WithMany("CursosInstrutor")
                        .HasForeignKey("CursoID");

                    b.HasOne("WebEscola.Models.Instrutor", "Instrutor")
                        .WithMany("CursosInstrutor")
                        .HasForeignKey("InstrutorID");
                });

            modelBuilder.Entity("WebEscola.Models.Departamento", b =>
                {
                    b.HasOne("WebEscola.Models.Instrutor", "Instrutor")
                        .WithMany("Departamentos")
                        .HasForeignKey("InstrutorID");
                });

            modelBuilder.Entity("WebEscola.Models.Escritorio", b =>
                {
                    b.HasOne("WebEscola.Models.Instrutor", "Instrutor")
                        .WithOne("Escritorio")
                        .HasForeignKey("WebEscola.Models.Escritorio", "InstrutorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebEscola.Models.Matricula", b =>
                {
                    b.HasOne("WebEscola.Models.Aluno", "Aluno")
                        .WithMany("Matriculas")
                        .HasForeignKey("AlunoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebEscola.Models.Curso", "Curso")
                        .WithMany("Matriculas")
                        .HasForeignKey("CursoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
