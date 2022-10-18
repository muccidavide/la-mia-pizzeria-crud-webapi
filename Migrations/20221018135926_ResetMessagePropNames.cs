using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace la_mia_pizzeria_post.Migrations
{
    public partial class ResetMessagePropNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenderFullName",
                table: "Messages",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "SenderEmail",
                table: "Messages",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Messages",
                newName: "SenderFullName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Messages",
                newName: "SenderEmail");
        }
    }
}
