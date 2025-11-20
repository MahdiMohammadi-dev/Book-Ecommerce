using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KetabSara.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class addimagenametobook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Books");
        }
    }
}
