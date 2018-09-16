﻿CREATE TABLE [dbo].[TB_CONSULTA_LISTA_COMPRA]
(
	 [ID_LISTA_COMPRA] INT NOT NULL
	,[ID_MERCADO] INT NOT NULL
	,[DT_CRIACAO] DATETIME NOT NULL
	,[QT_ITEM] INT NOT NULL
	,[QT_ITEM_DISPONIVEL] INT NOT NULL
	,[VL_TOTAL] FLOAT (53) NOT NULL
	,[ID_GEOCODE_CONSULTA] NVARCHAR(100) NOT NULL
	,[VL_DISTANCIA_MAXIMA] INT NOT NULL
	,[IN_DENTRO_MUNICIPIO] BIT NOT NULL
	,CONSTRAINT [PK_CONSULTA_LISTA_COMPRA] 
		PRIMARY KEY CLUSTERED 
		(
			 [ID_LISTA_COMPRA]
			,[ID_MERCADO]
			,[DT_CRIACAO]
		)
	,CONSTRAINT [UN_CONSULTA_LISTA_COMPRA] 
		UNIQUE
		(
			 [ID_LISTA_COMPRA]
			,[DT_CRIACAO]
		)
	,CONSTRAINT [FK_CONSULTA_LISTA_COMPRA_LISTA_COMPRA]
		FOREIGN KEY
		(
			[ID_LISTA_COMPRA]
		)
		REFERENCES [dbo].[TB_LISTA_COMPRA]
		(
			[ID_LISTA_COMPRA]
		)
	,CONSTRAINT [FK_CONSULTA_LISTA_COMPRA_SUPERMERCADO]
		FOREIGN KEY
		(
			[ID_MERCADO]
		)
		REFERENCES [dbo].[TB_SUPERMERCADO]
		(
			[ID_MERCADO]
		)
)
