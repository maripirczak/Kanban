﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

namespace Repository.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Departamento", b =>
                {
                    b.Property<int>("DepartamentoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeDepartamento");

                    b.HasKey("DepartamentoId");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("Domain.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("bairro");

                    b.Property<string>("cep");

                    b.Property<string>("cidade");

                    b.HasKey("EnderecoId");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Domain.Funcionario", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CpfFuncionario");

                    b.Property<int?>("EnderecoId");

                    b.Property<string>("NomeFuncionario");

                    b.Property<string>("SenhaFuncionario");

                    b.HasKey("FuncionarioId");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("Domain.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCriacaoJob");

                    b.Property<DateTime>("DataEntregaJob");

                    b.Property<string>("DescricaoJob");

                    b.Property<int?>("DptoResponsavelDepartamentoId");

                    b.Property<string>("NomeResponsavel");

                    b.Property<int>("ProjetoId");

                    b.Property<int?>("StatusJobTipoStatusId");

                    b.Property<string>("TituloJob");

                    b.HasKey("JobId");

                    b.HasIndex("DptoResponsavelDepartamentoId");

                    b.HasIndex("ProjetoId");

                    b.HasIndex("StatusJobTipoStatusId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Domain.Projeto", b =>
                {
                    b.Property<int>("ProjetoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCriacaoProjeto");

                    b.Property<string>("DescricaoProjeto")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("NomeEmpresa")
                        .IsRequired();

                    b.Property<string>("NomeProjeto")
                        .IsRequired();

                    b.Property<int?>("StatusProjetoTipoStatusId");

                    b.HasKey("ProjetoId");

                    b.HasIndex("StatusProjetoTipoStatusId");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("Domain.Tarefa", b =>
                {
                    b.Property<int>("TarefaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCriacaoTarefa");

                    b.Property<DateTime>("DataEntregaTarefa");

                    b.Property<string>("DescricaoTarefa");

                    b.Property<int>("JobId");

                    b.Property<int?>("ResponsavelFuncionarioId");

                    b.Property<int?>("StatusTarefaTipoStatusId");

                    b.Property<string>("TituloTarefa");

                    b.HasKey("TarefaId");

                    b.HasIndex("JobId");

                    b.HasIndex("ResponsavelFuncionarioId");

                    b.HasIndex("StatusTarefaTipoStatusId");

                    b.ToTable("Tarefas");
                });

            modelBuilder.Entity("Domain.TipoStatus", b =>
                {
                    b.Property<int>("TipoStatusId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeStatus");

                    b.HasKey("TipoStatusId");

                    b.ToTable("TipoStatus");
                });

            modelBuilder.Entity("Domain.Funcionario", b =>
                {
                    b.HasOne("Domain.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");
                });

            modelBuilder.Entity("Domain.Job", b =>
                {
                    b.HasOne("Domain.Departamento", "DptoResponsavel")
                        .WithMany()
                        .HasForeignKey("DptoResponsavelDepartamentoId");

                    b.HasOne("Domain.Projeto")
                        .WithMany("Jobs")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.TipoStatus", "StatusJob")
                        .WithMany()
                        .HasForeignKey("StatusJobTipoStatusId");
                });

            modelBuilder.Entity("Domain.Projeto", b =>
                {
                    b.HasOne("Domain.TipoStatus", "StatusProjeto")
                        .WithMany()
                        .HasForeignKey("StatusProjetoTipoStatusId");
                });

            modelBuilder.Entity("Domain.Tarefa", b =>
                {
                    b.HasOne("Domain.Job")
                        .WithMany("Tarefas")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Funcionario", "Responsavel")
                        .WithMany()
                        .HasForeignKey("ResponsavelFuncionarioId");

                    b.HasOne("Domain.TipoStatus", "StatusTarefa")
                        .WithMany()
                        .HasForeignKey("StatusTarefaTipoStatusId");
                });
#pragma warning restore 612, 618
        }
    }
}
