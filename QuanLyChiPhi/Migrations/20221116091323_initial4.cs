using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyChiPhi.Migrations
{
    public partial class initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SoPhieu",
                table: "QuanLyPhi",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoPhieu",
                table: "QuanLyPhi");
        }
    }
}
