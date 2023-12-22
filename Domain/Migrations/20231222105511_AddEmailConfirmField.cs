using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailConfirmField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEmailConfirmed",
                table: "base_user",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "VerificationToken",
                table: "base_user",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_base_user_VerificationToken",
                table: "base_user",
                column: "VerificationToken",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_base_user_VerificationToken",
                table: "base_user");

            migrationBuilder.DropColumn(
                name: "IsEmailConfirmed",
                table: "base_user");

            migrationBuilder.DropColumn(
                name: "VerificationToken",
                table: "base_user");
        }
    }
}
