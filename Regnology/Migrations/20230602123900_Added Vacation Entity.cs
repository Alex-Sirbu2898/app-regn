using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Regnology.Migrations
{
    /// <inheritdoc />
    public partial class AddedVacationEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_ManagerId",
                schema: "application",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Clients_ClientId",
                schema: "application",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ClientId",
                schema: "application",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parameters",
                schema: "application",
                table: "Parameters");

            migrationBuilder.DropColumn(
                name: "ClientName",
                schema: "application",
                table: "Projects");

            migrationBuilder.RenameTable(
                name: "Parameters",
                schema: "application",
                newName: "Parameter",
                newSchema: "application");

            migrationBuilder.RenameColumn(
                name: "CliientId",
                schema: "application",
                table: "Clients",
                newName: "ClientId");

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                schema: "application",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "ClientId1",
                schema: "application",
                table: "Projects",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "ManagerId",
                schema: "application",
                table: "Employees",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "application",
                table: "Employees",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfHire",
                schema: "application",
                table: "Employees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Employees_EmployeeId",
                schema: "application",
                table: "Employees",
                column: "EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parameter",
                schema: "application",
                table: "Parameter",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Vacations",
                schema: "application",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    NoOfUsedDays = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    VacationStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "application",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vacations_Employees_Id",
                        column: x => x.Id,
                        principalSchema: "application",
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientId1",
                schema: "application",
                table: "Projects",
                column: "ClientId1");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_EmployeeId",
                schema: "application",
                table: "Vacations",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_ManagerId",
                schema: "application",
                table: "Employees",
                column: "ManagerId",
                principalSchema: "application",
                principalTable: "Employees",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Clients_ClientId1",
                schema: "application",
                table: "Projects",
                column: "ClientId1",
                principalSchema: "application",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_ManagerId",
                schema: "application",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Clients_ClientId1",
                schema: "application",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "Vacations",
                schema: "application");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ClientId1",
                schema: "application",
                table: "Projects");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Employees_EmployeeId",
                schema: "application",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parameter",
                schema: "application",
                table: "Parameter");

            migrationBuilder.DropColumn(
                name: "ClientId1",
                schema: "application",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "DateOfHire",
                schema: "application",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Parameter",
                schema: "application",
                newName: "Parameters",
                newSchema: "application");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                schema: "application",
                table: "Clients",
                newName: "CliientId");

            migrationBuilder.AlterColumn<long>(
                name: "ClientId",
                schema: "application",
                table: "Projects",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                schema: "application",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                schema: "application",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "application",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parameters",
                schema: "application",
                table: "Parameters",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientId",
                schema: "application",
                table: "Projects",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_ManagerId",
                schema: "application",
                table: "Employees",
                column: "ManagerId",
                principalSchema: "application",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Clients_ClientId",
                schema: "application",
                table: "Projects",
                column: "ClientId",
                principalSchema: "application",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
