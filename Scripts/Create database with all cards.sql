USE [master]
GO
/****** Object:  Database [LOTR-game]    Script Date: 2019-01-12 17:21:25 ******/
CREATE DATABASE [LOTR-game]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LOTR2-game', FILENAME = N'C:\Users\Administrator\LOTR2-game.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LOTR2-game_log', FILENAME = N'C:\Users\Administrator\LOTR2-game_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [LOTR-game] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LOTR-game].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LOTR-game] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LOTR-game] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LOTR-game] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LOTR-game] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LOTR-game] SET ARITHABORT OFF 
GO
ALTER DATABASE [LOTR-game] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LOTR-game] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LOTR-game] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LOTR-game] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LOTR-game] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LOTR-game] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LOTR-game] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LOTR-game] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LOTR-game] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LOTR-game] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LOTR-game] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LOTR-game] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LOTR-game] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LOTR-game] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LOTR-game] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LOTR-game] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LOTR-game] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LOTR-game] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LOTR-game] SET  MULTI_USER 
GO
ALTER DATABASE [LOTR-game] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LOTR-game] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LOTR-game] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LOTR-game] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LOTR-game] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LOTR-game] SET QUERY_STORE = OFF
GO
USE [LOTR-game]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [LOTR-game]
GO
/****** Object:  Table [dbo].[Ability]    Script Date: 2019-01-12 17:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ability](
	[AbilityID] [int] IDENTITY(1,1) NOT NULL,
	[AbilityTypeId] [int] NULL,
	[Value] [int] NULL,
 CONSTRAINT [PK_CardAbilities] PRIMARY KEY CLUSTERED 
(
	[AbilityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AbilityToCard]    Script Date: 2019-01-12 17:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AbilityToCard](
	[AbilityId] [int] NOT NULL,
	[CardId] [int] NOT NULL,
 CONSTRAINT [PK_AbilityToCard] PRIMARY KEY CLUSTERED 
(
	[AbilityId] ASC,
	[CardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AbilityType]    Script Date: 2019-01-12 17:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AbilityType](
	[AbilityTypeID] [int] NOT NULL,
	[AbilityTypeName] [nchar](10) NULL,
 CONSTRAINT [PK_AbilityType] PRIMARY KEY CLUSTERED 
(
	[AbilityTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Card]    Script Date: 2019-01-12 17:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Card](
	[CardID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Cost] [int] NULL,
	[CardTypeId] [int] NULL,
	[Attack] [int] NULL,
	[Health] [int] NULL,
 CONSTRAINT [PK_Card] PRIMARY KEY CLUSTERED 
(
	[CardID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CardType]    Script Date: 2019-01-12 17:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CardType](
	[CardTypeID] [int] NOT NULL,
	[CardTypeName] [nchar](10) NULL,
 CONSTRAINT [PK_CardType] PRIMARY KEY CLUSTERED 
(
	[CardTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Player]    Script Date: 2019-01-12 17:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player](
	[Name] [nvarchar](50) NOT NULL,
	[Wins] [int] NULL,
	[Losses] [int] NULL,
 CONSTRAINT [PK_Player_1] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SavedGame]    Script Date: 2019-01-12 17:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SavedGame](
	[Id] [int] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Ability] ON 

INSERT [dbo].[Ability] ([AbilityID], [AbilityTypeId], [Value]) VALUES (10, 1, -3)
INSERT [dbo].[Ability] ([AbilityID], [AbilityTypeId], [Value]) VALUES (1, 1, 1)
INSERT [dbo].[Ability] ([AbilityID], [AbilityTypeId], [Value]) VALUES (2, 1, 2)
INSERT [dbo].[Ability] ([AbilityID], [AbilityTypeId], [Value]) VALUES (3, 1, 3)
INSERT [dbo].[Ability] ([AbilityID], [AbilityTypeId], [Value]) VALUES (4, 2, 1)
INSERT [dbo].[Ability] ([AbilityID], [AbilityTypeId], [Value]) VALUES (5, 2, 2)
INSERT [dbo].[Ability] ([AbilityID], [AbilityTypeId], [Value]) VALUES (6, 2, 3)
INSERT [dbo].[Ability] ([AbilityID], [AbilityTypeId], [Value]) VALUES (11, 2, 4)
INSERT [dbo].[Ability] ([AbilityID], [AbilityTypeId], [Value]) VALUES (12, 2, 5)
INSERT [dbo].[Ability] ([AbilityID], [AbilityTypeId], [Value]) VALUES (7, 3, 1)
INSERT [dbo].[Ability] ([AbilityID], [AbilityTypeId], [Value]) VALUES (8, 3, 2)
INSERT [dbo].[Ability] ([AbilityID], [AbilityTypeId], [Value]) VALUES (9, 3, 3)
SET IDENTITY_INSERT [dbo].[Ability] OFF
INSERT [dbo].[AbilityToCard] ([AbilityId], [CardId]) VALUES (1, 3)
INSERT [dbo].[AbilityToCard] ([AbilityId], [CardId]) VALUES (1, 5)
INSERT [dbo].[AbilityToCard] ([AbilityId], [CardId]) VALUES (1, 6)
INSERT [dbo].[AbilityToCard] ([AbilityId], [CardId]) VALUES (1, 29)
INSERT [dbo].[AbilityToCard] ([AbilityId], [CardId]) VALUES (2, 10)
INSERT [dbo].[AbilityToCard] ([AbilityId], [CardId]) VALUES (2, 18)
INSERT [dbo].[AbilityToCard] ([AbilityId], [CardId]) VALUES (2, 19)
INSERT [dbo].[AbilityToCard] ([AbilityId], [CardId]) VALUES (3, 16)
INSERT [dbo].[AbilityToCard] ([AbilityId], [CardId]) VALUES (3, 26)
INSERT [dbo].[AbilityToCard] ([AbilityId], [CardId]) VALUES (4, 12)
INSERT [dbo].[AbilityToCard] ([AbilityId], [CardId]) VALUES (4, 24)
INSERT [dbo].[AbilityToCard] ([AbilityId], [CardId]) VALUES (5, 21)
INSERT [dbo].[AbilityToCard] ([AbilityId], [CardId]) VALUES (5, 28)
INSERT [dbo].[AbilityToCard] ([AbilityId], [CardId]) VALUES (5, 31)
INSERT [dbo].[AbilityToCard] ([AbilityId], [CardId]) VALUES (7, 5)
INSERT [dbo].[AbilityToCard] ([AbilityId], [CardId]) VALUES (7, 9)
INSERT [dbo].[AbilityToCard] ([AbilityId], [CardId]) VALUES (7, 24)
INSERT [dbo].[AbilityToCard] ([AbilityId], [CardId]) VALUES (7, 32)
INSERT [dbo].[AbilityToCard] ([AbilityId], [CardId]) VALUES (8, 14)
INSERT [dbo].[AbilityToCard] ([AbilityId], [CardId]) VALUES (8, 15)
INSERT [dbo].[AbilityToCard] ([AbilityId], [CardId]) VALUES (8, 17)
INSERT [dbo].[AbilityToCard] ([AbilityId], [CardId]) VALUES (8, 31)
INSERT [dbo].[AbilityToCard] ([AbilityId], [CardId]) VALUES (9, 30)
INSERT [dbo].[AbilityToCard] ([AbilityId], [CardId]) VALUES (9, 34)
INSERT [dbo].[AbilityToCard] ([AbilityId], [CardId]) VALUES (10, 15)
INSERT [dbo].[AbilityToCard] ([AbilityId], [CardId]) VALUES (11, 32)
INSERT [dbo].[AbilityToCard] ([AbilityId], [CardId]) VALUES (12, 33)
INSERT [dbo].[AbilityType] ([AbilityTypeID], [AbilityTypeName]) VALUES (1, N'LifeGain  ')
INSERT [dbo].[AbilityType] ([AbilityTypeID], [AbilityTypeName]) VALUES (2, N'Damage    ')
INSERT [dbo].[AbilityType] ([AbilityTypeID], [AbilityTypeName]) VALUES (3, N'DrawCard  ')
SET IDENTITY_INSERT [dbo].[Card] ON 

INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (1, N'Orc', 1, 1, 2, 1)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (2, N'Human', 1, 1, 1, 2)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (3, N'Hobbit', 1, 1, 1, 1)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (4, N'Warg', 2, 1, 2, 2)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (5, N'Frodo', 4, 1, 2, 2)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (6, N'Elf', 2, 1, 2, 1)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (7, N'Dwarf', 2, 1, 2, 3)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (8, N'Sam', 3, 1, 2, 4)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (9, N'Pippin', 3, 1, 1, 1)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (10, N'Merry', 3, 1, 2, 2)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (11, N'Uruk''Hai', 3, 1, 3, 3)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (12, N'Azog', 4, 1, 4, 3)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (13, N'Fellbeast', 4, 1, 3, 5)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (14, N'Bilbo', 4, 1, 1, 1)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (15, N'Gollum', 4, 1, 2, 3)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (16, N'Arwen', 4, 1, 3, 2)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (17, N'Elrond', 5, 1, 3, 2)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (18, N'Boromir', 5, 1, 5, 4)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (19, N'Faramir', 5, 1, 4, 5)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (20, N'Gimli', 5, 1, 5, 5)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (21, N'Legolas', 5, 1, 4, 4)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (22, N'Cave Troll', 5, 1, 4, 6)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (23, N'Witch-king of Angmar', 6, 1, 7, 5)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (24, N'Nazgûl', 6, 1, 4, 4)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (25, N'Oliphaunt', 6, 1, 5, 7)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (26, N'Aragorn', 6, 1, 6, 6)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (27, N'Shelob', 6, 1, 4, 7)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (28, N'Balrog', 7, 1, 7, 6)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (29, N'Ent', 7, 1, 7, 8)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (30, N'Galadriel', 7, 1, 3, 4)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (31, N'Gandalf', 8, 1, 4, 6)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (32, N'Saruman', 8, 1, 4, 6)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (33, N'Smaug', 9, 1, 8, 8)
INSERT [dbo].[Card] ([CardID], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (34, N'Sauron', 10, 1, 10, 10)
SET IDENTITY_INSERT [dbo].[Card] OFF
INSERT [dbo].[CardType] ([CardTypeID], [CardTypeName]) VALUES (1, N'Creature  ')
INSERT [dbo].[CardType] ([CardTypeID], [CardTypeName]) VALUES (2, N'Spell     ')
INSERT [dbo].[Player] ([Name], [Wins], [Losses]) VALUES (N'Erika', 0, 0)
INSERT [dbo].[Player] ([Name], [Wins], [Losses]) VALUES (N'Magnus', 0, 0)
INSERT [dbo].[Player] ([Name], [Wins], [Losses]) VALUES (N'Rikard', 0, 0)
/****** Object:  Index [UC_Ability]    Script Date: 2019-01-12 17:21:26 ******/
ALTER TABLE [dbo].[Ability] ADD  CONSTRAINT [UC_Ability] UNIQUE NONCLUSTERED 
(
	[AbilityTypeId] ASC,
	[Value] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Ability]  WITH CHECK ADD  CONSTRAINT [FK_CardAbilities_AbilityType] FOREIGN KEY([AbilityTypeId])
REFERENCES [dbo].[AbilityType] ([AbilityTypeID])
GO
ALTER TABLE [dbo].[Ability] CHECK CONSTRAINT [FK_CardAbilities_AbilityType]
GO
ALTER TABLE [dbo].[AbilityToCard]  WITH CHECK ADD  CONSTRAINT [FK_AbilityToCard_Card] FOREIGN KEY([CardId])
REFERENCES [dbo].[Card] ([CardID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AbilityToCard] CHECK CONSTRAINT [FK_AbilityToCard_Card]
GO
ALTER TABLE [dbo].[AbilityToCard]  WITH CHECK ADD  CONSTRAINT [FK_AbilityToCard_CardAbilities] FOREIGN KEY([AbilityId])
REFERENCES [dbo].[Ability] ([AbilityID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AbilityToCard] CHECK CONSTRAINT [FK_AbilityToCard_CardAbilities]
GO
ALTER TABLE [dbo].[Card]  WITH CHECK ADD  CONSTRAINT [FK_Card_CardType] FOREIGN KEY([CardTypeId])
REFERENCES [dbo].[CardType] ([CardTypeID])
GO
ALTER TABLE [dbo].[Card] CHECK CONSTRAINT [FK_Card_CardType]
GO
USE [master]
GO
ALTER DATABASE [LOTR-game] SET  READ_WRITE 
GO
