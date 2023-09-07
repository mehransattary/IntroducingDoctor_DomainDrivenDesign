using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doctor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class change_visit_time : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisitTimes_VisitDays_VisitDayId",
                schema: "visit",
                table: "VisitTimes");

            migrationBuilder.DropColumn(
                name: "VisitDaysId",
                schema: "visit",
                table: "VisitTimes");

            migrationBuilder.AlterColumn<long>(
                name: "VisitDayId",
                schema: "visit",
                table: "VisitTimes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitTimes_VisitDays_VisitDayId",
                schema: "visit",
                table: "VisitTimes",
                column: "VisitDayId",
                principalSchema: "visit",
                principalTable: "VisitDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisitTimes_VisitDays_VisitDayId",
                schema: "visit",
                table: "VisitTimes");

            migrationBuilder.AlterColumn<long>(
                name: "VisitDayId",
                schema: "visit",
                table: "VisitTimes",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "VisitDaysId",
                schema: "visit",
                table: "VisitTimes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitTimes_VisitDays_VisitDayId",
                schema: "visit",
                table: "VisitTimes",
                column: "VisitDayId",
                principalSchema: "visit",
                principalTable: "VisitDays",
                principalColumn: "Id");
        }
    }
}
