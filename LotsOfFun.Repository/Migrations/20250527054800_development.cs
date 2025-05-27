using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LotsOfFun.Repository.Migrations
{
    /// <inheritdoc />
    public partial class development : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Location_LocationId",
                table: "Activity");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Activity",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Location_LocationId",
                table: "Activity",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Location_LocationId",
                table: "Activity");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Activity",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Location_LocationId",
                table: "Activity",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
