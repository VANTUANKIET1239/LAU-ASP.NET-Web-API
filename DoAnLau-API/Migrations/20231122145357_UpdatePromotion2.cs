using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnLau_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePromotion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PromotionDetailPromotions");

            migrationBuilder.AddColumn<string>(
                name: "promotion_Id",
                table: "PromotionDetails",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionDetails_promotion_Id",
                table: "PromotionDetails",
                column: "promotion_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PromotionDetails_Promotions_promotion_Id",
                table: "PromotionDetails",
                column: "promotion_Id",
                principalTable: "Promotions",
                principalColumn: "promotion_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromotionDetails_Promotions_promotion_Id",
                table: "PromotionDetails");

            migrationBuilder.DropIndex(
                name: "IX_PromotionDetails_promotion_Id",
                table: "PromotionDetails");

            migrationBuilder.DropColumn(
                name: "promotion_Id",
                table: "PromotionDetails");

            migrationBuilder.CreateTable(
                name: "PromotionDetailPromotions",
                columns: table => new
                {
                    promotion_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    promotionDetail_Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionDetailPromotions", x => new { x.promotion_Id, x.promotionDetail_Id });
                    table.ForeignKey(
                        name: "FK_PromotionDetailPromotions_PromotionDetails_promotion_Id",
                        column: x => x.promotion_Id,
                        principalTable: "PromotionDetails",
                        principalColumn: "promotionDetail_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromotionDetailPromotions_Promotions_promotionDetail_Id",
                        column: x => x.promotionDetail_Id,
                        principalTable: "Promotions",
                        principalColumn: "promotion_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PromotionDetailPromotions_promotionDetail_Id",
                table: "PromotionDetailPromotions",
                column: "promotionDetail_Id");
        }
    }
}
