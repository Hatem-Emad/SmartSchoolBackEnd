using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartSchool.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addedstdbirthcertphoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentBirthCertPhotoUrl",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudentBirthCertPhotoUrl",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentBirthCertPhotoUrl",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentBirthCertPhotoUrl",
                table: "Requests");
        }
    }
}
