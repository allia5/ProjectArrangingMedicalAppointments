using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "statusService",
                table: "cabinetMedicals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "cabinetMedicals",
                keyColumn: "Id",
                keyValue: new Guid("cf35304b-7896-4b81-8f57-d0dccdccb836"),
                column: "statusService",
                value: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "statusService",
                table: "cabinetMedicals");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("03d2395f-a472-4a41-b95f-45828d5f8af4"),
                column: "ConcurrencyStamp",
                value: "8a7c635b-b1ab-4657-b356-ecfe44f7beb6");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("0916f1e5-ff87-4d4f-89b2-d6dbb922027e"),
                column: "ConcurrencyStamp",
                value: "c7dc724a-6a12-4395-88cb-33f1a1d3cfa9");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("0d518584-64a4-424b-b011-7283083394b8"),
                column: "ConcurrencyStamp",
                value: "b81b0dc8-b999-4c99-8adf-958e8728c09a");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("14e8987f-77b0-44a9-a641-6c6779b9564c"),
                column: "ConcurrencyStamp",
                value: "bd7fa612-cdc8-4b0d-93bc-efa28d5f4c91");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("232d07c5-711e-4802-a048-f2f73804ea40"),
                column: "ConcurrencyStamp",
                value: "34ccc160-497a-4a52-8bc9-460443e3e007");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("2b102f8f-079c-4ae1-b093-487ba70cf183"),
                column: "ConcurrencyStamp",
                value: "cf2c8f03-82cc-4489-b238-af1c3f202195");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("cf35304b-0241-4b81-8f57-d0dccdccb836"),
                column: "ConcurrencyStamp",
                value: "c7b3765b-6fb3-4707-8493-81584ceda20d");
        }
    }
}
