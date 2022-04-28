using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedDefaultUsersUsernames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-ladd431ccbbf",
                column: "ConcurrencyStamp",
                value: "f81e44f5-5562-41fa-a5de-9a50263ecb0a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4448-baaf-labb431eabbf",
                column: "ConcurrencyStamp",
                value: "227223d9-412d-46e5-9eb0-ae732ba80a89");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30fq19bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "a4f91702-74f5-47f9-ac2e-88f7d98bcb46", true, "USER@LOCALHOST.COM", "AQAAAAEAACcQAAAAEOq24CRyYEYJ4DxinrhwZfyVwtrIZtVewruriQEL3iKVzirF5A2lY5AWHPBtznQjPQ==", "eb7b201c-1e3a-4598-86d5-f77915bfc350", "user@localhost.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408qq945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "46ef80ba-a78c-407f-b28f-640697090bf8", true, "ADMIN@LOCALHOST.COM", "AQAAAAEAACcQAAAAEBVtG8QmbqoTqSK2sUXFW8PNbH5ZefNP63dPX29GLT5le8wvn6TbVafNBV2jWH8iig==", "6250045d-8833-497a-a21c-e5044e687dab", "admin@localhost.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-ladd431ccbbf",
                column: "ConcurrencyStamp",
                value: "12400562-6bb5-48c5-ae07-cd91052ef9ef");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4448-baaf-labb431eabbf",
                column: "ConcurrencyStamp",
                value: "88e9fa86-cae7-48dd-9bfe-871a4dd9da25");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30fq19bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "5ff6a773-a4eb-4198-9865-14b32554f372", false, null, "AQAAAAEAACcQAAAAEF94cKZlw8+pKmxBuzH9U7Ma5Px7YhJRM5jXcJy9mumDpr/G/fCeYyktlpQ+nejk6A==", "a43b1f46-d93f-4d1d-a323-a9ce94e7bfb0", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408qq945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "89a27736-0cc3-436e-b83e-5aba8961c5ba", false, null, "AQAAAAEAACcQAAAAEOCGHc54Hk3LICYq6Go0up3oMYm6KGo7dfp3GdfdsXhEGcKiTAk7nZWIpf4ZfdJQAQ==", "b7ad2e6c-434c-435b-8afd-a259a6faeec4", null });
        }
    }
}
