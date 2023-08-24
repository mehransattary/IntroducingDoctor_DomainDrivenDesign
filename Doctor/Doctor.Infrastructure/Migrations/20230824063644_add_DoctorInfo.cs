using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doctor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_DoctorInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalServices",
                table: "MedicalServices");

            migrationBuilder.EnsureSchema(
                name: "doctorInfo");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "MedicalServices",
                newName: "MedicalServicies",
                newSchema: "dbo");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "MedicalServicies",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                schema: "dbo",
                table: "MedicalServicies",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                schema: "dbo",
                table: "MedicalServicies",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalServicies",
                schema: "dbo",
                table: "MedicalServicies",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DoctorInformations",
                schema: "doctorInfo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalLicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "doctorInfo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorInformationId = table.Column<long>(type: "bigint", nullable: false),
                    TextAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CodePosti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_DoctorInformations_DoctorInformationId",
                        column: x => x.DoctorInformationId,
                        principalSchema: "doctorInfo",
                        principalTable: "DoctorInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactNumbers",
                schema: "doctorInfo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorInformationId = table.Column<long>(type: "bigint", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactNumbers_DoctorInformations_DoctorInformationId",
                        column: x => x.DoctorInformationId,
                        principalSchema: "doctorInfo",
                        principalTable: "DoctorInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specialization",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorInformationId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specialization_DoctorInformations_DoctorInformationId",
                        column: x => x.DoctorInformationId,
                        principalSchema: "doctorInfo",
                        principalTable: "DoctorInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_DoctorInformationId",
                schema: "doctorInfo",
                table: "Addresses",
                column: "DoctorInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactNumbers_DoctorInformationId",
                schema: "doctorInfo",
                table: "ContactNumbers",
                column: "DoctorInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialization_DoctorInformationId",
                table: "Specialization",
                column: "DoctorInformationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "doctorInfo");

            migrationBuilder.DropTable(
                name: "ContactNumbers",
                schema: "doctorInfo");

            migrationBuilder.DropTable(
                name: "Specialization");

            migrationBuilder.DropTable(
                name: "DoctorInformations",
                schema: "doctorInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalServicies",
                schema: "dbo",
                table: "MedicalServicies");

            migrationBuilder.RenameTable(
                name: "MedicalServicies",
                schema: "dbo",
                newName: "MedicalServices");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "MedicalServices",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "MedicalServices",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "MedicalServices",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalServices",
                table: "MedicalServices",
                column: "Id");
        }
    }
}
