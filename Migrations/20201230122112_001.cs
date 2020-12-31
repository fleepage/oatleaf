using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace fleepage.oatleaf.com.Migrations
{
    public partial class _001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2020, 12, 30, 12, 21, 11, 840, DateTimeKind.Utc).AddTicks(757));

            migrationBuilder.UpdateData(
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2020, 12, 30, 12, 21, 11, 840, DateTimeKind.Utc).AddTicks(4590));

            migrationBuilder.UpdateData(
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2020, 12, 30, 12, 21, 11, 840, DateTimeKind.Utc).AddTicks(4691));

            migrationBuilder.UpdateData(
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2020, 12, 30, 12, 21, 11, 840, DateTimeKind.Utc).AddTicks(4694));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2020, 12, 29, 23, 20, 26, 177, DateTimeKind.Utc).AddTicks(8484));

            migrationBuilder.UpdateData(
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2020, 12, 29, 23, 20, 26, 178, DateTimeKind.Utc).AddTicks(3911));

            migrationBuilder.UpdateData(
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2020, 12, 29, 23, 20, 26, 178, DateTimeKind.Utc).AddTicks(4090));

            migrationBuilder.UpdateData(
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2020, 12, 29, 23, 20, 26, 178, DateTimeKind.Utc).AddTicks(4093));
        }
    }
}
