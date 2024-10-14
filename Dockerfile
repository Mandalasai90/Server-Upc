# Use the ASP.NET base image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Use the SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ServerUpc.csproj", "./"]  # Adjust if the project is in a folder
RUN dotnet restore "./ServerUpc.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ServerUpc.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "ServerUpc.csproj" -c Release -o /app/publish

# Final stage to run the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServerUpc.dll"]  # Adjust if needed
