using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUser_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_base_user_Nickname",
                table: "base_user");

            migrationBuilder.DropIndex(
                name: "IX_base_user_PhoneNumber",
                table: "base_user");

            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "base_user");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "base_user");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "base_user",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "base_user",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_base_user_Nickname",
                table: "base_user",
                column: "Nickname",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_base_user_PhoneNumber",
                table: "base_user",
                column: "PhoneNumber",
                unique: true);
        }
    }
}
