using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToursDatabase.Migrations
{
    /// <inheritdoc />
    public partial class updatetourstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "StartLocationAddress",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "StartingLatitude",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "StartingLongitude",
                table: "Tours");

            migrationBuilder.RenameColumn(
                name: "StartLocationDescription",
                table: "Tours",
                newName: "StartTourLocation");

            migrationBuilder.AddColumn<string>(
                name: "FirstLocation",
                table: "Tours",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastLocation",
                table: "Tours",
                type: "nvarchar(max)",
                nullable: true);

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
                columns: new[] { "CreateDate", "FirstLocation", "LastLocation", "StartTourLocation", "TourDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 10, 16, 52, 46, 480, DateTimeKind.Local).AddTicks(9818), null, null, "Ahmedabad", new DateTime(2024, 4, 10, 11, 22, 46, 480, DateTimeKind.Utc).AddTicks(9806), new DateTime(2024, 4, 10, 16, 52, 46, 480, DateTimeKind.Local).AddTicks(9819) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "FirstLocation",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "LastLocation",
                table: "Tours");

            migrationBuilder.RenameColumn(
                name: "StartTourLocation",
                table: "Tours",
                newName: "StartLocationDescription");

            migrationBuilder.AddColumn<string>(
                name: "StartLocationAddress",
                table: "Tours",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "StartingLatitude",
                table: "Tours",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "StartingLongitude",
                table: "Tours",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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
                columns: new[] { "CreateDate", "StartLocationAddress", "StartLocationDescription", "StartingLatitude", "StartingLongitude", "TourDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 10, 16, 2, 45, 615, DateTimeKind.Local).AddTicks(9954), "123 Main St, New York, NY", "This is the starting point of the tour.", 40.712800000000001, -74.006, new DateTime(2024, 4, 10, 10, 32, 45, 615, DateTimeKind.Utc).AddTicks(9941), new DateTime(2024, 4, 10, 16, 2, 45, 615, DateTimeKind.Local).AddTicks(9955) });
        }
    }
}
