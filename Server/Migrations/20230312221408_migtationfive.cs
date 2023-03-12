using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class migtationfive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("01e6e8a2-05c0-46e1-a6df-408bd8c321e3"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("08331218-5ab8-401b-96b5-c8086bed6056"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("2edcebfa-ca37-423f-9e6e-d115ada8b72c"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("7defe709-22b9-444b-aeae-a250667ba640"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("ad5fb954-4adb-439e-abc8-c4768476b13c"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("bbfde24d-002c-4aac-8087-30db7b3ed4ce"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("bf3697fe-ef51-4e2a-b228-ddf7e2f60466"));

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

            migrationBuilder.InsertData(
                table: "specialites",
                columns: new[] { "Id", "NameSpecialite" },
                values: new object[,]
                {
                    { 6, "GASTRO ENTÉROLOGIE" },
                    { 7, "GYNÉCOLOGIE" },
                    { 8, "HÉMATOLOGIE" },
                    { 9, "INFECTIOLOGIE" },
                    { 10, "MÉDECINE DU TRAVAIL" },
                    { 11, "MÉDECINE INTERNE" },
                    { 12, "NÉPHROLOGIE" },
                    { 13, "NEUROLOGIE" },
                    { 14, "OBSTÉTRIQUE" },
                    { 15, "ONCOLOGIE" },
                    { 16, "OPHTALMOLOGIE" },
                    { 17, "ORTHOPÉDIE" },
                    { 18, "OTO-RHINO-LARYNGOLOGIE" },
                    { 19, "PÉDIATRIE" },
                    { 20, "PNEUMOLOGIE" },
                    { 21, "PSYCHIATRIE" },
                    { 22, "RADIOLOGIE" },
                    { 23, "RHUMATOLOGIE" },
                    { 24, "URGENTISTE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "specialites",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "specialites",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "specialites",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "specialites",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "specialites",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "specialites",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "specialites",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "specialites",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "specialites",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "specialites",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "specialites",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "specialites",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "specialites",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "specialites",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "specialites",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "specialites",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "specialites",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "specialites",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "specialites",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("01e6e8a2-05c0-46e1-a6df-408bd8c321e3"), "0b20c4da-32f6-44c2-9786-7232e76fcff6", "SECRITARY", null },
                    { new Guid("08331218-5ab8-401b-96b5-c8086bed6056"), "f30a7b4e-5052-4b98-9ed1-2219eb06640c", "ANALYSIS", null },
                    { new Guid("2edcebfa-ca37-423f-9e6e-d115ada8b72c"), "de4433eb-3801-4328-860f-5c90a26140ac", "PHARMACEUTICAL", null },
                    { new Guid("7defe709-22b9-444b-aeae-a250667ba640"), "c7fd7a5f-5d4a-4fef-85cf-1473ad275203", "PATIENT", null },
                    { new Guid("ad5fb954-4adb-439e-abc8-c4768476b13c"), "384ae04b-3820-4b6f-8623-d701c5a74622", "ADMIN", null },
                    { new Guid("bbfde24d-002c-4aac-8087-30db7b3ed4ce"), "53618a92-42d6-48ab-b378-1643bc26af49", "DOCTOR", null },
                    { new Guid("bf3697fe-ef51-4e2a-b228-ddf7e2f60466"), "ce2234ca-8fb4-4679-a99e-9683535143ec", "RADIOLOGIST", null }
                });
        }
    }
}
