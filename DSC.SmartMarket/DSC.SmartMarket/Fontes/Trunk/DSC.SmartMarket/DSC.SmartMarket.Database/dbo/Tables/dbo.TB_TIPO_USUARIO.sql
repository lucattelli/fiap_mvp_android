﻿CREATE TABLE [dbo].[TB_TIPO_USUARIO]
(
	[ID_TIPO_USUARIO] INT NOT NULL,
	[DS_TIPO_USUARIO] NVARCHAR(100) NOT NULL,
	CONSTRAINT [PK_TIPO_USUARIO] PRIMARY KEY CLUSTERED ([ID_TIPO_USUARIO]),
	CONSTRAINT [UN_TIPO_USUARIO] UNIQUE ([DS_TIPO_USUARIO])
)
