# GrabInjection
A C# desktop application that reserves a device for some time.

## ***Application Requirements***

1. **Device Management**
	- The system will manage multiple injection devices, each identified by a unique name and IP address.
	- A root user will have the ability to add and remove devices from the system.

2. **Reservation System**
	- Users can reserve a device for a specific duration.
	- Once a device is in use, it will be marked as busy and unavailable to others until:
		- The reserved time ends.
		- The current user manually releases it.

3. **Real-Time Status Display**
	- The main page will display all devices along with their real-time status (Available / Busy).
	- If a device is busy, the system will show the start time and expected release time.
	- All users will have access to view device statuses at any time.


## ***Architecture and Technology Choices***

### **Client-Server Model - Centralized Server**
	- The client (C# desktop app) connects to a central REST API that will manage the devices, reservations, and users.
	- A SQL Server or PostgreSQL database stores device and reservation information.
	- The server handles real-time updates using SignalR (WebSockets).

### Motivation for choosing this architecture model - 
	Pros:
	- Users can see real-time status updates.
	- Can be accessed from multiple computers.
	- Scalable and more future-proof.
	- multiple users can interact with the system simultaneously.
	Cons:
	- Requires a network connection.
	- More complex setup with a backend.

### **Tech Stack**
	- Frontend: WPF (for a modern UI with MVVM)
	- Backend: .NET 7+ Web API
	- Database: PostgreSQL or SQL Server ( TODO Will choose one of them )
	- Real-time Communication: SignalR
	- Authentication: JWT (TODO if needed)
	- Deployment: Self-hosted or cloud (Azure, AWS)

### **Workflow**
1. A user logs in to the desktop app.
2. The app fetches the device list from the server.
3. When a user reserves a device, the backend updates the database and broadcasts the change via SignalR.
4. Other users see instant status updates.
5. When the reservation time ends, the device automatically becomes available.

