using Microsoft.EntityFrameworkCore.Migrations;

namespace AisMKIT.Migrations
{
    public partial class ObnovlenieModelei2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmplPosHistory_ListEmployees_EmployeeId",
                table: "EmplPosHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_EmplPosHistory_ListFaculties_FacultyId",
                table: "EmplPosHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ListEmployees_ListOfEducations_ListOfEducationsId",
                table: "ListEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_ListFaculties_ListOfEducations_ListOfEducationsId",
                table: "ListFaculties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ListFaculties",
                table: "ListFaculties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ListEmployees",
                table: "ListEmployees");

            migrationBuilder.RenameTable(
                name: "ListFaculties",
                newName: "Faculties");

            migrationBuilder.RenameTable(
                name: "ListEmployees",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_ListFaculties_ListOfEducationsId",
                table: "Faculties",
                newName: "IX_Faculties_ListOfEducationsId");

            migrationBuilder.RenameIndex(
                name: "IX_ListEmployees_ListOfEducationsId",
                table: "Employees",
                newName: "IX_Employees_ListOfEducationsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Faculties",
                table: "Faculties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

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
                name: "FK_Faculties_ListOfEducations_ListOfEducationsId",
                table: "Faculties",
                column: "ListOfEducationsId",
                principalTable: "ListOfEducations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "FK_Faculties_ListOfEducations_ListOfEducationsId",
                table: "Faculties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Faculties",
                table: "Faculties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Faculties",
                newName: "ListFaculties");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "ListEmployees");

            migrationBuilder.RenameIndex(
                name: "IX_Faculties_ListOfEducationsId",
                table: "ListFaculties",
                newName: "IX_ListFaculties_ListOfEducationsId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ListOfEducationsId",
                table: "ListEmployees",
                newName: "IX_ListEmployees_ListOfEducationsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListFaculties",
                table: "ListFaculties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListEmployees",
                table: "ListEmployees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmplPosHistory_ListEmployees_EmployeeId",
                table: "EmplPosHistory",
                column: "EmployeeId",
                principalTable: "ListEmployees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmplPosHistory_ListFaculties_FacultyId",
                table: "EmplPosHistory",
                column: "FacultyId",
                principalTable: "ListFaculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListEmployees_ListOfEducations_ListOfEducationsId",
                table: "ListEmployees",
                column: "ListOfEducationsId",
                principalTable: "ListOfEducations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListFaculties_ListOfEducations_ListOfEducationsId",
                table: "ListFaculties",
                column: "ListOfEducationsId",
                principalTable: "ListOfEducations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
