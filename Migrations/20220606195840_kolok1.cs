using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PreKolos2.Migrations
{
    public partial class kolok1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AssignmentDate",
                table: "FireTruck_Action",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 6, 21, 58, 40, 616, DateTimeKind.Local).AddTicks(5652),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 6, 21, 53, 25, 61, DateTimeKind.Local).AddTicks(5049));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AssignmentDate",
                table: "FireTruck_Action",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 6, 21, 53, 25, 61, DateTimeKind.Local).AddTicks(5049),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 6, 21, 58, 40, 616, DateTimeKind.Local).AddTicks(5652));
        }
    }
}
