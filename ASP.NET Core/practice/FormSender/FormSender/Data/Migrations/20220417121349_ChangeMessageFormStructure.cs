using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FormSender.Data.Migrations
{
    public partial class ChangeMessageFormStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "MessageForms");

            migrationBuilder.AddColumn<Guid>(
                name: "ContentId",
                table: "MessageForms",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebDocument",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebDocument_Content_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MessageForms_ContentId",
                table: "MessageForms",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_WebDocument_ContentId",
                table: "WebDocument",
                column: "ContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageForms_Content_ContentId",
                table: "MessageForms",
                column: "ContentId",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageForms_Content_ContentId",
                table: "MessageForms");

            migrationBuilder.DropTable(
                name: "WebDocument");

            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropIndex(
                name: "IX_MessageForms_ContentId",
                table: "MessageForms");

            migrationBuilder.DropColumn(
                name: "ContentId",
                table: "MessageForms");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "MessageForms",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
