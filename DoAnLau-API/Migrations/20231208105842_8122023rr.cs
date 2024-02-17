using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnLau_API.Migrations
{
    /// <inheritdoc />
    public partial class _8122023rr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "ReservationTime",
                newName: "time");

            migrationBuilder.RenameColumn(
                name: "ReservationDate",
                table: "Reservations",
                newName: "reservationDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "time",
                table: "ReservationTime",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "reservationDate",
                table: "Reservations",
                newName: "ReservationDate");
        }
    }
}
