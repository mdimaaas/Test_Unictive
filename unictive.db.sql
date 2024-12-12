/*
 Navicat Premium Data Transfer

 Source Server         : Localhost
 Source Server Type    : SQL Server
 Source Server Version : 16001135 (16.00.1135)
 Source Host           : localhost:1433
 Source Catalog        : unictive
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 16001135 (16.00.1135)
 File Encoding         : 65001

 Date: 12/12/2024 16:51:07
*/


-- ----------------------------
-- Table structure for tHobby
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tHobby]') AND type IN ('U'))
	DROP TABLE [dbo].[tHobby]
GO

CREATE TABLE [dbo].[tHobby] (
  [fID] int  IDENTITY(1,1) NOT NULL,
  [fHobby] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[tHobby] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tHobby
-- ----------------------------
SET IDENTITY_INSERT [dbo].[tHobby] ON
GO

INSERT INTO [dbo].[tHobby] ([fID], [fHobby]) VALUES (N'1', N'Menyanyi')
GO

INSERT INTO [dbo].[tHobby] ([fID], [fHobby]) VALUES (N'2', N'Memasak')
GO

INSERT INTO [dbo].[tHobby] ([fID], [fHobby]) VALUES (N'3', N'Fotografi')
GO

SET IDENTITY_INSERT [dbo].[tHobby] OFF
GO


-- ----------------------------
-- Table structure for tUser
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tUser]') AND type IN ('U'))
	DROP TABLE [dbo].[tUser]
GO

CREATE TABLE [dbo].[tUser] (
  [fID] int  IDENTITY(1,1) NOT NULL,
  [fName] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[tUser] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tUser
-- ----------------------------
SET IDENTITY_INSERT [dbo].[tUser] ON
GO

INSERT INTO [dbo].[tUser] ([fID], [fName]) VALUES (N'1', N'dimas')
GO

INSERT INTO [dbo].[tUser] ([fID], [fName]) VALUES (N'2', N'samid')
GO

SET IDENTITY_INSERT [dbo].[tUser] OFF
GO


-- ----------------------------
-- Table structure for tUserHobby
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tUserHobby]') AND type IN ('U'))
	DROP TABLE [dbo].[tUserHobby]
GO

CREATE TABLE [dbo].[tUserHobby] (
  [fID] int  IDENTITY(1,1) NOT NULL,
  [fUserID] int  NOT NULL,
  [fHobbyID] int  NOT NULL
)
GO

ALTER TABLE [dbo].[tUserHobby] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tUserHobby
-- ----------------------------
SET IDENTITY_INSERT [dbo].[tUserHobby] ON
GO

INSERT INTO [dbo].[tUserHobby] ([fID], [fUserID], [fHobbyID]) VALUES (N'1', N'1', N'3')
GO

INSERT INTO [dbo].[tUserHobby] ([fID], [fUserID], [fHobbyID]) VALUES (N'2', N'1', N'2')
GO

INSERT INTO [dbo].[tUserHobby] ([fID], [fUserID], [fHobbyID]) VALUES (N'3', N'2', N'1')
GO

INSERT INTO [dbo].[tUserHobby] ([fID], [fUserID], [fHobbyID]) VALUES (N'4', N'2', N'3')
GO

SET IDENTITY_INSERT [dbo].[tUserHobby] OFF
GO


-- ----------------------------
-- Auto increment value for tHobby
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[tHobby]', RESEED, 3)
GO


-- ----------------------------
-- Primary Key structure for table tHobby
-- ----------------------------
ALTER TABLE [dbo].[tHobby] ADD CONSTRAINT [PK__tHobbies__D9F8259C8E7003CD] PRIMARY KEY CLUSTERED ([fID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for tUser
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[tUser]', RESEED, 2)
GO


-- ----------------------------
-- Primary Key structure for table tUser
-- ----------------------------
ALTER TABLE [dbo].[tUser] ADD CONSTRAINT [PK__tUser__D9F8259CBD7F42AF] PRIMARY KEY CLUSTERED ([fID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for tUserHobby
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[tUserHobby]', RESEED, 4)
GO


-- ----------------------------
-- Primary Key structure for table tUserHobby
-- ----------------------------
ALTER TABLE [dbo].[tUserHobby] ADD CONSTRAINT [PK__tUserHob__D9F8259C103DB6BC] PRIMARY KEY CLUSTERED ([fID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

