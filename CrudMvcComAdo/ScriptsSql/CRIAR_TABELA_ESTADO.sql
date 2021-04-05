USE [CrudMvcComAdo]
GO

/****** Object:  Table [dbo].[Estado]    Script Date: 05/04/2021 07:26:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Estado](
	[EstadoId] [int] IDENTITY(1,1) NOT NULL,
	[EstadoSigla] [nchar](2) NOT NULL,
	[EstadoNome] [varchar](50) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

