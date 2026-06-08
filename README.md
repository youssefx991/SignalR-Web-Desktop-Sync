# SignalRChat: Real-Time Synchronous Communication Suite

A real-time chat and collaboration platform demonstrating the integration of ASP.NET Core SignalR across web clients and native desktop applications. This project features database persistence, user authentication, and multi-client messaging synchronization.

**Developer:** Youssef Wagih  
**Tech Stack:** C#, .NET 10, ASP.NET Core MVC, SignalR, Entity Framework Core, SQL Server, ASP.NET Core Identity, WinForms (C#)

---

## Key Features

### 1. Real-Time Hub Architecture
* **Bi-directional Communication**: Utilizes WebSockets (with fallback to Server-Sent Events or Long Polling) via ASP.NET Core SignalR for sub-second, low-latency message delivery.
* **Connection State Lifecycle Tracking**: Real-time events triggered on user connection (`OnConnectedAsync`) and disconnection (`OnDisconnectedAsync`) to notify other active users immediately.

### 2. Multi-Client Integration
* **Responsive Web Client**: A web-based interface built with ASP.NET Core MVC, Razor Views, Bootstrap, and the official JavaScript SignalR client library.
* **Native Desktop Client**: A Windows Forms (WinForms) application powered by the `.NET SignalR Client` library, showcasing how native desktop apps can subscribe to and push events to the web server in real-time.
* **Administrative Broadcasts**: The desktop app can broadcast global announcements to all web clients seamlessly.

### 3. Dynamic Room & Group Management
* **SignalR Groups API**: Dynamic creation, deletion, and subscription of chat rooms mapping directly to SignalR groups (`Groups.AddToGroupAsync` / `Clients.Group`).
* **Dynamic Client Updates**: Whenever a room is created or deleted by any client, all online clients (web and desktop) receive instant events to update their room selection lists without refreshing.

### 4. Direct (Private) Messaging
* **Targeted Delivery**: Sends private, secure, one-to-one messages using SignalR's user targeting mechanism (`Clients.User(receiverId)`).
* **Identity Mapping**: Leverages ASP.NET Core Identity to safely resolve and route messages to target users by mapping claims to SignalR connection identifiers.

### 5. Persistent EF Core Data Layer
* **Entity Framework Core**: Interacts with MS SQL Server for robust data mapping.
* **Database Logs & History**: 
  * Rooms (`Rooms` table)
  * Chat messages with sender, receiver, timestamp, and room mapping (`ChatMessages` table)
  * User-to-room relationships (`UserRooms` table for membership tracking)

---

## Architecture & Flow

```
                      ┌──────────────────────┐
                      │    SignalR Hub       │
                      │   (ChatHub.cs)       │
                      └──────────┬───────────┘
                                 │
         ┌───────────────────────┼───────────────────────┐
         ▼                       ▼                       ▼
┌─────────────────┐     ┌─────────────────┐     ┌─────────────────┐
│   Web Client    │     │ WinForms Client │     │     SQL Server  │
│  (Razor Views,  │     │ (SignalR.Client)│     │  (via EF Core)  │
│  JS Client)     │     └─────────────────┘     └─────────────────┘
└─────────────────┘
```

1. **Client Actions**: A user (Web or Desktop) triggers an event (e.g., sending a message or creating a room).
2. **Hub Processing**: The SignalR hub processes the request, validates the user context, and invokes the Entity Framework database context to store the record.
3. **Broadcasting**: The Hub broadcasts updates back to either the caller, the target user (for private messages), the group (for room messages), or all connected clients globally.

---

## Tech Stack & Libraries

* **Backend / Server**: 
  * C# 13, .NET 10.0
  * ASP.NET Core Web API & MVC
  * ASP.NET Core SignalR (Server Library)
  * ASP.NET Core Identity (Authentication & User Management)
* **ORM & Database**:
  * Entity Framework Core (EF Core 10)
  * MS SQL Server (LocalDB / Express)
* **Frontend Web**:
  * HTML5, CSS3 (Bootstrap 5)
  * JavaScript, jQuery
  * `@microsoft/signalr` (JavaScript client via npm/libman)
* **Desktop Client**:
  * Windows Forms (.NET 10.0-windows)
  * `Microsoft.AspNetCore.SignalR.Client` (NuGet Package)

---

## Getting Started

### Prerequisites
* **.NET 10 SDK** (or later) installed.
* **SQL Server Express** or **LocalDB** active.
* Visual Studio 2022 (or VS Code).

### Installation & Setup

1. **Clone the Repository**:
   ```bash
   git clone <repository_url>
   cd SignalRChat
   ```

2. **Configure Connection Strings**:
   Open `SignalRChat.Web/appsettings.json` and verify your SQL Server connection details:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Data Source=.\\SQLExpress;Initial Catalog=SignalRChatDb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"
   }
   ```

3. **Apply Database Migrations**:
   Run the following command in your terminal inside the `SignalRChat.Web` directory to set up the Identity and Chat schemas:
   ```bash
   cd SignalRChat.Web
   dotnet ef database update
   ```

4. **Run the Web Application**:
   Start the MVC server:
   ```bash
   dotnet run
   ```
   By default, the server runs on: `https://localhost:7100`

5. **Run the Desktop Client**:
   In a separate terminal, start the WinForms application:
   ```bash
   cd ../SignalRChat.Desktop
   dotnet run
   ```

---

## Verification & Testing

* **Room Synchronization**: Run both applications simultaneously. Create a room in the web UI; you will see it populate instantly in the desktop app's dropdown.
* **Cross-client Announcement**: Type a message in the "Send Desktop Message" input on either UI, and watch it register in real-time across both screens.
* **Identity Authentication**: Sign up two different user accounts in the MVC Web UI, login on separate browser sessions, and send direct private messages to test targeted SignalR delivery.
