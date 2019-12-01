using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class AddStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusProjeto",
                table: "Projetos");

            migrationBuilder.AddColumn<int>(
                name: "StatusProjetoStatusId",
                table: "Projetos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_StatusProjetoStatusId",
                table: "Projetos",
                column: "StatusProjetoStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projetos_Status_StatusProjetoStatusId",
                table: "Projetos",
                column: "StatusProjetoStatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projetos_Status_StatusProjetoStatusId",
                table: "Projetos");

            migrationBuilder.DropIndex(
                name: "IX_Projetos_StatusProjetoStatusId",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "StatusProjetoStatusId",
                table: "Projetos");

            migrationBuilder.AddColumn<string>(
                name: "StatusProjeto",
                table: "Projetos",
                nullable: true);
        }
    }
}
