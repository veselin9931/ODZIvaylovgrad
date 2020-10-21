using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ODZ.Data.Migrations
{
    public partial class userseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "375f748e-66c2-4e80-a775-7b70efc43a6e", 0, "e04e2a9e-1847-48dc-82d7-70484cade851", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.com", true, false, false, null, null, "admin@admin.com", "admin@admin.com", "AQAAAAEAACcQAAAAEP+8btibhocatyf0IDezWfc5ARGGbUmPyTWL8mTkmuiEHMHu/ZGdPths4D3xtSLMiw==", null, false, "836415c4-6123-483f-9199-c10e6e475432", false, "admin@admin.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "375f748e-66c2-4e80-a775-7b70efc43a6e");
        }
    }
}
