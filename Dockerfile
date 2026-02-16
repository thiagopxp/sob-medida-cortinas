# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Install Node.js for building frontend assets
RUN curl -fsSL https://deb.nodesource.com/setup_20.x | bash - \
    && apt-get install -y nodejs \
    && rm -rf /var/lib/apt/lists/*

# Copy project file
COPY ["SobMedidaCortinas/SobMedidaCortinas.Web.Core/SobMedidaCortinas.Web.Core.csproj", "SobMedidaCortinas/SobMedidaCortinas.Web.Core/"]

# Restore NuGet packages
RUN dotnet restore "SobMedidaCortinas/SobMedidaCortinas.Web.Core/SobMedidaCortinas.Web.Core.csproj"

# Copy the rest of the application code
COPY SobMedidaCortinas/ SobMedidaCortinas/

# Set working directory to the web project
WORKDIR /src/SobMedidaCortinas/SobMedidaCortinas.Web.Core

# Install npm dependencies and build CSS from LESS
RUN npm install && npm run build

# Build and publish the .NET application
RUN dotnet publish "SobMedidaCortinas.Web.Core.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy published application from build stage
COPY --from=build /app/publish .

# Expose ports
EXPOSE 8080
EXPOSE 8081

# Set environment variables
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

# Run the application
ENTRYPOINT ["dotnet", "SobMedidaCortinas.Web.Core.dll"]
