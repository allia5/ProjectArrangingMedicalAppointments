using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class migration8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkDoctors_Doctors_DoctorId",
                table: "WorkDoctors");

            migrationBuilder.DropIndex(
                name: "IX_WorkDoctors_DoctorId",
                table: "WorkDoctors");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "WorkDoctors");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("03d2395f-a472-4a41-b95f-45828d5f8af4"),
                column: "ConcurrencyStamp",
                value: "ee1a3344-9a50-41d4-94f7-666ac5d322c2");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("0916f1e5-ff87-4d4f-89b2-d6dbb922027e"),
                column: "ConcurrencyStamp",
                value: "4e995327-0dd5-4855-9f40-ec82ae2539d3");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("0d518584-64a4-424b-b011-7283083394b8"),
                column: "ConcurrencyStamp",
                value: "85ea311e-cf6a-4bc7-8a68-f7f6f7f2238e");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("14e8987f-77b0-44a9-a641-6c6779b9564c"),
                column: "ConcurrencyStamp",
                value: "a6e95b0f-0435-47e2-af02-dae377ecdfa1");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("232d07c5-711e-4802-a048-f2f73804ea40"),
                column: "ConcurrencyStamp",
                value: "2429ba4f-788f-465a-89b0-a5ac50a28c5f");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("2b102f8f-079c-4ae1-b093-487ba70cf183"),
                column: "ConcurrencyStamp",
                value: "bf465ffe-bfb0-4fb9-8c79-0511d6092482");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("cf35304b-0241-4b81-8f57-d0dccdccb836"),
                column: "ConcurrencyStamp",
                value: "91b50a36-4e3e-48c1-9b2c-4d8037804af8");

            migrationBuilder.CreateIndex(
                name: "IX_WorkDoctors_IdDoctor",
                table: "WorkDoctors",
                column: "IdDoctor");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkDoctors_Doctors_IdDoctor",
                table: "WorkDoctors",
                column: "IdDoctor",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkDoctors_Doctors_IdDoctor",
                table: "WorkDoctors");

            migrationBuilder.DropIndex(
                name: "IX_WorkDoctors_IdDoctor",
                table: "WorkDoctors");

            migrationBuilder.AddColumn<Guid>(
                name: "DoctorId",
                table: "WorkDoctors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("03d2395f-a472-4a41-b95f-45828d5f8af4"),
                column: "ConcurrencyStamp",
                value: "212a9322-c4d9-43c8-a6f6-3475bea58462");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("0916f1e5-ff87-4d4f-89b2-d6dbb922027e"),
                column: "ConcurrencyStamp",
                value: "10603c19-d05d-48ef-bf86-a5ec4ce4da0b");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("0d518584-64a4-424b-b011-7283083394b8"),
                column: "ConcurrencyStamp",
                value: "177f5ed8-194f-4289-a007-be8531e5a547");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("14e8987f-77b0-44a9-a641-6c6779b9564c"),
                column: "ConcurrencyStamp",
                value: "91e44475-eda0-429d-bc8c-10c8b77e35e0");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("232d07c5-711e-4802-a048-f2f73804ea40"),
                column: "ConcurrencyStamp",
                value: "00d29a5f-f619-4518-8ae3-895eb41100d7");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("2b102f8f-079c-4ae1-b093-487ba70cf183"),
                column: "ConcurrencyStamp",
                value: "ce360bdb-d65b-4cd5-bcb6-b556a5acaff4");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("cf35304b-0241-4b81-8f57-d0dccdccb836"),
                column: "ConcurrencyStamp",
                value: "115c9d12-645e-44f4-b6a4-dd67ada9ebd2");

            migrationBuilder.CreateIndex(
                name: "IX_WorkDoctors_DoctorId",
                table: "WorkDoctors",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkDoctors_Doctors_DoctorId",
                table: "WorkDoctors",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
