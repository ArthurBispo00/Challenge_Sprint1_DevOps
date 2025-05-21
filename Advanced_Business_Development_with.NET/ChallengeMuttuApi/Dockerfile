# Etapa base (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ChallengeMuttuApi/ChallengeMuttuApi.csproj", "ChallengeMuttuApi/"]
RUN dotnet restore "ChallengeMuttuApi/ChallengeMuttuApi.csproj"
COPY . .
WORKDIR "/src/ChallengeMuttuApi"
RUN dotnet build "ChallengeMuttuApi.csproj" -c Release -o /app/build

# Etapa de publish
FROM build AS publish
RUN dotnet publish "ChallengeMuttuApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChallengeMuttuApi.dll"]
