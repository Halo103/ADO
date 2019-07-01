CREATE TABLE [dbo].[Student]
(
	[Id] INT NOT NULL  IDENTITY,
	[FirstName] nvarchar(50) NOT NULL,
	[LastName] nvarchar(50) NOT NULL,
	[BirthDate] datetime2(7) NOT NULL,
	[YearResult] int NOT NULL,
	[SectionId] int NOT NULL,
	[Active] bit NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_Student] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Student_Section] FOREIGN KEY ([SectionId]) REFERENCES [Section]([Id]), 
    CONSTRAINT [CK_Student_YearResult] CHECK (YearResult BETWEEN 0 AND 20), 
    CONSTRAINT [CK_Student_BirthDate] CHECK (BirthDate >= '1930-01-01') 
)

GO

CREATE TRIGGER [dbo].[Trigger_Delete]
    ON [dbo].[Student]
    FOR DELETE
    AS
    BEGIN
        SET NoCount ON
		UPDATE Student
		SET Active = 0
		WHERE Id IN (SELECT Id FROM deleted)
		END