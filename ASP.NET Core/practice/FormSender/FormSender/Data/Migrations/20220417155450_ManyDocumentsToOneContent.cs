using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FormSender.Data.Migrations
{
    public partial class ManyDocumentsToOneContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Content_Id",
                table: "Documents",
                column: "Id",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Content_Id",
                table: "Documents");

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
    }
}
