CREATE PROCEDURE [dbo].[InsertEmployee]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@BirthDate datetime2,
	@Email nvarchar(100),
	@ResponsableID int
AS
BEGIN
	INSERT INTO [Employee](FirstName, LastName, BirthDate, Email, ResponsableID) VALUES (@FirstName, @LastName, @BirthDate, @Email, @ResponsableID)
END
