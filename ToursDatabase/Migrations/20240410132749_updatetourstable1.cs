using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToursDatabase.Migrations
{
    /// <inheritdoc />
    public partial class updatetourstable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("9f0f0fca-6f2d-467e-9461-f2ddd1691fed"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("96774d84-57b3-45f1-8029-7205f2167731"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: new Guid("93d32dfa-009f-49cb-8401-df4997568192"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: new Guid("c183f14e-977f-4472-87c1-508ce5edeccd"));

            migrationBuilder.DeleteData(
                table: "Stops",
                keyColumn: "StopId",
                keyValue: new Guid("a4adc6ea-62a6-41ed-9427-61627a496afb"));

            migrationBuilder.AddColumn<DateTime>(
                name: "TourEndDate",
                table: "Tours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "CreateDate", "FileDescription", "FileExtension", "FileName", "FilePath", "FileSizeInBytes", "TourId", "UpdateDate" },
                values: new object[] { new Guid("6b031730-9f77-4d70-b97e-0e6acebd00fc"), new DateTime(2024, 4, 10, 18, 57, 49, 336, DateTimeKind.Local).AddTicks(6172), "An example image", ".jpg", "example.jpg", "/Images/example.jpg", 1024L, new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 10, 18, 57, 49, 336, DateTimeKind.Local).AddTicks(6172) });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("7209f8df-5d18-4279-a03d-707624fb86bb"),
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 10, 18, 57, 49, 336, DateTimeKind.Local).AddTicks(6047), new DateTime(2024, 4, 10, 18, 57, 49, 336, DateTimeKind.Local).AddTicks(6048) });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Address", "CreateDate", "Description", "Latitude", "Longitude", "Name", "TourId", "UpdateDate" },
                values: new object[] { new Guid("f6d553b4-6981-410a-a9f3-29c2ab1d3e86"), "456 Road, City, Country", new DateTime(2024, 4, 10, 18, 57, 49, 336, DateTimeKind.Local).AddTicks(6065), "that is first street of place", 40.712800000000001, -74.006, "NYC Cruise by Circle Line", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 10, 18, 57, 49, 336, DateTimeKind.Local).AddTicks(6066) });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "CreateDate", "Rating", "ReviewDetail", "TourId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("334874f8-5ded-4a08-81ea-a551192f36de"), new DateTime(2024, 4, 10, 18, 57, 49, 336, DateTimeKind.Local).AddTicks(5813), 5.0, "Amazing experience!", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 10, 18, 57, 49, 336, DateTimeKind.Local).AddTicks(5813) },
                    { new Guid("ee6b810b-4573-4f2b-9fc3-d3d652703a21"), new DateTime(2024, 4, 10, 18, 57, 49, 336, DateTimeKind.Local).AddTicks(5796), 4.5, "Great tour!", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 10, 18, 57, 49, 336, DateTimeKind.Local).AddTicks(5807) }
                });

            migrationBuilder.InsertData(
                table: "Stops",
                columns: new[] { "StopId", "ArrivalTime", "DepartureTime", "LocationId", "Order", "TourId" },
                values: new object[] { new Guid("feec0bca-5768-4db5-9f9a-b6d897247b1f"), new DateTime(2024, 4, 10, 18, 57, 49, 336, DateTimeKind.Local).AddTicks(6193), new DateTime(2024, 4, 11, 4, 57, 49, 336, DateTimeKind.Local).AddTicks(6194), new Guid("7209f8df-5d18-4279-a03d-707624fb86bb"), 2, null });

            migrationBuilder.UpdateData(
                table: "TourBookings",
                keyColumn: "BookingID",
                keyValue: new Guid("ce12bfbd-465e-43a5-8576-65d5f1fe1e16"),
                columns: new[] { "BookingDate", "CreateDate", "TourDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 10, 18, 57, 49, 336, DateTimeKind.Local).AddTicks(6141), new DateTime(2024, 4, 10, 18, 57, 49, 336, DateTimeKind.Local).AddTicks(6146), new DateTime(2024, 4, 17, 18, 57, 49, 336, DateTimeKind.Local).AddTicks(6142), new DateTime(2024, 4, 10, 18, 57, 49, 336, DateTimeKind.Local).AddTicks(6146) });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "TourId",
                keyValue: new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"),
                columns: new[] { "CreateDate", "FirstLocation", "LastLocation", "TourDate", "TourEndDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 10, 18, 57, 49, 336, DateTimeKind.Local).AddTicks(6111), "Delhi", "Mumbai", new DateTime(2024, 4, 10, 13, 27, 49, 336, DateTimeKind.Utc).AddTicks(6094), new DateTime(2024, 4, 10, 13, 27, 49, 336, DateTimeKind.Utc).AddTicks(6095), new DateTime(2024, 4, 10, 18, 57, 49, 336, DateTimeKind.Local).AddTicks(6112) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("6b031730-9f77-4d70-b97e-0e6acebd00fc"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("f6d553b4-6981-410a-a9f3-29c2ab1d3e86"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: new Guid("334874f8-5ded-4a08-81ea-a551192f36de"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: new Guid("ee6b810b-4573-4f2b-9fc3-d3d652703a21"));

            migrationBuilder.DeleteData(
                table: "Stops",
                keyColumn: "StopId",
                keyValue: new Guid("feec0bca-5768-4db5-9f9a-b6d897247b1f"));

            migrationBuilder.DropColumn(
                name: "TourEndDate",
                table: "Tours");

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "CreateDate", "FileDescription", "FileExtension", "FileName", "FilePath", "FileSizeInBytes", "TourId", "UpdateDate" },
                values: new object[] { new Guid("9f0f0fca-6f2d-467e-9461-f2ddd1691fed"), new DateTime(2024, 4, 10, 16, 52, 46, 480, DateTimeKind.Local).AddTicks(9880), "An example image", ".jpg", "example.jpg", "/Images/example.jpg", 1024L, new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 10, 16, 52, 46, 480, DateTimeKind.Local).AddTicks(9880) });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("7209f8df-5d18-4279-a03d-707624fb86bb"),
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 10, 16, 52, 46, 480, DateTimeKind.Local).AddTicks(9762), new DateTime(2024, 4, 10, 16, 52, 46, 480, DateTimeKind.Local).AddTicks(9763) });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Address", "CreateDate", "Description", "Latitude", "Longitude", "Name", "TourId", "UpdateDate" },
                values: new object[] { new Guid("96774d84-57b3-45f1-8029-7205f2167731"), "456 Road, City, Country", new DateTime(2024, 4, 10, 16, 52, 46, 480, DateTimeKind.Local).AddTicks(9769), "that is first street of place", 40.712800000000001, -74.006, "NYC Cruise by Circle Line", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 10, 16, 52, 46, 480, DateTimeKind.Local).AddTicks(9769) });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "CreateDate", "Rating", "ReviewDetail", "TourId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("93d32dfa-009f-49cb-8401-df4997568192"), new DateTime(2024, 4, 10, 16, 52, 46, 480, DateTimeKind.Local).AddTicks(9567), 5.0, "Amazing experience!", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 10, 16, 52, 46, 480, DateTimeKind.Local).AddTicks(9568) },
                    { new Guid("c183f14e-977f-4472-87c1-508ce5edeccd"), new DateTime(2024, 4, 10, 16, 52, 46, 480, DateTimeKind.Local).AddTicks(9550), 4.5, "Great tour!", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 10, 16, 52, 46, 480, DateTimeKind.Local).AddTicks(9562) }
                });

            migrationBuilder.InsertData(
                table: "Stops",
                columns: new[] { "StopId", "ArrivalTime", "DepartureTime", "LocationId", "Order", "TourId" },
                values: new object[] { new Guid("a4adc6ea-62a6-41ed-9427-61627a496afb"), new DateTime(2024, 4, 10, 16, 52, 46, 480, DateTimeKind.Local).AddTicks(9898), new DateTime(2024, 4, 11, 2, 52, 46, 480, DateTimeKind.Local).AddTicks(9899), new Guid("7209f8df-5d18-4279-a03d-707624fb86bb"), 2, null });

            migrationBuilder.UpdateData(
                table: "TourBookings",
                keyColumn: "BookingID",
                keyValue: new Guid("ce12bfbd-465e-43a5-8576-65d5f1fe1e16"),
                columns: new[] { "BookingDate", "CreateDate", "TourDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 10, 16, 52, 46, 480, DateTimeKind.Local).AddTicks(9850), new DateTime(2024, 4, 10, 16, 52, 46, 480, DateTimeKind.Local).AddTicks(9853), new DateTime(2024, 4, 17, 16, 52, 46, 480, DateTimeKind.Local).AddTicks(9850), new DateTime(2024, 4, 10, 16, 52, 46, 480, DateTimeKind.Local).AddTicks(9854) });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "TourId",
                keyValue: new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"),
                columns: new[] { "CreateDate", "FirstLocation", "LastLocation", "TourDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 10, 16, 52, 46, 480, DateTimeKind.Local).AddTicks(9818), null, null, new DateTime(2024, 4, 10, 11, 22, 46, 480, DateTimeKind.Utc).AddTicks(9806), new DateTime(2024, 4, 10, 16, 52, 46, 480, DateTimeKind.Local).AddTicks(9819) });
        }
    }
}
