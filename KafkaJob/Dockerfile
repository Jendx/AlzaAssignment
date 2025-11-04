FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy projects
COPY ["KafkaJob/KafkaJob.csproj", "KafkaJob/"]
COPY [".env", "KafkaJob/"]
COPY ["Domain/Domain.csproj", "Domain/"]

RUN dotnet restore "KafkaJob/KafkaJob.csproj"
COPY . .

WORKDIR "/src/KafkaJob"
RUN dotnet build "./KafkaJob.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./KafkaJob.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KafkaJob.dll"]
