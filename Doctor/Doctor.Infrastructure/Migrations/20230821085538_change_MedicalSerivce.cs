using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doctor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class change_MedicalSerivce : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "MedicalServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "MedicalServices");
        }
    }
}
