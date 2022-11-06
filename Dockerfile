FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine3.16 AS build

WORKDIR /src

COPY . .

RUN dotnet restore
RUN dotnet publish src/Bootstrapper/Koncertomaniak.Api.Bootstrapper -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine3.16

WORKDIR /app

COPY --from=build /app .

EXPOSE 80 443

CMD [ "dotnet", "Koncertomaniak.Api.Bootstrapper.dll" ]