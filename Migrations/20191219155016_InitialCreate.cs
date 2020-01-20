using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemWspomagania.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameCompany = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PhoneNr = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Soldiers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(nullable: true),
                    Usersurname = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Pesel = table.Column<long>(nullable: false),
                    PhoneNr = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soldiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Soldiers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Leaves",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateLeave = table.Column<DateTime>(nullable: false),
                    DateReturn = table.Column<DateTime>(nullable: false),
                    Where = table.Column<string>(nullable: true),
                    Annotation = table.Column<string>(nullable: true),
                    Typ = table.Column<string>(nullable: true),
                    SoldierId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leaves_Soldiers_SoldierId",
                        column: x => x.SoldierId,
                        principalTable: "Soldiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Seria = table.Column<string>(nullable: true),
                    SoldierId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weapons_Soldiers_SoldierId",
                        column: x => x.SoldierId,
                        principalTable: "Soldiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IssueWeapons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateIssue = table.Column<DateTime>(nullable: false),
                    DateReturn = table.Column<DateTime>(nullable: false),
                    Stan = table.Column<string>(nullable: true),
                    WeaponId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueWeapons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueWeapons_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssueWeapons_WeaponId",
                table: "IssueWeapons",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_SoldierId",
                table: "Leaves",
                column: "SoldierId");

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_CompanyId",
                table: "Soldiers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_SoldierId",
                table: "Weapons",
                column: "SoldierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueWeapons");

            migrationBuilder.DropTable(
                name: "Leaves");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "Soldiers");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
