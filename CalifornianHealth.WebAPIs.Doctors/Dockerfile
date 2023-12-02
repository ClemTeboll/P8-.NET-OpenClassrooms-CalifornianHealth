#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CalifornianHealth.WebAPIs.Doctors/CalifornianHealth.WebAPIs.Doctors.csproj", "CalifornianHealth.WebAPIs.Doctors/"]
COPY ["CalifornianHealth.Core/CalifornianHealth.Core.csproj", "CalifornianHealth.Core/"]
COPY ["CalifornianHealth.Infrastructure/CalifornianHealth.Infrastructure.csproj", "CalifornianHealth.Infrastructure/"]
RUN dotnet restore "./CalifornianHealth.WebAPIs.Doctors/./CalifornianHealth.WebAPIs.Doctors.csproj"
COPY . .
WORKDIR "/src/CalifornianHealth.WebAPIs.Doctors"
RUN dotnet build "./CalifornianHealth.WebAPIs.Doctors.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CalifornianHealth.WebAPIs.Doctors.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalifornianHealth.WebAPIs.Doctors.dll"]