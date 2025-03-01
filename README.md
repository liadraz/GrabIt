# GrabIt
A C# desktop application that reserves a device for a determined time.

## ***Requirements***
### **1. Device Management**
- The system will track multiple injection devices each with a unique ID.
- Only the root user can add or remove devices.

### **2. Reservation System**
- Users can reserve an available device for a specified duration.
- A reserved device is marked as busy and remains unavailable until:
  - The reservation period expires.
  - The current user manually releases it.

### **3. Real-Time Status Display**
- The main page will show the status of all devices (Available/Busy).
- If a device is busy, its expected release time will be displayed.
- Status updates will be reflected in real-time for all users.

## ***Architecture***
### **Client-Server Model - Centralized Server**
The client-server architecture was chosen as many users can interact with one system simultaneously- 
1. The client (C# desktop app) connects to a central REST API that manages the devices, reservations, and users.
2. A MySQL Server database stores device and reservation information.
3. The server handles real-time updates using SignalR.

```
+------------------------+
|  Web API (REST API)    | <--->   Client (Desktop App - WPF)
+------------------------+                 |
            |                              |
            v                              v
+------------------------+         +----------------------+
| Domain Layer           | <--->   |   Database Layer     |
|                        |         |                      |
+------------------------+         +----------------------+
```

## **Tech Stack**
- Frontend: WPF with the use of a modern UI with MVVM
- Backend: .NET 7+ and ASP.NET Web API
- Database: MySQL
- Real-time Communication: SignalR
- Authentication: JWT (TODO if needed)
- Deployment: Self-hosted or cloud (TODO CHOOSE LATER Azure, AWS)
- XUnit for Unit Testing


## **App Layers**
The app is divided into different projects, each serving a specific role within the overall architecture:

### 1. Domain Layer (Core BLL)
- **Description**: Defines business models, interfaces, and domain logic.
- **Project Type**: Class Library (.NET)
- **Project Name**: `GrabIt.Domain`

### 2. Application Layer (Use Cases & Service Logic)
- **Description**: Implements business rules, orchestrates logic, and interacts with the Domain Layer.
- **Project Type**: Class Library (.NET)
- **Project Name**: `GrabIt.Application`

### 3. Infrastructure Layer (Database and External Services)
- **Description**: Handles data persistence (MySQL via EF Core) and external dependencies.
- **Project Type**: Class Library (.NET)
- **Project Name**: `GrabIt.Infrastructure`

### 4. Presentation Layer (Backend API - Exposes Endpoints)
- **Description**: Exposes endpoints that the client communicates with.
- **Project Type**: ASP.NET Core Web API
- **Project Name**: `GrabIt.API`

### 5. Client App Layer (UI Desktop)
- **Description**: The actual application users interact with.
- **Project Type**: WPF (.NET)
- **Project Name**: `GrabIt.Client`

### 6. Unit Tests
- **Description**: Validation of the projects' functionality and components.
- **Project Type**: xUnit (.NET)
- **Project Name**: `GrabIt.Tests`


## **Workflow**
1. A user logs in to the desktop app.
2. The app fetches the device list from the server.
3. When a user reserves a device, the backend updates the database and broadcasts the change via SignalR.
4. Other users see instant status updates.
5. When the reservation time ends, the device automatically becomes available.


