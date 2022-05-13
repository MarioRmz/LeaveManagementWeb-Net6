using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddingPeriodToAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-ladd431ccbbf",
                column: "ConcurrencyStamp",
                value: "0d5b3bf2-7292-480f-9297-eb09f3f269dd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4448-baaf-labb431eabbf",
                column: "ConcurrencyStamp",
                value: "10ac4f1d-bf3b-4d52-9988-182074da8e8a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30fq19bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e2316a9-fecf-4871-9946-ab5db85226a8", "AQAAAAEAACcQAAAAEDmgqROs2zs8DqJqk3IbAkT/W6eElDGJQ86BT+RZhcd/Vlf40q0Kyl9T3dqARc1N/A==", "81a86e12-cd78-48af-b69f-3a18b6bb22e4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408qq945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "761d794a-98e1-46ac-a56e-3a897567ca2c", "AQAAAAEAACcQAAAAEAcH/aHiouUDFT5aNFYMJ1GrXnsn1Ogg9hN22FAhuO7Own7ggrbOvO1um4OwyyFAMQ==", "6861962a-847c-418d-9936-605e824b2305" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllocations");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4f91702-74f5-47f9-ac2e-88f7d98bcb46", "AQAAAAEAACcQAAAAEOq24CRyYEYJ4DxinrhwZfyVwtrIZtVewruriQEL3iKVzirF5A2lY5AWHPBtznQjPQ==", "eb7b201c-1e3a-4598-86d5-f77915bfc350" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408qq945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46ef80ba-a78c-407f-b28f-640697090bf8", "AQAAAAEAACcQAAAAEBVtG8QmbqoTqSK2sUXFW8PNbH5ZefNP63dPX29GLT5le8wvn6TbVafNBV2jWH8iig==", "6250045d-8833-497a-a21c-e5044e687dab" });
        }
    }
}
