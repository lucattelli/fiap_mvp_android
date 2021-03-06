﻿CREATE TABLE [dbo].[TB_CLIENTE] (
     [ID_CLIENTE]  INT            IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL
    ,[NM_CLIENTE]  NVARCHAR (100) NOT NULL
    ,[NR_CPF]      NCHAR (11)     NOT NULL
    ,[NR_RG]       NVARCHAR (12)  NOT NULL
    ,[DS_EMAIL]    NVARCHAR (255) NULL
    ,[NR_TELEFONE] NVARCHAR (15)  NOT NULL
    ,CONSTRAINT [PK_CLIENTE]
		PRIMARY KEY CLUSTERED
		(
			[ID_CLIENTE] ASC
		)
);

