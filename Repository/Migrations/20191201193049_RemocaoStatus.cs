using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class RemocaoStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projetos_Status_StatusProjetoStatusId",
                table: "Projetos");

            migrationBuilder.DropTable(
                name: "Status");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusProjeto",
                table: "Projetos");

            migrationBuilder.AddColumn<int>(
                name: "StatusProjetoStatusId",
                table: "Projetos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TipoStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                });

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
    }
}
