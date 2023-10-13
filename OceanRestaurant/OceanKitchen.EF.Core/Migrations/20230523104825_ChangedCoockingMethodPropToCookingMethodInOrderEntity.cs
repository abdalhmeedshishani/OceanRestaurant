using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OceanRestaurant.EF.Core.Migrations
{
    /// <inheritdoc />
    public partial class ChangedCoockingMethodPropToCookingMethodInOrderEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoockingMethod",
                table: "Orders",
                newName: "CookingMethod");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CookingMethod",
                table: "Orders",
                newName: "CoockingMethod");
        }
    }
}
