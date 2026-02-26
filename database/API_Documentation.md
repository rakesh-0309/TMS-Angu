# TMS API Documentation

## Task Management APIs

### 1. List of Tasks API (GET)

Retrieves task records from the database. You can get all tasks or filter by specific criteria.

**Endpoint:** `/api/tasks`

**Description:** Fetches all tasks or searches for specific tasks based on filters.

**Payload:**
```json
{
  "task_Id": null,
  "task_Title": null
}
```

**Parameters:**
- `task_Id` (int, optional): If provided, returns the specific task with this ID. If null, returns all tasks.
- `task_Title` (string, optional): If provided, searches for tasks with matching title. If null, returns all tasks.

**Response:** Array of task objects with all details.

---

### 2. Create Task API (POST)

Creates a new task record in the database.

**Endpoint:** `/api/tasks/create`

**Description:** Adds a new task to the database with the provided details.

**Payload:**
```json
{
  "task_Title": "string",
  "task_Discription": "string",
  "DueDate": "date",
  "Status": "string",
  "Remark": "string",
  "CreatedBy": "string",
  "LastUpdatedBy": "string"
}
```

**Parameters:**
- `task_Title` (string): Title of the task
- `task_Discription` (string): Detailed description of the task
- `DueDate` (date): Due date for the task completion
- `Status` (string): Current status of the task (e.g., "Pending", "In Progress", "Completed")
- `Remark` (string): Additional remarks or notes
- `CreatedBy` (string): User who created the task
- `LastUpdatedBy` (string): User who last updated the task

**Response:** Returns the created task ID and confirmation.

---

### 3. Update Task API (PUT)

Updates an existing task record with new information.

**Endpoint:** `/api/tasks/{id}`

**Description:** Updates the fields of an existing task in the database. Only the fields provided will be updated.

**Payload:**
```json
{
  "task_Title": "string",
  "task_Discription": "string",
  "DueDate": "date",
  "Status": "string",
  "Remark": "string",
  "CreatedBy": "string",
  "LastUpdatedBy": "string"
}
```

**Parameters:**
- `task_Title` (string): Title of the task (optional, only if updating)
- `task_Discription` (string): Detailed description (optional, only if updating)
- `DueDate` (date): Due date (optional, only if updating)
- `Status` (string): Current status (optional, only if updating)
- `Remark` (string): Additional remarks (optional, only if updating)
- `CreatedBy` (string): Creator of the task (optional, only if updating)
- `LastUpdatedBy` (string): User updating the task (required)

**Response:** Returns the updated task details.

---

### 4. Delete Task API (DELETE)

Deletes a specific task record from the database.

**Endpoint:** `/api/tasks/{id}`

**Description:** Removes a task record from the database based on the provided task ID.

**Payload:**
```json
{
  "Task_Id": 2
}
```

**Parameters:**
- `Task_Id` (int, required): The ID of the task to be deleted

**Response:** Returns success status (1 for success, 0 for failure).

---

## Status Codes

- `200 OK`: Request successful
- `201 Created`: Resource created successfully
- `400 Bad Request`: Invalid request payload
- `404 Not Found`: Resource not found
- `500 Internal Server Error`: Server error

---

## Notes

- All date fields should be in ISO 8601 format (YYYY-MM-DD)
- Task IDs are auto-generated and returned upon creation
- The system automatically tracks creation and update timestamps
