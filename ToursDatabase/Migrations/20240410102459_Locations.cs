using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToursDatabase.Migrations
{
    /// <inheritdoc />
    public partial class Locations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Address", "CreateDate", "Description", "Latitude", "Longitude", "Name", "TourId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("7209f8df-5d18-4279-a03d-707624fb86bb"), "123 Street, City, Country", new DateTime(2024, 4, 10, 15, 54, 59, 727, DateTimeKind.Local).AddTicks(9745), "that is second street of place", 40.748817000000003, -73.985427999999999, "New York State Building Observatory", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 10, 15, 54, 59, 727, DateTimeKind.Local).AddTicks(9756) },
                    { new Guid("f77b8397-8467-4291-9698-155c20a70a68"), "456 Road, City, Country", new DateTime(2024, 4, 10, 15, 54, 59, 727, DateTimeKind.Local).AddTicks(9762), "that is first street of place", 40.712800000000001, -74.006, "NYC Cruise by Circle Line", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 10, 15, 54, 59, 727, DateTimeKind.Local).AddTicks(9762) }
                });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "TourId",
                keyValue: new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"),
                columns: new[] { "CreateDate", "TourDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 10, 15, 54, 59, 727, DateTimeKind.Local).AddTicks(9986), new DateTime(2024, 4, 10, 10, 24, 59, 727, DateTimeKind.Utc).AddTicks(9972), new DateTime(2024, 4, 10, 15, 54, 59, 727, DateTimeKind.Local).AddTicks(9987) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("7209f8df-5d18-4279-a03d-707624fb86bb"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("f77b8397-8467-4291-9698-155c20a70a68"));

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "TourId",
                keyValue: new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"),
                columns: new[] { "CreateDate", "TourDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 10, 15, 53, 40, 133, DateTimeKind.Local).AddTicks(4243), new DateTime(2024, 4, 10, 10, 23, 40, 133, DateTimeKind.Utc).AddTicks(4232), new DateTime(2024, 4, 10, 15, 53, 40, 133, DateTimeKind.Local).AddTicks(4255) });
        }
    }
}
