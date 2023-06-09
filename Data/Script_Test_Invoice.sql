USE [Test_Invoice]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceDetail]') AND type in (N'U'))
ALTER TABLE [dbo].[InvoiceDetail] DROP CONSTRAINT IF EXISTS [CHK_Qty]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceDetail]') AND type in (N'U'))
ALTER TABLE [dbo].[InvoiceDetail] DROP CONSTRAINT IF EXISTS [CHK_Price]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerType]') AND type in (N'U'))
ALTER TABLE [dbo].[CustomerType] DROP CONSTRAINT IF EXISTS [CHK_CustomerTypeDisplay]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerStatus]') AND type in (N'U'))
ALTER TABLE [dbo].[CustomerStatus] DROP CONSTRAINT IF EXISTS [CHK_CustomerStatusDisplay]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND type in (N'U'))
ALTER TABLE [dbo].[Customer] DROP CONSTRAINT IF EXISTS [CHK_CustomerName]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND type in (N'U'))
ALTER TABLE [dbo].[Customer] DROP CONSTRAINT IF EXISTS [CHK_Address]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceDetail]') AND type in (N'U'))
ALTER TABLE [dbo].[InvoiceDetail] DROP CONSTRAINT IF EXISTS [FK_InvoiceDetail_Product_Product_ID]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceDetail]') AND type in (N'U'))
ALTER TABLE [dbo].[InvoiceDetail] DROP CONSTRAINT IF EXISTS [FK_InvoiceDetail_Invoice_Invoice_ID]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceDetail]') AND type in (N'U'))
ALTER TABLE [dbo].[InvoiceDetail] DROP CONSTRAINT IF EXISTS [FK_InvoiceDetail_Customer_Customer_ID]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Invoice]') AND type in (N'U'))
ALTER TABLE [dbo].[Invoice] DROP CONSTRAINT IF EXISTS [FK_Invoice_Customer_Customer_ID]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND type in (N'U'))
ALTER TABLE [dbo].[Customer] DROP CONSTRAINT IF EXISTS [FK_Customer_CustomerType_CustomerType_ID]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND type in (N'U'))
ALTER TABLE [dbo].[Customer] DROP CONSTRAINT IF EXISTS [FK_Customer_CustomerStatus_CustomerStatus_ID]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceDetail]') AND type in (N'U'))
ALTER TABLE [dbo].[InvoiceDetail] DROP CONSTRAINT IF EXISTS [DF__InvoiceDe__Invoi__4F7CD00D]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceDetail]') AND type in (N'U'))
ALTER TABLE [dbo].[InvoiceDetail] DROP CONSTRAINT IF EXISTS [DF__InvoiceDe__Produ__4AB81AF0]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Invoice]') AND type in (N'U'))
ALTER TABLE [dbo].[Invoice] DROP CONSTRAINT IF EXISTS [DF__Invoice__Created__4E88ABD4]
GO
/****** Object:  Index [UQ_Products]    Script Date: 5/14/2023 7:38:37 PM ******/
DROP INDEX IF EXISTS [UQ_Products] ON [dbo].[Product]
GO
/****** Object:  Index [UQ_InvoiceDetails]    Script Date: 5/14/2023 7:38:37 PM ******/
DROP INDEX IF EXISTS [UQ_InvoiceDetails] ON [dbo].[InvoiceDetail]
GO
/****** Object:  Index [IX_InvoiceDetail_Product_ID]    Script Date: 5/14/2023 7:38:37 PM ******/
DROP INDEX IF EXISTS [IX_InvoiceDetail_Product_ID] ON [dbo].[InvoiceDetail]
GO
/****** Object:  Index [IX_InvoiceDetail_Invoice_ID]    Script Date: 5/14/2023 7:38:37 PM ******/
DROP INDEX IF EXISTS [IX_InvoiceDetail_Invoice_ID] ON [dbo].[InvoiceDetail]
GO
/****** Object:  Index [IX_InvoiceDetail_Customer_ID]    Script Date: 5/14/2023 7:38:37 PM ******/
DROP INDEX IF EXISTS [IX_InvoiceDetail_Customer_ID] ON [dbo].[InvoiceDetail]
GO
/****** Object:  Index [UQ_Invoices]    Script Date: 5/14/2023 7:38:37 PM ******/
DROP INDEX IF EXISTS [UQ_Invoices] ON [dbo].[Invoice]
GO
/****** Object:  Index [IX_Invoice_Customer_ID]    Script Date: 5/14/2023 7:38:37 PM ******/
DROP INDEX IF EXISTS [IX_Invoice_Customer_ID] ON [dbo].[Invoice]
GO
/****** Object:  Index [UQ_CustomerTypes]    Script Date: 5/14/2023 7:38:37 PM ******/
DROP INDEX IF EXISTS [UQ_CustomerTypes] ON [dbo].[CustomerType]
GO
/****** Object:  Index [UQ_CustomerStatus]    Script Date: 5/14/2023 7:38:37 PM ******/
DROP INDEX IF EXISTS [UQ_CustomerStatus] ON [dbo].[CustomerStatus]
GO
/****** Object:  Index [UQ_Customers]    Script Date: 5/14/2023 7:38:37 PM ******/
DROP INDEX IF EXISTS [UQ_Customers] ON [dbo].[Customer]
GO
/****** Object:  Index [IX_Customer_CustomerType_ID]    Script Date: 5/14/2023 7:38:37 PM ******/
DROP INDEX IF EXISTS [IX_Customer_CustomerType_ID] ON [dbo].[Customer]
GO
/****** Object:  Index [IX_Customer_CustomerStatus_ID]    Script Date: 5/14/2023 7:38:37 PM ******/
DROP INDEX IF EXISTS [IX_Customer_CustomerStatus_ID] ON [dbo].[Customer]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 5/14/2023 7:38:37 PM ******/
DROP TABLE IF EXISTS [dbo].[Product]
GO
/****** Object:  Table [dbo].[InvoiceDetail]    Script Date: 5/14/2023 7:38:37 PM ******/
DROP TABLE IF EXISTS [dbo].[InvoiceDetail]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 5/14/2023 7:38:37 PM ******/
DROP TABLE IF EXISTS [dbo].[Invoice]
GO
/****** Object:  Table [dbo].[CustomerType]    Script Date: 5/14/2023 7:38:37 PM ******/
DROP TABLE IF EXISTS [dbo].[CustomerType]
GO
/****** Object:  Table [dbo].[CustomerStatus]    Script Date: 5/14/2023 7:38:37 PM ******/
DROP TABLE IF EXISTS [dbo].[CustomerStatus]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 5/14/2023 7:38:37 PM ******/
DROP TABLE IF EXISTS [dbo].[Customer]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/14/2023 7:38:37 PM ******/
DROP TABLE IF EXISTS [dbo].[__EFMigrationsHistory]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/14/2023 7:38:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 5/14/2023 7:38:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Customer_ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](250) NOT NULL,
	[Address] [nvarchar](500) NOT NULL,
	[CustomerStatus_ID] [int] NOT NULL,
	[CustomerType_ID] [int] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Customer_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerStatus]    Script Date: 5/14/2023 7:38:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerStatus](
	[CustomerStatus_ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerStatusDisplay] [nvarchar](100) NOT NULL,
	[Order] [int] NOT NULL,
 CONSTRAINT [PK_CustomerStatus] PRIMARY KEY CLUSTERED 
(
	[CustomerStatus_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerType]    Script Date: 5/14/2023 7:38:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerType](
	[CustomerType_ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerTypeDisplay] [nvarchar](100) NOT NULL,
	[Order] [int] NOT NULL,
 CONSTRAINT [PK_CustomerType] PRIMARY KEY CLUSTERED 
(
	[CustomerType_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 5/14/2023 7:38:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[Invoice_ID] [int] IDENTITY(1,1) NOT NULL,
	[TotalItbis] [decimal](18, 2) NOT NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[Customer_ID] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[Invoice_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceDetail]    Script Date: 5/14/2023 7:38:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetail](
	[InvoiceDetail_ID] [int] IDENTITY(1,1) NOT NULL,
	[Qty] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[TotalItbis] [decimal](18, 2) NOT NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[Customer_ID] [int] NOT NULL,
	[Product_ID] [int] NOT NULL,
	[Invoice_ID] [int] NOT NULL,
 CONSTRAINT [PK_InvoiceDetail] PRIMARY KEY CLUSTERED 
(
	[InvoiceDetail_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 5/14/2023 7:38:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Product_ID] [int] IDENTITY(1,1) NOT NULL,
	[CodeProduct] [nvarchar](100) NOT NULL,
	[ProductName] [nvarchar](300) NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[UnitsInStock] [smallint] NOT NULL,
	[SalePrice] [decimal](18, 2) NOT NULL,
	[Discontinued] [bit] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Product_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230512142358_InitialMigration', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230513000858_AddTable_Products', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230513002822_InsertData_To_Products', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230513175203_InsertData_to_Customer', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230513225337_AddColumn_CreatedDete_to_Invoice', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230514155138_UpdateRelationships_InvoiceDetail', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230514190421_UpdateConstraints_to_InvoiceDetail', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230514193007_UpdateIndexConstraints_to_InvoiceDetail', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230514193129_UpdateIndexConstraints_to_Invoice', N'6.0.16')
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Customer_ID], [CustomerName], [Address], [CustomerStatus_ID], [CustomerType_ID]) VALUES (1, N'José Miguel Calcaño', N'Dirección del cliente 3', 1, 4)
INSERT [dbo].[Customer] ([Customer_ID], [CustomerName], [Address], [CustomerStatus_ID], [CustomerType_ID]) VALUES (2, N'María Peguero', N'Dirección del cliente 5', 2, 2)
INSERT [dbo].[Customer] ([Customer_ID], [CustomerName], [Address], [CustomerStatus_ID], [CustomerType_ID]) VALUES (3, N'Juan Acosta', N'Dirección del cliente 6', 1, 3)
INSERT [dbo].[Customer] ([Customer_ID], [CustomerName], [Address], [CustomerStatus_ID], [CustomerType_ID]) VALUES (4, N'Ramón Domínguez', N'Dirección del cliente 1', 2, 5)
INSERT [dbo].[Customer] ([Customer_ID], [CustomerName], [Address], [CustomerStatus_ID], [CustomerType_ID]) VALUES (5, N'Pedro Almonte', N'Dirección del cliente 5', 1, 1)
INSERT [dbo].[Customer] ([Customer_ID], [CustomerName], [Address], [CustomerStatus_ID], [CustomerType_ID]) VALUES (6, N'Hermy Garcia', N'Km 11½ Carretera Sánchez, Santo Domingo', 1, 4)
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[CustomerStatus] ON 

INSERT [dbo].[CustomerStatus] ([CustomerStatus_ID], [CustomerStatusDisplay], [Order]) VALUES (1, N'Activo', 1)
INSERT [dbo].[CustomerStatus] ([CustomerStatus_ID], [CustomerStatusDisplay], [Order]) VALUES (2, N'Inactivo', 2)
SET IDENTITY_INSERT [dbo].[CustomerStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[CustomerType] ON 

INSERT [dbo].[CustomerType] ([CustomerType_ID], [CustomerTypeDisplay], [Order]) VALUES (1, N'Loyal', 1)
INSERT [dbo].[CustomerType] ([CustomerType_ID], [CustomerTypeDisplay], [Order]) VALUES (2, N'Impulse', 2)
INSERT [dbo].[CustomerType] ([CustomerType_ID], [CustomerTypeDisplay], [Order]) VALUES (3, N'Discount', 3)
INSERT [dbo].[CustomerType] ([CustomerType_ID], [CustomerTypeDisplay], [Order]) VALUES (4, N'Need-based', 4)
INSERT [dbo].[CustomerType] ([CustomerType_ID], [CustomerTypeDisplay], [Order]) VALUES (5, N'Wandering', 5)
SET IDENTITY_INSERT [dbo].[CustomerType] OFF
GO
SET IDENTITY_INSERT [dbo].[Invoice] ON 

INSERT [dbo].[Invoice] ([Invoice_ID], [TotalItbis], [SubTotal], [Total], [Customer_ID], [CreatedDate]) VALUES (47, CAST(13073.04 AS Decimal(18, 2)), CAST(85701.05 AS Decimal(18, 2)), CAST(85701.05 AS Decimal(18, 2)), 5, CAST(N'2023-05-14T16:23:11.8466667' AS DateTime2))
INSERT [dbo].[Invoice] ([Invoice_ID], [TotalItbis], [SubTotal], [Total], [Customer_ID], [CreatedDate]) VALUES (48, CAST(1131.35 AS Decimal(18, 2)), CAST(7416.60 AS Decimal(18, 2)), CAST(7416.60 AS Decimal(18, 2)), 6, CAST(N'2023-05-14T16:23:25.6400000' AS DateTime2))
INSERT [dbo].[Invoice] ([Invoice_ID], [TotalItbis], [SubTotal], [Total], [Customer_ID], [CreatedDate]) VALUES (49, CAST(16444.35 AS Decimal(18, 2)), CAST(65265.73 AS Decimal(18, 2)), CAST(123114.87 AS Decimal(18, 2)), 3, CAST(N'2023-05-14T17:46:53.8166667' AS DateTime2))
INSERT [dbo].[Invoice] ([Invoice_ID], [TotalItbis], [SubTotal], [Total], [Customer_ID], [CreatedDate]) VALUES (50, CAST(4339.85 AS Decimal(18, 2)), CAST(28450.10 AS Decimal(18, 2)), CAST(28450.10 AS Decimal(18, 2)), 1, CAST(N'2023-05-14T19:22:31.4533333' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Invoice] OFF
GO
SET IDENTITY_INSERT [dbo].[InvoiceDetail] ON 

INSERT [dbo].[InvoiceDetail] ([InvoiceDetail_ID], [Qty], [Price], [TotalItbis], [SubTotal], [Total], [Customer_ID], [Product_ID], [Invoice_ID]) VALUES (55, 1, CAST(17825.00 AS Decimal(18, 2)), CAST(3208.50 AS Decimal(18, 2)), CAST(21033.50 AS Decimal(18, 2)), CAST(21033.50 AS Decimal(18, 2)), 5, 2, 47)
INSERT [dbo].[InvoiceDetail] ([InvoiceDetail_ID], [Qty], [Price], [TotalItbis], [SubTotal], [Total], [Customer_ID], [Product_ID], [Invoice_ID]) VALUES (56, 1, CAST(24610.29 AS Decimal(18, 2)), CAST(4429.85 AS Decimal(18, 2)), CAST(29040.14 AS Decimal(18, 2)), CAST(29040.14 AS Decimal(18, 2)), 5, 5, 47)
INSERT [dbo].[InvoiceDetail] ([InvoiceDetail_ID], [Qty], [Price], [TotalItbis], [SubTotal], [Total], [Customer_ID], [Product_ID], [Invoice_ID]) VALUES (57, 1, CAST(30192.72 AS Decimal(18, 2)), CAST(5434.69 AS Decimal(18, 2)), CAST(35627.41 AS Decimal(18, 2)), CAST(35627.41 AS Decimal(18, 2)), 5, 1, 47)
INSERT [dbo].[InvoiceDetail] ([InvoiceDetail_ID], [Qty], [Price], [TotalItbis], [SubTotal], [Total], [Customer_ID], [Product_ID], [Invoice_ID]) VALUES (58, 1, CAST(6285.25 AS Decimal(18, 2)), CAST(1131.35 AS Decimal(18, 2)), CAST(7416.60 AS Decimal(18, 2)), CAST(7416.60 AS Decimal(18, 2)), 6, 4, 48)
INSERT [dbo].[InvoiceDetail] ([InvoiceDetail_ID], [Qty], [Price], [TotalItbis], [SubTotal], [Total], [Customer_ID], [Product_ID], [Invoice_ID]) VALUES (59, 2, CAST(42536.13 AS Decimal(18, 2)), CAST(15313.01 AS Decimal(18, 2)), CAST(57849.14 AS Decimal(18, 2)), CAST(115698.27 AS Decimal(18, 2)), 3, 3, 49)
INSERT [dbo].[InvoiceDetail] ([InvoiceDetail_ID], [Qty], [Price], [TotalItbis], [SubTotal], [Total], [Customer_ID], [Product_ID], [Invoice_ID]) VALUES (60, 1, CAST(6285.25 AS Decimal(18, 2)), CAST(1131.35 AS Decimal(18, 2)), CAST(7416.60 AS Decimal(18, 2)), CAST(7416.60 AS Decimal(18, 2)), 3, 4, 49)
INSERT [dbo].[InvoiceDetail] ([InvoiceDetail_ID], [Qty], [Price], [TotalItbis], [SubTotal], [Total], [Customer_ID], [Product_ID], [Invoice_ID]) VALUES (61, 1, CAST(17825.00 AS Decimal(18, 2)), CAST(3208.50 AS Decimal(18, 2)), CAST(21033.50 AS Decimal(18, 2)), CAST(21033.50 AS Decimal(18, 2)), 1, 2, 50)
INSERT [dbo].[InvoiceDetail] ([InvoiceDetail_ID], [Qty], [Price], [TotalItbis], [SubTotal], [Total], [Customer_ID], [Product_ID], [Invoice_ID]) VALUES (62, 1, CAST(6285.25 AS Decimal(18, 2)), CAST(1131.35 AS Decimal(18, 2)), CAST(7416.60 AS Decimal(18, 2)), CAST(7416.60 AS Decimal(18, 2)), 1, 4, 50)
SET IDENTITY_INSERT [dbo].[InvoiceDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Product_ID], [CodeProduct], [ProductName], [UnitPrice], [UnitsInStock], [SalePrice], [Discontinued]) VALUES (1, N'EQ-1', N'Nevera LG 10pies', CAST(26254.54 AS Decimal(18, 2)), 398, CAST(30192.72 AS Decimal(18, 2)), 0)
INSERT [dbo].[Product] ([Product_ID], [CodeProduct], [ProductName], [UnitPrice], [UnitsInStock], [SalePrice], [Discontinued]) VALUES (2, N'EQ-2', N'Lavadora Nedoka', CAST(15500.00 AS Decimal(18, 2)), 581, CAST(17825.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Product] ([Product_ID], [CodeProduct], [ProductName], [UnitPrice], [UnitsInStock], [SalePrice], [Discontinued]) VALUES (3, N'EQ-3', N'Televisor 55 Pulgadas', CAST(36987.94 AS Decimal(18, 2)), 318, CAST(42536.13 AS Decimal(18, 2)), 0)
INSERT [dbo].[Product] ([Product_ID], [CodeProduct], [ProductName], [UnitPrice], [UnitsInStock], [SalePrice], [Discontinued]) VALUES (4, N'EQ-4', N'Abanico KDK pared', CAST(5465.43 AS Decimal(18, 2)), 347, CAST(6285.25 AS Decimal(18, 2)), 0)
INSERT [dbo].[Product] ([Product_ID], [CodeProduct], [ProductName], [UnitPrice], [UnitsInStock], [SalePrice], [Discontinued]) VALUES (5, N'EQ-5', N'Estufa 6 quemadores', CAST(21400.25 AS Decimal(18, 2)), 120, CAST(24610.29 AS Decimal(18, 2)), 0)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
/****** Object:  Index [IX_Customer_CustomerStatus_ID]    Script Date: 5/14/2023 7:38:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_Customer_CustomerStatus_ID] ON [dbo].[Customer]
(
	[CustomerStatus_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Customer_CustomerType_ID]    Script Date: 5/14/2023 7:38:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_Customer_CustomerType_ID] ON [dbo].[Customer]
(
	[CustomerType_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Customers]    Script Date: 5/14/2023 7:38:37 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ_Customers] ON [dbo].[Customer]
(
	[CustomerName] ASC,
	[CustomerStatus_ID] ASC,
	[CustomerType_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_CustomerStatus]    Script Date: 5/14/2023 7:38:37 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ_CustomerStatus] ON [dbo].[CustomerStatus]
(
	[CustomerStatusDisplay] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_CustomerTypes]    Script Date: 5/14/2023 7:38:37 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ_CustomerTypes] ON [dbo].[CustomerType]
(
	[CustomerTypeDisplay] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Invoice_Customer_ID]    Script Date: 5/14/2023 7:38:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_Invoice_Customer_ID] ON [dbo].[Invoice]
(
	[Customer_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_Invoices]    Script Date: 5/14/2023 7:38:37 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ_Invoices] ON [dbo].[Invoice]
(
	[Invoice_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_InvoiceDetail_Customer_ID]    Script Date: 5/14/2023 7:38:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_InvoiceDetail_Customer_ID] ON [dbo].[InvoiceDetail]
(
	[Customer_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_InvoiceDetail_Invoice_ID]    Script Date: 5/14/2023 7:38:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_InvoiceDetail_Invoice_ID] ON [dbo].[InvoiceDetail]
(
	[Invoice_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_InvoiceDetail_Product_ID]    Script Date: 5/14/2023 7:38:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_InvoiceDetail_Product_ID] ON [dbo].[InvoiceDetail]
(
	[Product_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_InvoiceDetails]    Script Date: 5/14/2023 7:38:37 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ_InvoiceDetails] ON [dbo].[InvoiceDetail]
(
	[InvoiceDetail_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Products]    Script Date: 5/14/2023 7:38:37 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ_Products] ON [dbo].[Product]
(
	[Product_ID] ASC,
	[ProductName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Invoice] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[InvoiceDetail] ADD  DEFAULT ((0)) FOR [Product_ID]
GO
ALTER TABLE [dbo].[InvoiceDetail] ADD  DEFAULT ((0)) FOR [Invoice_ID]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_CustomerStatus_CustomerStatus_ID] FOREIGN KEY([CustomerStatus_ID])
REFERENCES [dbo].[CustomerStatus] ([CustomerStatus_ID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_CustomerStatus_CustomerStatus_ID]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_CustomerType_CustomerType_ID] FOREIGN KEY([CustomerType_ID])
REFERENCES [dbo].[CustomerType] ([CustomerType_ID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_CustomerType_CustomerType_ID]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Customer_Customer_ID] FOREIGN KEY([Customer_ID])
REFERENCES [dbo].[Customer] ([Customer_ID])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Customer_Customer_ID]
GO
ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetail_Customer_Customer_ID] FOREIGN KEY([Customer_ID])
REFERENCES [dbo].[Customer] ([Customer_ID])
GO
ALTER TABLE [dbo].[InvoiceDetail] CHECK CONSTRAINT [FK_InvoiceDetail_Customer_Customer_ID]
GO
ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetail_Invoice_Invoice_ID] FOREIGN KEY([Invoice_ID])
REFERENCES [dbo].[Invoice] ([Invoice_ID])
GO
ALTER TABLE [dbo].[InvoiceDetail] CHECK CONSTRAINT [FK_InvoiceDetail_Invoice_Invoice_ID]
GO
ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetail_Product_Product_ID] FOREIGN KEY([Product_ID])
REFERENCES [dbo].[Product] ([Product_ID])
GO
ALTER TABLE [dbo].[InvoiceDetail] CHECK CONSTRAINT [FK_InvoiceDetail_Product_Product_ID]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [CHK_Address] CHECK  (([Address]<>''))
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [CHK_Address]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [CHK_CustomerName] CHECK  (([CustomerName]<>''))
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [CHK_CustomerName]
GO
ALTER TABLE [dbo].[CustomerStatus]  WITH CHECK ADD  CONSTRAINT [CHK_CustomerStatusDisplay] CHECK  (([CustomerStatusDisplay]<>''))
GO
ALTER TABLE [dbo].[CustomerStatus] CHECK CONSTRAINT [CHK_CustomerStatusDisplay]
GO
ALTER TABLE [dbo].[CustomerType]  WITH CHECK ADD  CONSTRAINT [CHK_CustomerTypeDisplay] CHECK  (([CustomerTypeDisplay]<>''))
GO
ALTER TABLE [dbo].[CustomerType] CHECK CONSTRAINT [CHK_CustomerTypeDisplay]
GO
ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD  CONSTRAINT [CHK_Price] CHECK  (([Price]<>(0)))
GO
ALTER TABLE [dbo].[InvoiceDetail] CHECK CONSTRAINT [CHK_Price]
GO
ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD  CONSTRAINT [CHK_Qty] CHECK  (([Qty]<>(0)))
GO
ALTER TABLE [dbo].[InvoiceDetail] CHECK CONSTRAINT [CHK_Qty]
GO
