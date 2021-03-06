﻿CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Birthday] DATE NOT NULL, 
    [Interests] NVARCHAR(250) NULL, 
    [AddressId] INT NOT NULL

	CONSTRAINT fk_user_address
		FOREIGN KEY ([AddressId])
		REFERENCES [dbo].[Address] ([Id])
)
