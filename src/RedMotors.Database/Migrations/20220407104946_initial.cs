using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedMotors.Database.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RedMotors");

            migrationBuilder.CreateTable(
                name: "Cars",
                schema: "RedMotors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CarRegistrationNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "RedMotors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TIN = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manager",
                schema: "RedMotors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalaryPerMonth = table.Column<decimal>(type: "decimal(18,2)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTasks",
                schema: "RedMotors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Hours = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Engineer",
                schema: "RedMotors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalaryPerMonth = table.Column<decimal>(type: "decimal(18,2)", maxLength: 50, nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engineer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Engineer_Manager_ManagerId",
                        column: x => x.ManagerId,
                        principalSchema: "RedMotors",
                        principalTable: "Manager",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                schema: "RedMotors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Cars_CarId",
                        column: x => x.CarId,
                        principalSchema: "RedMotors",
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "RedMotors",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Manager_ManagerId",
                        column: x => x.ManagerId,
                        principalSchema: "RedMotors",
                        principalTable: "Manager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionLines",
                schema: "RedMotors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EngineerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Hours = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    PricePerHour = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false, computedColumnSql: "[Hours] * [PricePerHour]")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionLines_Engineer_EngineerId",
                        column: x => x.EngineerId,
                        principalSchema: "RedMotors",
                        principalTable: "Engineer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionLines_ServiceTasks_ServiceTaskId",
                        column: x => x.ServiceTaskId,
                        principalSchema: "RedMotors",
                        principalTable: "ServiceTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionLines_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalSchema: "RedMotors",
                        principalTable: "Transactions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Engineer_ManagerId",
                schema: "RedMotors",
                table: "Engineer",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLines_EngineerId",
                schema: "RedMotors",
                table: "TransactionLines",
                column: "EngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLines_ServiceTaskId",
                schema: "RedMotors",
                table: "TransactionLines",
                column: "ServiceTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLines_TransactionId",
                schema: "RedMotors",
                table: "TransactionLines",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CarId",
                schema: "RedMotors",
                table: "Transactions",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CustomerId",
                schema: "RedMotors",
                table: "Transactions",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ManagerId",
                schema: "RedMotors",
                table: "Transactions",
                column: "ManagerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionLines",
                schema: "RedMotors");

            migrationBuilder.DropTable(
                name: "Engineer",
                schema: "RedMotors");

            migrationBuilder.DropTable(
                name: "ServiceTasks",
                schema: "RedMotors");

            migrationBuilder.DropTable(
                name: "Transactions",
                schema: "RedMotors");

            migrationBuilder.DropTable(
                name: "Cars",
                schema: "RedMotors");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "RedMotors");

            migrationBuilder.DropTable(
                name: "Manager",
                schema: "RedMotors");
        }
    }
}
