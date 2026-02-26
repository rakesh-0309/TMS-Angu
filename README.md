# TMS-Angu: Task Management System

A full-stack web application for efficient task management built with modern technologies and clean architecture principles.

## ?? Table of Contents

- [Overview](#overview)
- [Tech Stack](#tech-stack)
- [Project Structure](#project-structure)
- [Features](#features)
- [Prerequisites](#prerequisites)
- [Installation & Setup](#installation--setup)
- [API Documentation](#api-documentation)
- [Database Schema](#database-schema)
- [Usage Examples](#usage-examples)
- [Project Architecture](#project-architecture)
- [Best Practices](#best-practices)

---

## ?? Overview

**TMS-Angu** (Task Management System - Angular) is a full-stack application designed to help users create, manage, and track tasks efficiently. The application follows clean architecture principles and implements industry-standard practices for API development, database management, and frontend development.

This project demonstrates:
- RESTful API design with .NET 8
- SQL Server stored procedures for data operations
- Modern frontend frameworks (Angular/React)
- Clean Code Architecture
- Professional development practices

---

## ?? Tech Stack

### Backend
- **Framework**: .NET 8 Web API
- **Language**: C#
- **Database**: SQL Server
- **ORM/Data Access**: 
  - Dapper (lightweight, high-performance)
  - Entity Framework Core (alternative)
- **Architecture**: Clean Architecture with SOLID principles

### Frontend
- **Frameworks**: Angular 18+ / React 18+
- **Language**: TypeScript
- **Package Manager**: npm
- **Styling**: CSS3
- **Build Tool**: Angular CLI / Webpack

### Database
- **DBMS**: SQL Server
- **Stored Procedures**: 4 (Create, Read, Update, Delete)
- **Tables**: TaskList with comprehensive columns

---

## ?? Project Structure

```
TMS-Angu/
??? backend/
?   ??? Controllers/
?   ?   ??? TaskController.cs
?   ??? Models/
?   ?   ??? Task.cs
?   ??? Services/
?   ?   ??? TaskService.cs
?   ??? appsettings.json
?   ??? Program.cs
?   ??? TMS.csproj
?
??? frontend/
?   ??? src/
?   ?   ??? app/
?   ?   ?   ??? task/
?   ?   ?   ?   ??? task.ts
?   ?   ?   ?   ??? task.html
?   ?   ?   ?   ??? task.css
?   ?   ?   ?   ??? task.service.ts
?   ?   ?   ??? app.ts
?   ?   ?   ??? app.html
?   ?   ?   ??? app.routes.ts
?   ?   ??? main.ts
?   ?   ??? styles.css
?   ?   ??? index.html
?   ??? angular.json
?   ??? package.json
?   ??? tsconfig.json
?
??? database/
?   ??? API_Documentation.md
?   ??? table_schema.sql
?
??? README.md
??? .gitignore
```

---

## ? Features

### Core Functionality
- ? **Create Tasks**: Add new tasks with detailed information
- ? **Read/List Tasks**: Retrieve all tasks or search by specific criteria
- ? **Update Tasks**: Modify existing task details
- ? **Delete Tasks**: Remove tasks from the system
- ? **Filter & Search**: Find tasks by ID or Title

### Technical Features
- ?? Stored Procedure Implementation
- ??? Transaction Management
- ?? Error Handling & Logging
- ?? Clean Code Architecture
- ?? Responsive UI
- ?? RESTful API Design

---

## ?? Prerequisites

Before you begin, ensure you have the following installed:

### Backend
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server 2019+](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or SQL Server Express

### Frontend
- [Node.js 18+](https://nodejs.org/)
- [npm 9+](https://www.npmjs.com/)
- [Angular CLI](https://angular.io/cli) (optional but recommended)

### Tools
- SQL Server Management Studio (SSMS) - for database setup
- Visual Studio 2022 or Visual Studio Code
- Git

---

## ?? Installation & Setup

### Step 1: Clone the Repository

```bash
git clone https://github.com/rakesh-0309/TMS-Angu.git
cd TMS-Angu
```

### Step 2: Database Setup

1. **Open SQL Server Management Studio (SSMS)**

2. **Create a new database** (optional):
   ```sql
   CREATE DATABASE TMS_DB;
   GO
   ```

3. **Run the schema script**:
   - Open `database/table_schema.sql`
   - Execute the script in SSMS
   - This will create:
     - `TaskList` table
     - `createTaskList` stored procedure
     - `getTaskList` stored procedure
     - `updateTaskList` stored procedure
     - `delTaskList` stored procedure

### Step 3: Backend Configuration

1. **Navigate to backend directory**:
   ```bash
   cd backend
   ```

2. **Update connection string** in `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=TMS_DB;Trusted_Connection=true;"
     }
   }
   ```

   Replace `YOUR_SERVER_NAME` with your SQL Server instance name (e.g., `localhost` or `.\\SQLEXPRESS`)

3. **Restore NuGet packages**:
   ```bash
   dotnet restore
   ```

4. **Run the backend**:
   ```bash
   dotnet run
   ```

   The API will be available at `https://localhost:5001` or `http://localhost:5000`

### Step 4: Frontend Setup

1. **Navigate to frontend directory**:
   ```bash
   cd frontend
   ```

2. **Install dependencies**:
   ```bash
   npm install
   ```

3. **Update API base URL** (if needed) in `src/app/task/task.service.ts`:
   ```typescript
   private apiUrl = 'https://localhost:5001/api/tasks';
   ```

4. **Start the development server**:
   ```bash
   npm start
   ```
   or
   ```bash
   ng serve
   ```

5. **Access the application**:
   - Open your browser and navigate to `http://localhost:4200`

---

## ?? API Documentation

### Base URL
- **Development**: `https://localhost:5001/api`
- **Production**: (Configure as per deployment)

### Endpoints

#### 1. Get All Tasks / Search Tasks
```http
GET /api/tasks
```

**Request Body**:
```json
{
  "task_Id": null,
  "task_Title": null
}
```

**Response** (200 OK):
```json
[
  {
    "task_Id": 1,
    "task_Title": "Design Database Schema",
    "task_Discription": "Create database tables and relationships",
    "dueDate": "2024-03-15T00:00:00",
    "status": "Completed",
    "remark": "Completed ahead of schedule",
    "createdOn": "2024-01-20T10:30:00",
    "lastUpdatedDate": "2024-03-10T15:45:00",
    "createdBy": "Admin",
    "lastUpdatedBy": "Admin"
  }
]
```

#### 2. Create New Task
```http
POST /api/tasks/create
```

**Request Body**:
```json
{
  "task_Title": "Implement API Endpoints",
  "task_Discription": "Create REST endpoints for CRUD operations",
  "dueDate": "2024-03-20",
  "status": "In Progress",
  "remark": "High Priority",
  "createdBy": "John Doe",
  "lastUpdatedBy": "John Doe"
}
```

**Response** (201 Created):
```json
{
  "task_Id": 2,
  "message": "Task created successfully"
}
```

#### 3. Update Task
```http
PUT /api/tasks/{id}
```

**Request Body**:
```json
{
  "task_Title": "Implement API Endpoints - Updated",
  "status": "Completed",
  "lastUpdatedBy": "Jane Smith"
}
```

**Response** (200 OK):
```json
{
  "task_Id": 2,
  "task_Title": "Implement API Endpoints - Updated",
  "status": "Completed",
  "lastUpdatedDate": "2024-03-18T14:30:00"
}
```

#### 4. Delete Task
```http
DELETE /api/tasks/{id}
```

**Request Body**:
```json
{
  "task_Id": 2
}
```

**Response** (200 OK):
```json
{
  "result": 1,
  "message": "Task deleted successfully"
}
```

For detailed API documentation, see [API_Documentation.md](database/API_Documentation.md)

---

## ??? Database Schema

### TaskList Table

| Column | Type | Constraints | Description |
|--------|------|-------------|-------------|
| Task_Id | INT | PRIMARY KEY, IDENTITY | Unique task identifier |
| Task_Title | NVARCHAR(250) | NULL | Task title |
| Task_Discription | NVARCHAR(MAX) | NULL | Detailed task description |
| DueDate | DATETIME | NULL | Task due date |
| Status | NVARCHAR(50) | NULL | Current task status |
| Remark | NVARCHAR(500) | NULL | Additional remarks |
| CreatedOn | DATETIME | DEFAULT GETDATE() | Creation timestamp |
| LastUpdatedDate | DATETIME | NULL | Last update timestamp |
| CreatedBy | NVARCHAR(100) | NULL | Creator name |
| LastUpdatedBy | NVARCHAR(100) | NULL | Last updater name |

### Stored Procedures

1. **createTaskList**: Inserts a new task record
2. **getTaskList**: Retrieves tasks with filtering options
3. **updateTaskList**: Updates existing task records (partial updates supported)
4. **delTaskList**: Deletes a task by ID

For SQL implementation, see [table_schema.sql](database/table_schema.sql)

---

## ?? Usage Examples

### Using Postman or cURL

**Create a Task**:
```bash
curl -X POST https://localhost:5001/api/tasks/create \
  -H "Content-Type: application/json" \
  -d '{
    "task_Title": "Complete Assignment",
    "task_Discription": "Finish the TMS project",
    "dueDate": "2024-03-25",
    "status": "Pending",
    "remark": "Final submission required",
    "createdBy": "Student",
    "lastUpdatedBy": "Student"
  }'
```

**Get All Tasks**:
```bash
curl -X GET https://localhost:5001/api/tasks
```

**Get Specific Task**:
```bash
curl -X GET "https://localhost:5001/api/tasks?task_Id=1"
```

**Update Task**:
```bash
curl -X PUT https://localhost:5001/api/tasks/1 \
  -H "Content-Type: application/json" \
  -d '{
    "status": "Completed",
    "lastUpdatedBy": "Student"
  }'
```

**Delete Task**:
```bash
curl -X DELETE https://localhost:5001/api/tasks/1 \
  -H "Content-Type: application/json" \
  -d '{"task_Id": 1}'
```

---

## ??? Project Architecture

### Clean Architecture Layers

```
???????????????????????????????????
?   Presentation Layer            ?
?  (Angular/React Components)     ?
???????????????????????????????????
             ?
???????????????????????????????????
?   Application Layer             ?
?   (API Controllers & Services)  ?
???????????????????????????????????
             ?
???????????????????????????????????
?   Domain Layer                  ?
?   (Models & Business Logic)     ?
???????????????????????????????????
             ?
???????????????????????????????????
?   Data Access Layer             ?
?   (Dapper, Repositories)        ?
???????????????????????????????????
             ?
???????????????????????????????????
?   Database Layer                ?
?   (SQL Server, Stored Procs)    ?
???????????????????????????????????
```

### Design Patterns Implemented

- **Repository Pattern**: Data access abstraction
- **Dependency Injection**: Loose coupling
- **Service Layer**: Business logic separation
- **DTO Pattern**: Data transfer objects
- **SOLID Principles**: S, O, L, I, D compliance

---

## ? Best Practices

### Backend
- ?? RESTful API conventions
- ?? Proper HTTP status codes
- ?? Error handling and validation
- ?? Stored procedures for data operations
- ?? Connection pooling
- ?? Async/await operations
- ?? Dependency injection

### Frontend
- ?? Component-based architecture
- ?? Service-oriented pattern
- ?? Type safety with TypeScript
- ?? Reactive forms
- ?? Error handling
- ?? Environment configuration

### Database
- ?? Transaction management
- ?? Parameterized queries (prevents SQL injection)
- ?? Proper indexing on primary keys
- ?? Default values and constraints
- ?? Error handling in stored procedures
- ?? COALESCE for partial updates

---

## ?? Troubleshooting

### Common Issues

**Issue**: Connection string error
- **Solution**: Verify SQL Server is running and connection string is correct in `appsettings.json`

**Issue**: "Port 5001 already in use"
- **Solution**: Change port in `launchSettings.json` or kill process using the port

**Issue**: CORS errors in frontend
- **Solution**: Configure CORS in backend `Program.cs`:
  ```csharp
  builder.Services.AddCors(options =>
  {
      options.AddPolicy("AllowFrontend", policy =>
      {
          policy.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader();
      });
  });
  ```

**Issue**: npm install fails
- **Solution**: Clear npm cache and try again:
  ```bash
  npm cache clean --force
  npm install
  ```

---

## ?? License

This project is submitted as an academic assignment. All rights reserved.

---

## ????? Author

Submitted as an Academic Assignment

## ?? Project Submission Details

- **Project Name**: TMS-Angu (Task Management System)
- **Repository**: [GitHub - TMS-Angu](https://github.com/rakesh-0309/TMS-Angu)
- **Submission Date**: [Current Date]

---

## ?? Support

For issues or questions:
1. Check the troubleshooting section
2. Review the API documentation
3. Examine the database schema
4. Check console/terminal for error messages

---

**Happy Task Managing! ??**
