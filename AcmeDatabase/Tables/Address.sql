CREATE TABLE [dbo].[Address]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Street1] NVARCHAR(100) NOT NULL, 
    [Street2] NVARCHAR(100) NULL, 
    [City] NVARCHAR(50) NULL, 
    [State] INT NOT NULL, 
    [Zip] CHAR(5) NOT NULL

	CONSTRAINT fk_address_state
		FOREIGN KEY ([State])
		REFERENCES [dbo].[State] ([Id])
)
