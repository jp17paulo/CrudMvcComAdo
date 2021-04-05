USE [CrudMvcComAdo]
GO

/****** Object:  Table [dbo].[Times]    Script Date: 05/04/2021 07:27:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Times](
	[TimeId] [int] IDENTITY(1,1) NOT NULL,
	[Time] [nchar](100) NOT NULL,
	[EstadoId] [int] NOT NULL,
	[Cores] [nchar](50) NOT NULL
) ON [PRIMARY]

GO

