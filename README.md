# Sob Medida Cortinas

ASP.NET Core 8 web application for Sob Medida Cortinas curtain and blind services.

## Prerequisites

### For Local Development
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (v18 or later)
- A code editor (Visual Studio, VS Code, or Rider)

### For Docker Deployment
- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/install/) (optional, but recommended)

## Local Development

### 1. Clone the Repository
```bash
git clone <repository-url>
cd sob-medida-cortinas
```

### 2. Restore Dependencies

Navigate to the web project directory:
```bash
cd SobMedidaCortinas/SobMedidaCortinas.Web.Core
```

Restore NuGet packages:
```bash
dotnet restore
```

Install npm dependencies:
```bash
npm install
```

### 3. Build Frontend Assets

Build CSS from LESS files:
```bash
npm run build
```

Or run in watch mode for development:
```bash
npm run dev
```

### 4. Configure Application Settings

Copy the production template if needed:
```bash
cp appsettings.Production.json.template appsettings.Production.json
```

Edit `appsettings.json` or `appsettings.Development.json` with your configuration:
- SendGrid API key (for email functionality)
- ReCaptcha secret key
- Any other application-specific settings

### 5. Run the Application

From the `SobMedidaCortinas.Web.Core` directory:

**Development mode:**
```bash
dotnet run
```

**Or with specific environment:**
```bash
dotnet run --environment Development
```

The application will start at:
- HTTP: `http://localhost:5000`
- HTTPS: `https://localhost:5001`

### 6. Build for Production

Create a production build:
```bash
dotnet build -c Release
```

Publish the application:
```bash
dotnet publish -c Release -o ./publish
```

Run the published application:
```bash
cd publish
dotnet SobMedidaCortinas.Web.Core.dll
```

## Docker Deployment

### Option 1: Using Docker Commands

#### Build the Docker Image
From the project root directory:
```bash
docker build -t sob-medida-cortinas:latest .
```

To build with a specific tag:
```bash
docker build -t sob-medida-cortinas:v1.0.0 .
```

#### Run the Docker Container
```bash
docker run -d \
  --name sob-medida-cortinas-app \
  -p 5000:8080 \
  -e ASPNETCORE_ENVIRONMENT=Production \
  sob-medida-cortinas:latest
```

#### View Container Logs
```bash
docker logs -f sob-medida-cortinas-app
```

#### Stop and Remove Container
```bash
docker stop sob-medida-cortinas-app
docker rm sob-medida-cortinas-app
```

### Option 2: Using Docker Compose (Recommended)

#### Start the Application
```bash
docker-compose up -d
```

Build and start (if you made changes):
```bash
docker-compose up -d --build
```

#### View Logs
```bash
docker-compose logs -f
```

#### Stop the Application
```bash
docker-compose down
```

#### Remove Everything (including volumes)
```bash
docker-compose down -v
```

### Access the Application

Once running, access the application at:
- **Local Development**: `http://localhost:5000` or `https://localhost:5001`
- **Docker**: `http://localhost:5000`

### Environment Variables

You can configure the application using environment variables:

```bash
# Example with Docker run
docker run -d \
  --name sob-medida-cortinas-app \
  -p 5000:8080 \
  -e ASPNETCORE_ENVIRONMENT=Production \
  -e SendGrid__ApiKey="your-api-key" \
  -e ReCaptcha__SecretKey="your-secret-key" \
  sob-medida-cortinas:latest
```

Or create a `.env` file for Docker Compose:
```bash
cp .env.example .env
# Edit .env with your configuration
```

### Mounting Configuration Files

To use a custom `appsettings.Production.json`:

**With Docker run:**
```bash
docker run -d \
  --name sob-medida-cortinas-app \
  -p 5000:8080 \
  -v $(pwd)/appsettings.Production.json:/app/appsettings.Production.json:ro \
  sob-medida-cortinas:latest
```

**With Docker Compose:**
Uncomment the volumes section in `docker-compose.yml`:
```yaml
volumes:
  - ./appsettings.Production.json:/app/appsettings.Production.json:ro
```

## Project Structure

```
sob-medida-cortinas/
├── SobMedidaCortinas/
│   ├── SobMedidaCortinas.sln
│   └── SobMedidaCortinas.Web.Core/
│       ├── Controllers/          # MVC Controllers
│       ├── Models/              # Data models
│       ├── Views/               # Razor views
│       ├── Services/            # Business logic services
│       ├── Data/                # Data access layer
│       ├── wwwroot/             # Static files (CSS, JS, images)
│       ├── Program.cs           # Application entry point
│       ├── appsettings.json     # Configuration
│       └── package.json         # npm dependencies
├── Dockerfile                   # Docker build instructions
├── docker-compose.yml          # Docker Compose configuration
├── .dockerignore               # Docker build exclusions
└── README.md                   # This file
```

## NPM Scripts

Available npm scripts in `package.json`:

- `npm run build` - Build CSS from LESS files (minified and unminified)
- `npm run build:less` - Build unminified CSS
- `npm run build:less:min` - Build minified CSS
- `npm run watch:less` - Watch LESS files and rebuild on changes
- `npm run dev` - Build and watch in development mode

## Troubleshooting

### Port Already in Use
If port 5000 is already in use, change the port mapping:

**Docker run:**
```bash
docker run -d -p 5001:8080 --name sob-medida-cortinas-app sob-medida-cortinas:latest
```

**Docker Compose:**
Edit `docker-compose.yml` and change the ports section:
```yaml
ports:
  - "5001:8080"
```

### CSS Not Building
If CSS is not generating properly:
```bash
cd SobMedidaCortinas/SobMedidaCortinas.Web.Core
rm -rf node_modules
npm install
npm run build
```

### Docker Build Fails
Clear Docker cache and rebuild:
```bash
docker-compose down
docker system prune -a
docker-compose up --build
```

### Application Not Starting
Check logs for errors:
```bash
# Docker Compose
docker-compose logs -f

# Docker run
docker logs -f sob-medida-cortinas-app
```

## Production Deployment

For production deployment:

1. **Set environment variables** for sensitive data (API keys, connection strings)
2. **Use HTTPS** - Configure reverse proxy (nginx, Apache) or use Kestrel with certificates
3. **Configure logging** - Set up application insights or other logging providers
4. **Set up health checks** - Monitor application health
5. **Use container orchestration** - Consider Kubernetes, Docker Swarm, or cloud services

### Example Production nginx Configuration
```nginx
server {
    listen 80;
    server_name your-domain.com;

    location / {
        proxy_pass http://localhost:5000;
        proxy_http_version 1.1;
        proxy_set_header Upgrade $http_upgrade;
        proxy_set_header Connection keep-alive;
        proxy_set_header Host $host;
        proxy_cache_bypass $http_upgrade;
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Proto $scheme;
    }
}
```

## License

[Your License Here]

## Support

For issues and questions, please contact [your contact information].
