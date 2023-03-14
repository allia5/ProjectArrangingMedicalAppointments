using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class migrationeight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("30a34648-0a26-4f9b-8ba1-e01571f3b001"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("3a03f25d-2299-4fce-bed2-991d5d09bf76"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("60f2a2e4-636d-4161-8e97-0d609583292d"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("a3b1cbd5-7bd1-45a0-8718-45acf24c946b"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("e0a9e287-77a2-49dc-8f5d-159da004312c"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("ec9cab11-8d63-4b08-a57c-e37af41e7214"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("fb679392-3345-493b-8bb9-6ccea0402b30"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreateAccount",
                table: "users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("71ea89ea-939b-4bf5-8e66-1d344264a577"), "87ff8b7f-b672-4d6e-8eae-f3437fdd4329", "ANALYSE", null },
                    { new Guid("7e6377fd-f844-4ca5-9d62-92a4046123cc"), "44033e2f-685f-4304-84b8-f8e0eceafc5d", "SECRITAIRE", null },
                    { new Guid("8115b9d2-c135-4f56-ac93-8885dc90b87f"), "7796ae76-d422-4abf-ac8a-8a1365be9950", "RADIOLOGUE", null },
                    { new Guid("c874c8da-1e00-4b95-b40c-5c875f763152"), "2ef8eb6f-9a72-4e26-a049-2288846f3320", "ADMIN", null },
                    { new Guid("d05559ca-ac12-4cf2-b302-e6f6770f54f4"), "15be138a-d58b-47f9-92b6-f659a3849565", "PHARMACIEN", null },
                    { new Guid("d3aeb6de-1cd5-44cc-8c01-3cd5007648e4"), "d07b50d5-99c1-45c9-a01d-9cfd1ce56447", "PATIENT", null },
                    { new Guid("ec13cdfe-8476-4a74-9822-78a5a46f1cf9"), "08dfe806-5827-441e-8faa-54461c323171", "MEDECIN", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("71ea89ea-939b-4bf5-8e66-1d344264a577"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("7e6377fd-f844-4ca5-9d62-92a4046123cc"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("8115b9d2-c135-4f56-ac93-8885dc90b87f"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("c874c8da-1e00-4b95-b40c-5c875f763152"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("d05559ca-ac12-4cf2-b302-e6f6770f54f4"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("d3aeb6de-1cd5-44cc-8c01-3cd5007648e4"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("ec13cdfe-8476-4a74-9822-78a5a46f1cf9"));

            migrationBuilder.DropColumn(
                name: "DateCreateAccount",
                table: "users");

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("30a34648-0a26-4f9b-8ba1-e01571f3b001"), "714c12e8-6245-43a3-a6e5-8c399d2802ed", "MEDECIN", null },
                    { new Guid("3a03f25d-2299-4fce-bed2-991d5d09bf76"), "8944607e-d542-4725-bd0b-a8ad4e6f1492", "RADIOLOGUE", null },
                    { new Guid("60f2a2e4-636d-4161-8e97-0d609583292d"), "980628dd-cac5-425d-af00-e55df6c3ecc1", "PATIENT", null },
                    { new Guid("a3b1cbd5-7bd1-45a0-8718-45acf24c946b"), "02e0293e-c250-4f27-ae90-b81e72a317a4", "PHARMACIEN", null },
                    { new Guid("e0a9e287-77a2-49dc-8f5d-159da004312c"), "dc339555-acbb-451a-99a1-fb70a8bd2a63", "SECRITAIRE", null },
                    { new Guid("ec9cab11-8d63-4b08-a57c-e37af41e7214"), "7d2b6dad-e23b-409c-91e5-21ea831c26d9", "ADMIN", null },
                    { new Guid("fb679392-3345-493b-8bb9-6ccea0402b30"), "ff6d0c59-caee-461c-a6b1-9a53d8084657", "ANALYSE", null }
                });
        }
    }
}
