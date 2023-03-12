using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class migtationfor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "specialites",
                columns: new[] { "Id", "NameSpecialite" },
                values: new object[,]
                {
                    { 1, "ANESTHÉSIOLOGIE" },
                    { 2, "CARDIOLOGIE" },
                    { 3, "CHIRURGIE" },
                    { 4, "DERMATOLOGIE" },
                    { 5, "ENDOCRINOLOGIE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "specialites",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "specialites",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "specialites",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "specialites",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "specialites",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
