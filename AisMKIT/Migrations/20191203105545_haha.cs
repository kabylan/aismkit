using Microsoft.EntityFrameworkCore.Migrations;

namespace AisMKIT.Migrations
{
    public partial class haha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Awards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    AwardDate = table.Column<string>(nullable: false),
                    DescMerit = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Awards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CultHeritages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ShortInfo = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Kind = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    Date = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CultHeritages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CultObjectsAndArts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ShortInfo = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Kind = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    Date = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CultObjectsAndArts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Libraries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Established = table.Column<string>(nullable: false),
                    GeneralBookFund = table.Column<string>(nullable: false),
                    NumberReaders = table.Column<int>(nullable: false),
                    NumberWorkers = table.Column<int>(nullable: false),
                    LibraryStat = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libraries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubInstitutions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TIN = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    LegalAddress = table.Column<string>(nullable: false),
                    Contact = table.Column<string>(nullable: false),
                    DomainEmail = table.Column<string>(nullable: false),
                    ShortInfo = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubInstitutions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AwardedPersons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    CardId = table.Column<string>(nullable: true),
                    AwardId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwardedPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AwardedPersons_Awards_AwardId",
                        column: x => x.AwardId,
                        principalTable: "Awards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AwardedPersons_AwardId",
                table: "AwardedPersons",
                column: "AwardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AwardedPersons");

            migrationBuilder.DropTable(
                name: "CultHeritages");

            migrationBuilder.DropTable(
                name: "CultObjectsAndArts");

            migrationBuilder.DropTable(
                name: "Libraries");

            migrationBuilder.DropTable(
                name: "SubInstitutions");

            migrationBuilder.DropTable(
                name: "Awards");
        }
    }
}
