using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Migrations
{
    public partial class BookLendTableNameChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookBorrows",
                schema: "IM");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookLends",
                schema: "IM");

            migrationBuilder.CreateTable(
                name: "BookBorrows",
                schema: "IM",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimatedReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsReturned = table.Column<bool>(type: "bit", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VisitorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBorrows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookBorrows_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "IM",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBorrows_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalSchema: "VM",
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrows_BookId",
                schema: "IM",
                table: "BookBorrows",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrows_VisitorId",
                schema: "IM",
                table: "BookBorrows",
                column: "VisitorId");
        }
    }
}
