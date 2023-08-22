using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Migrations
{
    public partial class FileTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "OS");

            migrationBuilder.AddColumn<Guid>(
                name: "CoverImageId",
                schema: "IM",
                table: "Books",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Books_CoverImageId",
                schema: "IM",
                table: "Books",
                column: "CoverImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Files_CoverImageId",
                schema: "IM",
                table: "Books",
                column: "CoverImageId",
                principalSchema: "OS",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Files_CoverImageId",
                schema: "IM",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Files",
                schema: "OS");

            migrationBuilder.DropIndex(
                name: "IX_Books_CoverImageId",
                schema: "IM",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CoverImageId",
                schema: "IM",
                table: "Books");
        }
    }
}
