FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 7042

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy all csproj files for restore
COPY ["Api/Api.csproj", "Api/"]
COPY ["Data/Data.csproj", "Data/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["UnitTests/UnitTests.csproj", "UnitTests/"]

# Restore dependencies
RUN dotnet restore "Api/Api.csproj"

# Copy the rest of the code
COPY . .

WORKDIR "/src/Api"
RUN dotnet build "./Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]
