using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToursDatabase.Migrations
{
    /// <inheritdoc />
    public partial class Reviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("f77b8397-8467-4291-9698-155c20a70a68"));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("7209f8df-5d18-4279-a03d-707624fb86bb"),
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 10, 15, 55, 35, 403, DateTimeKind.Local).AddTicks(3360), new DateTime(2024, 4, 10, 15, 55, 35, 403, DateTimeKind.Local).AddTicks(3361) });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Address", "CreateDate", "Description", "Latitude", "Longitude", "Name", "TourId", "UpdateDate" },
                values: new object[] { new Guid("b0fbfde6-1c23-429c-b1aa-573a09ea7eb0"), "456 Road, City, Country", new DateTime(2024, 4, 10, 15, 55, 35, 403, DateTimeKind.Local).AddTicks(3367), "that is first street of place", 40.712800000000001, -74.006, "NYC Cruise by Circle Line", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 10, 15, 55, 35, 403, DateTimeKind.Local).AddTicks(3367) });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "CreateDate", "Rating", "ReviewDetail", "TourId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("9470bb12-0edc-4f45-9cab-2236b8c26c9e"), new DateTime(2024, 4, 10, 15, 55, 35, 403, DateTimeKind.Local).AddTicks(3127), 4.5, "Great tour!", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 10, 15, 55, 35, 403, DateTimeKind.Local).AddTicks(3140) },
                    { new Guid("f4ac192d-3fee-4ebc-aca7-e12ad3d241d8"), new DateTime(2024, 4, 10, 15, 55, 35, 403, DateTimeKind.Local).AddTicks(3146), 5.0, "Amazing experience!", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 10, 15, 55, 35, 403, DateTimeKind.Local).AddTicks(3146) }
                });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "TourId",
                keyValue: new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"),
                columns: new[] { "CreateDate", "TourDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 10, 15, 55, 35, 403, DateTimeKind.Local).AddTicks(3519), new DateTime(2024, 4, 10, 10, 25, 35, 403, DateTimeKind.Utc).AddTicks(3502), new DateTime(2024, 4, 10, 15, 55, 35, 403, DateTimeKind.Local).AddTicks(3520) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("b0fbfde6-1c23-429c-b1aa-573a09ea7eb0"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: new Guid("9470bb12-0edc-4f45-9cab-2236b8c26c9e"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: new Guid("f4ac192d-3fee-4ebc-aca7-e12ad3d241d8"));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("7209f8df-5d18-4279-a03d-707624fb86bb"),
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 10, 15, 54, 59, 727, DateTimeKind.Local).AddTicks(9745), new DateTime(2024, 4, 10, 15, 54, 59, 727, DateTimeKind.Local).AddTicks(9756) });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Address", "CreateDate", "Description", "Latitude", "Longitude", "Name", "TourId", "UpdateDate" },
                values: new object[] { new Guid("f77b8397-8467-4291-9698-155c20a70a68"), "456 Road, City, Country", new DateTime(2024, 4, 10, 15, 54, 59, 727, DateTimeKind.Local).AddTicks(9762), "that is first street of place", 40.712800000000001, -74.006, "NYC Cruise by Circle Line", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 10, 15, 54, 59, 727, DateTimeKind.Local).AddTicks(9762) });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "TourId",
                keyValue: new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"),
                columns: new[] { "CreateDate", "TourDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 10, 15, 54, 59, 727, DateTimeKind.Local).AddTicks(9986), new DateTime(2024, 4, 10, 10, 24, 59, 727, DateTimeKind.Utc).AddTicks(9972), new DateTime(2024, 4, 10, 15, 54, 59, 727, DateTimeKind.Local).AddTicks(9987) });
        }
    }
}
