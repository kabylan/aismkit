using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AisMKIT.Migrations
{
    public partial class UpdatedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_ListOfEducations_ListOfEducationsId",
                table: "Faculties");

            migrationBuilder.DropTable(
                name: "ListOfEducations");

            migrationBuilder.DropIndex(
                name: "IX_Faculties_ListOfEducationsId",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "ListOfEducationsId",
                table: "Faculties");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Specialties",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EduInstitutionId",
                table: "Faculties",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkEndDate",
                table: "EmplPosHistories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkStartDate",
                table: "EmplPosHistories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkEndDate",
                table: "EmplEducationalUnits",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkStartDate",
                table: "EmplEducationalUnits",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "EduInstitutions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INN = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    DomenNames = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DateOfCreated = table.Column<DateTime>(nullable: false),
                    BriefInfo = table.Column<string>(nullable: true),
                    ClUchZavedCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EduInstitutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EduInstitutions_ClUchZavedCategory_ClUchZavedCategoryId",
                        column: x => x.ClUchZavedCategoryId,
                        principalTable: "ClUchZavedCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_EduInstitutionId",
                table: "Faculties",
                column: "EduInstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_EduInstitutions_ClUchZavedCategoryId",
                table: "EduInstitutions",
                column: "ClUchZavedCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_EduInstitutions_EduInstitutionId",
                table: "Faculties",
                column: "EduInstitutionId",
                principalTable: "EduInstitutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_EduInstitutions_EduInstitutionId",
                table: "Faculties");

            migrationBuilder.DropTable(
                name: "EduInstitutions");

            migrationBuilder.DropIndex(
                name: "IX_Faculties_EduInstitutionId",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Specialties");

            migrationBuilder.DropColumn(
                name: "EduInstitutionId",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "WorkEndDate",
                table: "EmplPosHistories");

            migrationBuilder.DropColumn(
                name: "WorkStartDate",
                table: "EmplPosHistories");

            migrationBuilder.DropColumn(
                name: "WorkEndDate",
                table: "EmplEducationalUnits");

            migrationBuilder.DropColumn(
                name: "WorkStartDate",
                table: "EmplEducationalUnits");

            migrationBuilder.AddColumn<int>(
                name: "ListOfEducationsId",
                table: "Faculties",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ListOfEducations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClUchZavedCategoryId = table.Column<int>(type: "int", nullable: false),
                    DateOfCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DomenNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    INN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfEducations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfEducations_ClUchZavedCategory_ClUchZavedCategoryId",
                        column: x => x.ClUchZavedCategoryId,
                        principalTable: "ClUchZavedCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_ListOfEducationsId",
                table: "Faculties",
                column: "ListOfEducationsId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfEducations_ClUchZavedCategoryId",
                table: "ListOfEducations",
                column: "ClUchZavedCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_ListOfEducations_ListOfEducationsId",
                table: "Faculties",
                column: "ListOfEducationsId",
                principalTable: "ListOfEducations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
