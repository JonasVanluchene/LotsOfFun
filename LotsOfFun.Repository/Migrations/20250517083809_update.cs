using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LotsOfFun.Repository.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_Street",
                table: "Person",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "Address_PostalCode",
                table: "Person",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "Address_Number",
                table: "Person",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "Person",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "Address_Street",
                table: "Activity",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "Address_PostalCode",
                table: "Activity",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "Address_Number",
                table: "Activity",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "Activity",
                newName: "City");

            migrationBuilder.AddColumn<string>(
                name: "UnitNumber",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnitNumber",
                table: "Activity",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitNumber",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "UnitNumber",
                table: "Activity");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Person",
                newName: "Address_Street");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Person",
                newName: "Address_PostalCode");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Person",
                newName: "Address_Number");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Person",
                newName: "Address_City");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Activity",
                newName: "Address_Street");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Activity",
                newName: "Address_PostalCode");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Activity",
                newName: "Address_Number");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Activity",
                newName: "Address_City");
        }
    }
}
