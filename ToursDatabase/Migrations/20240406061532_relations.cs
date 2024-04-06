using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToursDatabase.Migrations
{
    /// <inheritdoc />
    public partial class relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("4c48d313-c1a9-4799-b6b4-218ff1929a37"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("5cf3ab94-25dd-4d98-b0db-291173ff033a"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("d6abe7a6-98e6-4a52-9239-3816aca48f73"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: new Guid("6e0d6fd9-5cb1-46e3-8761-8e20594eecb8"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: new Guid("a48f6df9-abfe-4dd1-83eb-a7357fb55b89"));

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "CreateDate", "FileDescription", "FileExtension", "FileName", "FilePath", "FileSizeInBytes", "TourId", "UpdateDate" },
                values: new object[] { new Guid("b3307032-02df-46c4-8847-dceb35615c87"), new DateTime(2024, 4, 6, 11, 45, 32, 261, DateTimeKind.Local).AddTicks(5569), "An example image", ".jpg", "example.jpg", "/Images/example.jpg", 1024L, new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 6, 11, 45, 32, 261, DateTimeKind.Local).AddTicks(5570) });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Address", "CreateDate", "Latitude", "Longitude", "Name", "TourId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("1c041a75-545c-4497-b17c-a485b20e2353"), "456 Road, City, Country", new DateTime(2024, 4, 6, 11, 45, 32, 261, DateTimeKind.Local).AddTicks(5454), 40.712800000000001, -74.006, "NYC Cruise by Circle Line", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 6, 11, 45, 32, 261, DateTimeKind.Local).AddTicks(5455) },
                    { new Guid("f69c9da9-0b38-4e66-8292-20b5963615ae"), "123 Street, City, Country", new DateTime(2024, 4, 6, 11, 45, 32, 261, DateTimeKind.Local).AddTicks(5445), 40.748817000000003, -73.985427999999999, "Empire State Building Observatory", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 6, 11, 45, 32, 261, DateTimeKind.Local).AddTicks(5447) }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "CreateDate", "Rating", "ReviewDetail", "TourId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("1aa7a96e-4b37-4fc2-ac14-a340759fc47f"), new DateTime(2024, 4, 6, 11, 45, 32, 261, DateTimeKind.Local).AddTicks(5165), 4.5, "Great tour!", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 6, 11, 45, 32, 261, DateTimeKind.Local).AddTicks(5178) },
                    { new Guid("a1235bb0-acce-42ad-9a96-286797122626"), new DateTime(2024, 4, 6, 11, 45, 32, 261, DateTimeKind.Local).AddTicks(5200), 5.0, "Amazing experience!", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 6, 11, 45, 32, 261, DateTimeKind.Local).AddTicks(5201) }
                });

            migrationBuilder.UpdateData(
                table: "TourBookings",
                keyColumn: "BookingID",
                keyValue: new Guid("ce12bfbd-465e-43a5-8576-65d5f1fe1e16"),
                columns: new[] { "BookingDate", "CreateDate", "TourDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 6, 11, 45, 32, 261, DateTimeKind.Local).AddTicks(5533), new DateTime(2024, 4, 6, 11, 45, 32, 261, DateTimeKind.Local).AddTicks(5538), new DateTime(2024, 4, 13, 11, 45, 32, 261, DateTimeKind.Local).AddTicks(5534), new DateTime(2024, 4, 6, 11, 45, 32, 261, DateTimeKind.Local).AddTicks(5539) });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "TourId",
                keyValue: new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"),
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 6, 11, 45, 32, 261, DateTimeKind.Local).AddTicks(5501), new DateTime(2024, 4, 6, 11, 45, 32, 261, DateTimeKind.Local).AddTicks(5502) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("b3307032-02df-46c4-8847-dceb35615c87"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("1c041a75-545c-4497-b17c-a485b20e2353"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("f69c9da9-0b38-4e66-8292-20b5963615ae"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: new Guid("1aa7a96e-4b37-4fc2-ac14-a340759fc47f"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: new Guid("a1235bb0-acce-42ad-9a96-286797122626"));

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "CreateDate", "FileDescription", "FileExtension", "FileName", "FilePath", "FileSizeInBytes", "TourId", "UpdateDate" },
                values: new object[] { new Guid("4c48d313-c1a9-4799-b6b4-218ff1929a37"), new DateTime(2024, 4, 6, 11, 43, 51, 893, DateTimeKind.Local).AddTicks(951), "An example image", ".jpg", "example.jpg", "/Images/example.jpg", 1024L, new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 6, 11, 43, 51, 893, DateTimeKind.Local).AddTicks(952) });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Address", "CreateDate", "Latitude", "Longitude", "Name", "TourId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("5cf3ab94-25dd-4d98-b0db-291173ff033a"), "456 Road, City, Country", new DateTime(2024, 4, 6, 11, 43, 51, 893, DateTimeKind.Local).AddTicks(844), 40.712800000000001, -74.006, "NYC Cruise by Circle Line", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 6, 11, 43, 51, 893, DateTimeKind.Local).AddTicks(845) },
                    { new Guid("d6abe7a6-98e6-4a52-9239-3816aca48f73"), "123 Street, City, Country", new DateTime(2024, 4, 6, 11, 43, 51, 893, DateTimeKind.Local).AddTicks(836), 40.748817000000003, -73.985427999999999, "Empire State Building Observatory", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 6, 11, 43, 51, 893, DateTimeKind.Local).AddTicks(838) }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "CreateDate", "Rating", "ReviewDetail", "TourId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("6e0d6fd9-5cb1-46e3-8761-8e20594eecb8"), new DateTime(2024, 4, 6, 11, 43, 51, 893, DateTimeKind.Local).AddTicks(555), 4.5, "Great tour!", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 6, 11, 43, 51, 893, DateTimeKind.Local).AddTicks(565) },
                    { new Guid("a48f6df9-abfe-4dd1-83eb-a7357fb55b89"), new DateTime(2024, 4, 6, 11, 43, 51, 893, DateTimeKind.Local).AddTicks(572), 5.0, "Amazing experience!", new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"), new DateTime(2024, 4, 6, 11, 43, 51, 893, DateTimeKind.Local).AddTicks(573) }
                });

            migrationBuilder.UpdateData(
                table: "TourBookings",
                keyColumn: "BookingID",
                keyValue: new Guid("ce12bfbd-465e-43a5-8576-65d5f1fe1e16"),
                columns: new[] { "BookingDate", "CreateDate", "TourDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 6, 11, 43, 51, 893, DateTimeKind.Local).AddTicks(916), new DateTime(2024, 4, 6, 11, 43, 51, 893, DateTimeKind.Local).AddTicks(920), new DateTime(2024, 4, 13, 11, 43, 51, 893, DateTimeKind.Local).AddTicks(917), new DateTime(2024, 4, 6, 11, 43, 51, 893, DateTimeKind.Local).AddTicks(921) });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "TourId",
                keyValue: new Guid("9c0cf771-2a31-44c9-adfd-b08c30397392"),
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 6, 11, 43, 51, 893, DateTimeKind.Local).AddTicks(885), new DateTime(2024, 4, 6, 11, 43, 51, 893, DateTimeKind.Local).AddTicks(887) });
        }
    }
}
