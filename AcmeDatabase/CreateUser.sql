CREATE PROCEDURE [dbo].[CreateUser]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Birthday date,
	@Interests nvarchar(250) = '',
	@Street1 nvarchar(100),
	@Street2 nvarchar(100) = '',
	@City nvarchar(50),
	@State char(2),
	@Zip char(5),
	@ImageType varchar(50) = null,
	@ImageData nvarchar(MAX) = null
AS
	
	SET NOCOUNT ON;

	DECLARE @AddressId int;
	DECLARE @UserId int;
	
	INSERT INTO [dbo].[Address](Street1, Street2, City, State, Zip)
		SELECT @Street1, @Street2, @City, st.Id, @Zip
		FROM [dbo].[State] st 
		WHERE [state] = UPPER(@State)

	--Capture id reference to created Address
	SET @AddressId = SCOPE_IDENTITY();

	INSERT INTO [dbo].[User](FirstName, LastName, Birthday, Interests, Address)
	VALUES (@FirstName, @LastName, @Birthday, @Interests, @AddressId)

	--Capture id reference to created User
	SET @UserId = SCOPE_IDENTITY();


	IF @ImageType IS NOT NULL
		INSERT INTO [dbo].[UserImage] (UserId, ImageType, Base64Image)
		values (@UserId, @ImageType, @ImageData)


	select @UserId

RETURN
GO
