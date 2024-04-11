using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToursDatabase.Migrations
{
    /// <inheritdoc />
    public partial class Stops : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "CreateDate", "FileDescription", "FileExtension", "FileName", "FilePath", "FileSizeInBytes", "TourId", "UpdateDate" },
                values: new object[] { new Guid("ba29ea09-1e62-41a8-8cd8-9452130301ac"), new DateTime(2024, 4, 10, 16, 2, 45, 616, DateTimeKind.Local).AddTicks(12), "An example image", ".jpg", "example.jpg", "/Images/example.jpg", 1024L, new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 10, 16, 2, 45, 616, DateTimeKind.Local).AddTicks(12) });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("7209f8df-5d18-4279-a03d-707624fb86bb"),
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 10, 16, 2, 45, 615, DateTimeKind.Local).AddTicks(9911), new DateTime(2024, 4, 10, 16, 2, 45, 615, DateTimeKind.Local).AddTicks(9912) });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Address", "CreateDate", "Description", "Latitude", "Longitude", "Name", "TourId", "UpdateDate" },
                values: new object[] { new Guid("325e1236-cfd2-4180-86c8-01526b28e2bc"), "456 Road, City, Country", new DateTime(2024, 4, 10, 16, 2, 45, 615, DateTimeKind.Local).AddTicks(9917), "that is first street of place", 40.712800000000001, -74.006, "NYC Cruise by Circle Line", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 10, 16, 2, 45, 615, DateTimeKind.Local).AddTicks(9917) });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "CreateDate", "Rating", "ReviewDetail", "TourId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("15a9a5fb-bcaa-49c6-b0b9-f49e27b3823a"), new DateTime(2024, 4, 10, 16, 2, 45, 615, DateTimeKind.Local).AddTicks(9741), 5.0, "Amazing experience!", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 10, 16, 2, 45, 615, DateTimeKind.Local).AddTicks(9741) },
                    { new Guid("323a900e-4897-4935-9307-0cbb3061265d"), new DateTime(2024, 4, 10, 16, 2, 45, 615, DateTimeKind.Local).AddTicks(9722), 4.5, "Great tour!", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 10, 16, 2, 45, 615, DateTimeKind.Local).AddTicks(9735) }
                });

            migrationBuilder.InsertData(
                table: "Stops",
                columns: new[] { "StopId", "ArrivalTime", "DepartureTime", "LocationId", "Order", "TourId" },
                values: new object[] { new Guid("b1f072fd-8f16-444f-80c9-25b42d80d4d4"), new DateTime(2024, 4, 10, 16, 2, 45, 616, DateTimeKind.Local).AddTicks(30), new DateTime(2024, 4, 11, 2, 2, 45, 616, DateTimeKind.Local).AddTicks(31), new Guid("7209f8df-5d18-4279-a03d-707624fb86bb"), 2, null });

            migrationBuilder.UpdateData(
                table: "TourBookings",
                keyColumn: "BookingID",
                keyValue: new Guid("ce12bfbd-465e-43a5-8576-65d5f1fe1e16"),
                columns: new[] { "BookingDate", "CreateDate", "TourDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 10, 16, 2, 45, 615, DateTimeKind.Local).AddTicks(9985), new DateTime(2024, 4, 10, 16, 2, 45, 615, DateTimeKind.Local).AddTicks(9992), new DateTime(2024, 4, 17, 16, 2, 45, 615, DateTimeKind.Local).AddTicks(9990), new DateTime(2024, 4, 10, 16, 2, 45, 615, DateTimeKind.Local).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "TourId",
                keyValue: new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"),
                columns: new[] { "CreateDate", "TourDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 10, 16, 2, 45, 615, DateTimeKind.Local).AddTicks(9954), new DateTime(2024, 4, 10, 10, 32, 45, 615, DateTimeKind.Utc).AddTicks(9941), new DateTime(2024, 4, 10, 16, 2, 45, 615, DateTimeKind.Local).AddTicks(9955) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("ba29ea09-1e62-41a8-8cd8-9452130301ac"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("325e1236-cfd2-4180-86c8-01526b28e2bc"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: new Guid("15a9a5fb-bcaa-49c6-b0b9-f49e27b3823a"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: new Guid("323a900e-4897-4935-9307-0cbb3061265d"));

            migrationBuilder.DeleteData(
                table: "Stops",
                keyColumn: "StopId",
                keyValue: new Guid("b1f072fd-8f16-444f-80c9-25b42d80d4d4"));

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

            migrationBuilder.UpdateData(
                table: "TourBookings",
                keyColumn: "BookingID",
                keyValue: new Guid("ce12bfbd-465e-43a5-8576-65d5f1fe1e16"),
                columns: new[] { "BookingDate", "CreateDate", "TourDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 10, 15, 58, 27, 500, DateTimeKind.Local).AddTicks(6444), new DateTime(2024, 4, 10, 15, 58, 27, 500, DateTimeKind.Local).AddTicks(6448), new DateTime(2024, 4, 17, 15, 58, 27, 500, DateTimeKind.Local).AddTicks(6445), new DateTime(2024, 4, 10, 15, 58, 27, 500, DateTimeKind.Local).AddTicks(6450) });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "TourId",
                keyValue: new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"),
                columns: new[] { "CreateDate", "TourDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 10, 15, 58, 27, 500, DateTimeKind.Local).AddTicks(6414), new DateTime(2024, 4, 10, 10, 28, 27, 500, DateTimeKind.Utc).AddTicks(6396), new DateTime(2024, 4, 10, 15, 58, 27, 500, DateTimeKind.Local).AddTicks(6415) });
        }
    }
}
