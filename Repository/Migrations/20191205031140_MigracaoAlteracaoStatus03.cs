using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class MigracaoAlteracaoStatus03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusTarefa",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "StatusProjeto",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "StatusJob",
                table: "Jobs");

            migrationBuilder.AddColumn<int>(
                name: "StatusTarefaTipoStatusId",
                table: "Tarefas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusProjetoTipoStatusId",
                table: "Projetos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusJobTipoStatusId",
                table: "Jobs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_StatusTarefaTipoStatusId",
                table: "Tarefas",
                column: "StatusTarefaTipoStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_StatusProjetoTipoStatusId",
                table: "Projetos",
                column: "StatusProjetoTipoStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_StatusJobTipoStatusId",
                table: "Jobs",
                column: "StatusJobTipoStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_TipoStatus_StatusJobTipoStatusId",
                table: "Jobs",
                column: "StatusJobTipoStatusId",
                principalTable: "TipoStatus",
                principalColumn: "TipoStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projetos_TipoStatus_StatusProjetoTipoStatusId",
                table: "Projetos",
                column: "StatusProjetoTipoStatusId",
                principalTable: "TipoStatus",
                principalColumn: "TipoStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_TipoStatus_StatusTarefaTipoStatusId",
                table: "Tarefas",
                column: "StatusTarefaTipoStatusId",
                principalTable: "TipoStatus",
                principalColumn: "TipoStatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_TipoStatus_StatusJobTipoStatusId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Projetos_TipoStatus_StatusProjetoTipoStatusId",
                table: "Projetos");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_TipoStatus_StatusTarefaTipoStatusId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_StatusTarefaTipoStatusId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Projetos_StatusProjetoTipoStatusId",
                table: "Projetos");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_StatusJobTipoStatusId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "StatusTarefaTipoStatusId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "StatusProjetoTipoStatusId",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "StatusJobTipoStatusId",
                table: "Jobs");

            migrationBuilder.AddColumn<string>(
                name: "StatusTarefa",
                table: "Tarefas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusProjeto",
                table: "Projetos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusJob",
                table: "Jobs",
                nullable: true);
        }
    }
}
