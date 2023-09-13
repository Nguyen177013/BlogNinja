using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBlog.Migrations
{
    public partial class UpdateBlogBody : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Blog_Body",
                table: "Blogs",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Blog_Body",
                table: "Blogs");
        }
    }
}
