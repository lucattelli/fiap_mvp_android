﻿CREATE TABLE [dbo].[TB_CONSULTA_LISTA_COMPRA_ITEM]
(
	 [ID_LISTA_COMPRA] INT NOT NULL
	,[ID_MERCADO] INT NOT NULL
	,[DT_CRIACAO] DATETIME NOT NULL
	,[ID_PRODUTO] INT NOT NULL
	,[IN_DISPONIVEL] BIT NOT NULL
	,[QT_ITEM] FLOAT (53) NULL
	,[VL_PRODUTO] FLOAT (53) NULL
	,CONSTRAINT [PK_CONSULTA_LISTA_COMPRA_ITEM] 
		PRIMARY KEY CLUSTERED
		(
			 [ID_LISTA_COMPRA]
			,[ID_MERCADO]
			,[DT_CRIACAO]
			,[ID_PRODUTO]
		)
	,CONSTRAINT [FK_CONSULTA_LISTA_COMPRA_ITEM_CONSULTA_LISTA_COMPRA] 
		FOREIGN KEY 
		(
			 [ID_LISTA_COMPRA]
			,[ID_MERCADO]
			,[DT_CRIACAO]
		)
		REFERENCES [dbo].[TB_CONSULTA_LISTA_COMPRA]
		(
			 [ID_LISTA_COMPRA]
			,[ID_MERCADO]
			,[DT_CRIACAO]
		)
	,CONSTRAINT [FK_CONSULTA_LISTA_COMPRA_ITEM_LISTA_COMPRA_ITEM]
		FOREIGN KEY
		(
			 [ID_LISTA_COMPRA]
			,[ID_PRODUTO]
		)
		REFERENCES [dbo].[TB_LISTA_COMPRA_ITEM]
		(
			  [ID_LISTA_COMPRA]
			 ,[ID_PRODUTO]
		)
)
