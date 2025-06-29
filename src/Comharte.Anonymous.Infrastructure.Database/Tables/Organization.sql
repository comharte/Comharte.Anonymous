CREATE TABLE [dbo].[Organization]
(
	 [Id] INT NOT NULL IDENTITY(1,1)
	,[GlobalId] UNIQUEIDENTIFIER NOT NULL
	,[DisplayName] NVARCHAR(60) NOT NULL
	,[IsDeleted] BIT NOT NULL
	,[CreationUserRef] UNIQUEIDENTIFIER NOT NULL
	,[CreationDate] DATETIME2(7) NOT NULL
)
GO

ALTER TABLE [dbo].[Organization] 
	ADD CONSTRAINT [PK_Organization] 
	PRIMARY KEY CLUSTERED ([Id] ASC);

GO

ALTER TABLE [dbo].[Organization] 
	ADD CONSTRAINT [UQ_Organization_GlobalId] 
	UNIQUE ([GlobalId]);
GO