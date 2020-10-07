FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY WAApuestas/*.csproj ./WAApuestas/
COPY UTGestionApuestas/*.csproj ./UTGestionApuestas/

RUN dotnet restore

# copy everything else and build app
COPY WAApuestas/. ./WAApuestas/
COPY UTGestionApuestas/. ./UTGestionApuestas/

WORKDIR /source/WAApuestas
RUN dotnet publish -c release -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "WAApuestas.dll"]

