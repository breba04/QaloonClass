


--/***************Users****************/

--CREATE PROCEDURE SP_InsertUsers 
--  @FirstName NVARCHAR(15),@SecondName NVARCHAR(15),@ThirdName NVARCHAR(15),@LastName NVARCHAR(15),@BirthDate NVARCHAR(20),@Address NVARCHAR(20)
--  ,@IsActive BIT,@UserName NVARCHAR(20),  @Password NVARCHAR(10), @UserRole TINYINT
--AS
--BEGIN
--INSERT INTO vw_UserView
--(
-- [FirstName],
-- [SecondName],
-- [ThirdName],
-- [LastName],
-- [BirthDate],
-- [Address],
-- [IsActive],
-- [UserName],
-- [Password],
-- [UserRole]
--)
--VALUES
--(
--@FirstName,@SecondName ,@ThirdName,@LastName,@BirthDate ,@Address
--  ,@IsActive ,@UserName ,  @Password , @UserRole 
--)
--;
--SELECT SCOPE_IDENTITY() AS NewID; 

--END
--GO

ALTER PROCEDURE SP_UpdateUsers 

  @UserID INT,  @FirstName NVARCHAR(15),@SecondName NVARCHAR(15),@ThirdName NVARCHAR(15),@LastName NVARCHAR(15),@BirthDate NVARCHAR(20),@Address NVARCHAR(20)
  ,@IsActive BIT,@UserName NVARCHAR(20),  @Password NVARCHAR(10), @UserRole TINYINT
AS
BEGIN
Update [vw_UserView] SET 
 [FirstName] = @FirstName,
 [SecondName] = @SecondName,
 [ThirdName] = @ThirdName,
 [LastName] = @LastName,
 [BirthDate] = @BirthDate,
 [Address] = @Address,
 [IsActive] = @IsActive,
 [UserName] = @UserName,
 [Password] = @Password,
 [UserRole] = @UserRole
 WHERE 
[UserID] = @UserID

END
GO

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



--CREATE PROCEDURE SP_Login
--@UserID INT OUTPUT,
--@UserName varchar(20),
--@Password varchar(10),
--@FullName varchar(10) OUTPUT,
--@UserRole tinyint OUTPUT
--AS
--BEGIN
	
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
