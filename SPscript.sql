


--/***************Users****************/

--CREATE PROCEDURE SP_InsertUsers 

--  @UserName VARCHAR(20),  @Password VARCHAR(10),  @FullName VARCHAR(100),  @UserRole TINYINT
--AS
--BEGIN
--INSERT INTO [Users]
--(
-- [UserName],
-- [Password],
-- [FullName],
-- [UserRole]
--)
--VALUES
--(
--@UserName,
--@Password,
--@FullName,
--@UserRole
--)
--;
--SELECT SCOPE_IDENTITY() AS NewID; 

--END
--GO

--CREATE PROCEDURE SP_UpdateUsers 

--  @UserID INT,  @UserName VARCHAR(20),  @Password VARCHAR(10),  @FullName VARCHAR(100),  @UserRole TINYINT
--AS
--BEGIN
--Update [Users] SET 
-- [UserName] = @UserName,
-- [Password] = @Password,
-- [FullName] = @FullName,
-- [UserRole] = @UserRole
-- WHERE 
--[UserID] = @UserID

--END
--GO

--CREATE PROCEDURE SP_DeleteUsers 

--  @UserID INT
--AS
--BEGIN
--DELETE FROM [Users]  
-- WHERE 
--[UserID] = @UserID
--; 

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

--CREATE PROCEDURE SP_InsertStudents 

--  @FullName VARCHAR(150),  @Age INT,  @ParentPhone VARCHAR(100),  @Address VARCHAR(50),  @JoinDate DATETIME,  @IsActive BIT,  @CircleID INT
--AS
--BEGIN
--INSERT INTO [Students]
--(
-- [FullName],
-- [Age],
-- [ParentPhone],
-- [Address],
-- [JoinDate],
-- [IsActive],
-- [CircleID]
--)
--VALUES
--(
--@FullName,
--@Age,
--@ParentPhone,
--@Address,
--@JoinDate,
--@IsActive,
--@CircleID
--)
--;
--SELECT SCOPE_IDENTITY() AS NewID; 

--END
--GO

--CREATE PROCEDURE SP_UpdateStudents 

--  @StudentID INT,  @FullName VARCHAR(150),  @Age INT,  @ParentPhone VARCHAR(100),  @Address VARCHAR(50),  @JoinDate DATETIME,  @IsActive BIT,  @CircleID INT
--AS
--BEGIN
--Update [Students] SET 
-- [FullName] = @FullName,
-- [Age] = @Age,
-- [ParentPhone] = @ParentPhone,
-- [Address] = @Address,
-- [JoinDate] = @JoinDate,
-- [IsActive] = @IsActive,
-- [CircleID] = @CircleID
-- WHERE 
--[StudentID] = @StudentID

--END
--GO

--CREATE PROCEDURE SP_DeleteStudents 

--  @StudentID INT
--AS
--BEGIN
--DELETE FROM [Students]  
-- WHERE 
--[StudentID] = @StudentID
--; 

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

--CREATE PROCEDURE SP_FindStudentByID 
--@StudentID INT,
--@FullName NVARCHAR(150) OUTPUT,
--@Age INT OUTPUT,
--@ParentPhone VARCHAR(100) OUTPUT,
--@Address VARCHAR(50) OUTPUT,
--@JoinDate DATETIME OUTPUT,
--@IsActive BIT OUTPUT,
--@CircleID INT OUTPUT
--AS
--BEGIN
--	IF EXISTS (SELECT 1 FROM Students WHERE StudentID = @StudentID)
--	BEGIN
--		SELECT @FullName = FullName, @Age = Age,@ParentPhone = ParentPhone,
--		@Address = Address, @JoinDate = JoinDate,@IsActive =IsActive, @CircleID = CircleID 
--		FROM Students
--		RETURN 1
--	END
--	ELSE
--		RETURN 0

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

