#!/bin/sh

dotnet ef database update -p ./src/Modules/Event/Koncertomaniak.Api.Module.Event.Infrastructure
dotnet ef database update -p ./src/Modules/Ticket/Koncertomaniak.Api.Module.Ticket.Infrastructure
dotnet ef database update -p ./src/Modules/Auth/Koncertomaniak.Api.Module.Auth.Infrastructure
psql --version
export PGPASSWORD="test"
psql -h localhost -p 5432 -U test -d koncertomaniak -f data/Events.sql
psql -h localhost -p 5432 -U test -d koncertomaniak -f data/TicketProviders.sql
psql -h localhost -p 5432 -U test -d koncertomaniak -f data/EventTickets.sql
psql -h localhost -p 5432 -U test -d koncertomaniak -f data/ApiClients.sql
