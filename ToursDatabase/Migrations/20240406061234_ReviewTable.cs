using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToursDatabase.Migrations
{
    /// <inheritdoc />
    public partial class ReviewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "CreateDate", "Rating", "ReviewDetail", "TourId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("ac92c4cc-ce06-4397-88b0-e55434c67f6c"), new DateTime(2024, 4, 6, 11, 42, 34, 373, DateTimeKind.Local).AddTicks(4798), 5.0, "Amazing experience!", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 6, 11, 42, 34, 373, DateTimeKind.Local).AddTicks(4799) },
                    { new Guid("c2e0753e-39f2-4b94-9f9e-f6dc3e969c62"), new DateTime(2024, 4, 6, 11, 42, 34, 373, DateTimeKind.Local).AddTicks(4761), 4.5, "Great tour!", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 6, 11, 42, 34, 373, DateTimeKind.Local).AddTicks(4777) }
                });

            migrationBuilder.UpdateData(
                table: "TourBookings",
                keyColumn: "BookingID",
                keyValue: new Guid("ce12bfbd-465e-43a5-8576-65d5f1fe1e16"),
                columns: new[] { "BookingDate", "CreateDate", "TourDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 6, 11, 42, 34, 373, DateTimeKind.Local).AddTicks(5093), new DateTime(2024, 4, 6, 11, 42, 34, 373, DateTimeKind.Local).AddTicks(5098), new DateTime(2024, 4, 13, 11, 42, 34, 373, DateTimeKind.Local).AddTicks(5094), new DateTime(2024, 4, 6, 11, 42, 34, 373, DateTimeKind.Local).AddTicks(5099) });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "TourId",
                keyValue: new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"),
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 6, 11, 42, 34, 373, DateTimeKind.Local).AddTicks(5058), new DateTime(2024, 4, 6, 11, 42, 34, 373, DateTimeKind.Local).AddTicks(5059) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: new Guid("ac92c4cc-ce06-4397-88b0-e55434c67f6c"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: new Guid("c2e0753e-39f2-4b94-9f9e-f6dc3e969c62"));

            migrationBuilder.UpdateData(
                table: "TourBookings",
                keyColumn: "BookingID",
                keyValue: new Guid("ce12bfbd-465e-43a5-8576-65d5f1fe1e16"),
                columns: new[] { "BookingDate", "CreateDate", "TourDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 6, 11, 41, 56, 395, DateTimeKind.Local).AddTicks(3417), new DateTime(2024, 4, 6, 11, 41, 56, 395, DateTimeKind.Local).AddTicks(3422), new DateTime(2024, 4, 13, 11, 41, 56, 395, DateTimeKind.Local).AddTicks(3418), new DateTime(2024, 4, 6, 11, 41, 56, 395, DateTimeKind.Local).AddTicks(3423) });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "TourId",
                keyValue: new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"),
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 6, 11, 41, 56, 395, DateTimeKind.Local).AddTicks(3074), new DateTime(2024, 4, 6, 11, 41, 56, 395, DateTimeKind.Local).AddTicks(3088) });
        }
    }
}
