using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AisMKIT.Migrations
{
    public partial class ObnovlenieModelei : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListDirectors");

            migrationBuilder.DropColumn(
                name: "PositionHeld",
                table: "ListEmployees");

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmplPosHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: true),
                    PositionId = table.Column<int>(nullable: true),
                    FacultyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmplPosHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmplPosHistory_ListEmployees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "ListEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmplPosHistory_ListFaculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "ListFaculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmplPosHistory_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmplPosHistory_EmployeeId",
                table: "EmplPosHistory",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmplPosHistory_FacultyId",
                table: "EmplPosHistory",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmplPosHistory_PositionId",
                table: "EmplPosHistory",
                column: "PositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmplPosHistory");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.AddColumn<string>(
                name: "PositionHeld",
                table: "ListEmployees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ListDirectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ListOfEducationsId = table.Column<int>(type: "int", nullable: true),
                    ManagementEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ManagementStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListDirectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListDirectors_ListOfEducations_ListOfEducationsId",
                        column: x => x.ListOfEducationsId,
                        principalTable: "ListOfEducations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListDirectors_ListOfEducationsId",
                table: "ListDirectors",
                column: "ListOfEducationsId");
        }
    }
}
