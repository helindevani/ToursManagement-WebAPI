using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToursDatabase.Migrations
{
    /// <inheritdoc />
    public partial class Images : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "CreateDate", "FileDescription", "FileExtension", "FileName", "FilePath", "FileSizeInBytes", "TourId", "UpdateDate" },
                values: new object[] { new Guid("f4efc921-21b9-4425-81bd-6c47081107a2"), new DateTime(2024, 4, 10, 15, 56, 12, 329, DateTimeKind.Local).AddTicks(3129), "An example image", ".jpg", "example.jpg", "/Images/example.jpg", 1024L, new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 10, 15, 56, 12, 329, DateTimeKind.Local).AddTicks(3130) });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("7209f8df-5d18-4279-a03d-707624fb86bb"),
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 10, 15, 56, 12, 329, DateTimeKind.Local).AddTicks(3047), new DateTime(2024, 4, 10, 15, 56, 12, 329, DateTimeKind.Local).AddTicks(3047) });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Address", "CreateDate", "Description", "Latitude", "Longitude", "Name", "TourId", "UpdateDate" },
                values: new object[] { new Guid("0a2a8a1c-8be0-42c3-8c67-646822c797fb"), "456 Road, City, Country", new DateTime(2024, 4, 10, 15, 56, 12, 329, DateTimeKind.Local).AddTicks(3067), "that is first street of place", 40.712800000000001, -74.006, "NYC Cruise by Circle Line", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 10, 15, 56, 12, 329, DateTimeKind.Local).AddTicks(3068) });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "CreateDate", "Rating", "ReviewDetail", "TourId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("14427b55-d956-4f28-a4f9-d2b69657846e"), new DateTime(2024, 4, 10, 15, 56, 12, 329, DateTimeKind.Local).AddTicks(2880), 5.0, "Amazing experience!", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 10, 15, 56, 12, 329, DateTimeKind.Local).AddTicks(2881) },
                    { new Guid("463ea699-7776-4a01-9ec9-dfb200e986b8"), new DateTime(2024, 4, 10, 15, 56, 12, 329, DateTimeKind.Local).AddTicks(2863), 4.5, "Great tour!", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 10, 15, 56, 12, 329, DateTimeKind.Local).AddTicks(2875) }
                });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "TourId",
                keyValue: new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"),
                columns: new[] { "CreateDate", "TourDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 10, 15, 56, 12, 329, DateTimeKind.Local).AddTicks(3104), new DateTime(2024, 4, 10, 10, 26, 12, 329, DateTimeKind.Utc).AddTicks(3089), new DateTime(2024, 4, 10, 15, 56, 12, 329, DateTimeKind.Local).AddTicks(3105) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("f4efc921-21b9-4425-81bd-6c47081107a2"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("0a2a8a1c-8be0-42c3-8c67-646822c797fb"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: new Guid("14427b55-d956-4f28-a4f9-d2b69657846e"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: new Guid("463ea699-7776-4a01-9ec9-dfb200e986b8"));

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
    }
}
