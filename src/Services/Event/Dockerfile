#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Restore
COPY ["Event.API/Event.API.csproj", "Event.API/"]
COPY ["Event.Application/Event.Application.csproj", "Event.Application/"]
COPY ["Event.Common/Event.Common.csproj", "Event.Common/"]
COPY ["Event.Domain/Event.Domain.csproj", "Event.Domain/"]
COPY ["Event.Infrastructure/Event.Infrastructure.csproj", "Event.Infrastructure/"]
RUN dotnet restore "Event.API/Event.API.csproj"
RUN dotnet restore "Event.Application/Event.Application.csproj"
RUN dotnet restore "Event.Common/Event.Common.csproj"
RUN dotnet restore "Event.Domain/Event.Domain.csproj"
RUN dotnet restore "Event.Infrastructure/Event.Infrastructure.csproj"
COPY ["Tests/EventUnitTests/EventUnitTests.csproj", "Tests/EventUnitTests/"]
RUN dotnet restore "Tests/EventUnitTests/EventUnitTests.csproj"

# Copy all source codes
COPY . .

# Build
RUN dotnet build "Event.API/Event.API.csproj" -c Release -o /app/build

# Run unit tests
RUN dotnet test "Tests/EventUnitTests/EventUnitTests.csproj"

# Publish
FROM build AS publish
RUN dotnet publish "Event.API/Event.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final image using runtime assemblies and publish artifacts
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Event.API.dll"]