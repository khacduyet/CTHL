using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyChiPhi.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdLoaiDongPhi",
                table: "QuanLyPhi",
                newName: "LoaiDongPhi");

            migrationBuilder.AddColumn<bool>(
                name: "isXeNgoai",
                table: "QuanLyPhi",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isXeNgoai",
                table: "QuanLyPhi");

            migrationBuilder.RenameColumn(
                name: "LoaiDongPhi",
                table: "QuanLyPhi",
                newName: "IdLoaiDongPhi");
        }
    }
}
