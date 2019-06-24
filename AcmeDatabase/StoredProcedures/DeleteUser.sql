CREATE PROCEDURE [dbo].[DeleteUser]
	@UserId int
AS
	
	If Exists (SELECT Id FROM UserImage WHERE UserId = @UserId)
	BEGIN
		Delete from UserImage where UserId = @UserId
	END

	If Exists (SELECT Id FROM UserImage WHERE UserId = @UserId)
	BEGIN
		Delete from UserImage where UserId = @UserId
	END


	If Exists (SELECT Id FROM [User] WHERE Id = @UserId)
	BEGIN
		DECLARE @AddressId int; 
		SET @AddressId = (Select AddressId from [User] where Id = @UserId)

		Delete from [User] where Id = @UserId
		Delete from [Address] where Id = @AddressId
	END


RETURN 0
