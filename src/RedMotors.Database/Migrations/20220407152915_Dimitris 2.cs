using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedMotors.Database.Migrations
{
    public partial class Dimitris2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Engineer_Manager_ManagerId",
                schema: "RedMotors",
                table: "Engineer");

            migrationBuilder.AddForeignKey(
                name: "FK_Engineer_Manager_ManagerId",
                schema: "RedMotors",
                table: "Engineer",
                column: "ManagerId",
                principalSchema: "RedMotors",
                principalTable: "Manager",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Engineer_Manager_ManagerId",
                schema: "RedMotors",
                table: "Engineer");

            migrationBuilder.AddForeignKey(
                name: "FK_Engineer_Manager_ManagerId",
                schema: "RedMotors",
                table: "Engineer",
                column: "ManagerId",
                principalSchema: "RedMotors",
                principalTable: "Manager",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
