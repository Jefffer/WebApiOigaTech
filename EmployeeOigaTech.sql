USE [master]
GO
/****** Object:  Database [EmployeeOigaTech]    Script Date: 6/11/2019 00:01:09 ******/
CREATE DATABASE [EmployeeOigaTech]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmployeeOigaTech', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\EmployeeOigaTech.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EmployeeOigaTech_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\EmployeeOigaTech_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [EmployeeOigaTech] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmployeeOigaTech].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmployeeOigaTech] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmployeeOigaTech] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmployeeOigaTech] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmployeeOigaTech] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmployeeOigaTech] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmployeeOigaTech] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmployeeOigaTech] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmployeeOigaTech] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmployeeOigaTech] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmployeeOigaTech] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmployeeOigaTech] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmployeeOigaTech] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmployeeOigaTech] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmployeeOigaTech] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmployeeOigaTech] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EmployeeOigaTech] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmployeeOigaTech] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmployeeOigaTech] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmployeeOigaTech] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmployeeOigaTech] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmployeeOigaTech] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmployeeOigaTech] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmployeeOigaTech] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EmployeeOigaTech] SET  MULTI_USER 
GO
ALTER DATABASE [EmployeeOigaTech] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmployeeOigaTech] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmployeeOigaTech] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmployeeOigaTech] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EmployeeOigaTech] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EmployeeOigaTech] SET QUERY_STORE = OFF
GO
USE [EmployeeOigaTech]
GO
/****** Object:  Table [dbo].[ContractType]    Script Date: 6/11/2019 00:01:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractType](
	[idContractType] [int] NOT NULL,
	[contractTypeName] [varchar](50) NOT NULL,
	[description] [varchar](50) NULL,
 CONSTRAINT [PK_ContractType] PRIMARY KEY CLUSTERED 
(
	[idContractType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 6/11/2019 00:01:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[idEmployee] [int] IDENTITY(1,1) NOT NULL,
	[employeeName] [varchar](50) NOT NULL,
	[employeePhone] [varchar](50) NOT NULL,
	[employeePosition] [varchar](50) NOT NULL,
	[fk_ContractType] [int] NOT NULL,
	[hourlySalary] [decimal](18, 0) NULL,
	[monthlySalary] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[idEmployee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ContractType] ([idContractType], [contractTypeName], [description]) VALUES (1, N'Hourly Salary', NULL)
INSERT [dbo].[ContractType] ([idContractType], [contractTypeName], [description]) VALUES (2, N'Monthly Salary', NULL)
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([idEmployee], [employeeName], [employeePhone], [employeePosition], [fk_ContractType], [hourlySalary], [monthlySalary]) VALUES (1, N'Beatriz Pinzón', N'3233455667', N'Accountant', 1, CAST(15000 AS Decimal(18, 0)), CAST(1800000 AS Decimal(18, 0)))
INSERT [dbo].[Employee] ([idEmployee], [employeeName], [employeePhone], [employeePosition], [fk_ContractType], [hourlySalary], [monthlySalary]) VALUES (6, N'Nicolás Mora', N'3230909764', N'Lawyer', 2, CAST(20000 AS Decimal(18, 0)), CAST(2000000 AS Decimal(18, 0)))
INSERT [dbo].[Employee] ([idEmployee], [employeeName], [employeePhone], [employeePosition], [fk_ContractType], [hourlySalary], [monthlySalary]) VALUES (7, N'Patricia Ramirez', N'9002338', N'Secretary', 2, CAST(8000 AS Decimal(18, 0)), CAST(1500000 AS Decimal(18, 0)))
INSERT [dbo].[Employee] ([idEmployee], [employeeName], [employeePhone], [employeePosition], [fk_ContractType], [hourlySalary], [monthlySalary]) VALUES (11, N'Armando Mendoza', N'3139899056', N'President', 1, CAST(50000 AS Decimal(18, 0)), CAST(5000000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Employee] OFF
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_ContractType] FOREIGN KEY([fk_ContractType])
REFERENCES [dbo].[ContractType] ([idContractType])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_ContractType]
GO
USE [master]
GO
ALTER DATABASE [EmployeeOigaTech] SET  READ_WRITE 
GO
