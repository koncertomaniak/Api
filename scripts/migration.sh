#!/bin/sh

dotnet ef database update -p ./src/Modules/Event/Koncertomaniak.Api.Module.Event.Infrastructure
dotnet ef database update -p ./src/Modules/Ticket/Koncertomaniak.Api.Module.Ticket.Infrastructure
psql --version
psql -h postgres -p 5432 -U test -d koncertomaniak -f data/Events.sql < test 
psql -h postgres -p 5432 -U test -d koncertomaniak -f data/TicketProviders.sql < test
