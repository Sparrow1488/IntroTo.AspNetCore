using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnEnglish.Migrations.ProfilesDb
{
    public partial class profil2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WordsDictionary_Profiles_ProfileKey",
                table: "WordsDictionary");

            migrationBuilder.RenameColumn(
                name: "ProfileKey",
                table: "WordsDictionary",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_WordsDictionary_ProfileKey",
                table: "WordsDictionary",
                newName: "IX_WordsDictionary_ProfileId");

            migrationBuilder.RenameColumn(
                name: "Key",
                table: "Profiles",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WordsDictionary_Profiles_ProfileId",
                table: "WordsDictionary",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WordsDictionary_Profiles_ProfileId",
                table: "WordsDictionary");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "WordsDictionary",
                newName: "ProfileKey");

            migrationBuilder.RenameIndex(
                name: "IX_WordsDictionary_ProfileId",
                table: "WordsDictionary",
                newName: "IX_WordsDictionary_ProfileKey");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Profiles",
                newName: "Key");

            migrationBuilder.AddForeignKey(
                name: "FK_WordsDictionary_Profiles_ProfileKey",
                table: "WordsDictionary",
                column: "ProfileKey",
                principalTable: "Profiles",
                principalColumn: "Key",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
