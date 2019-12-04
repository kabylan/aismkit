using Microsoft.EntityFrameworkCore.Migrations;

namespace AisMKIT.Migrations
{
    public partial class AddedFullNameToEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EducationalUnit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialty",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmplEducationalUnit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: true),
                    EducationalUnitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmplEducationalUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmplEducationalUnit_EducationalUnit_EducationalUnitId",
                        column: x => x.EducationalUnitId,
                        principalTable: "EducationalUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmplEducationalUnit_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FacultySpecialty",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialtyId = table.Column<int>(nullable: true),
                    FacultyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultySpecialty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacultySpecialty_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FacultySpecialty_Specialty_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmplEducationalUnit_EducationalUnitId",
                table: "EmplEducationalUnit",
                column: "EducationalUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_EmplEducationalUnit_EmployeeId",
                table: "EmplEducationalUnit",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_FacultySpecialty_FacultyId",
                table: "FacultySpecialty",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_FacultySpecialty_SpecialtyId",
                table: "FacultySpecialty",
                column: "SpecialtyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmplEducationalUnit");

            migrationBuilder.DropTable(
                name: "FacultySpecialty");

            migrationBuilder.DropTable(
                name: "EducationalUnit");

            migrationBuilder.DropTable(
                name: "Specialty");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Employees");
        }
    }
}
