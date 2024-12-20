USE [master]
GO
/****** Object:  Database [inventory_system]    Script Date: 07/12/2024 9:14:55 am ******/
CREATE DATABASE [inventory_system]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'inventory_system', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\inventory_system.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'inventory_system_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\inventory_system_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [inventory_system] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [inventory_system].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [inventory_system] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [inventory_system] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [inventory_system] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [inventory_system] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [inventory_system] SET ARITHABORT OFF 
GO
ALTER DATABASE [inventory_system] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [inventory_system] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [inventory_system] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [inventory_system] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [inventory_system] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [inventory_system] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [inventory_system] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [inventory_system] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [inventory_system] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [inventory_system] SET  ENABLE_BROKER 
GO
ALTER DATABASE [inventory_system] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [inventory_system] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [inventory_system] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [inventory_system] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [inventory_system] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [inventory_system] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [inventory_system] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [inventory_system] SET RECOVERY FULL 
GO
ALTER DATABASE [inventory_system] SET  MULTI_USER 
GO
ALTER DATABASE [inventory_system] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [inventory_system] SET DB_CHAINING OFF 
GO
ALTER DATABASE [inventory_system] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [inventory_system] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [inventory_system] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [inventory_system] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'inventory_system', N'ON'
GO
ALTER DATABASE [inventory_system] SET QUERY_STORE = ON
GO
ALTER DATABASE [inventory_system] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [inventory_system]
GO
/****** Object:  Table [dbo].[items]    Script Date: 07/12/2024 9:14:55 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[items](
	[item_id] [int] IDENTITY(1,1) NOT NULL,
	[item_stock_id] [int] NOT NULL,
	[item_name] [varchar](50) NOT NULL,
	[item_brand] [varchar](50) NULL,
	[item_serial_number] [varchar](50) NULL,
	[item_condition] [varchar](50) NULL,
	[item_is_borrowed] [bit] NULL,
	[item_is_archived] [bit] NULL,
	[item_is_maintenance] [bit] NULL,
	[item_type] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[maintenance]    Script Date: 07/12/2024 9:14:55 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[maintenance](
	[maintenance_id] [int] IDENTITY(1,1) NOT NULL,
	[maintenance_item_id] [int] NOT NULL,
	[maintenance_start_date] [date] NOT NULL,
	[maintenance_complete_date] [date] NULL,
	[maintenance_description] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[maintenance_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[notifications]    Script Date: 07/12/2024 9:14:55 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[notifications](
	[notification_id] [int] IDENTITY(1,1) NOT NULL,
	[notification_transaction_id] [int] NOT NULL,
	[notification_date] [date] NOT NULL,
	[notification_description] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[notification_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[roles]    Script Date: 07/12/2024 9:14:55 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roles](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [varchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[stocks]    Script Date: 07/12/2024 9:14:55 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stocks](
	[stock_id] [int] IDENTITY(1,1) NOT NULL,
	[stock_name] [varchar](50) NOT NULL,
	[stock_total_quantity] [int] NULL,
	[stock_available] [int] NULL,
	[stock_under_maintenance] [int] NULL,
	[stock_borrowed] [int] NULL,
	[stock_archived] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[stock_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[transactions]    Script Date: 07/12/2024 9:14:55 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[transactions](
	[transaction_id] [int] IDENTITY(1,1) NOT NULL,
	[transaction_user_id] [int] NULL,
	[transaction_item_id] [int] NOT NULL,
	[transaction_borrow_date] [date] NULL,
	[transaction_return_date] [date] NULL,
	[transaction_due_date] [date] NULL,
	[transaction_return_condition] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[transaction_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 07/12/2024 9:14:55 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[role_id] [int] NOT NULL,
	[user_uli] [int] NOT NULL,
	[user_username] [varchar](50) NOT NULL,
	[user_password] [varchar](50) NOT NULL,
	[user_name] [varchar](50) NOT NULL,
	[user_contact_number] [varchar](11) NULL,
	[user_address] [varchar](100) NULL,
	[user_birthday] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[items]  WITH CHECK ADD  CONSTRAINT [FK_item_stock_id_stock_id] FOREIGN KEY([item_stock_id])
REFERENCES [dbo].[stocks] ([stock_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[items] CHECK CONSTRAINT [FK_item_stock_id_stock_id]
GO
ALTER TABLE [dbo].[maintenance]  WITH CHECK ADD  CONSTRAINT [FK_maintenance_item_id_item_id] FOREIGN KEY([maintenance_item_id])
REFERENCES [dbo].[items] ([item_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[maintenance] CHECK CONSTRAINT [FK_maintenance_item_id_item_id]
GO
ALTER TABLE [dbo].[notifications]  WITH CHECK ADD  CONSTRAINT [FK_notification_transaction_id_transaction_id] FOREIGN KEY([notification_transaction_id])
REFERENCES [dbo].[transactions] ([transaction_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[notifications] CHECK CONSTRAINT [FK_notification_transaction_id_transaction_id]
GO
ALTER TABLE [dbo].[transactions]  WITH CHECK ADD  CONSTRAINT [FK_transaction_item_id_item_id] FOREIGN KEY([transaction_item_id])
REFERENCES [dbo].[items] ([item_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[transactions] CHECK CONSTRAINT [FK_transaction_item_id_item_id]
GO
ALTER TABLE [dbo].[transactions]  WITH CHECK ADD  CONSTRAINT [FK_transaction_user_id_user_id] FOREIGN KEY([transaction_user_id])
REFERENCES [dbo].[users] ([user_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[transactions] CHECK CONSTRAINT [FK_transaction_user_id_user_id]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_user_role_id_role_id] FOREIGN KEY([role_id])
REFERENCES [dbo].[roles] ([role_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_user_role_id_role_id]
GO
USE [master]
GO
ALTER DATABASE [inventory_system] SET  READ_WRITE 
GO
