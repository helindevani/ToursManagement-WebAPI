using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToursDatabase.Migrations
{
    /// <inheritdoc />
    public partial class ImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
