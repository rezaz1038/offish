using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftIran.DataLayer.Migrations
{
    public partial class dfT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionMakerId",
                table: "OffishActions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActionMakerId",
                table: "OffishActions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
