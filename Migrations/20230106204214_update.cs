using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientsDb.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Good_name",
                table: "Orders",
                newName: "Name");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Orders",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Orders",
                newName: "Good_name");
        }
    }
}
