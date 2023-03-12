using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class migtationsix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("01019741-7bb2-4be4-aa5d-b11d6133bd6d"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("03dd6ab5-0554-47ae-b6c6-48265a0d0347"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("366baefa-c674-4d78-bb27-907284a057db"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("67e2d8b4-7292-4afc-b0cf-94368a704dfc"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("cefdf5fe-4107-41b6-82ea-2572524f5993"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("d859e6be-4223-4f99-b9cf-3f88e5267ecd"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("e96246c7-8f15-4db2-bba3-312b0b8ff42c"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("01019741-7bb2-4be4-aa5d-b11d6133bd6d"), "eaec5f7b-0cca-4e2d-be95-7a65b7dad5fc", "SECRITARY", null },
                    { new Guid("03dd6ab5-0554-47ae-b6c6-48265a0d0347"), "52059de6-b102-4b8e-b8ed-a8f9898230bd", "ANALYSIS", null },
                    { new Guid("366baefa-c674-4d78-bb27-907284a057db"), "5ca3384d-a1e7-4d11-9e87-fa732d5c3597", "ADMIN", null },
                    { new Guid("67e2d8b4-7292-4afc-b0cf-94368a704dfc"), "88f9405b-8e5c-4dc6-967e-8091c5a46a55", "PHARMACEUTICAL", null },
                    { new Guid("cefdf5fe-4107-41b6-82ea-2572524f5993"), "cda89faa-9382-4d7e-a30b-37e0e56ec240", "RADIOLOGIST", null },
                    { new Guid("d859e6be-4223-4f99-b9cf-3f88e5267ecd"), "baeaaf33-71eb-4c4b-95f4-7a96a1387c25", "PATIENT", null },
                    { new Guid("e96246c7-8f15-4db2-bba3-312b0b8ff42c"), "b6c753bd-8c4f-4ff1-84d9-2693884ac988", "DOCTOR", null }
                });
        }
    }
}
