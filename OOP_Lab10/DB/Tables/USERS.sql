CREATE TABLE [dbo].[Users]
(
	Id uniqueidentifier NOT NULL CONSTRAINT PK_Users PRIMARY KEY,
	Email nvarchar(128) NOT NULL CONSTRAINT UQ_Users_Email UNIQUE,
	PasswordHash nvarchar(128) NOT NULL,
	UserName nvarchar(128) NOT NULL,
	UserSurname nvarchar(128) NOT NULL,
	IsActive bit NOT NULL
)
