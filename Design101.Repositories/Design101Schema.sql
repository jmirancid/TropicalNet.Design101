-- SQL Manager Lite for SQL Server 4.0.1.44515
-- ---------------------------------------
-- Host      : (local)
-- Database  : tropicalnet_design101_trunk
-- Version   : Microsoft SQL Server  10.50.1600.1


--
-- Dropping table Document : 
--

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Document') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
  DROP TABLE dbo.Document
GO

--
-- Dropping table User : 
--

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[User]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
  DROP TABLE dbo.[User]
GO

--
-- Dropping table Role : 
--

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Role') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
  DROP TABLE dbo.Role
GO

--
-- Definition for table Role : 
--

CREATE TABLE dbo.Role (
  RoleId int IDENTITY(1, 1) NOT NULL,
  Name nvarchar(40) COLLATE Modern_Spanish_CI_AS NOT NULL,
  Description nvarchar(120) COLLATE Modern_Spanish_CI_AS NULL
)
ON [PRIMARY]
GO

--
-- Definition for table User : 
--

CREATE TABLE dbo.[User] (
  UserId int IDENTITY(1, 1) NOT NULL,
  RoleId int NOT NULL,
  Name nvarchar(80) COLLATE Modern_Spanish_CI_AS NOT NULL,
  Location nvarchar(80) COLLATE Modern_Spanish_CI_AS NULL,
  Address nvarchar(120) COLLATE Modern_Spanish_CI_AS NULL,
  Phone nvarchar(30) COLLATE Modern_Spanish_CI_AS NULL,
  Mobile nvarchar(30) COLLATE Modern_Spanish_CI_AS NULL,
  Email nvarchar(30) COLLATE Modern_Spanish_CI_AS NULL,
  Username nvarchar(20) COLLATE Modern_Spanish_CI_AS NOT NULL,
  Password nvarchar(16) COLLATE Modern_Spanish_CI_AS NOT NULL,
  Enabled bit NOT NULL,
  Registered datetime NOT NULL,
  Login datetime NULL
)
ON [PRIMARY]
GO

--
-- Definition for table Document : 
--

CREATE TABLE dbo.Document (
  DocumentId int IDENTITY(1, 1) NOT NULL,
  UserId int NOT NULL,
  Name nvarchar(60) COLLATE Modern_Spanish_CI_AS NOT NULL,
  Description nvarchar(max) COLLATE Modern_Spanish_CI_AS NULL,
  Path nvarchar(max) COLLATE Modern_Spanish_CI_AS NOT NULL,
  Enabled bit NOT NULL,
  Priority int NULL,
  Assigned datetime NOT NULL
)
ON [PRIMARY]
GO

--
-- Definition for indices : 
--

ALTER TABLE dbo.Role
ADD CONSTRAINT PK_Role_RoleId 
PRIMARY KEY CLUSTERED (RoleId)
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
GO

ALTER TABLE dbo.[User]
ADD CONSTRAINT PK_User_UserId 
PRIMARY KEY CLUSTERED (UserId)
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
GO

ALTER TABLE dbo.[User]
ADD CONSTRAINT UQ_User_Username 
UNIQUE NONCLUSTERED (Username)
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
GO

ALTER TABLE dbo.Document
ADD CONSTRAINT PK_Document_DocumentId 
PRIMARY KEY CLUSTERED (DocumentId)
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
GO

--
-- Definition for foreign keys : 
--

ALTER TABLE dbo.[User]
ADD CONSTRAINT FK_User_Role FOREIGN KEY (RoleId) 
  REFERENCES dbo.Role (RoleId) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE dbo.Document
ADD CONSTRAINT FK_Document_User FOREIGN KEY (UserId) 
  REFERENCES dbo.[User] (UserId) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

