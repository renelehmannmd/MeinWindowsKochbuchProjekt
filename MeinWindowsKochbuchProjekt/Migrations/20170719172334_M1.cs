using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeinWindowsKochbuchProjekt.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_bilder",
                columns: table => new
                {
                    bild_id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    bild_blob = table.Column<byte[]>(nullable: true),
                    lm_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_bilder", x => x.bild_id);
                    table.ForeignKey(
                        name: "FK_tb_bilder_tb_lebensmittel_lm_id",
                        column: x => x.lm_id,
                        principalTable: "tb_lebensmittel",
                        principalColumn: "lm_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_bilder_lm_id",
                table: "tb_bilder",
                column: "lm_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_bilder");
        }
    }
}
