using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OceanRestaurant.EF.Core.Migrations
{
    public partial class RemovedCockingMethodFromDishEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CookingMethod",
                table: "Dishes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CookingMethod",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
