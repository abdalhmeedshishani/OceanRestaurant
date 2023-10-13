using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OceanRestaurant.EF.Core.Migrations
{
    /// <inheritdoc />
    public partial class CorrectedTheSpellingOfCookingMethodInOrderEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CockingMethod",
                table: "Orders",
                newName: "CoockingMethod");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoockingMethod",
                table: "Orders",
                newName: "CockingMethod");
        }
    }
}
