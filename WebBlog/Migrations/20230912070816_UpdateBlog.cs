using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBlog.Migrations
{
    public partial class UpdateBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Snippet",
                table: "Blogs",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Snippet",
                table: "Blogs");
        }
    }
}
