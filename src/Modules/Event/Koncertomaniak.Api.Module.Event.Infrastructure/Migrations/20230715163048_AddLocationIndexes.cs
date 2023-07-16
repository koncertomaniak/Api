using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Koncertomaniak.Api.Module.Event.Infrastructure.Migrations
{
    public partial class AddLocationIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_Events_EventsPK",
                table: "Location");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "Locations");

            migrationBuilder.RenameIndex(
                name: "IX_Location_EventsPK",
                table: "Locations",
                newName: "IX_Locations_EventsPK");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_City_Place",
                table: "Locations",
                columns: new[] { "City", "Place" });

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Events_EventsPK",
                table: "Locations",
                column: "EventsPK",
                principalTable: "Events",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Events_EventsPK",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_City_Place",
                table: "Locations");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Location");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_EventsPK",
                table: "Location",
                newName: "IX_Location_EventsPK");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Events_EventsPK",
                table: "Location",
                column: "EventsPK",
                principalTable: "Events",
                principalColumn: "Id");
        }
    }
}
