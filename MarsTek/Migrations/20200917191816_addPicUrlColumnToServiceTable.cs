using Microsoft.EntityFrameworkCore.Migrations;

namespace MarsTek.Migrations
{
    public partial class addPicUrlColumnToServiceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PicUrl",
                table: "Service",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PicUrl",
                table: "Service");
        }
    }
}
