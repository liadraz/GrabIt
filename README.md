# 🚀 GrabIt

## 📖 Overview

A web-based reservation app for power injection units.

**Problem Statement:** At Elspec's testing lab, power injection units are reserved using physical paper notes, leading to confusion when papers fall off, unclear ownership duration, and inefficient resource utilization.

**Solution:** A centralized web application that automatically discovers network devices, tracks their status, and allows users to reserve equipment digitally with time-based automatic release.

## ✨ Features

### 🔌 Device Management

* **Real-Time Monitoring**: Tracks status (Online, Offline, Occupied, Maintenance)
* **Health Indicators**: Detects reboots, connectivity issues
* **Visual Status**: Color-coded grid view

### 🖖 Reservation System

* **One-Click Reservations**: Set durations in hours/days
* **Auto-Release**: Devices are freed automatically after expiration
* **Extend or Cancel**: Modify active reservations anytime
* **Queue View**: See upcoming device availability

### 🖥 User Interface

* **Dashboard**: At-a-glance view of all units
* **Details Panel**: Specifications, uptime, history per device
* **Search & Filter**: Quickly locate units by IP, status, or name

### 📱 Monitoring & Alerts

* **Live Updates**: Powered by SignalR and WebSockets
* **Notifications**: Alerts for expiring reservations and offline units

## 🏗️ Architecture Design

### System Architecture

```
          [Browser]
            ↓
        [Web Server .NET]
            ↓
        [PostgreSQL DB]
            ↓
      [Network Scanner]
            ↓
   [Power Injection Units]
```

## 🛠️ Technology Stack

### Frontend

* **React.js + TypeScript**
* **Tailwind CSS**
* **Socket.io Client**
* **React Query + React Router**

### Backend

* **.NET 8 Web API (ASP.NET Core)**
* **SignalR** for real-time communication
* **Entity Framework Core + PostgreSQL**
* **Hangfire** for background jobs

### DevOps

* **Docker & Docker Compose**
* **Nginx** (reverse proxy only, no load balancing needed)
* **Serilog** for structured logging

## ⚙️ Getting Started

### 📦 Prerequisites

```bash
# .NET 8
sudo apt install dotnet-sdk-8.0

# PostgreSQL
sudo apt install postgresql

# Docker (optional for containerized setup)
curl -fsSL https://get.docker.com -o get-docker.sh
sudo sh get-docker.sh
```

---

### 🔄 Run with Docker

```bash
# Clone the repo
git clone https://github.com/yourusername/grabit.git
cd grabit

# Start services
docker-compose up -d

# Init DB
docker-compose exec backend dotnet ef database update
```

---

### 💻 Manual Setup

**Backend**

```bash
cd backend
dotnet restore
cp appsettings.example.json appsettings.Development.json
# Edit the config file
dotnet ef database update
dotnet run
```

**Frontend**

```bash
cd frontend
npm install
cp .env.example .env
# Edit the API URL
npm run dev
```

## 📱 API Documentation

### 🔍 Devices

| Endpoint            | Method | Description                     |
| ------------------- | ------ | ------------------------------- |
| `/api/devices`      | GET    | List all devices                |
| `/api/devices/{ip}` | GET    | Get details for specific device |

### 🗓 Reservations

| Endpoint                        | Method | Description                    |
| ------------------------------- | ------ | ------------------------------ |
| `/api/reservations`             | POST   | Create a reservation           |
| `/api/reservations/{id}/extend` | PUT    | Extend active reservation      |
| `/api/reservations/{id}`        | DELETE | Cancel a reservation           |
| `/api/reservations`             | GET    | List reservations (filterable) |

---

## 🔔 SignalR Events

### Client → Server

* `JoinDeviceUpdates(room)`
* `ReserveDevice(request)`
* `ReleaseDevice(reservationId)`

### Server → Client

* `DeviceStatusUpdate(update)`
* `ReservationCreated(data)`
* `ReservationExpired(data)`
* `DeviceConnectivityChanged(data)`

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

### Environment Variables

```bash
# Database Connection
ConnectionStrings__DefaultConnection=Server=localhost;Database=PowerUnits;User Id=postgres;Password=password;

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

## 🪢 Health & Monitoring

| Check         | Endpoint              |
| ------------- | --------------------- |
| App Status    | `/api/health`         |
| DB Connection | `/api/health/db`      |
| Scanner       | `/api/health/scanner` |

**Built with ❤️ to solve real lab management challenges**
