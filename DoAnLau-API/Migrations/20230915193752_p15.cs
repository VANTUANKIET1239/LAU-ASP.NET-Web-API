using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnLau_API.Migrations
{
    /// <inheritdoc />
    public partial class p15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "XaPhuong");

            migrationBuilder.DropTable(
                name: "QuanHuyen");

            migrationBuilder.DropTable(
                name: "TinhThanhPho");

            migrationBuilder.DropTable(
                name: "QuocGia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuocGia",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    tenQuocGia = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuocGia", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TinhThanhPho",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    quocGiaID = table.Column<int>(type: "int", nullable: false),
                    tenTinhThanhPho = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhThanhPho", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TinhThanhPho_QuocGia_quocGiaID",
                        column: x => x.quocGiaID,
                        principalTable: "QuocGia",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuanHuyen",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    tinhThanhPhoID = table.Column<int>(type: "int", nullable: false),
                    tenQuanHuyen = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanHuyen", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QuanHuyen_TinhThanhPho_tinhThanhPhoID",
                        column: x => x.tinhThanhPhoID,
                        principalTable: "TinhThanhPho",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "XaPhuong",
                columns: table => new
                {
                    ward_Id = table.Column<int>(type: "int", nullable: false),
                    quanHuyenID = table.Column<int>(type: "int", nullable: false),
                    tenXaPhuong = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XaPhuong", x => x.ward_Id);
                    table.ForeignKey(
                        name: "FK_XaPhuong_QuanHuyen_quanHuyenID",
                        column: x => x.quanHuyenID,
                        principalTable: "QuanHuyen",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuanHuyen_tinhThanhPhoID",
                table: "QuanHuyen",
                column: "tinhThanhPhoID");

            migrationBuilder.CreateIndex(
                name: "IX_TinhThanhPho_quocGiaID",
                table: "TinhThanhPho",
                column: "quocGiaID");

            migrationBuilder.CreateIndex(
                name: "IX_XaPhuong_quanHuyenID",
                table: "XaPhuong",
                column: "quanHuyenID");
        }
    }
}
