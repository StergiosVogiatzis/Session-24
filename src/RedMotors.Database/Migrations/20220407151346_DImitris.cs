using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedMotors.Database.Migrations
{
    public partial class DImitris : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Engineer_Manager_ManagerId",
                schema: "RedMotors",
                table: "Engineer");

            migrationBuilder.DropForeignKey(
                name: "FK_Manager_Engineer_EngineerId",
                schema: "RedMotors",
                table: "Manager");

            migrationBuilder.DropIndex(
                name: "IX_Manager_EngineerId",
                schema: "RedMotors",
                table: "Manager");

            migrationBuilder.DropColumn(
                name: "EngineerId",
                schema: "RedMotors",
                table: "Manager");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Engineer_Manager_ManagerId",
                schema: "RedMotors",
                table: "Engineer");

            migrationBuilder.AddColumn<Guid>(
                name: "EngineerId",
                schema: "RedMotors",
                table: "Manager",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manager_EngineerId",
                schema: "RedMotors",
                table: "Manager",
                column: "EngineerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Engineer_Manager_ManagerId",
                schema: "RedMotors",
                table: "Engineer",
                column: "ManagerId",
                principalSchema: "RedMotors",
                principalTable: "Manager",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Manager_Engineer_EngineerId",
                schema: "RedMotors",
                table: "Manager",
                column: "EngineerId",
                principalSchema: "RedMotors",
                principalTable: "Engineer",
                principalColumn: "Id");
        }
    }
}
