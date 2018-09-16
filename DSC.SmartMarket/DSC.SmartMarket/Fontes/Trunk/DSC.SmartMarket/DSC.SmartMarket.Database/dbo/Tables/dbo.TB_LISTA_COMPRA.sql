﻿CREATE TABLE [dbo].[TB_LISTA_COMPRA]
(
	 [ID_LISTA_COMPRA] INT IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL
	,[DS_LISTA_COMPRA] NVARCHAR(255) NOT NULL
	,[ID_CLIENTE] INT NOT NULL
	,[QT_ITEM] INT NOT NULL
	,[DT_CRIACAO] DATETIME NOT NULL
	,[DT_ALTERACAO] DATETIME NOT NULL
	,[DT_ULT_CONSULTA] DATETIME NULL
	,[DT_EXCLUSAO] DATETIME NULL
	,[IN_EXCLUIDO] BIT NOT NULL
		CONSTRAINT [DF_LISTA_COMPRA_IN_EXCLUIDO]
			DEFAULT (0)
	,[ID_GEOCODE_CONSULTA] NVARCHAR(100) NOT NULL
	,[VL_DISTANCIA_MAXIMA] INT NOT NULL
	,[IN_DENTRO_MUNICIPIO] BIT NOT NULL
	,CONSTRAINT [PK_LISTA_COMPRA]
		PRIMARY KEY
		(
			[ID_LISTA_COMPRA]
		)
	,CONSTRAINT [FK_LISTA_COMPRA_CLIENTE]
		FOREIGN KEY
		(
			[ID_CLIENTE]
		)
		REFERENCES [dbo].[TB_CLIENTE]
		(
			[ID_CLIENTE]
		)
)