FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CalifornianHealth.WebAPIs.Calendar/CalifornianHealth.WebAPIs.Calendar.csproj", "CalifornianHealth.WebAPIs.Calendar/"]
COPY ["CalifornianHealth.Core/CalifornianHealth.Core.csproj", "CalifornianHealth.Core/"]
COPY ["CalifornianHealth.Infrastructure/CalifornianHealth.Infrastructure.csproj", "CalifornianHealth.Infrastructure/"]
COPY ["CalifornianHealth.Infrastructure/CalifornianHealth.Infrastructure.csproj", "CalifornianHealth.Infrastructure/"]
RUN dotnet restore "./CalifornianHealth.WebAPIs.Calendar/CalifornianHealth.WebAPIs.Calendar.csproj"
COPY . .
WORKDIR "/src/CalifornianHealth.WebAPIs.Calendar"
RUN dotnet build "./CalifornianHealth.WebAPIs.Calendar.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CalifornianHealth.WebAPIs.Calendar.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalifornianHealth.WebAPIs.Calendar.dll"]