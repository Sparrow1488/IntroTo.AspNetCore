using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FormSender.Data.Migrations
{
    public partial class OneToOneFormsAndContent2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageForms_Content_ContentId",
                table: "MessageForms");

            migrationBuilder.DropIndex(
                name: "IX_MessageForms_ContentId",
                table: "MessageForms");

            migrationBuilder.DropColumn(
                name: "ContentId",
                table: "MessageForms");

            migrationBuilder.AddForeignKey(
                name: "FK_Content_MessageForms_Id",
                table: "Content",
                column: "Id",
                principalTable: "MessageForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Content_MessageForms_Id",
                table: "Content");

            migrationBuilder.AddColumn<Guid>(
                name: "ContentId",
                table: "MessageForms",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MessageForms_ContentId",
                table: "MessageForms",
                column: "ContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageForms_Content_ContentId",
                table: "MessageForms",
                column: "ContentId",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
