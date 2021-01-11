using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace fleepage.oatleaf.com.Migrations
{
    public partial class _007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Schools",
                type: "nvarchar(256)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2021, 1, 11, 9, 28, 56, 778, DateTimeKind.Utc).AddTicks(1745));

            migrationBuilder.UpdateData(
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2021, 1, 11, 9, 28, 56, 778, DateTimeKind.Utc).AddTicks(5812));

            migrationBuilder.UpdateData(
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2021, 1, 11, 9, 28, 56, 778, DateTimeKind.Utc).AddTicks(5919));

            migrationBuilder.UpdateData(
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2021, 1, 11, 9, 28, 56, 778, DateTimeKind.Utc).AddTicks(5921));

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_SchoolId",
                table: "Teachers",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolId",
                table: "Students",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_SchoolId",
                table: "Staffs",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolAdmin_SchoolId",
                table: "SchoolAdmin",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgAdmin_OrganisationId",
                table: "OrgAdmin",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_OrganisationId",
                table: "Member",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_Freelance_SchoolId",
                table: "Freelance",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Freelance_Schools_SchoolId",
                table: "Freelance",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Organisation_OrganisationId",
                table: "Member",
                column: "OrganisationId",
                principalTable: "Organisation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrgAdmin_Organisation_OrganisationId",
                table: "OrgAdmin",
                column: "OrganisationId",
                principalTable: "Organisation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolAdmin_Schools_SchoolId",
                table: "SchoolAdmin",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Schools_SchoolId",
                table: "Staffs",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Schools_SchoolId",
                table: "Students",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Schools_SchoolId",
                table: "Teachers",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Freelance_Schools_SchoolId",
                table: "Freelance");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_Organisation_OrganisationId",
                table: "Member");

            migrationBuilder.DropForeignKey(
                name: "FK_OrgAdmin_Organisation_OrganisationId",
                table: "OrgAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolAdmin_Schools_SchoolId",
                table: "SchoolAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Schools_SchoolId",
                table: "Staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Schools_SchoolId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Schools_SchoolId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_SchoolId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_SchoolId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_SchoolId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_SchoolAdmin_SchoolId",
                table: "SchoolAdmin");

            migrationBuilder.DropIndex(
                name: "IX_OrgAdmin_OrganisationId",
                table: "OrgAdmin");

            migrationBuilder.DropIndex(
                name: "IX_Member_OrganisationId",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Freelance_SchoolId",
                table: "Freelance");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2020, 12, 31, 15, 3, 57, 335, DateTimeKind.Utc).AddTicks(5376));

            migrationBuilder.UpdateData(
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2020, 12, 31, 15, 3, 57, 336, DateTimeKind.Utc).AddTicks(621));

            migrationBuilder.UpdateData(
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2020, 12, 31, 15, 3, 57, 336, DateTimeKind.Utc).AddTicks(797));

            migrationBuilder.UpdateData(
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2020, 12, 31, 15, 3, 57, 336, DateTimeKind.Utc).AddTicks(802));
        }
    }
}
