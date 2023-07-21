#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Restore
COPY ["User.WebApp/User.WebApp.csproj", "User.WebApp/"]
RUN dotnet restore "User.WebApp/User.WebApp.csproj"

# Copy all source codes
COPY . .

# Build
RUN dotnet build "User.WebApp/User.WebApp.csproj" -c Release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "User.WebApp/User.WebApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final image using runtime assemblies and publish artifacts
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "User.WebApp.dll"]