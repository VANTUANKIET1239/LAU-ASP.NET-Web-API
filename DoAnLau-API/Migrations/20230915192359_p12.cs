using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnLau_API.Migrations
{
    /// <inheritdoc />
    public partial class p12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    tenQuocGia = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    tenTinhThanhPho = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    quocGiaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_quocGiaID",
                        column: x => x.quocGiaID,
                        principalTable: "Countries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    tenQuanHuyen = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    tinhThanhPhoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Districts_Cities_tinhThanhPhoID",
                        column: x => x.tinhThanhPhoID,
                        principalTable: "Cities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wards",
                columns: table => new
                {
                    ward_Id = table.Column<int>(type: "int", nullable: false),
                    tenXaPhuong = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    quanHuyenID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wards", x => x.ward_Id);
                    table.ForeignKey(
                        name: "FK_Wards_Districts_quanHuyenID",
                        column: x => x.quanHuyenID,
                        principalTable: "Districts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_quocGiaID",
                table: "Cities",
                column: "quocGiaID");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_tinhThanhPhoID",
                table: "Districts",
                column: "tinhThanhPhoID");

            migrationBuilder.CreateIndex(
                name: "IX_Wards_quanHuyenID",
                table: "Wards",
                column: "quanHuyenID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wards");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
