using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmeRazor.Migrations
{
    public partial class addPrecoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Genrero",
                table: "Filmes",
                newName: "Genero");

            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "Filmes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Filmes");

            migrationBuilder.RenameColumn(
                name: "Genero",
                table: "Filmes",
                newName: "Genrero");
        }
    }
}
