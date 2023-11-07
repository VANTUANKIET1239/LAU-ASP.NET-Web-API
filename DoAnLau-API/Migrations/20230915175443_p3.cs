using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnLau_API.Migrations
{
    /// <inheritdoc />
    public partial class p3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wards");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Cities");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    city_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    cityName = table.Column<string>(type: "nvarchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.city_Id);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    district_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    city_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    districtName = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.district_Id);
                    table.ForeignKey(
                        name: "FK_Districts_Cities_city_Id",
                        column: x => x.city_Id,
                        principalTable: "Cities",
                        principalColumn: "city_Id");
                });

            migrationBuilder.CreateTable(
                name: "Wards",
                columns: table => new
                {
                    ward_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    district_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    wardName = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wards", x => x.ward_Id);
                    table.ForeignKey(
                        name: "FK_Wards_Districts_district_Id",
                        column: x => x.district_Id,
                        principalTable: "Districts",
                        principalColumn: "district_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Districts_city_Id",
                table: "Districts",
                column: "city_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Wards_district_Id",
                table: "Wards",
                column: "district_Id");
        }
    }
}
