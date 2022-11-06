using Microsoft.EntityFrameworkCore.Migrations;

namespace PontoAll.Service.Data.Migrations
{
    public partial class ADD_FULLNAME_COLLABORATER : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FULL_NAME",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FULL_NAME",
                table: "AspNetUsers");
        }
    }
}
