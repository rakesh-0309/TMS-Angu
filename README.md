#  TMS-Angu – Task Management System

A full-stack Task Management System built using **Angular (Frontend)** and **ASP.NET Core Web API (Backend)** with **SQL Server** database.

This project demonstrates clean architecture, RESTful API development, and frontend-backend integration following industry best practices.

---

## ?? Tech Stack

### ?? Frontend
- **Framework**: Angular 18+
- **Language**: TypeScript
- **Styling**: HTML5 & CSS3
- **HTTP Client**: Angular HttpClient
- **Routing**: Angular Router

### ?? Backend
- **Framework**: ASP.NET Core 8 Web API
- **Language**: C#
- **Database Access**: Dapper / Entity Framework Core
- **Architecture**: Clean Architecture with SOLID Principles

### ?? Database
- **DBMS**: SQL Server
- **Data Access**: Stored Procedures
- **Tables**: TaskList with 10 columns
- **Procedures**: 4 (Create, Read, Update, Delete)

---

## ?? Project Structure

```
TMS-Angu/
?
??? backend/
?   ??? Controllers/
?   ?   ??? TaskController.cs          # HTTP request handlers
?   ??? Models/
?   ?   ??? Task.cs                    # Data models
?   ??? Services/
?   ?   ??? TaskService.cs             # Business logic
?   ??? appsettings.json               # Configuration
?   ??? Program.cs                     # Application startup
?   ??? TMS.csproj                     # Project file
?
??? frontend/
?   ??? src/
?   ?   ??? app/
?   ?   ?   ??? task/
?   ?   ?   ?   ??? task.ts            # Component logic
?   ?   ?   ?   ??? task.html          # Component template
?   ?   ?   ?   ??? task.css           # Component styles
?   ?   ?   ?   ??? task.service.ts    # API service
?   ?   ?   ??? app.ts                 # Root component
?   ?   ?   ??? app.html               # Root template
?   ?   ?   ??? app.routes.ts          # Route configuration
?   ?   ??? main.ts                    # Entry point
?   ?   ??? styles.css                 # Global styles
?   ?   ??? index.html                 # HTML template
?   ??? angular.json                   # Angular config
?   ??? package.json                   # Dependencies
?   ??? tsconfig.json                  # TypeScript config
?
??? database/
?   ??? API_Documentation.md           # Detailed API docs
?   ??? table_schema.sql               # DB schema & procedures
?
??? README.md                          # Project documentation
??? .gitignore                         # Git ignore rules
```

---

## ? Features

- ? **Create Task** - Add new tasks with detailed information
- ? **Read/List Tasks** - Retrieve all or search for specific tasks
- ? **Update Task** - Modify existing task details
- ? **Delete Task** - Remove tasks from the system
- ? **Filter & Search** - Find tasks by ID or Title
- ? **RESTful API** - Professional API design
- ? **Clean Architecture** - Layered, maintainable code structure
- ? **Stored Procedures** - Database operations via SQL procedures
- ? **Error Handling** - Comprehensive exception handling
- ? **Responsive UI** - User-friendly interface

---

## ?? Prerequisites

Before you begin, ensure you have installed:

### Backend Requirements
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server 2019+](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or SQL Server Express
- SQL Server Management Studio (SSMS)

### Frontend Requirements
- [Node.js 18+](https://nodejs.org/)
- [npm 9+](https://www.npmjs.com/)
- Code Editor (VS Code, Visual Studio)

### Development Tools
- Git
- Postman (for API testing - optional)

---

## ?? Installation & Setup

### Step 1: Clone the Repository

```bash
git clone https://github.com/rakesh-0309/TMS-Angu.git
cd TMS-Angu
```

### Step 2: Database Setup

1. **Open SQL Server Management Studio (SSMS)**

2. **Create database (optional)**:
   ```sql
   CREATE DATABASE TMS_DB;
   GO
   ```

3. **Run the schema script**:
   - Open `database/table_schema.sql` in SSMS
   - Execute the entire script
   - This creates:
     - `TaskList` table
     - `createTaskList` stored procedure
     - `getTaskList` stored procedure
     - `updateTaskList` stored procedure
     - `delTaskList` stored procedure

### Step 3: Backend Setup

```bash
cd backend

# Restore NuGet packages
dotnet restore

# Update appsettings.json with your connection string
# Example: "Server=localhost;Database=TMS_DB;Trusted_Connection=true;"

# Run the backend
dotnet run
```

**Backend will run on:**
- HTTPS: `https://localhost:5001`
- HTTP: `http://localhost:5000`

### Step 4: Frontend Setup

```bash
cd frontend

# Install npm dependencies
npm install

# Update API base URL in src/app/task/task.service.ts (if needed)
# Default: https://localhost:5001/api/tasks

# Start development server
npm start
# or
ng serve
```

**Frontend will run on:** `http://localhost:4200`

---

## ?? API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/tasks` | Get all tasks or search |
| POST | `/api/tasks/create` | Create new task |
| PUT | `/api/tasks/{id}` | Update existing task |
| DELETE | `/api/tasks/{id}` | Delete task |

### Example Requests

**Get All Tasks:**
```bash
curl -X GET https://localhost:5001/api/tasks
```

**Create Task:**
```bash
curl -X POST https://localhost:5001/api/tasks/create \
  -H "Content-Type: application/json" \
  -d '{
    "task_Title": "Complete Assignment",
    "task_Discription": "Finish the TMS project",
    "dueDate": "2024-03-25",
    "status": "Pending",
    "remark": "Final submission",
    "createdBy": "Student",
    "lastUpdatedBy": "Student"
  }'
```

**Update Task:**
```bash
curl -X PUT https://localhost:5001/api/tasks/1 \
  -H "Content-Type: application/json" \
  -d '{
    "status": "Completed",
    "lastUpdatedBy": "Student"
  }'
```

**Delete Task:**
```bash
curl -X DELETE https://localhost:5001/api/tasks/1
```

For detailed API documentation, see [API_Documentation.md](database/API_Documentation.md)

---

## ??? Database Schema

### TaskList Table

| Column | Type | Constraints | Description |
|--------|------|-------------|-------------|
| Task_Id | INT | PRIMARY KEY, IDENTITY | Auto-incremented task ID |
| Task_Title | NVARCHAR(250) | NULL | Task title |
| Task_Discription | NVARCHAR(MAX) | NULL | Detailed description |
| DueDate | DATETIME | NULL | Due date |
| Status | NVARCHAR(50) | NULL | Task status |
| Remark | NVARCHAR(500) | NULL | Additional remarks |
| CreatedOn | DATETIME | DEFAULT GETDATE() | Creation timestamp |
| LastUpdatedDate | DATETIME | NULL | Last update timestamp |
| CreatedBy | NVARCHAR(100) | NULL | Creator name |
| LastUpdatedBy | NVARCHAR(100) | NULL | Last updater name |

### Stored Procedures

1. **createTaskList** - Creates new task record
2. **getTaskList** - Retrieves tasks with filtering
3. **updateTaskList** - Updates existing task
4. **delTaskList** - Deletes task by ID

See [table_schema.sql](database/table_schema.sql) for implementation details.

---

## ??? Architecture Overview

```
???????????????????????????????????
?   Angular Frontend              ?
?  (Components & Services)        ?
???????????????????????????????????
             ? HTTP/REST
???????????????????????????????????
?   ASP.NET Core API              ?
?  (Controllers & Services)       ?
???????????????????????????????????
             ? SQL
???????????????????????????????????
?   SQL Server Database           ?
?  (Tables & Stored Procedures)   ?
???????????????????????????????????
```

### Layered Architecture

- **Presentation Layer** ? Angular components and UI
- **API Layer** ? Controllers handling HTTP requests
- **Business Logic Layer** ? Services with core logic
- **Data Access Layer** ? Database operations via Dapper
- **Database Layer** ? SQL Server with stored procedures

---

## ? Best Practices Implemented

### Backend
- ?? RESTful API design
- ?? Dependency Injection
- ?? Exception handling
- ?? Stored procedures for data operations
- ?? Connection pooling
- ?? Async operations (where applicable)
- ?? Proper HTTP status codes

### Frontend
- ?? Component-based architecture
- ?? Service layer for API calls
- ?? TypeScript for type safety
- ?? Reactive forms
- ?? Error handling
- ?? Environment configuration

### Database
- ?? Transaction management
- ?? Parameterized queries (SQL injection prevention)
- ?? Primary keys and constraints
- ?? Default values
- ?? Error handling in procedures

---

## ?? Troubleshooting

**Connection String Error**
- Verify SQL Server is running
- Check connection string in `appsettings.json`
- Example: `"Server=.\\SQLEXPRESS;Database=TMS_DB;Trusted_Connection=true;"`

**Port Already in Use**
- Change port in `launchSettings.json`
- Or kill the process using the port

**CORS Errors**
- Add CORS configuration to `Program.cs`
- Allow frontend URL (http://localhost:4200)

**npm Install Issues**
- Clear npm cache: `npm cache clean --force`
- Delete `node_modules` and `package-lock.json`
- Run `npm install` again

---

## ?? Documentation

- **API Documentation**: [API_Documentation.md](database/API_Documentation.md)
- **Database Schema**: [table_schema.sql](database/table_schema.sql)

---

## ?? Project Statistics

- **Lines of Code**: ~2000+
- **API Endpoints**: 4
- **Database Tables**: 1
- **Stored Procedures**: 4
- **Components**: 5+
- **Services**: 2+

---

## ?? Academic Assignment

This is an academic assignment project demonstrating:
- Full-stack application development
- Clean code architecture
- Database design and optimization
- RESTful API development
- Frontend-backend integration
- Professional development practices

---

## ?? Project Details

- **Project Name**: TMS-Angu (Task Management System - Angular)
- **Submission Type**: Academic Assignment
- **Repository**: [GitHub - TMS-Angu](https://github.com/rakesh-0309/TMS-Angu)

---

## ?? License

This project is submitted as an academic assignment.

---

**Ready to submit your assignment? Make sure to:**
- ? Test all CRUD operations
- ? Verify database connectivity
- ? Check API endpoints work correctly
- ? Test frontend functionality
- ? Review code quality and documentation

**Good luck with your submission! ??**
