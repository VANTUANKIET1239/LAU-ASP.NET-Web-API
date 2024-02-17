using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnLau_API.Migrations
{
    /// <inheritdoc />
    public partial class updatefluentAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromotionUsers_AspNetUsers_promotion_Id",
                table: "PromotionUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PromotionUsers_Promotions_user_Id",
                table: "PromotionUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_PromotionUsers_AspNetUsers_user_Id",
                table: "PromotionUsers",
                column: "user_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PromotionUsers_Promotions_promotion_Id",
                table: "PromotionUsers",
                column: "promotion_Id",
                principalTable: "Promotions",
                principalColumn: "promotion_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromotionUsers_AspNetUsers_user_Id",
                table: "PromotionUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PromotionUsers_Promotions_promotion_Id",
                table: "PromotionUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_PromotionUsers_AspNetUsers_promotion_Id",
                table: "PromotionUsers",
                column: "promotion_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PromotionUsers_Promotions_user_Id",
                table: "PromotionUsers",
                column: "user_Id",
                principalTable: "Promotions",
                principalColumn: "promotion_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
