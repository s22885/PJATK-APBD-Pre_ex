using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PreKolos2.Migrations
{
    public partial class kolok : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Action",
                columns: table => new
                {
                    IdAction = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NeedSpecialEquipment = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Action_pk", x => x.IdAction);
                });

            migrationBuilder.CreateTable(
                name: "FireTruck",
                columns: table => new
                {
                    IdFiretruck = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SpecialEquipment = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("FireTruck_pk", x => x.IdFiretruck);
                });

            migrationBuilder.CreateTable(
                name: "FireTruck_Action",
                columns: table => new
                {
                    IdFireTruck = table.Column<int>(type: "int", nullable: false),
                    IdAction = table.Column<int>(type: "int", nullable: false),
                    AssignmentDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 6, 6, 21, 53, 25, 61, DateTimeKind.Local).AddTicks(5049))
                },
                constraints: table =>
                {
                    table.PrimaryKey("FireTruckAction_pk", x => new { x.IdFireTruck, x.IdAction });
                    table.ForeignKey(
                        name: "FileTruckAction_Action",
                        column: x => x.IdAction,
                        principalTable: "Action",
                        principalColumn: "IdAction",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FileTruckAction_FireTruck",
                        column: x => x.IdFireTruck,
                        principalTable: "FireTruck",
                        principalColumn: "IdFiretruck",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Action",
                columns: new[] { "IdAction", "EndTime", "NeedSpecialEquipment", "StartTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2013, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2012, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2014, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2013, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2015, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2014, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "FireTruck",
                columns: new[] { "IdFiretruck", "OperationNumber", "SpecialEquipment" },
                values: new object[,]
                {
                    { 1, "2137", true },
                    { 2, "69420", true },
                    { 3, "42069", false }
                });

            migrationBuilder.InsertData(
                table: "FireTruck_Action",
                columns: new[] { "IdAction", "IdFireTruck", "AssignmentDate" },
                values: new object[] { 3, 1, new DateTime(2018, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "FireTruck_Action",
                columns: new[] { "IdAction", "IdFireTruck", "AssignmentDate" },
                values: new object[] { 2, 2, new DateTime(2018, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "FireTruck_Action",
                columns: new[] { "IdAction", "IdFireTruck", "AssignmentDate" },
                values: new object[] { 1, 3, new DateTime(2018, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_FireTruck_Action_IdAction",
                table: "FireTruck_Action",
                column: "IdAction");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FireTruck_Action");

            migrationBuilder.DropTable(
                name: "Action");

            migrationBuilder.DropTable(
                name: "FireTruck");
        }
    }
}
