#!/bin/sh

dotnet ef database update -p ./src/Modules/Event/Koncertomaniak.Api.Module.Event.Infrastructure
psql --version
psql -h postgres -p 5432 -U test -d koncertomaniak -f data/Events.sql << test