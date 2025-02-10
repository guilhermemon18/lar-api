FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Backend.Api/*.csproj ./Backend.Api/
RUN dotnet restore

# copy everything else and build app
COPY Backend.Api/. ./Backend.Api/
WORKDIR /source/Backend.Api
RUN dotnet publish -c release -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app ./

ENTRYPOINT ["dotnet", "Backend.Api.dll"]