using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace repolayer.Migrations
{
    public partial class UsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userid = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userid);
                });

            migrationBuilder.CreateTable(
                name: "NotesTable",
                columns: table => new
                {
                    noteid = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    reminder = table.Column<DateTime>(nullable: false),
                    color = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    isArchived = table.Column<bool>(nullable: false),
                    isPinned = table.Column<bool>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    createdAt = table.Column<DateTime>(nullable: true),
                    editedAt = table.Column<DateTime>(nullable: true),
                    userid = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotesTable", x => x.noteid);
                    table.ForeignKey(
                        name: "FK_NotesTable_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CollaboratorsTable",
                columns: table => new
                {
                    collabId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(nullable: true),
                    userid = table.Column<long>(nullable: false),
                    noteid = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaboratorsTable", x => x.collabId);
                    table.ForeignKey(
                        name: "FK_CollaboratorsTable_NotesTable_noteid",
                        column: x => x.noteid,
                        principalTable: "NotesTable",
                        principalColumn: "noteid",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CollaboratorsTable_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Labels",
                columns: table => new
                {
                    labelID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    label = table.Column<string>(nullable: true),
                    userid = table.Column<long>(nullable: false),
                    noteid = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labels", x => x.labelID);
                    table.ForeignKey(
                        name: "FK_Labels_NotesTable_noteid",
                        column: x => x.noteid,
                        principalTable: "NotesTable",
                        principalColumn: "noteid",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Labels_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollaboratorsTable_noteid",
                table: "CollaboratorsTable",
                column: "noteid");

            migrationBuilder.CreateIndex(
                name: "IX_CollaboratorsTable_userid",
                table: "CollaboratorsTable",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Labels_noteid",
                table: "Labels",
                column: "noteid");

            migrationBuilder.CreateIndex(
                name: "IX_Labels_userid",
                table: "Labels",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_NotesTable_userid",
                table: "NotesTable",
                column: "userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollaboratorsTable");

            migrationBuilder.DropTable(
                name: "Labels");

            migrationBuilder.DropTable(
                name: "NotesTable");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
