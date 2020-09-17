using MarsTek.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Data.Common;

namespace MarsTek.Migrations
{
    public partial class addServiceToDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Kind = table.Column<string>(nullable: true),
                    InfoBody = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });
            using (DbConnection connection = new SqlConnection("DefaultConnection"))
            {
                connection.Open();
                using (DbCommand command = new SqlCommand("alter table [Service] add [PicUrl] string default NULL"))
                {
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Service");
        }
    }
}
