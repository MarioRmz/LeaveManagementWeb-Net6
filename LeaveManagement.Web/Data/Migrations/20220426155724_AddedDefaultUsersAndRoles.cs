using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedDefaultUsersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cac43a6e-f7bb-4448-baaf-ladd431ccbbf", "12400562-6bb5-48c5-ae07-cd91052ef9ef", "Administrator", "ADMINISTRATOR" },
                    { "cac43a7e-f7cb-4448-baaf-labb431eabbf", "88e9fa86-cae7-48dd-9bfe-871a4dd9da25", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "30fq19bd-f907-4409-b416-ba356312e659", 0, "5ff6a773-a4eb-4198-9865-14b32554f372", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@localhost.com", false, "System", "User", false, null, "USER@LOCALHOST.COM", null, "AQAAAAEAACcQAAAAEF94cKZlw8+pKmxBuzH9U7Ma5Px7YhJRM5jXcJy9mumDpr/G/fCeYyktlpQ+nejk6A==", null, false, "a43b1f46-d93f-4d1d-a323-a9ce94e7bfb0", null, false, null },
                    { "408qq945-3d84-4421-8342-7269ec64d949", 0, "89a27736-0cc3-436e-b83e-5aba8961c5ba", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", false, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", null, "AQAAAAEAACcQAAAAEOCGHc54Hk3LICYq6Go0up3oMYm6KGo7dfp3GdfdsXhEGcKiTAk7nZWIpf4ZfdJQAQ==", null, false, "b7ad2e6c-434c-435b-8afd-a259a6faeec4", null, false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cac43a7e-f7cb-4448-baaf-labb431eabbf", "30fq19bd-f907-4409-b416-ba356312e659" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cac43a6e-f7bb-4448-baaf-ladd431ccbbf", "408qq945-3d84-4421-8342-7269ec64d949" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cac43a7e-f7cb-4448-baaf-labb431eabbf", "30fq19bd-f907-4409-b416-ba356312e659" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cac43a6e-f7bb-4448-baaf-ladd431ccbbf", "408qq945-3d84-4421-8342-7269ec64d949" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-ladd431ccbbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4448-baaf-labb431eabbf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30fq19bd-f907-4409-b416-ba356312e659");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408qq945-3d84-4421-8342-7269ec64d949");
        }
    }
}
