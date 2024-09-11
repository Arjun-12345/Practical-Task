Create Database Entity;
Use Entity;
--Table Creating
Create Table Department(
Id int identity(1,1) primary key,
DepartmentName varchar(100) not null,
IsActive int
)
Go

Create Table Employee(
Id int identity(1,1) primary key,
FirstName varchar(100) not null,
MiddleName varchar(100) not null,
LastName varchar(100) not null,
Dob varchar(100) not null,
Salary varchar(100) not null,
DepartmentId int References Department(Id),
IsActive int
)
Go

--Stored Procedures GetAllemployees or By ID,Create, Update, Delete
CREATE PROCEDURE [dbo].[CreateNewEmployee]
@FirstName varchar(100),
@MiddleName varchar(100),
@LastName varchar(100),
@Dob varchar(100),
@Salary int,
@DepartmentId int,
@IsActive int
AS
BEGIN
	Insert into Employee(FirstName,MiddleName,LastName,Dob,Salary,DepartmentId,IsActive)
	Values(@FirstName,@MiddleName,@LastName,@Dob,@Salary,@DepartmentId,@IsActive)
END
GO

CREATE PROCEDURE [dbo].[GetAllEmployeeData]
	@Id int =0
AS
BEGIN
	If (@Id=0)
		Select * from Employee
		--inner join Department on Department.Id = Employee.Id
	Else
		Select * from Employee
		inner join Department on Department.Id = Employee.Id
		where Employee.Id = @Id
END
GO

CREATE PROCEDURE [dbo].[UpdateEmployee]
@Id int,
@FirstName varchar(100),
@MiddleName varchar(100),
@LastName varchar(100),
@Dob varchar(100),
@Salary int,
@DepartmentId int,
@IsActive int
AS
BEGIN
	Update Employee
	Set FirstName = @FirstName,
	MiddleName = @MiddleName,
	LastName = @LastName,
	Dob = @Dob,
	Salary = @Salary,
	DepartmentId = @DepartmentId,
	IsActive = @IsActive
	where Id = @Id
END
GO


CREATE PROCEDURE [dbo].[DeleteEmployee]
	@Id int 
AS
BEGIN
	If Exists(Select 1 from Employee where Id = @Id)
				Delete from Employee where Id = @Id;
END
GO
