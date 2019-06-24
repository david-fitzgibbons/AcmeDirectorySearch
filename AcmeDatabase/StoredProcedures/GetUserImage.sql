CREATE PROCEDURE [dbo].[GetUserImage]
	@UserId int
AS

	If Exists (SELECT Id FROM UserImage WHERE UserId = @UserId)
		BEGIN
			SELECT 
				ui.[ImageType] as "Type",
				ui.[Base64Image] AS "Base64Image"

			FROM
				UserImage ui
		END
	ELSE
		BEGIN
			--Use Default Image Value
			SELECT
				'image/png' as "Type",
				p.Value as "Base64Image"
			FROM
				Property p
			WHERE
				p.Property = 'default_image'

		END

RETURN
GO
