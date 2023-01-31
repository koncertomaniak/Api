using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Koncertomaniak.Api.Module.Ticket.Infrastructure.Migrations
{
    public partial class EventTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketProviders_Events_EventsPK",
                table: "TicketProviders");

            migrationBuilder.DropIndex(
                name: "IX_TicketProviders_EventsPK",
                table: "TicketProviders");

            migrationBuilder.DropColumn(
                name: "EventsPK",
                table: "TicketProviders");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "TicketProviders");

            migrationBuilder.CreateTable(
                name: "EventTickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    TicketProvidersPK = table.Column<Guid>(type: "uuid", nullable: false),
                    EventsPK = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventTickets_Events_EventsPK",
                        column: x => x.EventsPK,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTickets_TicketProviders_TicketProviderId",
                        column: x => x.TicketProvidersPK,
                        principalTable: "TicketProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventTickets_EventsPK",
                table: "EventTickets",
                column: "EventsPK");

            migrationBuilder.CreateIndex(
                name: "IX_EventTickets_TicketProvidersPK",
                table: "EventTickets",
                column: "TicketProvidersPK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventTickets");
            
            migrationBuilder.AddColumn<Guid>(
                name: "EventsPK",
                table: "TicketProviders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "TicketProviders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TicketProviders_EventsPK",
                table: "TicketProviders",
                column: "EventsPK");
        }
    }
}
