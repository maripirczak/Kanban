using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class CriarBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    DepartamentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeDepartamento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.DepartamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeFuncionario = table.Column<string>(nullable: true),
                    CpfFuncionario = table.Column<string>(nullable: true),
                    SenhaFuncionario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.FuncionarioId);
                });

            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    ProjetoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeProjeto = table.Column<string>(nullable: false),
                    DescricaoProjeto = table.Column<string>(maxLength: 200, nullable: false),
                    NomeEmpresa = table.Column<string>(nullable: false),
                    DataCriacaoProjeto = table.Column<DateTime>(nullable: false),
                    StatusProjeto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.ProjetoId);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjetoId = table.Column<int>(nullable: false),
                    TituloJob = table.Column<string>(nullable: true),
                    DescricaoJob = table.Column<string>(nullable: true),
                    DataCriacaoJob = table.Column<DateTime>(nullable: false),
                    DataEntregaJob = table.Column<DateTime>(nullable: false),
                    StatusJob = table.Column<string>(nullable: true),
                    DptoResponsavelDepartamentoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_Jobs_Departamentos_DptoResponsavelDepartamentoId",
                        column: x => x.DptoResponsavelDepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "DepartamentoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jobs_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "ProjetoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    TarefaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JobId = table.Column<int>(nullable: false),
                    TituloTarefa = table.Column<string>(nullable: true),
                    DescricaoTarefa = table.Column<string>(nullable: true),
                    DataCriacaoTarefa = table.Column<DateTime>(nullable: false),
                    DataEntregaTarefa = table.Column<DateTime>(nullable: false),
                    ResponsavelFuncionarioId = table.Column<int>(nullable: true),
                    StatusTarefa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.TarefaId);
                    table.ForeignKey(
                        name: "FK_Tarefas_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tarefas_Funcionarios_ResponsavelFuncionarioId",
                        column: x => x.ResponsavelFuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_DptoResponsavelDepartamentoId",
                table: "Jobs",
                column: "DptoResponsavelDepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ProjetoId",
                table: "Jobs",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_JobId",
                table: "Tarefas",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_ResponsavelFuncionarioId",
                table: "Tarefas",
                column: "ResponsavelFuncionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarefas");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Projetos");
        }
    }
}
