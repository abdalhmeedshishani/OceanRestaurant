using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OceanRestaurant.EF.Core.Migrations
{
    /// <inheritdoc />
    public partial class changed_props_names_DishDeatilsProp_and_DishPriceProp_To_Details_and_Price_in_dish_entity_and_dishDto_DishListDto_and_dishDeatilsDto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DishPrice",
                table: "Dishes",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "DishDetails",
                table: "Dishes",
                newName: "Details");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Dishes",
                newName: "DishPrice");

            migrationBuilder.RenameColumn(
                name: "Details",
                table: "Dishes",
                newName: "DishDetails");
        }
    }
}
