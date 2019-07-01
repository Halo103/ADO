SET IDENTITY_INSERT Employee ON;

INSERT INTO [Employee] (Id,FirstName,LastName,Email, BirthDate, ResponsableID)
VALUES
(1,	'Ken','Sánchez','ken0@adventure-works.com','1969-01-29',NULL),
(16,'David','Bradley','david0@adventure-works.com','1975-03-19',273),
(23,'Mary','Gibson','mary0@adventure-works.com','1962-09-13',16),
(273,'Brian','Welcker','brian3@adventure-works.com','1977-06-06',1),
(274,'Stephen','Jiang','stephen0@adventure-works.com','1951-10-17',273),
(275,'Michael','Blythe','michael9@adventure-works.com','1968-12-25',274),
(276,'Linda','Mitchell','linda3@adventure-works.com','1980-02-27',274),
(285,'Syed','Abbas','syed0@adventure-works.com','1975-01-11',273),
(286,'Lynn','Tsoflias','lynn0@adventure-works.com','1977-02-14',285);

SET IDENTITY_INSERT [Employee] OFF;
