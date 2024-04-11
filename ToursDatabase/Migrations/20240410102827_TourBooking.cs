using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToursDatabase.Migrations
{
    /// <inheritdoc />
    public partial class TourBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "CreateDate", "FileDescription", "FileExtension", "FileName", "FilePath", "FileSizeInBytes", "TourId", "UpdateDate" },
                values: new object[] { new Guid("2bc55382-767e-48aa-95de-5f2dee853db8"), new DateTime(2024, 4, 10, 15, 58, 27, 500, DateTimeKind.Local).AddTicks(6472), "An example image", ".jpg", "example.jpg", "/Images/example.jpg", 1024L, new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 10, 15, 58, 27, 500, DateTimeKind.Local).AddTicks(6472) });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("7209f8df-5d18-4279-a03d-707624fb86bb"),
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 10, 15, 58, 27, 500, DateTimeKind.Local).AddTicks(6353), new DateTime(2024, 4, 10, 15, 58, 27, 500, DateTimeKind.Local).AddTicks(6354) });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Address", "CreateDate", "Description", "Latitude", "Longitude", "Name", "TourId", "UpdateDate" },
                values: new object[] { new Guid("909654dc-70be-487b-be37-a20be7652732"), "456 Road, City, Country", new DateTime(2024, 4, 10, 15, 58, 27, 500, DateTimeKind.Local).AddTicks(6373), "that is first street of place", 40.712800000000001, -74.006, "NYC Cruise by Circle Line", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 10, 15, 58, 27, 500, DateTimeKind.Local).AddTicks(6373) });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "CreateDate", "Rating", "ReviewDetail", "TourId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("166cd234-c8a0-4fd0-a883-7643ff7132ae"), new DateTime(2024, 4, 10, 15, 58, 27, 500, DateTimeKind.Local).AddTicks(6186), 5.0, "Amazing experience!", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 10, 15, 58, 27, 500, DateTimeKind.Local).AddTicks(6187) },
                    { new Guid("46797bfc-543a-431d-998c-98f560b083d3"), new DateTime(2024, 4, 10, 15, 58, 27, 500, DateTimeKind.Local).AddTicks(6165), 4.5, "Great tour!", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 10, 15, 58, 27, 500, DateTimeKind.Local).AddTicks(6182) }
                });

            migrationBuilder.InsertData(
                table: "TourBookings",
                columns: new[] { "BookingID", "BookingDate", "CreateDate", "CustomerEmail", "CustomerName", "Status", "TourDate", "TourId", "UpdateDate" },
                values: new object[] { new Guid("ce12bfbd-465e-43a5-8576-65d5f1fe1e16"), new DateTime(2024, 4, 10, 15, 58, 27, 500, DateTimeKind.Local).AddTicks(6444), new DateTime(2024, 4, 10, 15, 58, 27, 500, DateTimeKind.Local).AddTicks(6448), "john@example.com", "John Doe", 1, new DateTime(2024, 4, 17, 15, 58, 27, 500, DateTimeKind.Local).AddTicks(6445), new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 10, 15, 58, 27, 500, DateTimeKind.Local).AddTicks(6450) });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "TourId",
                keyValue: new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"),
                columns: new[] { "CreateDate", "TourDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 10, 15, 58, 27, 500, DateTimeKind.Local).AddTicks(6414), new DateTime(2024, 4, 10, 10, 28, 27, 500, DateTimeKind.Utc).AddTicks(6396), new DateTime(2024, 4, 10, 15, 58, 27, 500, DateTimeKind.Local).AddTicks(6415) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("2bc55382-767e-48aa-95de-5f2dee853db8"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("909654dc-70be-487b-be37-a20be7652732"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: new Guid("166cd234-c8a0-4fd0-a883-7643ff7132ae"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: new Guid("46797bfc-543a-431d-998c-98f560b083d3"));

            migrationBuilder.DeleteData(
                table: "TourBookings",
                keyColumn: "BookingID",
                keyValue: new Guid("ce12bfbd-465e-43a5-8576-65d5f1fe1e16"));

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
    }
}
