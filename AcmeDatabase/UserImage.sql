CREATE TABLE [dbo].[UserImage]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [UserId] INT NOT NULL, 
    [ImageType] NVARCHAR(50) NOT NULL, 
    [Base64Image] NVARCHAR(MAX) NOT NULL

	CONSTRAINT fk_userimage_user
		FOREIGN KEY ([UserId])
		REFERENCES [dbo].[User] ([Id])
)
