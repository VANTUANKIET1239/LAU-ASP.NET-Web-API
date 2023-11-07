using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnLau_API.Migrations
{
    /// <inheritdoc />
    public partial class p16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    tenTinhThanhPho = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    quocGiaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhThanhPho", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TinhThanhPho_QuocGia_quocGiaId",
                        column: x => x.quocGiaId,
                        principalTable: "QuocGia",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuanHuyen",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    tenQuanHuyen = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    tinhThanhPhoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanHuyen", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QuanHuyen_TinhThanhPho_tinhThanhPhoId",
                        column: x => x.tinhThanhPhoId,
                        principalTable: "TinhThanhPho",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "XaPhuong",
                columns: table => new
                {
                    ward_Id = table.Column<int>(type: "int", nullable: false),
                    tenXaPhuong = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    quanHuyenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XaPhuong", x => x.ward_Id);
                    table.ForeignKey(
                        name: "FK_XaPhuong_QuanHuyen_quanHuyenId",
                        column: x => x.quanHuyenId,
                        principalTable: "QuanHuyen",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuanHuyen_tinhThanhPhoId",
                table: "QuanHuyen",
                column: "tinhThanhPhoId");

            migrationBuilder.CreateIndex(
                name: "IX_TinhThanhPho_quocGiaId",
                table: "TinhThanhPho",
                column: "quocGiaId");

            migrationBuilder.CreateIndex(
                name: "IX_XaPhuong_quanHuyenId",
                table: "XaPhuong",
                column: "quanHuyenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
