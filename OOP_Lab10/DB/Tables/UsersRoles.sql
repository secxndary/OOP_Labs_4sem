CREATE TABLE [dbo].[UsersRoles]
(
	UserId uniqueidentifier CONSTRAINT FK_UsersRoles_Users FOREIGN KEY REFERENCES dbo.Users(Id),
	RoleId int CONSTRAINT FK_UsersRoles_Roles FOREIGN KEY REFERENCES dbo.Roles(Id),
	CONSTRAINT PK_UsersRoles PRIMARY KEY (UserId, RoleId)
)

go
CREATE INDEX IX_UsersRoles_UserId ON dbo.UsersRoles(UserId)
go

go
CREATE INDEX IX_UsersRoles_RoleId ON dbo.UsersRoles(RoleId)
go
