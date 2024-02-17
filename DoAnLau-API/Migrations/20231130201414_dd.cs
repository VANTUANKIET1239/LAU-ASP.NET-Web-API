using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnLau_API.Migrations
{
    /// <inheritdoc />
    public partial class dd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromotionBranchs_Branches_promotion_Id",
                table: "PromotionBranchs");

            migrationBuilder.DropForeignKey(
                name: "FK_PromotionBranchs_Promotions_branch_Id",
                table: "PromotionBranchs");

            migrationBuilder.AddForeignKey(
                name: "FK_PromotionBranchs_Branches_branch_Id",
                table: "PromotionBranchs",
                column: "branch_Id",
                principalTable: "Branches",
                principalColumn: "branch_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PromotionBranchs_Promotions_promotion_Id",
                table: "PromotionBranchs",
                column: "promotion_Id",
                principalTable: "Promotions",
                principalColumn: "promotion_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromotionBranchs_Branches_branch_Id",
                table: "PromotionBranchs");

            migrationBuilder.DropForeignKey(
                name: "FK_PromotionBranchs_Promotions_promotion_Id",
                table: "PromotionBranchs");

            migrationBuilder.AddForeignKey(
                name: "FK_PromotionBranchs_Branches_promotion_Id",
                table: "PromotionBranchs",
                column: "promotion_Id",
                principalTable: "Branches",
                principalColumn: "branch_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PromotionBranchs_Promotions_branch_Id",
                table: "PromotionBranchs",
                column: "branch_Id",
                principalTable: "Promotions",
                principalColumn: "promotion_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
