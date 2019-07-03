CREATE PROCEDURE [dbo].[DeleteSection]
	@Id int
AS
	DELETE FROM Section
	WHERE Id = @Id
RETURN 0
