using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JsonToDbTest.Migrations
{
    public partial class @try : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Seasons",
                newName: "SeasonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeasonId",
                table: "Seasons",
                newName: "Year");
        }
    }
}
