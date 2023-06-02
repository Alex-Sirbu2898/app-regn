using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Regnology.Migrations
{
    /// <inheritdoc />
    public partial class Addednewentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProjectId",
                schema: "application",
                table: "Employees",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Clients",
                schema: "application",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CliientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                schema: "application",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Clients_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "application",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ProjectId",
                schema: "application",
                table: "Employees",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientId",
                schema: "application",
                table: "Projects",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Projects_ProjectId",
                schema: "application",
                table: "Employees",
                column: "ProjectId",
                principalSchema: "application",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Projects_ProjectId",
                schema: "application",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Projects",
                schema: "application");

            migrationBuilder.DropTable(
                name: "Clients",
                schema: "application");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ProjectId",
                schema: "application",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                schema: "application",
                table: "Employees");
        }
    }
}
