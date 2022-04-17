using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FormSender.Data.Migrations
{
    public partial class AddDocumentsToContentProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ContentId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ContentId",
                table: "Documents",
                column: "ContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Content_ContentId",
                table: "Documents",
                column: "ContentId",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Content_ContentId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_ContentId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ContentId",
                table: "Documents");
        }
    }
}
