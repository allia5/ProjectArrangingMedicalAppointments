using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdCabinetMedical",
                table: "MedicalOrdres",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("03d2395f-a472-4a41-b95f-45828d5f8af4"),
                column: "ConcurrencyStamp",
                value: "ea866171-1012-41aa-bcf5-d0db08ba0554");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("0916f1e5-ff87-4d4f-89b2-d6dbb922027e"),
                column: "ConcurrencyStamp",
                value: "6faa5e3a-2dd5-4e40-a6a4-d6999162def5");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("0d518584-64a4-424b-b011-7283083394b8"),
                column: "ConcurrencyStamp",
                value: "8096d543-6cfa-4d99-bca3-c6aa52eba7fc");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("14e8987f-77b0-44a9-a641-6c6779b9564c"),
                column: "ConcurrencyStamp",
                value: "17059315-dc37-4e24-aba8-689388ba5757");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("232d07c5-711e-4802-a048-f2f73804ea40"),
                column: "ConcurrencyStamp",
                value: "a9730119-ee11-462e-ab6a-699ade68b43c");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("2b102f8f-079c-4ae1-b093-487ba70cf183"),
                column: "ConcurrencyStamp",
                value: "c7dbb838-5558-460c-b798-4513c13e791c");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("cf35304b-0241-4b81-8f57-d0dccdccb836"),
                column: "ConcurrencyStamp",
                value: "6a13774d-b4e2-4979-a130-2a6491ae6a0d");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalOrdres_IdCabinetMedical",
                table: "MedicalOrdres",
                column: "IdCabinetMedical");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalOrdres_cabinetMedicals_IdCabinetMedical",
                table: "MedicalOrdres",
                column: "IdCabinetMedical",
                principalTable: "cabinetMedicals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalOrdres_cabinetMedicals_IdCabinetMedical",
                table: "MedicalOrdres");

            migrationBuilder.DropIndex(
                name: "IX_MedicalOrdres_IdCabinetMedical",
                table: "MedicalOrdres");

            migrationBuilder.DropColumn(
                name: "IdCabinetMedical",
                table: "MedicalOrdres");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("03d2395f-a472-4a41-b95f-45828d5f8af4"),
                column: "ConcurrencyStamp",
                value: "f64b3a9d-2a9d-4d46-888f-68547fb68f06");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("0916f1e5-ff87-4d4f-89b2-d6dbb922027e"),
                column: "ConcurrencyStamp",
                value: "ffa4aa77-e340-4615-909d-21641f6079e6");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("0d518584-64a4-424b-b011-7283083394b8"),
                column: "ConcurrencyStamp",
                value: "9782001a-acf8-44e7-8c0a-4a77cf30f2e6");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("14e8987f-77b0-44a9-a641-6c6779b9564c"),
                column: "ConcurrencyStamp",
                value: "97db8a56-8ea6-429f-b053-1b53763f54e3");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("232d07c5-711e-4802-a048-f2f73804ea40"),
                column: "ConcurrencyStamp",
                value: "20ffe143-611d-472c-bc75-ff768c534e53");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("2b102f8f-079c-4ae1-b093-487ba70cf183"),
                column: "ConcurrencyStamp",
                value: "c540107f-873d-4858-98b3-d7cd8861c8d1");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("cf35304b-0241-4b81-8f57-d0dccdccb836"),
                column: "ConcurrencyStamp",
                value: "50ddbfa0-7450-4040-b27d-797f3d61be08");
        }
    }
}
