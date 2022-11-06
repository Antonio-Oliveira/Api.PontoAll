using Microsoft.EntityFrameworkCore.Migrations;

namespace PontoAll.Service.Data.Migrations
{
    public partial class ModifyCpfForText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "AspNetUsers",
                type: "nchar(11)",
                fixedLength: true,
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldFixedLength: true,
                oldMaxLength: 11,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CPF",
                table: "AspNetUsers",
                type: "int",
                fixedLength: true,
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(11)",
                oldFixedLength: true,
                oldMaxLength: 11,
                oldNullable: true);
        }
    }
}
