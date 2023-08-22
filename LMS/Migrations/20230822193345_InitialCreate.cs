using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "IM");

            migrationBuilder.EnsureSchema(
                name: "OS");

            migrationBuilder.EnsureSchema(
                name: "VM");

            migrationBuilder.CreateTable(
                name: "Files",
                schema: "OS",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Folder = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Extension = table.Column<string>(nullable: true),
                    ContentType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
                schema: "VM",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                schema: "IM",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CoverImageId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Files_CoverImageId",
                        column: x => x.CoverImageId,
                        principalSchema: "OS",
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookLends",
                schema: "IM",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BookId = table.Column<Guid>(nullable: false),
                    VisitorId = table.Column<Guid>(nullable: false),
                    BorrowDate = table.Column<DateTime>(nullable: false),
                    EstimatedReturnDate = table.Column<DateTime>(nullable: true),
                    ReturnDate = table.Column<DateTime>(nullable: true),
                    IsReturned = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookLends_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "IM",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookLends_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalSchema: "VM",
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookStatuses",
                schema: "IM",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BookId = table.Column<Guid>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookStatuses_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "IM",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookLends_BookId",
                schema: "IM",
                table: "BookLends",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookLends_VisitorId",
                schema: "IM",
                table: "BookLends",
                column: "VisitorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CoverImageId",
                schema: "IM",
                table: "Books",
                column: "CoverImageId");

            migrationBuilder.CreateIndex(
                name: "IX_BookStatuses_BookId",
                schema: "IM",
                table: "BookStatuses",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookLends",
                schema: "IM");

            migrationBuilder.DropTable(
                name: "BookStatuses",
                schema: "IM");

            migrationBuilder.DropTable(
                name: "Visitors",
                schema: "VM");

            migrationBuilder.DropTable(
                name: "Books",
                schema: "IM");

            migrationBuilder.DropTable(
                name: "Files",
                schema: "OS");
        }
    }
}
