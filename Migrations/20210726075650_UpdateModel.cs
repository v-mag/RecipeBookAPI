using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeBookAPI.Migrations
{
    public partial class UpdateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "time",
                table: "Recipes",
                newName: "servings");

            migrationBuilder.RenameColumn(
                name: "servingPersons",
                table: "Recipes",
                newName: "readyInMinutes");

            migrationBuilder.AddColumn<int>(
                name: "aggregateLikes",
                table: "Recipes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "healthScore",
                table: "Recipes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "instructions",
                table: "Recipes",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "aggregateLikes",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "healthScore",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "instructions",
                table: "Recipes");

            migrationBuilder.RenameColumn(
                name: "servings",
                table: "Recipes",
                newName: "time");

            migrationBuilder.RenameColumn(
                name: "readyInMinutes",
                table: "Recipes",
                newName: "servingPersons");
        }
    }
}
