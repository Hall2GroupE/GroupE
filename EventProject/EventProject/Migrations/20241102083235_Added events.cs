using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace events.Migrations
{
    /// <inheritdoc />
    public partial class Addedevents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblEvents",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    NumberOfPeople = table.Column<int>(type: "int", nullable: false),
                    HallID = table.Column<int>(type: "int", nullable: false),
                    EventTypeID = table.Column<int>(type: "int", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEvents", x => x.EventID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblEvents");
        }
    }
}
