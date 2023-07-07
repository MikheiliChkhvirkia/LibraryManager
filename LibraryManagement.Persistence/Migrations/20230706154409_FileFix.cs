using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FileFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_File_FileId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_FileId",
                table: "Books");

            migrationBuilder.AlterColumn<Guid>(
                name: "FileId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Books_FileId",
                table: "Books",
                column: "FileId",
                unique: true,
                filter: "[FileId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_File_FileId",
                table: "Books",
                column: "FileId",
                principalTable: "File",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_File_FileId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_FileId",
                table: "Books");

            migrationBuilder.AlterColumn<Guid>(
                name: "FileId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_FileId",
                table: "Books",
                column: "FileId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_File_FileId",
                table: "Books",
                column: "FileId",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
