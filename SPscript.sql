


--/***************Users****************/

--ALTER PROCEDURE SP_InsertUsers 
--    @FirstName NVARCHAR(15),
--    @SecondName NVARCHAR(15),
--    @ThirdName NVARCHAR(15),
--    @LastName NVARCHAR(15),
--    @BirthDate NVARCHAR(20),
--    @Address NVARCHAR(20),
--    @IsActive BIT,
--    @UserName NVARCHAR(20),
--    @Password NVARCHAR(10),
--    @UserRole TINYINT
--AS
--BEGIN
--    SET NOCOUNT ON;--REMOVE (1 row affected)

--    DECLARE @PersonID INT;
--    DECLARE @UserID INT;

--    BEGIN TRY

--        BEGIN TRANSACTION;

--        -- 🔹 1. إدخال في People
--        INSERT INTO People
--        (
--            FirstName,
--            SecondName,
--            ThirdName,
--            LastName,
--            BirthDate,
--            Address,
--            IsActive
--        )
--        VALUES
--        (
--            @FirstName,
--            @SecondName,
--            @ThirdName,
--            @LastName,
--            @BirthDate,
--            @Address,
--            @IsActive
--        );

--        SET @PersonID = SCOPE_IDENTITY();

--        INSERT INTO Users
--        (
--            UserName,
--            Password,
--            UserRole,
--            PersonID
--        )
--        VALUES
--        (
--            @UserName,
--            @Password,
--            @UserRole,
--            @PersonID
--        );

--        SET @UserID = SCOPE_IDENTITY();

--        COMMIT TRANSACTION;

--        SELECT @UserID AS NewUserID;

--    END TRY
--    BEGIN CATCH

--        IF @@TRANCOUNT > 0
--            ROLLBACK TRANSACTION;

--        SELECT 
--            ERROR_MESSAGE() AS ErrorMessage,
--            ERROR_NUMBER() AS ErrorNumber;

--    END CATCH

--END
--GO
--END
--GO

--CREATE PROCEDURE SP_UpdateUsers 

--  @UserID INT,  @FirstName NVARCHAR(15),@SecondName NVARCHAR(15),@ThirdName NVARCHAR(15),@LastName NVARCHAR(15),@BirthDate NVARCHAR(20),@Address NVARCHAR(20)
--  ,@IsActive BIT,@UserName NVARCHAR(20),  @Password NVARCHAR(10), @UserRole TINYINT
--AS
--BEGIN
--Update [vw_UserView] SET 
-- [FirstName] = @FirstName,
-- [SecondName] = @SecondName,
-- [ThirdName] = @ThirdName,
-- [LastName] = @LastName,
-- [BirthDate] = @BirthDate,
-- [Address] = @Address,
-- [IsActive] = @IsActive,
-- [UserName] = @UserName,
-- [Password] = @Password,
-- [UserRole] = @UserRole
-- WHERE 
--[UserID] = @UserID

--END
--GO

--ALTER PROCEDURE SP_DeleteUsers 
--    @UserID INT
--AS
--BEGIN
--    SET NOCOUNT ON;

--    BEGIN TRY
--        BEGIN TRANSACTION;

--        DECLARE @PersonID INT;

--        SELECT @PersonID = PersonID FROM Users WHERE UserID = @UserID;

--        DELETE FROM Users WHERE UserID = @UserID;

--        DELETE FROM People WHERE PersonID = @PersonID;

--        COMMIT TRANSACTION;

--        SELECT 1 AS Result;

--    END TRY
--    BEGIN CATCH
--        IF @@TRANCOUNT > 0 ROLLBACK;

--        SELECT ERROR_MESSAGE() AS ErrorMessage;
--    END CATCH
--END
--GO

--CREATE PROCEDURE SP_SelectAllUserss 

--AS
--BEGIN
--SELECT * FROM [Users]  

--END
--GO

--CREATE PROCEDURE SP_SelectUsersBy 

--  @UserID INT
--AS
--BEGIN
--SELECT * FROM [Users]
--WHERE [UserID] = @UserID

--END
--GO

--CREATE PROCEDURE SP_IsUsersExist 

--  @UserID INT
--AS
--BEGIN
--IF EXISTS (
--SELECT 1 FROM [Users]
--WHERE [UserID] = @UserID
--)
--RETURN 1
--ELSE
--RETURN 0

--END
--GO



--/***************Attendance****************/

--CREATE PROCEDURE SP_InsertAttendance 

--  @StudentID INT,  @AttendanceDate DATE,  @Status TINYINT
--AS
--BEGIN
--INSERT INTO [Attendance]
--(
-- [StudentID],
-- [AttendanceDate],
-- [Status]
--)
--VALUES
--(
--@StudentID,
--@AttendanceDate,
--@Status
--)
--;
--SELECT SCOPE_IDENTITY() AS NewID; 

--END
--GO

--CREATE PROCEDURE SP_UpdateAttendance 

--  @AttendanceID INT,  @StudentID INT,  @AttendanceDate DATE,  @Status TINYINT
--AS
--BEGIN
--Update [Attendance] SET 
-- [StudentID] = @StudentID,
-- [AttendanceDate] = @AttendanceDate,
-- [Status] = @Status
-- WHERE 
--[AttendanceID] = @AttendanceID

--END
--GO

--CREATE PROCEDURE SP_DeleteAttendance 

--  @AttendanceID INT
--AS
--BEGIN
--DELETE FROM [Attendance]  
-- WHERE 
--[AttendanceID] = @AttendanceID
--; 

--END
--GO

--CREATE PROCEDURE SP_SelectAllAttendances 

--AS
--BEGIN
--SELECT * FROM [Attendance]  

--END
--GO

--CREATE PROCEDURE SP_SelectAttendanceBy 

--  @AttendanceID INT
--AS
--BEGIN
--SELECT * FROM [Attendance]
--WHERE [AttendanceID] = @AttendanceID

--END
--GO

--CREATE PROCEDURE SP_IsAttendanceExist 

--  @AttendanceID INT
--AS
--BEGIN
--IF EXISTS (
--SELECT 1 FROM [Attendance]
--WHERE [AttendanceID] = @AttendanceID
--)
--RETURN 1
--ELSE
--RETURN 0

--END
--GO



--/***************Circles****************/

--CREATE PROCEDURE SP_InsertCircles 

--  @CircleName VARCHAR(20),  @TeacherID INT,  @MaxCapacity INT
--AS
--BEGIN
--INSERT INTO [Circles]
--(
-- [CircleName],
-- [TeacherID],
-- [MaxCapacity]
--)
--VALUES
--(
--@CircleName,
--@TeacherID,
--@MaxCapacity
--)
--;
--SELECT SCOPE_IDENTITY() AS NewID; 

--END
--GO

--CREATE PROCEDURE SP_UpdateCircles 

--  @CircleID INT,  @CircleName VARCHAR(20),  @TeacherID INT,  @MaxCapacity INT
--AS
--BEGIN
--Update [Circles] SET 
-- [CircleName] = @CircleName,
-- [TeacherID] = @TeacherID,
-- [MaxCapacity] = @MaxCapacity
-- WHERE 
--[CircleID] = @CircleID

--END
--GO

--CREATE PROCEDURE SP_DeleteCircles 

--  @CircleID INT
--AS
--BEGIN
--DELETE FROM [Circles]  
-- WHERE 
--[CircleID] = @CircleID
--; 

--END
--GO

--CREATE PROCEDURE SP_SelectAllCircless 

--AS
--BEGIN
--SELECT * FROM [Circles]  

--END
--GO

--CREATE PROCEDURE SP_SelectCirclesBy 

--  @CircleID INT
--AS
--BEGIN
--SELECT * FROM [Circles]
--WHERE [CircleID] = @CircleID

--END
--GO

--CREATE PROCEDURE SP_IsCirclesExist 

--  @CircleID INT
--AS
--BEGIN
--IF EXISTS (
--SELECT 1 FROM [Circles]
--WHERE [CircleID] = @CircleID
--)
--RETURN 1
--ELSE
--RETURN 0

--END
--GO



--/***************Evaluations****************/

--CREATE PROCEDURE SP_InsertEvaluations 

--  @StudentID INT,  @FromAyahID SMALLINT,  @ToAyahID INT,  @EvalDate DATETIME
--AS
--BEGIN
--INSERT INTO [Evaluations]
--(
-- [StudentID],
-- [FromAyahID],
-- [ToAyahID],
-- [EvalDate]
--)
--VALUES
--(
--@StudentID,
--@FromAyahID,
--@ToAyahID,
--@EvalDate
--)
--;
--SELECT SCOPE_IDENTITY() AS NewID; 

--END
--GO

--CREATE PROCEDURE SP_UpdateEvaluations 

--  @EvaluationID INT,  @StudentID INT,  @FromAyahID SMALLINT,  @ToAyahID INT,  @EvalDate DATETIME
--AS
--BEGIN
--Update [Evaluations] SET 
-- [StudentID] = @StudentID,
-- [FromAyahID] = @FromAyahID,
-- [ToAyahID] = @ToAyahID,
-- [EvalDate] = @EvalDate
-- WHERE 
--[EvaluationID] = @EvaluationID

--END
--GO

--CREATE PROCEDURE SP_DeleteEvaluations 

--  @EvaluationID INT
--AS
--BEGIN
--DELETE FROM [Evaluations]  
-- WHERE 
--[EvaluationID] = @EvaluationID
--; 

--END
--GO

--CREATE PROCEDURE SP_SelectAllEvaluationss 

--AS
--BEGIN
--SELECT * FROM [Evaluations]  

--END
--GO

--CREATE PROCEDURE SP_SelectEvaluationsBy 

--  @EvaluationID INT
--AS
--BEGIN
--SELECT * FROM [Evaluations]
--WHERE [EvaluationID] = @EvaluationID

--END
--GO

--CREATE PROCEDURE SP_IsEvaluationsExist 

--  @EvaluationID INT
--AS
--BEGIN
--IF EXISTS (
--SELECT 1 FROM [Evaluations]
--WHERE [EvaluationID] = @EvaluationID
--)
--RETURN 1
--ELSE
--RETURN 0

--END
--GO



--/***************StudentProgress****************/

--CREATE PROCEDURE SP_InsertStudentProgress 

--  @StudentID INT,  @FromAyahID SMALLINT,  @ToAyahID INT,  @UpdateDate DATETIME,  @TeacherID INT
--AS
--BEGIN
--INSERT INTO [StudentProgress]
--(
-- [StudentID],
-- [FromAyahID],
-- [ToAyahID],
-- [UpdateDate],
-- [TeacherID]
--)
--VALUES
--(
--@StudentID,
--@FromAyahID,
--@ToAyahID,
--@UpdateDate,
--@TeacherID
--)
--;
--SELECT SCOPE_IDENTITY() AS NewID; 

--END
--GO

--CREATE PROCEDURE SP_UpdateStudentProgress 

--  @StudentProgressID INT,  @StudentID INT,  @FromAyahID SMALLINT,  @ToAyahID INT,  @UpdateDate DATETIME,  @TeacherID INT
--AS
--BEGIN
--Update [StudentProgress] SET 
-- [StudentID] = @StudentID,
-- [FromAyahID] = @FromAyahID,
-- [ToAyahID] = @ToAyahID,
-- [UpdateDate] = @UpdateDate,
-- [TeacherID] = @TeacherID
-- WHERE 
--[StudentProgressID] = @StudentProgressID

--END
--GO

--CREATE PROCEDURE SP_DeleteStudentProgress 

--  @StudentProgressID INT
--AS
--BEGIN
--DELETE FROM [StudentProgress]  
-- WHERE 
--[StudentProgressID] = @StudentProgressID
--; 

--END
--GO

--CREATE PROCEDURE SP_SelectAllStudentProgresss 

--AS
--BEGIN
--SELECT * FROM [StudentProgress]  

--END
--GO

--CREATE PROCEDURE SP_SelectStudentProgressBy 

--  @StudentProgressID INT
--AS
--BEGIN
--SELECT * FROM [StudentProgress]
--WHERE [StudentProgressID] = @StudentProgressID

--END
--GO

--CREATE PROCEDURE SP_IsStudentProgressExist 

--  @StudentProgressID INT
--AS
--BEGIN
--IF EXISTS (
--SELECT 1 FROM [StudentProgress]
--WHERE [StudentProgressID] = @StudentProgressID
--)
--RETURN 1
--ELSE
--RETURN 0

--END
--GO


--/***************Students****************/

--ALTER PROCEDURE SP_InsertStudents 
--    @FirstName NVARCHAR(15),
--    @SecondName NVARCHAR(15),
--    @ThirdName NVARCHAR(15),
--    @LastName NVARCHAR(15),
--    @BirthDate NVARCHAR(20),
--    @Address NVARCHAR(20),
--    @IsActive BIT,
--    @ParentPhone VARCHAR(100),
--    @JoinDate DATETIME,
--    @CircleID INT
--AS
--BEGIN
--    SET NOCOUNT ON;

--    DECLARE @PersonID INT;
--    DECLARE @StudentID INT;

--    BEGIN TRY
--        BEGIN TRANSACTION;

--        -- People
--        INSERT INTO People
--        (
--            FirstName, SecondName, ThirdName, LastName,
--            BirthDate, Address, IsActive
--        )
--        VALUES
--        (
--            @FirstName, @SecondName, @ThirdName, @LastName,
--            @BirthDate, @Address, @IsActive
--        );

--        SET @PersonID = SCOPE_IDENTITY();

--        -- Students
--        INSERT INTO Students
--        (
--            PersonID, ParentPhone, JoinDate, CircleID
--        )
--        VALUES
--        (
--            @PersonID, @ParentPhone, @JoinDate, @CircleID
--        );

--        SET @StudentID = SCOPE_IDENTITY();

--        COMMIT TRANSACTION;

--        SELECT @StudentID AS NewStudentID;

--    END TRY
--    BEGIN CATCH
--        IF @@TRANCOUNT > 0 ROLLBACK;

--        SELECT ERROR_MESSAGE() AS ErrorMessage;
--    END CATCH
--END
--GO



--  ALTER PROCEDURE SP_UpdateStudents 
--    @StudentID INT,
--    @FirstName NVARCHAR(15),
--    @SecondName NVARCHAR(15),
--    @ThirdName NVARCHAR(15),
--    @LastName NVARCHAR(15),
--    @BirthDate NVARCHAR(20),
--    @Address NVARCHAR(20),
--    @IsActive BIT,
--    @ParentPhone VARCHAR(100),
--    @JoinDate DATETIME,
--    @CircleID INT
--AS
--BEGIN
--    SET NOCOUNT ON;

--    BEGIN TRY
--        BEGIN TRANSACTION;

--        DECLARE @PersonID INT;

--        SELECT @PersonID = PersonID FROM Students WHERE StudentID = @StudentID;

--        -- تحديث People
--        UPDATE People SET
--            FirstName = @FirstName,
--            SecondName = @SecondName,
--            ThirdName = @ThirdName,
--            LastName = @LastName,
--            BirthDate = @BirthDate,
--            Address = @Address,
--            IsActive = @IsActive
--        WHERE PersonID = @PersonID;

--        -- تحديث Students
--        UPDATE Students SET
--            ParentPhone = @ParentPhone,
--            JoinDate = @JoinDate,
--            CircleID = @CircleID
--        WHERE StudentID = @StudentID;

--        COMMIT TRANSACTION;

--        SELECT 1 AS Result;

--    END TRY
--    BEGIN CATCH
--        IF @@TRANCOUNT > 0 ROLLBACK;

--        SELECT ERROR_MESSAGE() AS ErrorMessage;
--    END CATCH
--END
--GO

--ALTER PROCEDURE SP_DeleteStudents 
--    @StudentID INT
--AS
--BEGIN
--    SET NOCOUNT ON;

--    BEGIN TRY
--        BEGIN TRANSACTION;

--        DECLARE @PersonID INT;

--        SELECT @PersonID = PersonID FROM Students WHERE StudentID = @StudentID;

--        DELETE FROM Students WHERE StudentID = @StudentID;

--        DELETE FROM People WHERE PersonID = @PersonID;

--        COMMIT TRANSACTION;

--        SELECT 1 AS Result;

--    END TRY
--    BEGIN CATCH
--        IF @@TRANCOUNT > 0 ROLLBACK;

--        SELECT ERROR_MESSAGE() AS ErrorMessage;
--    END CATCH
--END
--GO


--CREATE PROCEDURE SP_SelectAllStudentss 

--AS
--BEGIN
--SELECT * FROM [Students]  

--END
--GO

--CREATE PROCEDURE SP_SelectStudentsBy 

--  @StudentID INT
--AS
--BEGIN
--SELECT * FROM [Students]
--WHERE [StudentID] = @StudentID

--END
--GO

--CREATE PROCEDURE SP_IsStudentsExist 

--  @StudentID INT
--AS
--BEGIN
--IF EXISTS (
--SELECT 1 FROM [Students]
--WHERE [StudentID] = @StudentID
--)
--RETURN 1
--ELSE
--RETURN 0

--END
--GO

--ALTER PROCEDURE SP_FindStudentByID 
--    @StudentID INT,
--    @FirstName NVARCHAR(50) OUTPUT,
--    @SecondName NVARCHAR(50) OUTPUT,
--    @ThirdName NVARCHAR(50) OUTPUT,
--    @LastName NVARCHAR(50) OUTPUT,
--    @BirthDate DATETIME OUTPUT,
--    @ParentPhone VARCHAR(100) OUTPUT,
--    @Address NVARCHAR(100) OUTPUT,
--    @JoinDate DATETIME OUTPUT,
--    @IsActive BIT OUTPUT,
--    @CircleID INT OUTPUT
--AS
--BEGIN
--    SELECT 
--        @FirstName = P.FirstName,
--        @SecondName = P.SecondName,
--        @ThirdName = P.ThirdName,
--        @LastName = P.LastName,
--        @BirthDate = P.BirthDate,
--        @Address = P.Address,
--        @IsActive = P.IsActive,

--        @ParentPhone = S.ParentPhone,
--        @JoinDate = S.JoinDate,
--        @CircleID = S.CircleID

--    FROM Students S
--    INNER JOIN People P ON S.PersonID = P.PersonID
--    WHERE S.StudentID = @StudentID

--    IF @@ROWCOUNT > 0
--        RETURN 1
--    ELSE
--        RETURN 0
--END



--/***************Waitlist****************/

--CREATE PROCEDURE SP_InsertWaitlist 

--  @FullName VARCHAR(150),  @Age INT,  @ParentPhone VARCHAR(100),  @Address VARCHAR(50),  @RegistrationDate DATETIME,  @Notes VARCHAR(200),  @IsAdded BIT
--AS
--BEGIN
--INSERT INTO [Waitlist]
--(
-- [FullName],
-- [Age],
-- [ParentPhone],
-- [Address],
-- [RegistrationDate],
-- [Notes],
-- [IsAdded]
--)
--VALUES
--(
--@FullName,
--@Age,
--@ParentPhone,
--@Address,
--@RegistrationDate,
--@Notes,
--@IsAdded
--)
--;
--SELECT SCOPE_IDENTITY() AS NewID; 

--END
--GO

--CREATE PROCEDURE SP_UpdateWaitlist 

--  @WaitlistID INT,  @FullName VARCHAR(150),  @Age INT,  @ParentPhone VARCHAR(100),  @Address VARCHAR(50),  @RegistrationDate DATETIME,  @Notes VARCHAR(200),  @IsAdded BIT
--AS
--BEGIN
--Update [Waitlist] SET 
-- [FullName] = @FullName,
-- [Age] = @Age,
-- [ParentPhone] = @ParentPhone,
-- [Address] = @Address,
-- [RegistrationDate] = @RegistrationDate,
-- [Notes] = @Notes,
-- [IsAdded] = @IsAdded
-- WHERE 
--[WaitlistID] = @WaitlistID

--END
--GO

--CREATE PROCEDURE SP_DeleteWaitlist 

--  @WaitlistID INT
--AS
--BEGIN
--DELETE FROM [Waitlist]  
-- WHERE 
--[WaitlistID] = @WaitlistID
--; 

--END
--GO

--CREATE PROCEDURE SP_SelectAllWaitlists 

--AS
--BEGIN
--SELECT * FROM [Waitlist]  

--END
--GO

--CREATE PROCEDURE SP_SelectWaitlistBy 

--  @WaitlistID INT
--AS
--BEGIN
--SELECT * FROM [Waitlist]
--WHERE [WaitlistID] = @WaitlistID

--END
--GO

--CREATE PROCEDURE SP_IsWaitlistExist 

--  @WaitlistID INT
--AS
--BEGIN
--IF EXISTS (
--SELECT 1 FROM [Waitlist]
--WHERE [WaitlistID] = @WaitlistID
--)
--RETURN 1
--ELSE
--RETURN 0

--END
--GO

--CREATE PROCEDURE SP_IsAttendanceExistsToday
--@CircleID INT 
--AS
--BEGIN
--    IF EXISTS (
--        SELECT 1 FROM Attendance a
--		JOIN Students s ON s.StudentID = a.StudentID
--        WHERE AttendanceDate = CAST(GETDATE() AS DATE) AND CircleID = @CircleID
--    )
--        RETURN 1;
--    ELSE
--        RETURN 0;
--END




--CREATE PROCEDURE SP_GetStudentsAttendanceForToday
--@CircleID INT
--AS
----BEGIN
--	SELECT DISTINCT a.AttendanceID,
--	(
--		SELECT MAX(a.CreatedAt) FROM Students WHERE StudentID = s.StudentID
--	)
--	, s.StudentID,FullName,ats.StatusID,ats.StatusName, a.AttendanceDate  FROM Attendance a
--	JOIN Students s ON  s.StudentID = a.StudentID
--	JOIN AttendanceStatus ats ON ats.StatusID = a.Status
--	WHERE AttendanceDate = CAST('2026-04-03' AS date) AND CircleID = 1
--	ORDER BY a.CreatedAt,a.AttendanceID,a.AttendanceDate DESC,s.FullName,ats.StatusID 
--END

--CREATE PROCEDURE SP_GetAttendanceStudentHistoryInMonth
--@StudentID INT,
--@Year SMALLINT,
--@Month TINYINT
--AS
--BEGIN
--	SELECT s.StudentID,FullName,ats.StatusName,a.AttendanceDate FROM Attendance a
--	JOIN Students s ON  s.StudentID = a.StudentID
--	JOIN AttendanceStatus ats ON ats.StatusID = a.Status
--	WHERE s.StudentID = @StudentID AND MONTH(AttendanceDate) = @Month  AND YEAR(AttendanceDate) = @Year
--	ORDER BY a.AttendanceDate DESC,s.FullName,ats.StatusID 
--END

--ALTER PROCEDURE SP_GetAbsentCount
--@StudentID INT,
--@FromDate Date,
--@ToDate Date,
--@CountAbsent INT OUTPUT
--AS
--BEGIN
--	SELECT @CountAbsent = COUNT(*) FROM Attendance
--	WHERE StudentID =@StudentID AND AttendanceDate BETWEEN @FromDate AND @ToDate AND Status = 3

--END



--ALTER PROCEDURE SP_Login
--    @UserName NVARCHAR(50),
--    @Password NVARCHAR(50),

--    @UserID INT OUTPUT,
--    @UserRole INT OUTPUT,

--    @FirstName NVARCHAR(50) OUTPUT,
--    @SecondName NVARCHAR(50) OUTPUT,
--    @ThirdName NVARCHAR(50) OUTPUT,
--    @LastName NVARCHAR(50) OUTPUT,
--    @Address NVARCHAR(100) OUTPUT,
--    @IsActive BIT OUTPUT
--AS
--BEGIN
--    SELECT
--        @UserID = U.UserID,
--        @UserRole = U.UserRole,

--        @FirstName = P.FirstName,
--        @SecondName = P.SecondName,
--        @ThirdName = P.ThirdName,
--        @LastName = P.LastName,
--        @Address = P.Address,
--        @IsActive = P.IsActive

--    FROM Users U
--    INNER JOIN People P ON U.PersonID = P.PersonID
--    WHERE U.UserName = @UserName 
--      AND U.Password = @Password

--    IF @@ROWCOUNT > 0
--        RETURN 1
--    ELSE
--        RETURN 0
--END
		
--ALTER TRIGGER tg_InsteadOfInsertUser ON vw_UserView
--INSTEAD OF INSERT 
--AS
--BEGIN
--BEGIN TRANSACTION 
--	BEGIN TRY 
--	   DECLARE @PersonID INT;
--	   INSERT INTO People (FirstName,SecondName,ThirdName,LastName,BirthDate,Address,IsActive)
--	   SELECT FirstName,SecondName ,ThirdName ,LastName ,BirthDate ,Address ,IsActive FROM inserted
--	   SELECT @PersonID = SCOPE_IDENTITY()
   
--	   INSERT INTO Users(UserName,Password,PersonID,UserRole)
--	   SELECT UserName,Password,@PersonID,UserRole FROM inserted
--	   COMMIT	
--	END TRY
--	BEGIN CATCH
--	ROLLBACK TRANSACTION

--	END CATCH
--END

--CREATE TRIGGER tg_InsteadOfUpdateUser ON vw_UserView
--INSTEAD OF UPDATE 
--AS
--BEGIN
--BEGIN TRANSACTION 
--	BEGIN TRY 
--	   DECLARE @PersonID INT;
--UPDATE P
--SET 
--    P.FirstName = I.FirstName,
--    P.SecondName = I.SecondName,
--    P.ThirdName = I.ThirdName,
--    P.LastName = I.LastName,
--    P.BirthDate = I.BirthDate,
--    P.Address = I.Address,
--    P.IsActive = I.IsActive
--FROM People P
--INNER JOIN inserted I ON P.PersonID = I.PersonID;
   
--	   UPDATE U
--	   SET U.UserName= I.UserName,
--	   U.Password = I.Password,
--	   U.UserRole = I.UserRole
--	   FROM Users U 
--	   INNER JOIN inserted I ON U.PersonID = I.PersonID
--	   COMMIT	
--	END TRY
--	BEGIN CATCH
--	ROLLBACK TRANSACTION

--	END CATCH
--END

--CREATE TRIGGER tg_InsteadOfInsertStudent ON vw_StudentView
--INSTEAD OF INSERT 
--AS
--BEGIN
--BEGIN TRANSACTION 
--	BEGIN TRY 
--	   DECLARE @PersonID INT;
--	   INSERT INTO People (FirstName,SecondName,ThirdName,LastName,BirthDate,Address,IsActive)
--	   SELECT FirstName,SecondName ,ThirdName ,LastName ,BirthDate ,Address ,IsActive FROM inserted
--	   SELECT @PersonID = SCOPE_IDENTITY()
   
--	   INSERT INTO Students(PersonID,ParentPhone,JoinDate,CircleID)
--	   SELECT @PersonID,ParentPhone,JoinDate,CircleID FROM inserted
--	   COMMIT	
--	END TRY
--	BEGIN CATCH
--	ROLLBACK TRANSACTION

--	END CATCH
--END


--CREATE TRIGGER tg_InsteadOfUpdateStudent ON vw_StudentView
--INSTEAD OF UPDATE 
--AS
--BEGIN
--BEGIN TRANSACTION 
--	BEGIN TRY 
--	   DECLARE @PersonID INT;
--UPDATE P
--SET 
--    P.FirstName = I.FirstName,
--    P.SecondName = I.SecondName,
--    P.ThirdName = I.ThirdName,
--    P.LastName = I.LastName,
--    P.BirthDate = I.BirthDate,
--    P.Address = I.Address,
--    P.IsActive = I.IsActive
--FROM People P
--INNER JOIN inserted I ON P.PersonID = I.PersonID;
   
--	   UPDATE s
--	   SET s.ParentPhone= I.ParentPhone,
--	   s.JoinDate = I.JoinDate,
--	   s.CircleID = I.CircleID
--	   FROM Students s
--	   INNER JOIN inserted I ON s.PersonID = I.PersonID
--	   COMMIT	
--	END TRY
--	BEGIN CATCH
--	ROLLBACK TRANSACTION

--	END CATCH
--END

--ALTER PROCEDURE SP_GetMonthlyNewCirclesCount
--    @Month TINYINT, 
--    @Year SMALLINT,
--	@Result SMALLINT OUTPUT
--AS
--BEGIN


    
--    DECLARE @CurrentMonthStart DATE = DATEFROMPARTS(@Year, @Month, 1);
--    DECLARE @NextMonthStart DATE = DATEADD(MONTH,+1,@CurrentMonthStart);

--    SELECT  COUNT(*) 
--	AS TotalMonths

--    FROM Circles 
--    WHERE CreatedAt >= @CurrentMonthStart
--      AND CreatedAt <= @NextMonthStart

--END

--CREATE PROCEDURE SP_GetNewCirclesStatsLastMonth
--AS
--BEGIN
--    DECLARE @CurrentMonth TINYINT = MONTH(GETDATE());
--    DECLARE @CurrentYear SMALLINT = YEAR(GETDATE());
--    DECLARE @FinalResult INT;

--    EXEC SP_GetMonthlyNewCirclesCount @CurrentMonth, @CurrentYear, @Result = @FinalResult OUTPUT;

--    SELECT @FinalResult AS GrowthStats;
--END


--ALTER PROCEDURE SP_GetMonthlyNewStudentsCount
--    @Month TINYINT, 
--    @Year SMALLINT,
--	@Result SMALLINT OUTPUT 
--AS
--BEGIN
--    DECLARE @CurrentMonthStart DATE = DATEFROMPARTS(@Year, @Month, 1);
--    DECLARE @NextMonthStart DATE = DATEADD(MONTH,+1,@CurrentMonthStart);    
--    DECLARE @CountThisMonth INT;

--    SELECT  COUNT(*) 
--	AS TotalMonths
--    FROM Students 
--    WHERE JoinDate >= @CurrentMonthStart
--    AND JoinDate <= @NextMonthStart

--END

--CREATE PROCEDURE SP_GetNewStudentsStatsLastMonth
--AS
--BEGIN
--    DECLARE @CurrentMonth TINYINT = MONTH(GETDATE());
--    DECLARE @CurrentYear SMALLINT = YEAR(GETDATE());
--    DECLARE @FinalResult INT; 

--    EXEC SP_GetMonthlyNewStudentsCount @CurrentMonth, @CurrentYear, @Result = @FinalResult OUTPUT;

--    SELECT @FinalResult AS GrowthStats;
--END