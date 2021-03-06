USE [master]
GO
/****** Object:  Database [LOTR-game]    Script Date: 2019-01-10 16:04:34 ******/
CREATE DATABASE [LOTR-game]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LOTR-game', FILENAME = N'C:\Users\Administrator\LOTR-game.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LOTR-game_log', FILENAME = N'C:\Users\Administrator\LOTR-game_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
/****** Object:  Table [dbo].[AbilityToCard]    Script Date: 2019-01-10 16:04:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AbilityToCard](
	[CardAbility] [int] NOT NULL,
	[CardId] [int] NOT NULL,
 CONSTRAINT [PK_AbilityToCard] PRIMARY KEY CLUSTERED 
(
	[CardAbility] ASC,
	[CardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AbilityType]    Script Date: 2019-01-10 16:04:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AbilityType](
	[Id] [int] NOT NULL,
	[Name] [nchar](10) NULL,
 CONSTRAINT [PK_AbilityType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Card]    Script Date: 2019-01-10 16:04:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Card](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Cost] [int] NULL,
	[CardTypeId] [int] NULL,
	[Attack] [int] NULL,
	[Health] [int] NULL,
 CONSTRAINT [PK_Card] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CardAbilities]    Script Date: 2019-01-10 16:04:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CardAbilities](
	[Id] [int] NOT NULL,
	[AbilitieTypeId] [int] NULL,
	[Value] [int] NULL,
 CONSTRAINT [PK_CardAbilities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CardType]    Script Date: 2019-01-10 16:04:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CardType](
	[Id] [int] NOT NULL,
	[Type] [nchar](10) NULL,
 CONSTRAINT [PK_CardType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Player]    Script Date: 2019-01-10 16:04:34 ******/
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
/****** Object:  Table [dbo].[SavedGame]    Script Date: 2019-01-10 16:04:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SavedGame](
	[Id] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[AbilityToCard] ([CardAbility], [CardId]) VALUES (1, 3)
INSERT [dbo].[AbilityToCard] ([CardAbility], [CardId]) VALUES (1, 5)
INSERT [dbo].[AbilityToCard] ([CardAbility], [CardId]) VALUES (7, 5)
INSERT [dbo].[AbilityType] ([Id], [Name]) VALUES (1, N'LifeGain  ')
INSERT [dbo].[AbilityType] ([Id], [Name]) VALUES (2, N'Damage    ')
INSERT [dbo].[AbilityType] ([Id], [Name]) VALUES (3, N'DrawCard  ')
INSERT [dbo].[Card] ([Id], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (1, N'Orc', 1, 1, 2, 1)
INSERT [dbo].[Card] ([Id], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (2, N'Human', 1, 1, 1, 2)
INSERT [dbo].[Card] ([Id], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (3, N'Hobbit', 1, 1, 1, 1)
INSERT [dbo].[Card] ([Id], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (4, N'Warg', 2, 1, 2, 2)
INSERT [dbo].[Card] ([Id], [Name], [Cost], [CardTypeId], [Attack], [Health]) VALUES (5, N'Frodo', 4, 1, 2, 2)
INSERT [dbo].[CardAbilities] ([Id], [AbilitieTypeId], [Value]) VALUES (1, 1, 1)
INSERT [dbo].[CardAbilities] ([Id], [AbilitieTypeId], [Value]) VALUES (2, 1, 2)
INSERT [dbo].[CardAbilities] ([Id], [AbilitieTypeId], [Value]) VALUES (3, 1, 3)
INSERT [dbo].[CardAbilities] ([Id], [AbilitieTypeId], [Value]) VALUES (4, 2, 1)
INSERT [dbo].[CardAbilities] ([Id], [AbilitieTypeId], [Value]) VALUES (5, 2, 2)
INSERT [dbo].[CardAbilities] ([Id], [AbilitieTypeId], [Value]) VALUES (6, 2, 3)
INSERT [dbo].[CardAbilities] ([Id], [AbilitieTypeId], [Value]) VALUES (7, 3, 1)
INSERT [dbo].[CardAbilities] ([Id], [AbilitieTypeId], [Value]) VALUES (8, 3, 2)
INSERT [dbo].[CardAbilities] ([Id], [AbilitieTypeId], [Value]) VALUES (9, 3, 3)
INSERT [dbo].[CardType] ([Id], [Type]) VALUES (1, N'Creature  ')
INSERT [dbo].[CardType] ([Id], [Type]) VALUES (2, N'Spell     ')
INSERT [dbo].[Player] ([Name], [Wins], [Losses]) VALUES (N'Erika', 0, 0)
INSERT [dbo].[Player] ([Name], [Wins], [Losses]) VALUES (N'Magnus', 0, 0)
INSERT [dbo].[Player] ([Name], [Wins], [Losses]) VALUES (N'Rikard', 0, 0)
ALTER TABLE [dbo].[AbilityToCard]  WITH CHECK ADD  CONSTRAINT [FK_AbilityToCard_Card] FOREIGN KEY([CardId])
REFERENCES [dbo].[Card] ([Id])
GO
ALTER TABLE [dbo].[AbilityToCard] CHECK CONSTRAINT [FK_AbilityToCard_Card]
GO
ALTER TABLE [dbo].[AbilityToCard]  WITH CHECK ADD  CONSTRAINT [FK_AbilityToCard_CardAbilities] FOREIGN KEY([CardAbility])
REFERENCES [dbo].[CardAbilities] ([Id])
GO
ALTER TABLE [dbo].[AbilityToCard] CHECK CONSTRAINT [FK_AbilityToCard_CardAbilities]
GO
ALTER TABLE [dbo].[Card]  WITH CHECK ADD  CONSTRAINT [FK_Card_CardType] FOREIGN KEY([CardTypeId])
REFERENCES [dbo].[CardType] ([Id])
GO
ALTER TABLE [dbo].[Card] CHECK CONSTRAINT [FK_Card_CardType]
GO
ALTER TABLE [dbo].[CardAbilities]  WITH CHECK ADD  CONSTRAINT [FK_CardAbilities_AbilityType] FOREIGN KEY([AbilitieTypeId])
REFERENCES [dbo].[AbilityType] ([Id])
GO
ALTER TABLE [dbo].[CardAbilities] CHECK CONSTRAINT [FK_CardAbilities_AbilityType]
GO
USE [master]
GO
ALTER DATABASE [LOTR-game] SET  READ_WRITE 
GO
