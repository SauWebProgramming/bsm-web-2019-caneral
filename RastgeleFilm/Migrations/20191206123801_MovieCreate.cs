using Microsoft.EntityFrameworkCore.Migrations;

namespace RastgeleFilm.Migrations
{
    public partial class MovieCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filmler",
                columns: table => new
                {
                    FilmId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmAd = table.Column<string>(type: "varchar(200)", nullable: false),
                    FilmTur = table.Column<string>(type: "varchar(100)", nullable: false),
                    FilmPuan = table.Column<double>(type: "float", nullable: false),
                    FilmKategori = table.Column<bool>(type: "bit", nullable: false),
                    ResimYolu = table.Column<string>(type: "varchar(400)", nullable: false),
                    VideoYolu = table.Column<string>(type: "varchar(400)", nullable: false),
                    FilmAciklama = table.Column<string>(type: "varchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmler", x => x.FilmId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmler");
        }
    }
}
