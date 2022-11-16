using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyChiPhi.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isGanNhat",
                table: "QuanLyPhi",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IdChungCu",
                table: "CanHo_PhuongTien",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdLoaiXe",
                table: "CanHo_PhuongTien",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isGanNhat",
                table: "QuanLyPhi");

            migrationBuilder.DropColumn(
                name: "IdChungCu",
                table: "CanHo_PhuongTien");

            migrationBuilder.DropColumn(
                name: "IdLoaiXe",
                table: "CanHo_PhuongTien");
        }
    }
}
