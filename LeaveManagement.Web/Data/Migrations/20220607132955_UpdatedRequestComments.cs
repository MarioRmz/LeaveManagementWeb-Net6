using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class UpdatedRequestComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-ladd431ccbbf",
                column: "ConcurrencyStamp",
                value: "91ac3f42-870c-44e7-91ed-9573dea33958");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4448-baaf-labb431eabbf",
                column: "ConcurrencyStamp",
                value: "9e93db29-91de-4f28-9a82-ad9ae11d1ecb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30fq19bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6f3d1b3-0b41-4767-b1ba-3834c5c30d93", "AQAAAAEAACcQAAAAEKfKMFn+2Ktib3Qf9WzXq602rYXo2Qim8L2sCB7wAu0NtK6CKCG3QYAjxb4oYoczZA==", "f1306764-ce58-4e8a-b2aa-a5c7f694b6bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408qq945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc6458d9-8c60-4a4a-81b2-f93f67f6803d", "AQAAAAEAACcQAAAAEHhEr6k4OYgUpxa8AtnfvuQ0V8/Iq/gquZWpWWJ/+xYKGDIE6zvk08Sk08Fq5soXQQ==", "82a6732a-5f80-4346-92ce-0c0342a4449b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-ladd431ccbbf",
                column: "ConcurrencyStamp",
                value: "3c862446-17b3-4f1b-90f7-3338430c5e03");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4448-baaf-labb431eabbf",
                column: "ConcurrencyStamp",
                value: "225ae6ca-6e06-4404-b07e-08afbf3660b8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30fq19bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6dd3556a-6bb2-409b-be8e-aee027db9ad4", "AQAAAAEAACcQAAAAEJeUdAcTnngn3okYjUzl0CXHfnIp6LXuN74u7YlC//gds6vi1PRwcZwXv51cTdsjEw==", "0c20c5dd-b965-4f17-b048-417115319863" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408qq945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74b9047f-95cc-4dbd-b382-babb81de9199", "AQAAAAEAACcQAAAAEN+cmSkdTZAb5wpON97JcgUcqvN85PC1kFhzaT3i8umOgAsbSuPHPmdhDYsKX4UyOg==", "a0960364-6b5b-4a76-9233-2c52dddf6053" });
        }
    }
}
