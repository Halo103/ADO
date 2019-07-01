CREATE PROCEDURE [dbo].[AddStudent]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@BirthDate datetime2,
	@YearResult int,
	@SectionId int,
	@Active bit
AS
	BEGIN
		INSERT INTO Student(FirstName, LastName, BirthDate, YearResult, SectionId, Active) VALUES (@FirstName, @LastName, @BirthDate, @YearResult, @SectionId, @Active)
	END
