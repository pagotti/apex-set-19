using Microsoft.EntityFrameworkCore.Migrations;

namespace apexapp.Migrations
{
    public partial class produtosPreco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Preço",
                table: "Produtos",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Preço",
                table: "Produtos",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
