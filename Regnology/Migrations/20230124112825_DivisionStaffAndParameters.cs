using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Regnology.Migrations
{
    /// <inheritdoc />
    public partial class DivisionStaffAndParameters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Majors_MajorId",
                schema: "application",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Majors_MajorId1",
                schema: "application",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Majors",
                schema: "application");

            migrationBuilder.RenameColumn(
                name: "MajorId1",
                schema: "application",
                table: "Students",
                newName: "DivisionId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_MajorId1",
                schema: "application",
                table: "Students",
                newName: "IX_Students_DivisionId");

            migrationBuilder.CreateTable(
                name: "Divisions",
                schema: "application",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parameters",
                schema: "application",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                schema: "application",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalaryBeforeTax = table.Column<float>(type: "real", nullable: false),
                    StartYear = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staffs_Divisions_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "application",
                        principalTable: "Divisions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Staffs_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "application",
                        principalTable: "Divisions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_DepartmentId",
                schema: "application",
                table: "Staffs",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_DivisionId",
                schema: "application",
                table: "Staffs",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_StaffId",
                schema: "application",
                table: "Staffs",
                column: "StaffId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Divisions_DivisionId",
                schema: "application",
                table: "Students",
                column: "DivisionId",
                principalSchema: "application",
                principalTable: "Divisions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Divisions_MajorId",
                schema: "application",
                table: "Students",
                column: "MajorId",
                principalSchema: "application",
                principalTable: "Divisions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Divisions_DivisionId",
                schema: "application",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Divisions_MajorId",
                schema: "application",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Parameters",
                schema: "application");

            migrationBuilder.DropTable(
                name: "Staffs",
                schema: "application");

            migrationBuilder.DropTable(
                name: "Divisions",
                schema: "application");

            migrationBuilder.RenameColumn(
                name: "DivisionId",
                schema: "application",
                table: "Students",
                newName: "MajorId1");

            migrationBuilder.RenameIndex(
                name: "IX_Students_DivisionId",
                schema: "application",
                table: "Students",
                newName: "IX_Students_MajorId1");

            migrationBuilder.CreateTable(
                name: "Majors",
                schema: "application",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majors", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Majors_MajorId",
                schema: "application",
                table: "Students",
                column: "MajorId",
                principalSchema: "application",
                principalTable: "Majors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Majors_MajorId1",
                schema: "application",
                table: "Students",
                column: "MajorId1",
                principalSchema: "application",
                principalTable: "Majors",
                principalColumn: "Id");
        }
    }
}
