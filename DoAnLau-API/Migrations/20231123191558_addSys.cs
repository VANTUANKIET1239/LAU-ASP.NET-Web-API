using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnLau_API.Migrations
{
    /// <inheritdoc />
    public partial class addSys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SYS_INDices",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    prefix = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    currentIndex = table.Column<int>(type: "int", nullable: false),
                    nameIndex = table.Column<string>(type: " nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_INDices", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SYS_INDices");
        }
    }
}
