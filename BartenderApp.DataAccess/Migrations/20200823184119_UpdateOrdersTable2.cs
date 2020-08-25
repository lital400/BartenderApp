using Microsoft.EntityFrameworkCore.Migrations;

namespace BartenderApp.DataAccess.Migrations
{
    public partial class UpdateOrdersTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Cocktails_CocktailId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CocktailId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CocktailId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "CocktailName",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CocktailName",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "CocktailId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CocktailId",
                table: "Orders",
                column: "CocktailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Cocktails_CocktailId",
                table: "Orders",
                column: "CocktailId",
                principalTable: "Cocktails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
