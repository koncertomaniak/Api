using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Koncertomaniak.Api.Module.Event.Infrastructure.Migrations
{
    public partial class UseIndexOnNameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Events_Name",
                table: "Events",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Events_Name",
                table: "Events");
        }
    }
}
