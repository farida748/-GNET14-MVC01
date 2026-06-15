using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManagment.Migrations
{
    /// <inheritdoc />
    public partial class Addplanstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Plan",
                table: "Plan");

            migrationBuilder.RenameTable(
                name: "Plan",
                newName: "Plans");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plans",
                table: "Plans",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Plans",
                table: "Plans");

            migrationBuilder.RenameTable(
                name: "Plans",
                newName: "Plan");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plan",
                table: "Plan",
                column: "id");
        }
    }
}
