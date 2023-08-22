using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Migrations
{
    public partial class InventoryManagementSchemaAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "IM");

            migrationBuilder.EnsureSchema(
                name: "VM");

            migrationBuilder.RenameTable(
                name: "Books",
                schema: "LMS",
                newName: "Books",
                newSchema: "IM");

            migrationBuilder.CreateTable(
                name: "BookStatuses",
                schema: "IM",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BookId = table.Column<Guid>(nullable: false),
                    Status = table.Column<byte>(nullable: false)
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
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookBorrows",
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

            migrationBuilder.CreateIndex(
                name: "IX_BookStatuses_BookId",
                schema: "IM",
                table: "BookStatuses",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookBorrows",
                schema: "IM");

            migrationBuilder.DropTable(
                name: "BookStatuses",
                schema: "IM");

            migrationBuilder.DropTable(
                name: "Visitors",
                schema: "VM");

            migrationBuilder.EnsureSchema(
                name: "LMS");

            migrationBuilder.RenameTable(
                name: "Books",
                schema: "IM",
                newName: "Books",
                newSchema: "LMS");
        }
    }
}
