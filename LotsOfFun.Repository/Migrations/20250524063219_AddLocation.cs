using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LotsOfFun.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "UnitNumber",
                table: "Activity");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Activity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_LocationId",
                table: "Activity",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Location_LocationId",
                table: "Activity",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Location_LocationId",
                table: "Activity");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Activity_LocationId",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Activity");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Activity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Activity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Activity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Activity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Activity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnitNumber",
                table: "Activity",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
