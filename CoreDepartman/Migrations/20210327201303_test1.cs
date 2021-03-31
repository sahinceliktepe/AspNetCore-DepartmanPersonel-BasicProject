using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreDepartman.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartId",
                table: "Personels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personels_DepartId",
                table: "Personels",
                column: "DepartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_Departmanlars_DepartId",
                table: "Personels",
                column: "DepartId",
                principalTable: "Departmanlars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personels_Departmanlars_DepartId",
                table: "Personels");

            migrationBuilder.DropIndex(
                name: "IX_Personels_DepartId",
                table: "Personels");

            migrationBuilder.DropColumn(
                name: "DepartId",
                table: "Personels");
        }
    }
}
