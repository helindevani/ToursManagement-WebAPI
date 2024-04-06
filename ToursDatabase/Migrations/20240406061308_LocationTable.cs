using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToursDatabase.Migrations
{
    /// <inheritdoc />
    public partial class LocationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: new Guid("ac92c4cc-ce06-4397-88b0-e55434c67f6c"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: new Guid("c2e0753e-39f2-4b94-9f9e-f6dc3e969c62"));

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Address", "CreateDate", "Latitude", "Longitude", "Name", "TourId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("198213f1-c03d-4cc6-820e-598de9a0ed30"), "123 Street, City, Country", new DateTime(2024, 4, 6, 11, 43, 8, 666, DateTimeKind.Local).AddTicks(2051), 40.748817000000003, -73.985427999999999, "Empire State Building Observatory", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 6, 11, 43, 8, 666, DateTimeKind.Local).AddTicks(2054) },
                    { new Guid("cc977efd-7574-441a-ad05-c28721735e95"), "456 Road, City, Country", new DateTime(2024, 4, 6, 11, 43, 8, 666, DateTimeKind.Local).AddTicks(2082), 40.712800000000001, -74.006, "NYC Cruise by Circle Line", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 6, 11, 43, 8, 666, DateTimeKind.Local).AddTicks(2084) }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "CreateDate", "Rating", "ReviewDetail", "TourId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("6884587b-b9ef-40c9-bdc6-d55e7025aefe"), new DateTime(2024, 4, 6, 11, 43, 8, 666, DateTimeKind.Local).AddTicks(1585), 4.5, "Great tour!", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 6, 11, 43, 8, 666, DateTimeKind.Local).AddTicks(1597) },
                    { new Guid("8bbab493-3b98-4842-95aa-0d4f9f1a3119"), new DateTime(2024, 4, 6, 11, 43, 8, 666, DateTimeKind.Local).AddTicks(1608), 5.0, "Amazing experience!", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 6, 11, 43, 8, 666, DateTimeKind.Local).AddTicks(1609) }
                });

            migrationBuilder.UpdateData(
                table: "TourBookings",
                keyColumn: "BookingID",
                keyValue: new Guid("ce12bfbd-465e-43a5-8576-65d5f1fe1e16"),
                columns: new[] { "BookingDate", "CreateDate", "TourDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 6, 11, 43, 8, 666, DateTimeKind.Local).AddTicks(2184), new DateTime(2024, 4, 6, 11, 43, 8, 666, DateTimeKind.Local).AddTicks(2191), new DateTime(2024, 4, 13, 11, 43, 8, 666, DateTimeKind.Local).AddTicks(2186), new DateTime(2024, 4, 6, 11, 43, 8, 666, DateTimeKind.Local).AddTicks(2192) });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "TourId",
                keyValue: new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"),
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 6, 11, 43, 8, 666, DateTimeKind.Local).AddTicks(2133), new DateTime(2024, 4, 6, 11, 43, 8, 666, DateTimeKind.Local).AddTicks(2135) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("198213f1-c03d-4cc6-820e-598de9a0ed30"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("cc977efd-7574-441a-ad05-c28721735e95"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: new Guid("6884587b-b9ef-40c9-bdc6-d55e7025aefe"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: new Guid("8bbab493-3b98-4842-95aa-0d4f9f1a3119"));

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
    }
}
