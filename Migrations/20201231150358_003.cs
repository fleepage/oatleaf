using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace fleepage.oatleaf.com.Migrations
{
    public partial class _003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fees_Setup_SetupId",
                table: "Fees");

            migrationBuilder.RenameColumn(
                name: "SetupId",
                table: "Fees",
                newName: "MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Fees_SetupId",
                table: "Fees",
                newName: "IX_Fees_MemberId");

            migrationBuilder.AddColumn<DateTime>(
                name: "TransactionDate",
                table: "Transactions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FeeDate",
                table: "Fees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Fees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "RegisterId",
                table: "Attendance",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GradePoint",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartRange = table.Column<int>(type: "int", nullable: false),
                    EndRange = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(8)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(64)", nullable: true),
                    SetupId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradePoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradePoint_Setup_SetupId",
                        column: x => x.SetupId,
                        principalTable: "Setup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TermCA",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalMark = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    GradePointId = table.Column<long>(type: "bigint", nullable: true),
                    StudentsId = table.Column<long>(type: "bigint", nullable: true),
                    TeachersId = table.Column<long>(type: "bigint", nullable: true),
                    TermId = table.Column<long>(type: "bigint", nullable: true),
                    LevelId = table.Column<long>(type: "bigint", nullable: true),
                    SetupId = table.Column<long>(type: "bigint", nullable: true),
                    SchoolAdminId = table.Column<long>(type: "bigint", nullable: true),
                    StaffsId = table.Column<long>(type: "bigint", nullable: true),
                    SessionId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermCA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TermCA_GradePoint_GradePointId",
                        column: x => x.GradePointId,
                        principalTable: "GradePoint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TermCA_Level_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TermCA_Session_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Session",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TermCA_Setup_SetupId",
                        column: x => x.SetupId,
                        principalTable: "Setup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TermCA_Term_TermId",
                        column: x => x.TermId,
                        principalTable: "Term",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectCA",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalMark = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    GradePointId = table.Column<long>(type: "bigint", nullable: true),
                    SessionId = table.Column<long>(type: "bigint", nullable: true),
                    StudentsId = table.Column<long>(type: "bigint", nullable: true),
                    TeachersId = table.Column<long>(type: "bigint", nullable: true),
                    TermId = table.Column<long>(type: "bigint", nullable: true),
                    LevelId = table.Column<long>(type: "bigint", nullable: true),
                    SetupId = table.Column<long>(type: "bigint", nullable: true),
                    SubjectsId = table.Column<long>(type: "bigint", nullable: true),
                    TermCAId = table.Column<long>(type: "bigint", nullable: true),
                    StudentId = table.Column<long>(type: "bigint", nullable: true),
                    TeacherId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectCA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectCA_GradePoint_GradePointId",
                        column: x => x.GradePointId,
                        principalTable: "GradePoint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectCA_Level_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectCA_Setup_SetupId",
                        column: x => x.SetupId,
                        principalTable: "Setup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectCA_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectCA_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectCA_Term_TermId",
                        column: x => x.TermId,
                        principalTable: "Term",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectCA_TermCA_TermCAId",
                        column: x => x.TermCAId,
                        principalTable: "TermCA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assessment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    AssessmntDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Mark = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    StudentsId = table.Column<long>(type: "bigint", nullable: true),
                    TeachersId = table.Column<long>(type: "bigint", nullable: true),
                    TermId = table.Column<long>(type: "bigint", nullable: true),
                    LevelId = table.Column<long>(type: "bigint", nullable: true),
                    SetupId = table.Column<long>(type: "bigint", nullable: true),
                    SubjectsId = table.Column<long>(type: "bigint", nullable: true),
                    SubjectCAId = table.Column<long>(type: "bigint", nullable: true),
                    StudentId = table.Column<long>(type: "bigint", nullable: true),
                    TeacherId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assessment_Level_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assessment_Setup_SetupId",
                        column: x => x.SetupId,
                        principalTable: "Setup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assessment_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assessment_SubjectCA_SubjectCAId",
                        column: x => x.SubjectCAId,
                        principalTable: "SubjectCA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assessment_Subjects_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assessment_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assessment_Term_TermId",
                        column: x => x.TermId,
                        principalTable: "Term",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Term_SessionId",
                table: "Term",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Register_LevelId",
                table: "Register",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Register_TermId",
                table: "Register",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_Fees_OrganisationId",
                table: "Fees",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_RegisterId",
                table: "Attendance",
                column: "RegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessment_LevelId",
                table: "Assessment",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessment_SetupId",
                table: "Assessment",
                column: "SetupId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessment_StudentId",
                table: "Assessment",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessment_SubjectCAId",
                table: "Assessment",
                column: "SubjectCAId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessment_SubjectsId",
                table: "Assessment",
                column: "SubjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessment_TeacherId",
                table: "Assessment",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessment_TermId",
                table: "Assessment",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_GradePoint_SetupId",
                table: "GradePoint",
                column: "SetupId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCA_GradePointId",
                table: "SubjectCA",
                column: "GradePointId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCA_LevelId",
                table: "SubjectCA",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCA_SetupId",
                table: "SubjectCA",
                column: "SetupId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCA_StudentId",
                table: "SubjectCA",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCA_TeacherId",
                table: "SubjectCA",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCA_TermCAId",
                table: "SubjectCA",
                column: "TermCAId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCA_TermId",
                table: "SubjectCA",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_TermCA_GradePointId",
                table: "TermCA",
                column: "GradePointId");

            migrationBuilder.CreateIndex(
                name: "IX_TermCA_LevelId",
                table: "TermCA",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_TermCA_SessionId",
                table: "TermCA",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_TermCA_SetupId",
                table: "TermCA",
                column: "SetupId");

            migrationBuilder.CreateIndex(
                name: "IX_TermCA_TermId",
                table: "TermCA",
                column: "TermId",
                unique: true,
                filter: "[TermId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Register_RegisterId",
                table: "Attendance",
                column: "RegisterId",
                principalTable: "Register",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fees_Member_MemberId",
                table: "Fees",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fees_Organisation_OrganisationId",
                table: "Fees",
                column: "OrganisationId",
                principalTable: "Organisation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Register_Level_LevelId",
                table: "Register",
                column: "LevelId",
                principalTable: "Level",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Register_Term_TermId",
                table: "Register",
                column: "TermId",
                principalTable: "Term",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Term_Session_SessionId",
                table: "Term",
                column: "SessionId",
                principalTable: "Session",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Register_RegisterId",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Fees_Member_MemberId",
                table: "Fees");

            migrationBuilder.DropForeignKey(
                name: "FK_Fees_Organisation_OrganisationId",
                table: "Fees");

            migrationBuilder.DropForeignKey(
                name: "FK_Register_Level_LevelId",
                table: "Register");

            migrationBuilder.DropForeignKey(
                name: "FK_Register_Term_TermId",
                table: "Register");

            migrationBuilder.DropForeignKey(
                name: "FK_Term_Session_SessionId",
                table: "Term");

            migrationBuilder.DropTable(
                name: "Assessment");

            migrationBuilder.DropTable(
                name: "SubjectCA");

            migrationBuilder.DropTable(
                name: "TermCA");

            migrationBuilder.DropTable(
                name: "GradePoint");

            migrationBuilder.DropIndex(
                name: "IX_Term_SessionId",
                table: "Term");

            migrationBuilder.DropIndex(
                name: "IX_Register_LevelId",
                table: "Register");

            migrationBuilder.DropIndex(
                name: "IX_Register_TermId",
                table: "Register");

            migrationBuilder.DropIndex(
                name: "IX_Fees_OrganisationId",
                table: "Fees");

            migrationBuilder.DropIndex(
                name: "IX_Attendance_RegisterId",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "TransactionDate",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "FeeDate",
                table: "Fees");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Fees");

            migrationBuilder.DropColumn(
                name: "RegisterId",
                table: "Attendance");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "Fees",
                newName: "SetupId");

            migrationBuilder.RenameIndex(
                name: "IX_Fees_MemberId",
                table: "Fees",
                newName: "IX_Fees_SetupId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Fees_Setup_SetupId",
                table: "Fees",
                column: "SetupId",
                principalTable: "Setup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
