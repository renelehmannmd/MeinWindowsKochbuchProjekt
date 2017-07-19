using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeinWindowsKochbuchProjekt.Migrations
{
    public partial class M0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_kategorie",
                columns: table => new
                {
                    kat_id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    kat_beschreibung = table.Column<string>(nullable: false),
                    kat_name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_kategorie", x => x.kat_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_lebensmittel_kats",
                columns: table => new
                {
                    lk_id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    lk_beschreibung = table.Column<string>(nullable: true),
                    lk_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_lebensmittel_kats", x => x.lk_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_rezept",
                columns: table => new
                {
                    rez_id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    rez_beschreibung = table.Column<string>(nullable: false),
                    rez_name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_rezept", x => x.rez_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_lebensmittel",
                columns: table => new
                {
                    lm_id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    lm_beschreibung = table.Column<string>(nullable: true),
                    lm_informationen = table.Column<string>(nullable: true),
                    leka_id = table.Column<int>(nullable: false),
                    lm_name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_lebensmittel", x => x.lm_id);
                    table.ForeignKey(
                        name: "FK_tb_lebensmittel_tb_lebensmittel_kats_leka_id",
                        column: x => x.leka_id,
                        principalTable: "tb_lebensmittel_kats",
                        principalColumn: "lk_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_anleitung",
                columns: table => new
                {
                    al_id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    al_name = table.Column<string>(nullable: false),
                    al_zeit = table.Column<string>(nullable: false),
                    fk_rez_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_anleitung", x => x.al_id);
                    table.ForeignKey(
                        name: "FK_tb_anleitung_tb_rezept_fk_rez_id",
                        column: x => x.fk_rez_id,
                        principalTable: "tb_rezept",
                        principalColumn: "rez_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_rez_kat",
                columns: table => new
                {
                    fk_rez_id = table.Column<int>(nullable: false),
                    fk_kat_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_rez_kat", x => new { x.fk_rez_id, x.fk_kat_id });
                    table.ForeignKey(
                        name: "FK_tb_rez_kat_tb_kategorie_fk_kat_id",
                        column: x => x.fk_kat_id,
                        principalTable: "tb_kategorie",
                        principalColumn: "kat_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_rez_kat_tb_rezept_fk_rez_id",
                        column: x => x.fk_rez_id,
                        principalTable: "tb_rezept",
                        principalColumn: "rez_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_naehrwerttabelle",
                columns: table => new
                {
                    nwt_id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fk_lm_id = table.Column<int>(nullable: false),
                    nwt_alkoholgehalt = table.Column<double>(nullable: false),
                    nwt_balaststoffe = table.Column<double>(nullable: false),
                    nwt_brennwert = table.Column<double>(nullable: false),
                    nwt_fett = table.Column<double>(nullable: false),
                    nwt_grundmenge = table.Column<double>(nullable: false),
                    nwt_kohlenhydrate = table.Column<double>(nullable: false),
                    nwt_zuckergehalt = table.Column<double>(nullable: false),
                    nwt_eiweiss = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_naehrwerttabelle", x => x.nwt_id);
                    table.ForeignKey(
                        name: "FK_tb_naehrwerttabelle_tb_lebensmittel_fk_lm_id",
                        column: x => x.fk_lm_id,
                        principalTable: "tb_lebensmittel",
                        principalColumn: "lm_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_anleitung_fk_rez_id",
                table: "tb_anleitung",
                column: "fk_rez_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_lebensmittel_leka_id",
                table: "tb_lebensmittel",
                column: "leka_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_naehrwerttabelle_fk_lm_id",
                table: "tb_naehrwerttabelle",
                column: "fk_lm_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_rez_kat_fk_kat_id",
                table: "tb_rez_kat",
                column: "fk_kat_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_anleitung");

            migrationBuilder.DropTable(
                name: "tb_naehrwerttabelle");

            migrationBuilder.DropTable(
                name: "tb_rez_kat");

            migrationBuilder.DropTable(
                name: "tb_lebensmittel");

            migrationBuilder.DropTable(
                name: "tb_kategorie");

            migrationBuilder.DropTable(
                name: "tb_rezept");

            migrationBuilder.DropTable(
                name: "tb_lebensmittel_kats");
        }
    }
}
