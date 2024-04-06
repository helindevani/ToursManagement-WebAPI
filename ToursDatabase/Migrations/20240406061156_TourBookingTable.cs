using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToursDatabase.Migrations
{
    /// <inheritdoc />
    public partial class TourBookingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TourBookings",
                columns: new[] { "BookingID", "BookingDate", "CreateDate", "CustomerEmail", "CustomerName", "Status", "TourDate", "TourId", "UpdateDate" },
                values: new object[] { new Guid("ce12bfbd-465e-43a5-8576-65d5f1fe1e16"), new DateTime(2024, 4, 6, 11, 41, 56, 395, DateTimeKind.Local).AddTicks(3417), new DateTime(2024, 4, 6, 11, 41, 56, 395, DateTimeKind.Local).AddTicks(3422), "john@example.com", "John Doe", 1, new DateTime(2024, 4, 13, 11, 41, 56, 395, DateTimeKind.Local).AddTicks(3418), new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 6, 11, 41, 56, 395, DateTimeKind.Local).AddTicks(3423) });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "TourId",
                keyValue: new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"),
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 6, 11, 41, 56, 395, DateTimeKind.Local).AddTicks(3074), new DateTime(2024, 4, 6, 11, 41, 56, 395, DateTimeKind.Local).AddTicks(3088) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TourBookings",
                keyColumn: "BookingID",
                keyValue: new Guid("ce12bfbd-465e-43a5-8576-65d5f1fe1e16"));

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "TourId",
                keyValue: new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"),
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 6, 11, 41, 6, 304, DateTimeKind.Local).AddTicks(4570), new DateTime(2024, 4, 6, 11, 41, 6, 304, DateTimeKind.Local).AddTicks(4586) });
        }
    }
}
