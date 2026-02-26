-- ============================================================================
-- TMS (Task Management System) Database Schema and Stored Procedures
-- ============================================================================

-- Table: dbo.TaskList
IF OBJECT_ID('dbo.TaskList', 'U') IS NOT NULL
    DROP TABLE dbo.TaskList;
GO

CREATE TABLE dbo.TaskList
(
    Task_Id INT IDENTITY(1,1) PRIMARY KEY,
    Task_Title NVARCHAR(250) NULL,
    Task_Discription NVARCHAR(MAX) NULL,
    DueDate DATETIME NULL,
    Status NVARCHAR(50) NULL,
    Remark NVARCHAR(500) NULL,
    CreatedOn DATETIME NOT NULL DEFAULT(GETDATE()),
    LastUpdatedDate DATETIME NULL,
    CreatedBy NVARCHAR(100) NULL,
    LastUpdatedBy NVARCHAR(100) NULL
);
GO

-- ============================================================================
-- Stored Procedures
-- ============================================================================

-- Stored procedure: createTaskList
IF OBJECT_ID('dbo.createTaskList', 'P') IS NOT NULL
    DROP PROCEDURE dbo.createTaskList;
GO

CREATE PROCEDURE dbo.createTaskList
    @Task_Title NVARCHAR(250) = NULL,
    @Task_Discription NVARCHAR(MAX) = NULL,
    @DueDate DATETIME = NULL,
    @status NVARCHAR(50) = NULL,
    @remark NVARCHAR(500) = NULL,
    @CreatedBy NVARCHAR(100) = NULL,
    @LastUpdatedBy NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        INSERT INTO dbo.TaskList
            (Task_Title, Task_Discription, DueDate, Status, Remark, CreatedBy, LastUpdatedBy, CreatedOn)
        VALUES
            (@Task_Title, @Task_Discription, @DueDate, @status, @remark, @CreatedBy, @LastUpdatedBy, GETDATE());

        SELECT CAST(SCOPE_IDENTITY() AS INT) AS Task_Id;
    END TRY
    BEGIN CATCH
        DECLARE @ErrMsg NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrMsg, 16, 1);
    END CATCH
END;
GO

-- Stored procedure: getTaskList
IF OBJECT_ID('dbo.getTaskList', 'P') IS NOT NULL
    DROP PROCEDURE dbo.getTaskList;
GO

CREATE PROCEDURE dbo.getTaskList
    @Task_Id INT = NULL,
    @Task_Title NVARCHAR(250) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        Task_Id,
        Task_Title,
        Task_Discription,
        DueDate,
        Status,
        Remark,
        CreatedOn,
        LastUpdatedDate,
        CreatedBy,
        LastUpdatedBy
    FROM dbo.TaskList
    WHERE
        (@Task_Id IS NULL OR Task_Id = @Task_Id)
        AND (@Task_Title IS NULL OR Task_Title LIKE '%' + @Task_Title + '%')
    ORDER BY Task_Id DESC;
END;
GO

-- Stored procedure: updateTaskList
IF OBJECT_ID('dbo.updateTaskList', 'P') IS NOT NULL
    DROP PROCEDURE dbo.updateTaskList;
GO

CREATE PROCEDURE dbo.updateTaskList
    @Task_Id INT,
    @Task_Title NVARCHAR(250) = NULL,
    @Task_Discription NVARCHAR(MAX) = NULL,
    @DueDate DATETIME = NULL,
    @Status NVARCHAR(50) = NULL,
    @remark NVARCHAR(500) = NULL,
    @CreatedBy NVARCHAR(100) = NULL,
    @LastUpdatedBy NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRAN;

        IF EXISTS (SELECT 1 FROM dbo.TaskList WHERE Task_Id = @Task_Id)
        BEGIN
            UPDATE dbo.TaskList
            SET
                Task_Title = COALESCE(@Task_Title, Task_Title),
                Task_Discription = COALESCE(@Task_Discription, Task_Discription),
                DueDate = COALESCE(@DueDate, DueDate),
                Status = COALESCE(@Status, Status),
                Remark = COALESCE(@remark, Remark),
                CreatedBy = COALESCE(@CreatedBy, CreatedBy),
                LastUpdatedBy = COALESCE(@LastUpdatedBy, LastUpdatedBy),
                LastUpdatedDate = GETDATE()
            WHERE Task_Id = @Task_Id;

            COMMIT TRAN;

            -- return the updated row(s) as the controller expects a query result
            SELECT
                Task_Id,
                Task_Title,
                Task_Discription,
                DueDate,
                Status,
                Remark,
                CreatedOn,
                LastUpdatedDate,
                CreatedBy,
                LastUpdatedBy
            FROM dbo.TaskList
            WHERE Task_Id = @Task_Id;
        END
        ELSE
        BEGIN
            ROLLBACK TRAN;
            -- return empty result set
            SELECT CAST(NULL AS INT) AS Task_Id WHERE 1 = 0;
        END
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0
            ROLLBACK TRAN;
        DECLARE @ErrMsg NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrMsg, 16, 1);
    END CATCH
END;
GO

-- Stored procedure: delTaskList
IF OBJECT_ID('dbo.delTaskList', 'P') IS NOT NULL
    DROP PROCEDURE dbo.delTaskList;
GO

CREATE PROCEDURE dbo.delTaskList
    @Task_Id INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        DELETE FROM dbo.TaskList WHERE Task_Id = @Task_Id;

        IF @@ROWCOUNT > 0
            SELECT 1 AS Result;
        ELSE
            SELECT 0 AS Result;
    END TRY
    BEGIN CATCH
        DECLARE @ErrMsg NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrMsg, 16, 1);
    END CATCH
END;
GO

-- ============================================================================
-- Setup Complete
-- ============================================================================
-- The TMS database schema has been created with the following:
-- - TaskList Table with 10 columns
-- - 4 Stored Procedures: createTaskList, getTaskList, updateTaskList, delTaskList
-- ============================================================================
