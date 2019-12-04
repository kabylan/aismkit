using Microsoft.EntityFrameworkCore.Migrations;

namespace AisMKIT.Migrations
{
    public partial class SomethingChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmplEducationalUnit_EducationalUnit_EducationalUnitId",
                table: "EmplEducationalUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_EmplEducationalUnit_Employees_EmployeeId",
                table: "EmplEducationalUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ListOfEducations_ListOfEducationsId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EmplPosHistory_Employees_EmployeeId",
                table: "EmplPosHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_EmplPosHistory_Faculties_FacultyId",
                table: "EmplPosHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_EmplPosHistory_Position_PositionId",
                table: "EmplPosHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_FacultySpecialty_Faculties_FacultyId",
                table: "FacultySpecialty");

            migrationBuilder.DropForeignKey(
                name: "FK_FacultySpecialty_Specialty_SpecialtyId",
                table: "FacultySpecialty");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ListOfEducationsId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specialty",
                table: "Specialty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Position",
                table: "Position");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FacultySpecialty",
                table: "FacultySpecialty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmplPosHistory",
                table: "EmplPosHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmplEducationalUnit",
                table: "EmplEducationalUnit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EducationalUnit",
                table: "EducationalUnit");

            migrationBuilder.DropColumn(
                name: "ListOfEducationsId",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Specialty",
                newName: "Specialties");

            migrationBuilder.RenameTable(
                name: "Position",
                newName: "Positions");

            migrationBuilder.RenameTable(
                name: "FacultySpecialty",
                newName: "FacultySpecialties");

            migrationBuilder.RenameTable(
                name: "EmplPosHistory",
                newName: "EmplPosHistories");

            migrationBuilder.RenameTable(
                name: "EmplEducationalUnit",
                newName: "EmplEducationalUnits");

            migrationBuilder.RenameTable(
                name: "EducationalUnit",
                newName: "EducationalUnits");

            migrationBuilder.RenameIndex(
                name: "IX_FacultySpecialty_SpecialtyId",
                table: "FacultySpecialties",
                newName: "IX_FacultySpecialties_SpecialtyId");

            migrationBuilder.RenameIndex(
                name: "IX_FacultySpecialty_FacultyId",
                table: "FacultySpecialties",
                newName: "IX_FacultySpecialties_FacultyId");

            migrationBuilder.RenameIndex(
                name: "IX_EmplPosHistory_PositionId",
                table: "EmplPosHistories",
                newName: "IX_EmplPosHistories_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_EmplPosHistory_FacultyId",
                table: "EmplPosHistories",
                newName: "IX_EmplPosHistories_FacultyId");

            migrationBuilder.RenameIndex(
                name: "IX_EmplPosHistory_EmployeeId",
                table: "EmplPosHistories",
                newName: "IX_EmplPosHistories_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmplEducationalUnit_EmployeeId",
                table: "EmplEducationalUnits",
                newName: "IX_EmplEducationalUnits_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmplEducationalUnit_EducationalUnitId",
                table: "EmplEducationalUnits",
                newName: "IX_EmplEducationalUnits_EducationalUnitId");

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "EmplEducationalUnits",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specialties",
                table: "Specialties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Positions",
                table: "Positions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FacultySpecialties",
                table: "FacultySpecialties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmplPosHistories",
                table: "EmplPosHistories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmplEducationalUnits",
                table: "EmplEducationalUnits",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EducationalUnits",
                table: "EducationalUnits",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_EmplEducationalUnits_FacultyId",
                table: "EmplEducationalUnits",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmplEducationalUnits_EducationalUnits_EducationalUnitId",
                table: "EmplEducationalUnits",
                column: "EducationalUnitId",
                principalTable: "EducationalUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmplEducationalUnits_Employees_EmployeeId",
                table: "EmplEducationalUnits",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmplEducationalUnits_Faculties_FacultyId",
                table: "EmplEducationalUnits",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmplPosHistories_Employees_EmployeeId",
                table: "EmplPosHistories",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmplPosHistories_Faculties_FacultyId",
                table: "EmplPosHistories",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmplPosHistories_Positions_PositionId",
                table: "EmplPosHistories",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FacultySpecialties_Faculties_FacultyId",
                table: "FacultySpecialties",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FacultySpecialties_Specialties_SpecialtyId",
                table: "FacultySpecialties",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmplEducationalUnits_EducationalUnits_EducationalUnitId",
                table: "EmplEducationalUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_EmplEducationalUnits_Employees_EmployeeId",
                table: "EmplEducationalUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_EmplEducationalUnits_Faculties_FacultyId",
                table: "EmplEducationalUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_EmplPosHistories_Employees_EmployeeId",
                table: "EmplPosHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_EmplPosHistories_Faculties_FacultyId",
                table: "EmplPosHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_EmplPosHistories_Positions_PositionId",
                table: "EmplPosHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_FacultySpecialties_Faculties_FacultyId",
                table: "FacultySpecialties");

            migrationBuilder.DropForeignKey(
                name: "FK_FacultySpecialties_Specialties_SpecialtyId",
                table: "FacultySpecialties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specialties",
                table: "Specialties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Positions",
                table: "Positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FacultySpecialties",
                table: "FacultySpecialties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmplPosHistories",
                table: "EmplPosHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmplEducationalUnits",
                table: "EmplEducationalUnits");

            migrationBuilder.DropIndex(
                name: "IX_EmplEducationalUnits_FacultyId",
                table: "EmplEducationalUnits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EducationalUnits",
                table: "EducationalUnits");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "EmplEducationalUnits");

            migrationBuilder.RenameTable(
                name: "Specialties",
                newName: "Specialty");

            migrationBuilder.RenameTable(
                name: "Positions",
                newName: "Position");

            migrationBuilder.RenameTable(
                name: "FacultySpecialties",
                newName: "FacultySpecialty");

            migrationBuilder.RenameTable(
                name: "EmplPosHistories",
                newName: "EmplPosHistory");

            migrationBuilder.RenameTable(
                name: "EmplEducationalUnits",
                newName: "EmplEducationalUnit");

            migrationBuilder.RenameTable(
                name: "EducationalUnits",
                newName: "EducationalUnit");

            migrationBuilder.RenameIndex(
                name: "IX_FacultySpecialties_SpecialtyId",
                table: "FacultySpecialty",
                newName: "IX_FacultySpecialty_SpecialtyId");

            migrationBuilder.RenameIndex(
                name: "IX_FacultySpecialties_FacultyId",
                table: "FacultySpecialty",
                newName: "IX_FacultySpecialty_FacultyId");

            migrationBuilder.RenameIndex(
                name: "IX_EmplPosHistories_PositionId",
                table: "EmplPosHistory",
                newName: "IX_EmplPosHistory_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_EmplPosHistories_FacultyId",
                table: "EmplPosHistory",
                newName: "IX_EmplPosHistory_FacultyId");

            migrationBuilder.RenameIndex(
                name: "IX_EmplPosHistories_EmployeeId",
                table: "EmplPosHistory",
                newName: "IX_EmplPosHistory_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmplEducationalUnits_EmployeeId",
                table: "EmplEducationalUnit",
                newName: "IX_EmplEducationalUnit_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmplEducationalUnits_EducationalUnitId",
                table: "EmplEducationalUnit",
                newName: "IX_EmplEducationalUnit_EducationalUnitId");

            migrationBuilder.AddColumn<int>(
                name: "ListOfEducationsId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specialty",
                table: "Specialty",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Position",
                table: "Position",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FacultySpecialty",
                table: "FacultySpecialty",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmplPosHistory",
                table: "EmplPosHistory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmplEducationalUnit",
                table: "EmplEducationalUnit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EducationalUnit",
                table: "EducationalUnit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ListOfEducationsId",
                table: "Employees",
                column: "ListOfEducationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmplEducationalUnit_EducationalUnit_EducationalUnitId",
                table: "EmplEducationalUnit",
                column: "EducationalUnitId",
                principalTable: "EducationalUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmplEducationalUnit_Employees_EmployeeId",
                table: "EmplEducationalUnit",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ListOfEducations_ListOfEducationsId",
                table: "Employees",
                column: "ListOfEducationsId",
                principalTable: "ListOfEducations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmplPosHistory_Employees_EmployeeId",
                table: "EmplPosHistory",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmplPosHistory_Faculties_FacultyId",
                table: "EmplPosHistory",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmplPosHistory_Position_PositionId",
                table: "EmplPosHistory",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FacultySpecialty_Faculties_FacultyId",
                table: "FacultySpecialty",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FacultySpecialty_Specialty_SpecialtyId",
                table: "FacultySpecialty",
                column: "SpecialtyId",
                principalTable: "Specialty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
