using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnLau_API.Migrations
{
    /// <inheritdoc />
    public partial class updatePromotion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "validityPeriod",
                table: "Promotions");

            migrationBuilder.AddColumn<DateTime>(
                name: "createDate",
                table: "Promotions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createDate",
                table: "Promotions");

            migrationBuilder.AddColumn<string>(
                name: "validityPeriod",
                table: "Promotions",
                type: "varchar(80)",
                nullable: false,
                defaultValue: "");
        }
    }
}
