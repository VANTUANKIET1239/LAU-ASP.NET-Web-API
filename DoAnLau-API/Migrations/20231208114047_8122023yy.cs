using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnLau_API.Migrations
{
    /// <inheritdoc />
    public partial class _8122023yy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchReservationTime_ReservationTime_branch_Id",
                table: "BranchReservationTime");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_CustomerSize_customerSize_Id",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ReservationTime_reservationTime_Id",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationTime",
                table: "ReservationTime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerSize",
                table: "CustomerSize");

            migrationBuilder.RenameTable(
                name: "ReservationTime",
                newName: "ReservationTimes");

            migrationBuilder.RenameTable(
                name: "CustomerSize",
                newName: "CustomerSizes");

            migrationBuilder.AlterColumn<string>(
                name: "customerSize_Id",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationTimes",
                table: "ReservationTimes",
                column: "reservationTime_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerSizes",
                table: "CustomerSizes",
                column: "customerSize_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchReservationTime_ReservationTimes_branch_Id",
                table: "BranchReservationTime",
                column: "branch_Id",
                principalTable: "ReservationTimes",
                principalColumn: "reservationTime_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_CustomerSizes_customerSize_Id",
                table: "Reservations",
                column: "customerSize_Id",
                principalTable: "CustomerSizes",
                principalColumn: "customerSize_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ReservationTimes_reservationTime_Id",
                table: "Reservations",
                column: "reservationTime_Id",
                principalTable: "ReservationTimes",
                principalColumn: "reservationTime_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchReservationTime_ReservationTimes_branch_Id",
                table: "BranchReservationTime");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_CustomerSizes_customerSize_Id",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ReservationTimes_reservationTime_Id",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationTimes",
                table: "ReservationTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerSizes",
                table: "CustomerSizes");

            migrationBuilder.RenameTable(
                name: "ReservationTimes",
                newName: "ReservationTime");

            migrationBuilder.RenameTable(
                name: "CustomerSizes",
                newName: "CustomerSize");

            migrationBuilder.AlterColumn<string>(
                name: "customerSize_Id",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationTime",
                table: "ReservationTime",
                column: "reservationTime_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerSize",
                table: "CustomerSize",
                column: "customerSize_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchReservationTime_ReservationTime_branch_Id",
                table: "BranchReservationTime",
                column: "branch_Id",
                principalTable: "ReservationTime",
                principalColumn: "reservationTime_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_CustomerSize_customerSize_Id",
                table: "Reservations",
                column: "customerSize_Id",
                principalTable: "CustomerSize",
                principalColumn: "customerSize_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ReservationTime_reservationTime_Id",
                table: "Reservations",
                column: "reservationTime_Id",
                principalTable: "ReservationTime",
                principalColumn: "reservationTime_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
