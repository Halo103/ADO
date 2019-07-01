CREATE VIEW [dbo].[V_Employee]
	AS SELECT Emp.*, Resp.LastName AS RespLastName, Resp.FirstName AS RespFirstName, Resp.Email AS RespEmail 
	FROM [Employee] Emp JOIN [Employee] Resp ON Emp.ResponsableID = Resp.Id 
