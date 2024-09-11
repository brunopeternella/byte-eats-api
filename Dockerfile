FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["API.ByteEats/API.ByteEats.csproj", "API.ByteEats/"]
COPY ["API.ByteEats.Domain/API.ByteEats.Domain.csproj", "API.ByteEats.Domain/"]
COPY ["API.ByteEats.Infrastructure/API.ByteEats.Infrastructure.csproj", "API.ByteEats.Infrastructure/"]
RUN dotnet restore "API.ByteEats/API.ByteEats.csproj"
RUN dotnet restore "API.ByteEats.Domain/API.ByteEats.Domain.csproj"
RUN dotnet restore "API.ByteEats.Infrastructure/API.ByteEats.Infrastructure.csproj"
COPY . .
WORKDIR "/src/API.ByteEats"
RUN dotnet build "API.ByteEats.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.ByteEats.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.ByteEats.dll"]
