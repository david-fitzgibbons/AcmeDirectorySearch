CREATE VIEW [dbo].[UserView]
	AS select 
		usr.Id   as "UserId", 
		usr.FirstName   as "FirstName", 
		usr.LastName    as "LastName", 
		usr.Birthday    as "Birthday", 
		usr.Interests   as "Interests", 
		addr.Id         as "AddressId", 
		addr.Street1    as "Street1",
		addr.Street2    as "Street2",
		addr.City       as "City", 
		st.[State]      as "State", 
		addr.Zip        as "Zip"

    from [dbo].[User] usr
        inner join [dbo].[Address] addr on usr.[Address] = addr.Id
        inner join [dbo].[State] st on addr.[State] = st.Id
