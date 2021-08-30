USE [Testing]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 2021/08/30 16:29:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[FK_TypeID] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[EmailAddress] [varchar](50) NOT NULL,
	[Cellphone] [nchar](10) NOT NULL,
	[Amount] [decimal](18, 5) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Types]    Script Date: 2021/08/30 16:29:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Types](
	[TypeID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Types] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([FK_TypeID], [FirstName], [Surname], [EmailAddress], [Cellphone], [Amount], [IsActive], [DateCreated]) VALUES ( 1, N'mbali', N'dlomo', N'mbali@gmail.com', N'0312365   ', CAST(10.00000 AS Decimal(18, 5)), 0, CAST(N'2021-08-28T03:57:13.750' AS DateTime))

SET IDENTITY_INSERT [dbo].[Customers] OFF
SET IDENTITY_INSERT [dbo].[Types] ON 

INSERT [dbo].[Types] ([TypeID], [TypeName]) VALUES (1, N'Person')
INSERT [dbo].[Types] ([TypeID], [TypeName]) VALUES (2, N'Company')
SET IDENTITY_INSERT [dbo].[Types] OFF
ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF_Customers_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Types] FOREIGN KEY([FK_TypeID])
REFERENCES [dbo].[Types] ([TypeID])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_Types]
GO
/****** Object:  StoredProcedure [dbo].[DeleteCustomer]    Script Date: 2021/08/30 16:29:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteCustomer]
       @CustomerID int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
   UPDATE [Testing].[dbo].[Customers]
   SET IsActive = 0
   WHERE CustomerID = @CustomerID
END
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerByCustomerID]    Script Date: 2021/08/30 16:29:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCustomerByCustomerID]
       @CustomerID int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT [CustomerID]
      ,[FK_TypeID]
	  ,T.TypeName
      ,[FirstName]
      ,[Surname]
      ,[EmailAddress]
      ,[Cellphone]
      ,[Amount]
      ,[IsActive]
      ,[DateCreated]
  FROM [Testing].[dbo].[Customers](NOLOCK) C
  INNER JOIN  [Testing].[dbo].[Types] T ON C.FK_TypeID = T.TypeID
  WHERE [CustomerID] = @CustomerID
END
GO
/****** Object:  StoredProcedure [dbo].[GetCustomers]    Script Date: 2021/08/30 16:29:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCustomers]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT [CustomerID]
      ,[FK_TypeID]
	  ,T.TypeName
      ,[FirstName]
      ,[Surname]
      ,[EmailAddress]
      ,[Cellphone]
      ,[Amount]
      ,[IsActive]
      ,[DateCreated]
  FROM [Testing].[dbo].[Customers](NOLOCK) C
  INNER JOIN  [Testing].[dbo].[Types] T ON C.FK_TypeID = T.TypeID
  WHERE [IsActive] = 1
END
GO
/****** Object:  StoredProcedure [dbo].[GetTypes]    Script Date: 2021/08/30 16:29:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTypes]
 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [TypeID]
      ,[TypeName]
  FROM [Testing].[dbo].[Types]
END
GO
/****** Object:  StoredProcedure [dbo].[InsertCustomer]    Script Date: 2021/08/30 16:29:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertCustomer]
       @FK_TypeID int
      ,@FirstName varchar(50)
      ,@Surname varchar(50)
      ,@EmailAddress varchar(50)
      ,@Cellphone varchar(10)
      ,@Amount decimal(18,5)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
   INSERT INTO [Testing].[dbo].[Customers]([FK_TypeID],[FirstName],[Surname],[EmailAddress],[Cellphone],[Amount],[DateCreated])
   OUTPUT INSERTED.[CustomerID]
   VALUES(@FK_TypeID ,@FirstName ,@Surname ,@EmailAddress ,@Cellphone ,@Amount,GETDATE())
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCustomer]    Script Date: 2021/08/30 16:29:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateCustomer]
       @CustomerID int 
      ,@FK_TypeID int
      ,@FirstName varchar(50)
      ,@Surname varchar(50)
      ,@EmailAddress varchar(50)
      ,@Cellphone varchar(10)
      ,@Amount decimal(18,5)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
   UPDATE [Testing].[dbo].[Customers]
   SET [FK_TypeID] = @FK_TypeID,
   [FirstName] = @FirstName,
   [Surname] = @Surname,
   [EmailAddress] = @EmailAddress,
   [Cellphone] = @Cellphone,
   [Amount] = @Amount,
   [DateCreated] = GETDATE()
   WHERE CustomerID = @CustomerID
END
GO
