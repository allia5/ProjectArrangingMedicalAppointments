using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class migration13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medicalPlannings_users_userId",
                table: "medicalPlannings");

            migrationBuilder.DropIndex(
                name: "IX_medicalPlannings_userId",
                table: "medicalPlannings");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "medicalPlannings");

            migrationBuilder.AlterColumn<string>(
                name: "IdUser",
                table: "medicalPlannings",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("03d2395f-a472-4a41-b95f-45828d5f8af4"),
                column: "ConcurrencyStamp",
                value: "b4b117e8-b14e-4f2b-9130-5a6a9809631b");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("0916f1e5-ff87-4d4f-89b2-d6dbb922027e"),
                column: "ConcurrencyStamp",
                value: "d9349b06-4de2-4d99-99f5-e4ac70cb2409");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("0d518584-64a4-424b-b011-7283083394b8"),
                column: "ConcurrencyStamp",
                value: "ec980107-5f13-4974-ac3f-03f0fb8e7bb0");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("14e8987f-77b0-44a9-a641-6c6779b9564c"),
                column: "ConcurrencyStamp",
                value: "6a0dbd60-10dc-41d0-a42a-e858d6399b75");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("232d07c5-711e-4802-a048-f2f73804ea40"),
                column: "ConcurrencyStamp",
                value: "ad581d56-4518-485b-9df4-f3a7e43bc8d9");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("2b102f8f-079c-4ae1-b093-487ba70cf183"),
                column: "ConcurrencyStamp",
                value: "540e8d4f-ae9d-4a8a-a695-4ec7fef89033");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("cf35304b-0241-4b81-8f57-d0dccdccb836"),
                column: "ConcurrencyStamp",
                value: "b048fc12-2f20-4722-8cf7-f8326f76487f");

            migrationBuilder.CreateIndex(
                name: "IX_medicalPlannings_IdUser",
                table: "medicalPlannings",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_medicalPlannings_users_IdUser",
                table: "medicalPlannings",
                column: "IdUser",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medicalPlannings_users_IdUser",
                table: "medicalPlannings");

            migrationBuilder.DropIndex(
                name: "IX_medicalPlannings_IdUser",
                table: "medicalPlannings");

            migrationBuilder.AlterColumn<string>(
                name: "IdUser",
                table: "medicalPlannings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "medicalPlannings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("03d2395f-a472-4a41-b95f-45828d5f8af4"),
                column: "ConcurrencyStamp",
                value: "52ef1b4c-e346-4118-9238-e7a80560c2ec");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("0916f1e5-ff87-4d4f-89b2-d6dbb922027e"),
                column: "ConcurrencyStamp",
                value: "549aad55-8b2b-4678-b547-e446eb7f8183");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("0d518584-64a4-424b-b011-7283083394b8"),
                column: "ConcurrencyStamp",
                value: "e6442d0b-a5e1-4928-8090-bb4d989deed2");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("14e8987f-77b0-44a9-a641-6c6779b9564c"),
                column: "ConcurrencyStamp",
                value: "3fcf97c5-4647-4511-8577-7cb5cb83e9dc");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("232d07c5-711e-4802-a048-f2f73804ea40"),
                column: "ConcurrencyStamp",
                value: "051c9a11-e55a-40fa-b0d6-5a1f381102a9");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("2b102f8f-079c-4ae1-b093-487ba70cf183"),
                column: "ConcurrencyStamp",
                value: "bf7000c6-133c-40ff-8509-e0f62719fe14");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("cf35304b-0241-4b81-8f57-d0dccdccb836"),
                column: "ConcurrencyStamp",
                value: "32463c83-c2e8-41a0-a05a-88528bbfca2e");

            migrationBuilder.CreateIndex(
                name: "IX_medicalPlannings_userId",
                table: "medicalPlannings",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_medicalPlannings_users_userId",
                table: "medicalPlannings",
                column: "userId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
