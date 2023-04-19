using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roditelj",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrTel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roditelj", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SkolaSporta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Broj = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkolaSporta", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Dete",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Godine = table.Column<int>(type: "int", nullable: false),
                    JMBG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RoditeljID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dete", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Dete_Roditelj_RoditeljID",
                        column: x => x.RoditeljID,
                        principalTable: "Roditelj",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sport",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrsta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaxBrojDece = table.Column<int>(type: "int", nullable: false),
                    TrenBrojDece = table.Column<int>(type: "int", nullable: false),
                    Cena = table.Column<int>(type: "int", nullable: false),
                    SkolaSportaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sport", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sport_SkolaSporta_SkolaSportaID",
                        column: x => x.SkolaSportaID,
                        principalTable: "SkolaSporta",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Spoj",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeteID = table.Column<int>(type: "int", nullable: true),
                    SportID = table.Column<int>(type: "int", nullable: true),
                    DatumUpisa = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spoj", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spoj_Dete_DeteID",
                        column: x => x.DeteID,
                        principalTable: "Dete",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Spoj_Sport_SportID",
                        column: x => x.SportID,
                        principalTable: "Sport",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dete_RoditeljID",
                table: "Dete",
                column: "RoditeljID");

            migrationBuilder.CreateIndex(
                name: "IX_Spoj_DeteID",
                table: "Spoj",
                column: "DeteID");

            migrationBuilder.CreateIndex(
                name: "IX_Spoj_SportID",
                table: "Spoj",
                column: "SportID");

            migrationBuilder.CreateIndex(
                name: "IX_Sport_SkolaSportaID",
                table: "Sport",
                column: "SkolaSportaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spoj");

            migrationBuilder.DropTable(
                name: "Dete");

            migrationBuilder.DropTable(
                name: "Sport");

            migrationBuilder.DropTable(
                name: "Roditelj");

            migrationBuilder.DropTable(
                name: "SkolaSporta");
        }
    }
}
