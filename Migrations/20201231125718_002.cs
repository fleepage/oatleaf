using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace fleepage.oatleaf.com.Migrations
{
    public partial class _002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Semester");

            migrationBuilder.RenameColumn(
                name: "SemesterId",
                table: "Register",
                newName: "TermId");

            migrationBuilder.CreateTable(
                name: "Fees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TermId = table.Column<long>(type: "bigint", nullable: true),
                    SetupId = table.Column<long>(type: "bigint", nullable: true),
                    StudentsId = table.Column<long>(type: "bigint", nullable: true),
                    StaffsId = table.Column<long>(type: "bigint", nullable: true),
                    TeachersId = table.Column<long>(type: "bigint", nullable: true),
                    SchoolId = table.Column<long>(type: "bigint", nullable: true),
                    OrganisationId = table.Column<long>(type: "bigint", nullable: true),
                    StudentId = table.Column<long>(type: "bigint", nullable: true),
                    TeacherId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fees_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fees_Setup_SetupId",
                        column: x => x.SetupId,
                        principalTable: "Setup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fees_Staffs_StaffsId",
                        column: x => x.StaffsId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fees_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fees_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Term",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SetupId = table.Column<long>(type: "bigint", nullable: true),
                    SessionId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Term", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Term_Setup_SetupId",
                        column: x => x.SetupId,
                        principalTable: "Setup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Refrence = table.Column<string>(type: "nvarchar(64)", nullable: true),
                    TransactionId = table.Column<string>(type: "nvarchar(64)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    FeeId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Fees_FeeId",
                        column: x => x.FeeId,
                        principalTable: "Fees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2020, 12, 31, 12, 57, 17, 578, DateTimeKind.Utc).AddTicks(8263));

            migrationBuilder.UpdateData(
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2020, 12, 31, 12, 57, 17, 579, DateTimeKind.Utc).AddTicks(4944));

            migrationBuilder.UpdateData(
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2020, 12, 31, 12, 57, 17, 579, DateTimeKind.Utc).AddTicks(5127));

            migrationBuilder.UpdateData(
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2020, 12, 31, 12, 57, 17, 579, DateTimeKind.Utc).AddTicks(5131));

            migrationBuilder.CreateIndex(
                name: "IX_Fees_SchoolId",
                table: "Fees",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Fees_SetupId",
                table: "Fees",
                column: "SetupId");

            migrationBuilder.CreateIndex(
                name: "IX_Fees_StaffsId",
                table: "Fees",
                column: "StaffsId");

            migrationBuilder.CreateIndex(
                name: "IX_Fees_StudentId",
                table: "Fees",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Fees_TeacherId",
                table: "Fees",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Term_SetupId",
                table: "Term",
                column: "SetupId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_FeeId",
                table: "Transactions",
                column: "FeeId",
                unique: true,
                filter: "[FeeId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Term");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Fees");

            migrationBuilder.RenameColumn(
                name: "TermId",
                table: "Register",
                newName: "SemesterId");

            migrationBuilder.CreateTable(
                name: "Semester",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    SessionId = table.Column<long>(type: "bigint", nullable: true),
                    SetupId = table.Column<long>(type: "bigint", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semester", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Semester_Setup_SetupId",
                        column: x => x.SetupId,
                        principalTable: "Setup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Semester_SetupId",
                table: "Semester",
                column: "SetupId");
        }
    }
}
