# GrabInjection

Injection devices reservation system for a set period time.

## Requirements
Device Management:

The application is a **device reservation system** that allows users to check the availability of injection devices, reserve them for a set period, and ensure no conflicts in usage.  

### **Application Requirements:**  
1. **Device Management:**  
   - The system will manage multiple injection devices, each identified by a unique name and IP address.  
   - A root user will have the ability to add and remove devices from the system.  

2. **Reservation System:**  
   - Users can reserve a device for a specific duration.  
   - Once a device is in use, it will be marked as **busy** and unavailable to others until:  
     - The reserved time ends.  
     - The current user manually releases it.  

3. **Real-Time Status Display:**  
   - The main page will display all devices along with their real-time status (**available/busy**).  
   - If a device is busy, the system will show the **start time** and **expected release time**.  
   - All users will have access to view device statuses at any time.  

Let me know if you want any refinements! 🚀
