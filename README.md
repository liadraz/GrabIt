# GrabIt

## 📖 Overview

A web-based management system designed to replace the manual, paper-based reservation system for power injection units in testing laboratories. This application provides real-time visibility of device availability, automated reservation management, and eliminates the issues of lost paper tags and unclear device ownership.

**Problem Statement:** At Elspec's testing lab, power injection units are reserved using physical paper notes, leading to confusion when papers fall off, unclear ownership duration, and inefficient resource utilization.

**Solution:** A centralized web application that automatically discovers network devices, tracks their status, and allows users to reserve equipment digitally with time-based automatic release.

## ✨ Key Features

### Device Management
- **Automatic Device Discovery**: Scans network IP ranges to detect connected power injection units
- **Real-time Status Monitoring**: Continuously monitors device connectivity and operational status
- **Device Health Tracking**: Detects offline devices, rebooting units, and connectivity issues
- **Visual Status Indicators**: Clear color-coded status (Available, Occupied, Offline, Maintenance)

### Reservation System
- **Quick Reservation**: One-click device reservation with customizable time duration
- **Flexible Time Slots**: Reserve devices for hours, days, or custom periods
- **Automatic Release**: Devices automatically become available when reservation expires
- **Extension Capability**: Extend reservations before they expire
- **Reservation Queue**: See upcoming availability and queue for busy devices

### User Interface
- **Dashboard View**: Grid layout showing all devices with current status
- **Device Details**: Click for detailed information about each unit
- **Reservation History**: Track past and current reservations
- **Search & Filter**: Find devices by IP, status, or location
- **Mobile Responsive**: Access from any device in the lab

### Monitoring & Alerts
- **Real-time Updates**: Live status updates without page refresh
- **Notification System**: Alerts for reservation expiry, device issues
- **Usage Analytics**: Track device utilization patterns
- **Maintenance Mode**: Mark devices as under maintenance

## 🏗️ Architecture Design

### System Architecture

```
┌─────────────────┐    ┌─────────────────┐    ┌─────────────────┐
│   Web Browser   │    │   Mobile App    │    │   Lab Display   │
│                 │    │                 │    │                 │
└─────────┬───────┘    └─────────┬───────┘    └─────────┬───────┘
          │                      │                      │
          └──────────────────────┼──────────────────────┘
                                 │
                    ┌─────────────────┐
                    │  Load Balancer  │
                    │     (Nginx)     │
                    └─────────┬───────┘
                              │
                 ┌─────────────────┐
                 │  Web Server     │
                 │  (Node.js +     │
                 │   Express)      │
                 └─────────┬───────┘
                           │
              ┌─────────────────┐
              │  WebSocket      │
              │  Server         │
              └─────────┬───────┘
                        │
           ┌─────────────────┐
           │  Database       │
           │  (PostgreSQL)   │
           └─────────┬───────┘
                     │
        ┌─────────────────┐
        │  Network        │
        │  Scanner        │
        │  Service        │
        └─────────┬───────┘
                  │
     ┌─────────────────┐
     │  Power Injection │
     │  Units (IP       │
     │  Devices)        │
     └─────────────────┘
```

### Application Layers

#### 1. Presentation Layer (Frontend)
- **Framework**: React.js with TypeScript
- **UI Components**: Material-UI or Tailwind CSS
- **State Management**: Redux Toolkit or Zustand
- **Real-time Updates**: WebSocket client
- **Responsive Design**: Mobile-first approach

#### 2. API Layer (Backend Services)
- **Web Framework**: ASP.NET Core Web API
- **Authentication**: JWT Bearer tokens with ASP.NET Identity
- **Real-time Communication**: SignalR hubs
- **Input Validation**: Data annotations and FluentValidation
- **Error Handling**: Global exception middleware

#### 3. Business Logic Layer
- **Device Service**: Network scanning and device management using System.Net.NetworkInformation
- **Reservation Service**: Booking logic and time management
- **Notification Service**: Alerts and status updates via SignalR
- **Analytics Service**: Usage tracking and reporting with LINQ
- **Background Services**: IHostedService implementations for continuous monitoring

#### 4. Data Layer
- **Primary Database**: PostgreSQL or SQL Server for relational data
- **ORM**: Entity Framework Core with migrations
- **Caching**: IMemoryCache and Redis distributed cache
- **Configuration**: IConfiguration for device settings

#### 5. Infrastructure Layer
- **Network Scanner**: Custom hosted service using Ping class and parallel processing
- **Background Jobs**: Hangfire or IHostedService for scheduled tasks
- **Monitoring**: ASP.NET Core health checks and Serilog logging
- **Deployment**: Docker containers with multi-stage builds

## 🛠️ Technology Stack

### Frontend
- **React.js 18+**: Component-based UI framework
- **TypeScript**: Type-safe JavaScript development
- **Tailwind CSS**: Utility-first CSS framework
- **Socket.io-client**: Real-time communication
- **React Query**: Server state management
- **React Router**: Client-side routing

### Backend
- **.NET 8**: Cross-platform runtime and framework
- **ASP.NET Core**: Web API framework
- **SignalR**: Real-time bidirectional communication
- **Entity Framework Core**: ORM for database operations
- **PostgreSQL/SQL Server**: Relational database
- **Redis**: Caching and session storage
- **Hangfire**: Background job processing

### DevOps & Deployment
- **Docker**: Containerization
- **Docker Compose**: Multi-container orchestration
- **Nginx**: Reverse proxy and load balancing
- **PM2**: Process management for Node.js

### Development Tools
- **Visual Studio 2022**: IDE with excellent .NET support
- **JetBrains Rider**: Cross-platform .NET IDE
- **VS Code**: Lightweight editor with C# extension
- **Vite**: Build tool for frontend development
- **ESLint & Prettier**: Frontend code quality
- **EditorConfig**: Consistent coding styles
- **xUnit**: Testing framework for .NET
- **Jest**: Frontend testing framework

## 🏛️ Design Decisions & Rationale

### Why .NET 8 + ASP.NET Core?
- **Enterprise Ready**: Mature, stable platform with excellent tooling
- **Performance**: Superior performance compared to Node.js for CPU-intensive tasks
- **Type Safety**: Strong typing throughout the application stack
- **Network Operations**: Excellent libraries for ping, network scanning, and device communication
- **SignalR Integration**: Built-in real-time communication framework
- **Dependency Injection**: Native DI container for clean architecture
- **Background Services**: Built-in hosted services for network scanning
- **Cross-Platform**: Runs on Linux, Windows, and containers

### Why PostgreSQL?
- **ACID Compliance**: Ensures data consistency for reservations
- **Complex Queries**: Advanced querying capabilities for analytics
- **JSON Support**: Flexible storage for device metadata
- **Reliability**: Battle-tested in enterprise environments
- **Scalability**: Can handle growing device and user base

### Why React + TypeScript?
- **Component Reusability**: Modular UI components for different device types
- **Type Safety**: Prevents runtime errors in production
- **Real-time Updates**: Excellent integration with WebSocket
- **Developer Experience**: Great tooling and debugging capabilities

### Why SignalR for Real-time Updates?
- **Native Integration**: Built into ASP.NET Core framework
- **Automatic Fallback**: Handles WebSocket, Server-Sent Events, Long Polling automatically
- **Strongly Typed**: Type-safe hub methods and client contracts
- **Scalability**: Built-in support for Redis backplane for multiple servers
- **Authentication**: Seamless integration with ASP.NET Core authentication
- **User Experience**: Live dashboard without manual refresh

## 📋 System Requirements

### Server Requirements
- **CPU**: 2+ cores
- **RAM**: 4GB minimum, 8GB recommended
- **Storage**: 20GB SSD
- **Network**: Gigabit Ethernet
- **OS**: Linux (Ubuntu 20.04+ recommended)

### Network Requirements
- **IP Range Access**: Ability to scan internal network subnets
- **Port Access**: HTTP (80), HTTPS (443), WebSocket (3001)
- **Firewall**: Allow outbound connections for device scanning

### Client Requirements
- **Browser**: Chrome 90+, Firefox 88+, Safari 14+, Edge 90+
- **JavaScript**: Enabled
- **Network**: Access to internal network

## 🚀 Installation & Setup

### Prerequisites
```bash
# Install .NET 8 SDK
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get update
sudo apt-get install -y apt-transport-https
sudo apt-get install -y dotnet-sdk-8.0

# Install PostgreSQL
sudo apt install postgresql postgresql-contrib

# Install Redis
sudo apt install redis-server

# Install Docker (optional)
curl -fsSL https://get.docker.com -o get-docker.sh
sudo sh get-docker.sh
```

### Quick Start with Docker
```bash
# Clone the repository
git clone https://github.com/yourusername/power-unit-manager.git
cd power-unit-manager

# Start all services
docker-compose up -d

# Initialize database
docker-compose exec backend npm run db:migrate
docker-compose exec backend npm run db:seed

# Access the application
open http://localhost:3000
```

### Manual Installation
```bash
# Backend setup
cd backend
dotnet restore
cp appsettings.example.json appsettings.Development.json
# Edit appsettings.Development.json with your configuration
dotnet ef database update
dotnet run --environment Development

# Frontend setup (new terminal)
cd frontend
npm install
cp .env.example .env
# Edit .env with API endpoint
npm run dev

# Access application at http://localhost:5173
# API available at https://localhost:7001
```

## 📡 API Documentation

### Base URL
```
Development: https://localhost:7001/api
Production: https://your-domain.com/api
```

### Device Endpoints

#### GET /api/devices
Get all devices with current status
```csharp
// Response Model
public class DeviceResponse
{
    public string Id { get; set; }
    public string IpAddress { get; set; }
    public string Name { get; set; }
    public DeviceStatus Status { get; set; } // Available, Occupied, Offline, Maintenance
    public string Location { get; set; }
    public DateTime LastSeen { get; set; }
    public ReservationDto? CurrentReservation { get; set; }
}
```

#### GET /api/devices/{ipAddress}
Get specific device details
```csharp
// Response Model
public class DeviceDetailResponse : DeviceResponse
{
    public DeviceSpecifications Specifications { get; set; }
    public TimeSpan Uptime { get; set; }
    public List<ReservationHistoryDto> RecentHistory { get; set; }
}
```

### Reservation Endpoints

#### POST /api/reservations
Create a new reservation
```csharp
// Request Model
public class CreateReservationRequest
{
    [Required]
    public string DeviceId { get; set; }
    
    [Required]
    [StringLength(100)]
    public string UserName { get; set; }
    
    [Range(1, 72)]
    public int DurationHours { get; set; }
    
    [StringLength(500)]
    public string Purpose { get; set; }
    
    [EmailAddress]
    public string? Email { get; set; }
}

// Response Model
public class ReservationResponse
{
    public string Id { get; set; }
    public string DeviceId { get; set; }
    public string UserName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public ReservationStatus Status { get; set; }
    public string Purpose { get; set; }
}
```

#### PUT /api/reservations/{id}/extend
Extend an existing reservation
```csharp
public class ExtendReservationRequest
{
    [Range(1, 24)]
    public int AdditionalHours { get; set; }
}
```

#### DELETE /api/reservations/{id}
Cancel a reservation
```csharp
public class CancelReservationRequest
{
    [StringLength(200)]
    public string? Reason { get; set; }
}
```

#### GET /api/reservations
Get all reservations with filters
```
Query parameters:
- status: active, completed, cancelled
- deviceId: specific device
- userName: specific user
- date: YYYY-MM-DD format
```

### SignalR Hub Events

#### Client → Server Methods
```csharp
// Hub Interface
public interface IDeviceHub
{
    Task JoinDeviceUpdates(string room = "all");
    Task ReserveDevice(CreateReservationRequest request);
    Task ReleaseDevice(string reservationId);
}

// TypeScript Client
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/deviceHub")
    .build();

// Join device updates
await connection.invoke("JoinDeviceUpdates", "all");

// Reserve device
await connection.invoke("ReserveDevice", {
    deviceId: "192.168.1.100",
    userName: "John Doe",
    durationHours: 8,
    purpose: "Testing"
});
```

#### Server → Client Events
```csharp
// Hub methods called by server
public interface IDeviceHubClient
{
    Task DeviceStatusUpdate(DeviceStatusUpdate update);
    Task ReservationCreated(ReservationResponse reservation);
    Task ReservationExpired(ReservationResponse reservation);
    Task DeviceConnectivityChanged(DeviceConnectivityUpdate update);
}
```

## 💻 User Interface Examples

### Dashboard View
```
┌─────────────────────────────────────────────────────────────┐
│ Power Injection Unit Manager                    🔄 Live     │
├─────────────────────────────────────────────────────────────┤
│ Filter: [All ▼] [Available] [Occupied] [Offline]  🔍 Search │
├─────────────────────────────────────────────────────────────┤
│                                                             │
│ ┌─────────┐ ┌─────────┐ ┌─────────┐ ┌─────────┐           │
│ │ 🟢 A1   │ │ 🔴 B2   │ │ 🟡 C3   │ │ ⚪ D4   │           │
│ │192.1.100│ │192.1.101│ │192.1.102│ │192.1.103│           │
│ │Available│ │John Doe │ │Maint.   │ │Offline  │           │
│ │         │ │4h left  │ │         │ │2min ago │           │
│ │[Reserve]│ │[Extend] │ │[Update] │ │[Ping]   │           │
│ └─────────┘ └─────────┘ └─────────┘ └─────────┘           │
│                                                             │
│ ┌─────────┐ ┌─────────┐ ┌─────────┐ ┌─────────┐           │
│ │ 🟢 E5   │ │ 🔴 F6   │ │ 🟢 G7   │ │ 🟢 H8   │           │
│ │192.1.104│ │192.1.105│ │192.1.106│ │192.1.107│           │
│ │Available│ │Sarah M. │ │Available│ │Available│           │
│ │         │ │1d left  │ │         │ │         │           │
│ │[Reserve]│ │[Details]│ │[Reserve]│ │[Reserve]│           │
│ └─────────┘ └─────────┘ └─────────┘ └─────────┘           │
└─────────────────────────────────────────────────────────────┘
```

### Device Reservation Modal
```
┌─────────────────────────────────────┐
│ Reserve Power Unit A1               │
├─────────────────────────────────────┤
│ Device: 192.168.1.100               │
│ Status: 🟢 Available                │
│ Location: Lab Room 1                │
│                                     │
│ Your Name: [John Doe            ] │
│                                     │
│ Duration: [8] hours ▼               │
│ ○ 2 hours   ○ 4 hours              │
│ ○ 8 hours   ● 1 day                │
│ ○ 3 days    ○ Custom: [  ] hours   │
│                                     │
│ Purpose: [Motor performance testing] │
│                                     │
│ Email (optional):                   │
│ [john.doe@company.com           ]   │
│                                     │
│ [Cancel]          [Reserve Device]  │
└─────────────────────────────────────┘
```

### Device Details Panel
```
┌─────────────────────────────────────────┐
│ Power Unit A1 Details                   │
├─────────────────────────────────────────┤
│ IP Address: 192.168.1.100               │
│ Status: 🔴 Occupied by John Doe         │
│ Location: Lab Room 1, Rack A           │
│ Uptime: 3 days, 15:42:18               │
│                                         │
│ Specifications:                         │
│ • Max Voltage: 500V                     │
│ • Max Current: 20A                      │
│ • Model: PIU-500-20-V2                  │
│ • Serial: PIU20240156                   │
│                                         │
│ Current Reservation:                    │
│ • User: John Doe                        │
│ • Started: Today, 09:00                 │
│ • Ends: Today, 17:00 (3h 18m left)     │
│ • Purpose: Motor performance testing    │
│                                         │
│ Recent History:                         │
│ • 2024-08-05: Sarah M. (8 hours)        │
│ • 2024-08-04: Mike L. (4 hours)         │
│ • 2024-08-03: John Doe (6 hours)        │
│                                         │
│ [🔔 Notify when free] [📊 Usage Stats]  │
└─────────────────────────────────────────┘
```

## 🔧 Usage Instructions

### For Lab Technicians

1. **Check Device Availability**
   - Open the dashboard to see all devices at a glance
   - Green = Available, Red = Occupied, Yellow = Maintenance, Gray = Offline

2. **Reserve a Device**
   - Click on an available device
   - Enter your name and select duration
   - Add a brief description of your work
   - Click "Reserve Device"

3. **Extend Your Reservation**
   - Find your active reservation
   - Click "Extend" before it expires
   - Select additional time needed

4. **Release Early**
   - Click on your occupied device
   - Select "Release Early" if finished
   - This makes the device available immediately

### For Lab Managers

1. **Monitor Usage**
   - View real-time dashboard
   - Check usage statistics and patterns
   - Identify underutilized or overbooked devices

2. **Maintenance Mode**
   - Mark devices as under maintenance
   - Add maintenance notes and expected completion
   - Automatically notify users when available

3. **Device Management**
   - Add new devices to the network scan
   - Update device information and specifications
   - Configure automatic alerts for offline devices

## 🚀 Deployment Guide

### Production Deployment with Docker

1. **Server Setup**
```bash
# Create application user
sudo useradd -m -s /bin/bash appuser
sudo usermod -aG docker appuser

# Create application directory
sudo mkdir -p /opt/power-unit-manager
sudo chown appuser:appuser /opt/power-unit-manager
```

2. **Environment Configuration**
```bash
# Copy production environment files
cp .env.production .env
cp docker-compose.prod.yml docker-compose.yml

# Edit environment variables
nano .env
```

3. **SSL Certificate Setup**
```bash
# Using Let's Encrypt
sudo apt install certbot
sudo certbot certonly --standalone -d your-domain.com

# Update nginx configuration
sudo cp nginx/production.conf /etc/nginx/sites-available/power-unit-manager
sudo ln -s /etc/nginx/sites-available/power-unit-manager /etc/nginx/sites-enabled/
```

4. **Deploy Application**
```bash
# Build and start services
docker-compose up -d --build

# Initialize database with Entity Framework
docker-compose exec backend dotnet ef database update
docker-compose exec backend dotnet run --seed-data

# Verify deployment
docker-compose ps
curl -f http://localhost/api/health
```

### Environment Variables

```bash
# Database Connection
ConnectionStrings__DefaultConnection=Server=localhost;Database=PowerUnits;User Id=postgres;Password=password;

# Redis
ConnectionStrings__Redis=localhost:6379

# Network Scanning
NetworkScanning__IpRanges=192.168.1.0/24,10.0.0.0/24
NetworkScanning__ScanIntervalSeconds=30
NetworkScanning__PingTimeoutMs=5000

# Application
ASPNETCORE_ENVIRONMENT=Production
ASPNETCORE_URLS=https://+:443;http://+:80
Kestrel__Certificates__Default__Path=/certs/certificate.pfx
Kestrel__Certificates__Default__Password=cert-password

# JWT Authentication
JwtSettings__SecretKey=your-secret-key-here
JwtSettings__Issuer=PowerUnitManager
JwtSettings__Audience=PowerUnitManager
JwtSettings__ExpiryMinutes=60

# Email Notifications (optional)
EmailSettings__SmtpHost=smtp.company.com
EmailSettings__SmtpPort=587
EmailSettings__Username=notifications@company.com
EmailSettings__Password=smtp-password

# Logging
Serilog__MinimumLevel__Default=Information
Serilog__WriteTo__0__Name=Console
Serilog__WriteTo__1__Name=File
Serilog__WriteTo__1__Args__path=/logs/app-.txt
Serilog__WriteTo__1__Args__rollingInterval=Day
```

## 🔍 Monitoring & Maintenance

### Health Checks
- **Application Health**: `/api/health`
- **Database Connection**: `/api/health/db`
- **Redis Connection**: `/api/health/redis`
- **Network Scanning**: `/api/health/scanner`

### Logging
- **Application Logs**: `/var/log/power-unit-manager/app.log`
- **Access Logs**: `/var/log/power-unit-manager/access.log`
- **Error Logs**: `/var/log/power-unit-manager/error.log`

### Backup Strategy
```bash
# Database backup (daily)
0 2 * * * pg_dump power_units | gzip > /backup/db-$(date +%Y%m%d).sql.gz

# Application backup (weekly)
0 3 * * 0 tar -czf /backup/app-$(date +%Y%m%d).tar.gz /opt/power-unit-manager
```

## 🔮 Future Enhancements

### Phase 1 - Core Features (Current)
- [x] Device discovery and monitoring
- [x] Basic reservation system
- [x] Real-time status updates
- [x] Web interface

### Phase 2 - Enhanced Features
- [ ] User authentication and roles
- [ ] Email notifications
- [ ] Advanced analytics and reporting
- [ ] Mobile application
- [ ] Calendar integration

### Phase 3 - Enterprise Features
- [ ] LDAP/Active Directory integration
- [ ] API rate limiting and security
- [ ] Multi-lab support
- [ ] Advanced scheduling and queuing
- [ ] Integration with lab management systems

### Phase 4 - Advanced Capabilities
- [ ] Machine learning for usage prediction
- [ ] Automated device health diagnostics
- [ ] Voice commands and alerts
- [ ] IoT sensor integration
- [ ] Advanced reporting and BI dashboards

## 🤝 Contributing

This project is currently in the conceptual phase. Once implementation begins:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙋‍♂️ Support

For support and questions:
- Create an issue on GitHub
- Email: your-email@company.com
- Internal Slack: #power-unit-manager

## 📚 Additional Resources

- [Network Scanning Best Practices](docs/network-scanning.md)
- [API Integration Guide](docs/api-integration.md)
- [Deployment Troubleshooting](docs/troubleshooting.md)
- [Security Considerations](docs/security.md)

---

**Built with ❤️ to solve real lab management challenges**

*This system replaces the old paper-based reservation method with a modern, efficient, and reliable digital solution.*
