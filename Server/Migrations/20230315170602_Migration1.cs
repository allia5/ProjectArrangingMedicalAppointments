using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("1b3f2841-d086-4def-8bff-e0ebcdffcd02"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("28b44ccb-cb89-43f4-90da-4caf3f4d483a"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("2af56642-d47e-45c1-a624-11a87690d687"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("48d6d414-b030-451b-8965-9d7723039f7a"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("832476e3-d289-4c47-aa22-8beceea22c9d"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("a5b089be-9b77-41bf-a864-e1ca0ae575d7"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("d14b3e47-5d61-47d3-b7df-6c02979c37e4"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfCreate",
                table: "fileMedicals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2628c844-27cf-45a7-9d4a-6f38b5c319b7"), "39226c7e-a09e-45e2-a1af-929fb8b5b6a8", "SECRITAIRE", null },
                    { new Guid("8b592c83-217c-4009-857f-c6a317eec3d9"), "6667c724-ba92-4236-be91-d321d1273a2e", "ADMIN", null },
                    { new Guid("a389093a-e928-4085-a084-21f42856225f"), "c9dd8ba2-9416-4e00-b490-6cf1a265d3fa", "MEDECIN", null },
                    { new Guid("b275d069-0f86-4069-952b-cba00510638b"), "af4c82b0-4cf8-4a7b-9b3b-a8fded14f3ee", "PATIENT", null },
                    { new Guid("c274c012-c3c6-447f-80bc-e82bff888ac7"), "a01461a0-3144-43b9-b53d-a2199d8fc60f", "ANALYSE", null },
                    { new Guid("f3786009-28e1-44e9-b0f5-f4c129e62055"), "8f7c7298-50ac-49c2-9cf1-842c1d326749", "RADIOLOGUE", null },
                    { new Guid("fbc14de5-bf0b-42eb-8e35-09a75f0729ee"), "afaa82ad-f133-4279-9b2e-afa861fb551c", "PHARMACIEN", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("2628c844-27cf-45a7-9d4a-6f38b5c319b7"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("8b592c83-217c-4009-857f-c6a317eec3d9"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("a389093a-e928-4085-a084-21f42856225f"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("b275d069-0f86-4069-952b-cba00510638b"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("c274c012-c3c6-447f-80bc-e82bff888ac7"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("f3786009-28e1-44e9-b0f5-f4c129e62055"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("fbc14de5-bf0b-42eb-8e35-09a75f0729ee"));

            migrationBuilder.DropColumn(
                name: "DateOfCreate",
                table: "fileMedicals");

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1b3f2841-d086-4def-8bff-e0ebcdffcd02"), "46c09e0a-e8a6-4e10-8339-53f2250d2827", "RADIOLOGUE", null },
                    { new Guid("28b44ccb-cb89-43f4-90da-4caf3f4d483a"), "e251d0d5-10d5-4ad4-8b99-7d3b3dc60053", "ANALYSE", null },
                    { new Guid("2af56642-d47e-45c1-a624-11a87690d687"), "2054539d-32ec-4db0-af45-be7368c95701", "ADMIN", null },
                    { new Guid("48d6d414-b030-451b-8965-9d7723039f7a"), "1cf7beb9-99c6-4c99-8ba9-1d03d6928e3b", "PATIENT", null },
                    { new Guid("832476e3-d289-4c47-aa22-8beceea22c9d"), "ec8c42d1-5a19-471d-bff9-c4a4878eb11b", "MEDECIN", null },
                    { new Guid("a5b089be-9b77-41bf-a864-e1ca0ae575d7"), "26f38e8a-c10a-41b3-affd-8cfdc87711d9", "PHARMACIEN", null },
                    { new Guid("d14b3e47-5d61-47d3-b7df-6c02979c37e4"), "5dbb98b4-2b04-463c-8778-934dbb8cc241", "SECRITAIRE", null }
                });
        }
    }
}
