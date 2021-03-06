﻿Use Web

CREATE TABLE dbo.Award (
	ID_Award INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Award PRIMARY KEY,
	Title NVARCHAR(MAX) NOT NULL,
);

CREATE TABLE dbo.Users (
	ID_Users INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_User PRIMARY KEY,
	Name NVARCHAR(MAX) NOT NULL,
	DateOfBirth DATETIME NOT NULL,
	Age INT NOT NULL,
);

CREATE TABLE dbo.UsersAndAwards (
	ID_UsersAndAwards INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_UsersAndAwards PRIMARY KEY,
	ID_Award INT NOT NULL,
	ID_Users INT NOT NULL,
);

ALTER TABLE UsersAndAwards ADD CONSTRAINT FK0_UsersAndAwards FOREIGN KEY (ID_Award) REFERENCES Award(ID_Award);

ALTER TABLE UsersAndAwards ADD CONSTRAINT FK1_UsersAndAwards FOREIGN KEY (ID_Users) REFERENCES Users(ID_Users);


CREATE TABLE dbo.Account (
	ID_Account INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Account PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
	Role NVARCHAR(MAX) NOT NULL,
	Password NVARCHAR(MAX) NOT NULL
);

insert into Account(Mail, Role, Password) values('admin@gmail.com', 'admin', 'admin1234')
delete from account where id_account = 1
select * from account