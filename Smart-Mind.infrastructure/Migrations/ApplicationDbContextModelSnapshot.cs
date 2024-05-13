﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Smart_Mind.infrastructure.Context;

#nullable disable

namespace Smart_Mind.infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("QuestaoTeste", b =>
                {
                    b.Property<int>("QuestoesId")
                        .HasColumnType("int");

                    b.Property<int>("TestesId")
                        .HasColumnType("int");

                    b.HasKey("QuestoesId", "TestesId");

                    b.HasIndex("TestesId");

                    b.ToTable("QuestaoTeste");
                });

            modelBuilder.Entity("Smart_Mind.Domain.Entities.Alternativa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Correta")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("QuestaoId")
                        .HasColumnType("int");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("QuestaoId");

                    b.ToTable("Alternativas");
                });

            modelBuilder.Entity("Smart_Mind.Domain.Entities.Assunto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MateriaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("VideoAulaUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MateriaId");

                    b.ToTable("Assuntos");
                });

            modelBuilder.Entity("Smart_Mind.Domain.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Smart_Mind.Domain.Entities.Explicacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AssuntoId")
                        .HasColumnType("int");

                    b.Property<string>("Imagem")
                        .HasColumnType("longtext");

                    b.Property<int>("QuestaoId")
                        .HasColumnType("int");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AssuntoId");

                    b.HasIndex("QuestaoId")
                        .IsUnique();

                    b.ToTable("Explicacao");
                });

            modelBuilder.Entity("Smart_Mind.Domain.Entities.ExplicacaoAssunto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AssuntoId")
                        .HasColumnType("int");

                    b.Property<string>("Imagem")
                        .HasColumnType("longtext");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AssuntoId");

                    b.ToTable("ExplicacaoAssuntos");
                });

            modelBuilder.Entity("Smart_Mind.Domain.Entities.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("ImagemUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Materias");
                });

            modelBuilder.Entity("Smart_Mind.Domain.Entities.Questao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AssuntoId")
                        .HasColumnType("int");

                    b.Property<string>("Dificuldade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Enunciado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImagemUrl")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AssuntoId");

                    b.ToTable("Questoes");
                });

            modelBuilder.Entity("Smart_Mind.Domain.Entities.RespostaUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Acertou")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("AlternativaId")
                        .HasColumnType("int");

                    b.Property<int?>("TesteId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlternativaId");

                    b.HasIndex("TesteId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("RespostasUsuarios");
                });

            modelBuilder.Entity("Smart_Mind.Domain.Entities.Teste", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataDaRealizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Pontuacao")
                        .HasColumnType("int");

                    b.Property<int>("PontuacaoUsuario")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Testes");
                });

            modelBuilder.Entity("Smart_Mind.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("ImagemUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("QuestaoTeste", b =>
                {
                    b.HasOne("Smart_Mind.Domain.Entities.Questao", null)
                        .WithMany()
                        .HasForeignKey("QuestoesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Smart_Mind.Domain.Entities.Teste", null)
                        .WithMany()
                        .HasForeignKey("TestesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Smart_Mind.Domain.Entities.Alternativa", b =>
                {
                    b.HasOne("Smart_Mind.Domain.Entities.Questao", "Questao")
                        .WithMany("Alternativas")
                        .HasForeignKey("QuestaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Questao");
                });

            modelBuilder.Entity("Smart_Mind.Domain.Entities.Assunto", b =>
                {
                    b.HasOne("Smart_Mind.Domain.Entities.Materia", "Materia")
                        .WithMany("Assuntos")
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("Smart_Mind.Domain.Entities.Explicacao", b =>
                {
                    b.HasOne("Smart_Mind.Domain.Entities.Assunto", null)
                        .WithMany("Explicacoes")
                        .HasForeignKey("AssuntoId");

                    b.HasOne("Smart_Mind.Domain.Entities.Questao", "Questao")
                        .WithOne("Explicacao")
                        .HasForeignKey("Smart_Mind.Domain.Entities.Explicacao", "QuestaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Questao");
                });

            modelBuilder.Entity("Smart_Mind.Domain.Entities.ExplicacaoAssunto", b =>
                {
                    b.HasOne("Smart_Mind.Domain.Entities.Assunto", "Assunto")
                        .WithMany()
                        .HasForeignKey("AssuntoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assunto");
                });

            modelBuilder.Entity("Smart_Mind.Domain.Entities.Materia", b =>
                {
                    b.HasOne("Smart_Mind.Domain.Entities.Categoria", "Categoria")
                        .WithMany("Materias")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Smart_Mind.Domain.Entities.Questao", b =>
                {
                    b.HasOne("Smart_Mind.Domain.Entities.Assunto", "Assunto")
                        .WithMany("Questoes")
                        .HasForeignKey("AssuntoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assunto");
                });

            modelBuilder.Entity("Smart_Mind.Domain.Entities.RespostaUsuario", b =>
                {
                    b.HasOne("Smart_Mind.Domain.Entities.Alternativa", "Alternativa")
                        .WithMany()
                        .HasForeignKey("AlternativaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Smart_Mind.Domain.Entities.Teste", null)
                        .WithMany("RespostaUsuarios")
                        .HasForeignKey("TesteId");

                    b.HasOne("Smart_Mind.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alternativa");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Smart_Mind.Domain.Entities.Teste", b =>
                {
                    b.HasOne("Smart_Mind.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Testes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Smart_Mind.Domain.Entities.Assunto", b =>
                {
                    b.Navigation("Explicacoes");

                    b.Navigation("Questoes");
                });

            modelBuilder.Entity("Smart_Mind.Domain.Entities.Categoria", b =>
                {
                    b.Navigation("Materias");
                });

            modelBuilder.Entity("Smart_Mind.Domain.Entities.Materia", b =>
                {
                    b.Navigation("Assuntos");
                });

            modelBuilder.Entity("Smart_Mind.Domain.Entities.Questao", b =>
                {
                    b.Navigation("Alternativas");

                    b.Navigation("Explicacao");
                });

            modelBuilder.Entity("Smart_Mind.Domain.Entities.Teste", b =>
                {
                    b.Navigation("RespostaUsuarios");
                });

            modelBuilder.Entity("Smart_Mind.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Testes");
                });
#pragma warning restore 612, 618
        }
    }
}
