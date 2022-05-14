CREATE TABLE [dbo].[Roles]
(
	Id int NOT NULL CONSTRAINT PK_Roles PRIMARY KEY, 
	RoleName nvarchar(32) NOT NULL CONSTRAINT UQ_Roles_RoleName UNIQUE
)
