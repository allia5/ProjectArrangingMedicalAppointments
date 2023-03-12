using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class migtationseven : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("03774a0c-daea-4307-a5c7-5c70c6ceb66b"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("1365f700-dc1f-4976-b95a-347c260cd248"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("6632ad66-7b67-4d83-9ade-3796178cd5d6"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("7bb41889-0876-4fb7-8be2-2260dae9c453"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("b4e82abc-7536-4371-a58e-e5ff0da322d3"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("be1aac51-9269-4b93-8f0c-afd5b6d0b5c7"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("e877586d-71f9-4d74-a4d9-5e35dbee5206"));

            migrationBuilder.InsertData(
                table: "chronicDiseases",
                columns: new[] { "Id", "NameChronicDiseases" },
                values: new object[,]
                {
                    { 1, "DIABÈTE" },
                    { 2, "HYPERTENSION-ARTÉRIELLE" },
                    { 3, "MALADIES-RESPIRATOIRES" },
                    { 4, "MALADIES RÉNALES" },
                    { 5, "MALADIES ARTICULAIRES" },
                    { 6, "MALADIES DU FOIE" },
                    { 7, "MALADIES NEUROLOGIQUES" },
                    { 8, "CANCER" },
                    { 9, "MALADIES-CARDIOVASCULAIRES" }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "chronicDiseases",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "chronicDiseases",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "chronicDiseases",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "chronicDiseases",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "chronicDiseases",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "chronicDiseases",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "chronicDiseases",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "chronicDiseases",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "chronicDiseases",
                keyColumn: "Id",
                keyValue: 9);

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

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("03774a0c-daea-4307-a5c7-5c70c6ceb66b"), "83587897-e131-4634-882f-70ae3c48398b", "ADMIN", null },
                    { new Guid("1365f700-dc1f-4976-b95a-347c260cd248"), "769af9b8-a168-4803-a84a-625c08827f5e", "PHARMACIEN", null },
                    { new Guid("6632ad66-7b67-4d83-9ade-3796178cd5d6"), "54ab3908-c766-4235-b37b-24f42da574c1", "PATIENT", null },
                    { new Guid("7bb41889-0876-4fb7-8be2-2260dae9c453"), "46753a3f-5546-4523-b5b3-adcad8ad1e26", "RADIOLOGUE", null },
                    { new Guid("b4e82abc-7536-4371-a58e-e5ff0da322d3"), "f9532f28-adac-4681-bde3-b5ca638e2e93", "MEDECIN", null },
                    { new Guid("be1aac51-9269-4b93-8f0c-afd5b6d0b5c7"), "8fadad6a-9088-442f-b586-f2a3dc1f9eb1", "ANALYSE", null },
                    { new Guid("e877586d-71f9-4d74-a4d9-5e35dbee5206"), "0f2a043c-88a0-4ef6-a1d7-837f3000ecf4", "SECRITAIRE", null }
                });
        }
    }
}
