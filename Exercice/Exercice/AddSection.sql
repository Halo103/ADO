CREATE PROCEDURE [dbo].[AddSection]
	@Id int,
	@SectionName nvarchar(50)
AS
BEGIN
	INSERT INTO Section VALUES(@Id, @SectionName)
END
