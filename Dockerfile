# Base image for runtime environment
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5269
EXPOSE 7106

# Image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy the .csproj files and restore dependencies
COPY ["EquityAfia.UserManagement.Api/EquityAfia.UserManagement.Api.csproj", "EquityAfia.UserManagement.Api/"]
COPY ["EquityAfia.UserManagement.Application/EquityAfia.UserManagement.Application.csproj", "EquityAfia.UserManagement.Application/"]
COPY ["EquityAfia.UserManagement.Contracts/EquityAfia.UserManagement.Contracts.csproj", "EquityAfia.UserManagement.Contracts/"]
COPY ["EquityAfia.UserManagement.Domain/EquityAfia.UserManagement.Domain.csproj", "EquityAfia.UserManagement.Domain/"]
COPY ["EquityAfia.UserManagement.Infrastructure/EquityAfia.UserManagement.Infrastructure.csproj", "EquityAfia.UserManagement.Infrastructure/"]

RUN dotnet restore "EquityAfia.UserManagement.Api/EquityAfia.UserManagement.Api.csproj"

# Copy the rest of the source code
COPY . .
WORKDIR "/src/EquityAfia.UserManagement.Api"

# Build the application
RUN dotnet build "EquityAfia.UserManagement.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "EquityAfia.UserManagement.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EquityAfia.UserManagement.Api.dll"]
