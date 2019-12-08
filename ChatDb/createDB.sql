USE master;
IF DB_ID('ChatDb') IS NOT NULL
	DROP DATABASE ChatDb
CREATE DATABASE ChatDb
GO

USE ChatDB

CREATE TABLE Users
(
	Id INT IDENTITY,
	Username NVARCHAR(MAX),
	Password NVARCHAR(MAX),
	Token NVARCHAR(MAX),
	Role NVARCHAR(MAX) NOT NULL,

	CONSTRAINT PK_User_Id PRIMARY KEY (Id)
)

CREATE TABLE UserProfiles
(
	Id INT,
	Name NVARCHAR(MAX),
	Surname  NVARCHAR(MAX),
	ImageUrl NVARCHAR(MAX),
	About NVARCHAR(MAX),
	Country NVARCHAR(MAX),
	City NVARCHAR(MAX),
	
	CONSTRAINT PK_UsersProfile_Id PRIMARY KEY (Id),
	CONSTRAINT FK_UserProfile_To_Users FOREIGN KEY (Id) REFERENCES Users(Id),
)

CREATE TABLE Contacts
(
	RelationshipId UNIQUEIDENTIFIER DEFAULT NEWID(),
	MyId INT,
	ContactId INT,

	CONSTRAINT PK_Contacts_Id PRIMARY KEY (RelationshipId),
	CONSTRAINT FK_Contacts_To_MyUser FOREIGN KEY (MyId) REFERENCES Users(Id),
	CONSTRAINT FK_Contacts_To_MyFriend FOREIGN KEY (ContactId) REFERENCES Users(Id),
)

CREATE TABLE Messages
(
	Id UNIQUEIDENTIFIER DEFAULT NEWID(),
	TextMessage NVARCHAR(MAX) NOT NULL,
	DateAndTime DATETIME NOT NULL,
	IdSender INT NOT NULL,
	IdRecipient INT NOT NULL,

	CONSTRAINT PK_Messages_Id PRIMARY KEY (Id),
	CONSTRAINT FK_Messages_To_Senders FOREIGN KEY (IdSender) REFERENCES Users(Id),
	CONSTRAINT FK_Messages_To_Recipients FOREIGN KEY (IdRecipient) REFERENCES Users(Id),
)

GO
CREATE NONCLUSTERED INDEX Message_Date_Index
ON Messages (DateAndTime DESC)
INCLUDE (TextMessage, IdSender, IdRecipient)
