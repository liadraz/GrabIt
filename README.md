# GrabInjection
Reserve a device for a period of time.

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
