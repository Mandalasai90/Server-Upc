# See https://aka.ms/customizecontainer to learn how to customize your debug container
# and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy the project files and restore dependencies
COPY ["UrbanPoshAPIApp/UrbanPoshAPIApp.csproj", "UrbanPoshAPIApp/"]
COPY ["Urban.BAL/Urban.BAL.csproj", "Urban.BAL/"]
COPY ["Urban.DAL/Urban.DAL.csproj", "Urban.DAL/"]

# Restore dependencies
RUN dotnet restore "UrbanPoshAPIApp/UrbanPoshAPIApp.csproj"

# Copy the entire source code into the container
COPY . .

# Set the working directory to the main project directory
WORKDIR "/src/UrbanPoshAPIApp"

# Build the application in Release mode
RUN dotnet build "UrbanPoshAPIApp.csproj" -c Release -o /app/build

# Stage 2: Publish the application
FROM build AS publish
RUN dotnet publish "UrbanPoshAPIApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 3: Create the runtime image
FROM base AS final
WORKDIR /app

# Copy the published files from the publish stage
COPY --from=publish /app/publish .

# Set the entry point to run the application
ENTRYPOINT ["dotnet", "UrbanPoshAPIApp.dll"]
