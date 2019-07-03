CREATE PROCEDURE [dbo].[UpdateSection]
	@name varchar(50),
	@Id int
AS
	UPDATE Section
	SET SectionName = @name
	WHERE Id = @Id
RETURN 0
