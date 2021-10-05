using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnEnglish.Migrations
{
    public partial class Dictionary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_Dictionaries_WordsDictionaryId",
                table: "Words");

            migrationBuilder.RenameColumn(
                name: "WordsDictionaryId",
                table: "Words",
                newName: "DictionaryId");

            migrationBuilder.RenameIndex(
                name: "IX_Words_WordsDictionaryId",
                table: "Words",
                newName: "IX_Words_DictionaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Dictionaries_DictionaryId",
                table: "Words",
                column: "DictionaryId",
                principalTable: "Dictionaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_Dictionaries_DictionaryId",
                table: "Words");

            migrationBuilder.RenameColumn(
                name: "DictionaryId",
                table: "Words",
                newName: "WordsDictionaryId");

            migrationBuilder.RenameIndex(
                name: "IX_Words_DictionaryId",
                table: "Words",
                newName: "IX_Words_WordsDictionaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Dictionaries_WordsDictionaryId",
                table: "Words",
                column: "WordsDictionaryId",
                principalTable: "Dictionaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
