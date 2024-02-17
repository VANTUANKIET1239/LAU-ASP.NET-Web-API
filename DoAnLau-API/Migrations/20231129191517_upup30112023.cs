using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnLau_API.Migrations
{
    /// <inheritdoc />
    public partial class upup30112023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ward",
                table: "Branches",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: " nvarchar(20)");

            migrationBuilder.AlterColumn<int>(
                name: "district",
                table: "Branches",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: " nvarchar(20)");

            migrationBuilder.AlterColumn<int>(
                name: "city",
                table: "Branches",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ward",
                table: "Branches",
                type: " nvarchar(20)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "district",
                table: "Branches",
                type: " nvarchar(20)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "city",
                table: "Branches",
                type: "nvarchar(30)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
