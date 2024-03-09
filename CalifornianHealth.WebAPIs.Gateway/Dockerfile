FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CalifornianHealth.WebAPIs.Gateway/CalifornianHealth.WebAPIs.Gateway.csproj", "CalifornianHealth.WebAPIs.Gateway/"]
COPY ["CalifornianHealth.Core/CalifornianHealth.Core.csproj", "CalifornianHealth.Core/"]
COPY ["CalifornianHealth.Infrastructure/CalifornianHealth.Infrastructure.csproj", "CalifornianHealth.Infrastructure/"]
RUN dotnet restore "./CalifornianHealth.WebAPIs.Gateway/CalifornianHealth.WebAPIs.Gateway.csproj"
COPY . .
WORKDIR "/src/CalifornianHealth.WebAPIs.Gateway"
RUN dotnet build "./CalifornianHealth.WebAPIs.Gateway.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CalifornianHealth.WebAPIs.Gateway.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalifornianHealth.WebAPIs.Gateway.dll"]