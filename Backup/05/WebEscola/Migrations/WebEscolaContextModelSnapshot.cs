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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CursoID");

                    b.ToTable("Curso");
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
