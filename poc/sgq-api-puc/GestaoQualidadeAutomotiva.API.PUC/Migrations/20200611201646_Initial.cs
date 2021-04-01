using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoQualidadeAutomotiva.API.PUC.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Norma",
                columns: table => new
                {
                    NormaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(nullable: true),
                    DataPublicacao = table.Column<DateTime>(nullable: false),
                    Comite = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Organismo = table.Column<string>(nullable: true),
                    Objetivo = table.Column<string>(nullable: true),
                    UrlDocumento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Norma", x => x.NormaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Norma");
        }
    }
}
