using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftIran.DataLayer.Migrations
{
    public partial class df : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OffishUser_AspNetRoles_RoleId",
                table: "OffishUser");

            migrationBuilder.DropForeignKey(
                name: "FK_OffishUser_AspNetUsers_UserId",
                table: "OffishUser");

            migrationBuilder.DropForeignKey(
                name: "FK_OffishUser_Offishes_OffishId",
                table: "OffishUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OffishUser",
                table: "OffishUser");

            migrationBuilder.RenameTable(
                name: "OffishUser",
                newName: "OffishUsers");

            migrationBuilder.RenameIndex(
                name: "IX_OffishUser_UserId",
                table: "OffishUsers",
                newName: "IX_OffishUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OffishUser_RoleId",
                table: "OffishUsers",
                newName: "IX_OffishUsers_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_OffishUser_OffishId",
                table: "OffishUsers",
                newName: "IX_OffishUsers_OffishId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OffishUsers",
                table: "OffishUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OffishUsers_AspNetRoles_RoleId",
                table: "OffishUsers",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OffishUsers_AspNetUsers_UserId",
                table: "OffishUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OffishUsers_Offishes_OffishId",
                table: "OffishUsers",
                column: "OffishId",
                principalTable: "Offishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OffishUsers_AspNetRoles_RoleId",
                table: "OffishUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_OffishUsers_AspNetUsers_UserId",
                table: "OffishUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_OffishUsers_Offishes_OffishId",
                table: "OffishUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OffishUsers",
                table: "OffishUsers");

            migrationBuilder.RenameTable(
                name: "OffishUsers",
                newName: "OffishUser");

            migrationBuilder.RenameIndex(
                name: "IX_OffishUsers_UserId",
                table: "OffishUser",
                newName: "IX_OffishUser_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OffishUsers_RoleId",
                table: "OffishUser",
                newName: "IX_OffishUser_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_OffishUsers_OffishId",
                table: "OffishUser",
                newName: "IX_OffishUser_OffishId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OffishUser",
                table: "OffishUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OffishUser_AspNetRoles_RoleId",
                table: "OffishUser",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OffishUser_AspNetUsers_UserId",
                table: "OffishUser",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OffishUser_Offishes_OffishId",
                table: "OffishUser",
                column: "OffishId",
                principalTable: "Offishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
