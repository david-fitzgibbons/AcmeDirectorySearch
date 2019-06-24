﻿/*
Deployment script for Acme

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Acme"
:setvar DefaultFilePrefix "Acme"
:setvar DefaultDataPath ""
:setvar DefaultLogPath ""

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

insert into dbo.Property 
	SELECT 'default_image',  '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'
	WHERE NOT EXISTS (SELECT 1 from dbo.Property WHERE Property = 'default_image') 


insert into dbo.State SELECT 'AK' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'AK') 
insert into dbo.State SELECT 'AL' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'AL') 
insert into dbo.State SELECT 'AR' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'AR') 
insert into dbo.State SELECT 'AZ' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'AZ') 
insert into dbo.State SELECT 'CA' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'CA') 
insert into dbo.State SELECT 'CO' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'CO') 
insert into dbo.State SELECT 'CT' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'CT') 
insert into dbo.State SELECT 'DE' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'DE') 
insert into dbo.State SELECT 'FL' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'FL') 
insert into dbo.State SELECT 'GA' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'GA') 
insert into dbo.State SELECT 'HI' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'HI') 
insert into dbo.State SELECT 'IA' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'IA') 
insert into dbo.State SELECT 'ID' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'ID') 
insert into dbo.State SELECT 'IL' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'IL') 
insert into dbo.State SELECT 'IN' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'IN') 
insert into dbo.State SELECT 'KS' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'KS') 
insert into dbo.State SELECT 'KY' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'KY') 
insert into dbo.State SELECT 'LA' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'LA') 
insert into dbo.State SELECT 'MA' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'MA') 
insert into dbo.State SELECT 'MD' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'MD') 
insert into dbo.State SELECT 'ME' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'ME') 
insert into dbo.State SELECT 'MI' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'MI') 
insert into dbo.State SELECT 'MN' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'MN')  
insert into dbo.State SELECT 'MO' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'MO') 
insert into dbo.State SELECT 'MS' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'MS') 
insert into dbo.State SELECT 'MT' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'MT') 
insert into dbo.State SELECT 'NC' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'NC') 
insert into dbo.State SELECT 'ND' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'ND') 
insert into dbo.State SELECT 'NE' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'NE') 
insert into dbo.State SELECT 'NH' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'NH') 
insert into dbo.State SELECT 'NJ' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'NJ') 
insert into dbo.State SELECT 'NM' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'NM') 
insert into dbo.State SELECT 'NV' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'NV') 
insert into dbo.State SELECT 'NY' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'NY') 
insert into dbo.State SELECT 'OH' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'OH') 
insert into dbo.State SELECT 'OK' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'OK') 
insert into dbo.State SELECT 'OR' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'OR') 
insert into dbo.State SELECT 'PA' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'PA') 
insert into dbo.State SELECT 'RI' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'RI') 
insert into dbo.State SELECT 'SC' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'SC') 
insert into dbo.State SELECT 'SD' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'SD') 
insert into dbo.State SELECT 'TN' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'TN') 
insert into dbo.State SELECT 'TX' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'TX') 
insert into dbo.State SELECT 'UT' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'UT') 
insert into dbo.State SELECT 'VA' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'VA') 
insert into dbo.State SELECT 'VT' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'VT') 
insert into dbo.State SELECT 'WA' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'WA') 
insert into dbo.State SELECT 'WI' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'WI') 
insert into dbo.State SELECT 'WV' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'WV') 
insert into dbo.State SELECT 'WY' WHERE NOT EXISTS (SELECT [State] FROM [State] WHERE [State] = 'WY') 


DELETE FROM UserImage;
DELETE FROM [User];
DELETE FROM [Address];
GO

EXEC CreateUser  @FirstName='Josephine', @LastName='Darakjy', @Birthday='02/05/1969', @Interests='Sports', @Street1='4 B Blue Ridge Blvd',  @Street2 =NULL, @City='Brighton', @State='MI', @Zip='48116' 
GO
EXEC CreateUser  @FirstName='Art', @LastName='Venere', @Birthday='09/25/1970', @Interests='Music', @Street1='8 W Cerritos Ave #54',  @Street2 =NULL, @City='Bridgeport', @State='NJ', @Zip='8014' 
GO
EXEC CreateUser  @FirstName='Lenna', @LastName='Paprocki', @Birthday='12/29/1977', @Interests=NULL, @Street1='639 Main St',  @Street2 ='Apt 3', @City='Anchorage', @State='AK', @Zip='99501' 
GO
EXEC CreateUser  @FirstName='Donette', @LastName='Foller', @Birthday='04/11/1980', @Interests='Travelling, Fishing, Hunting', @Street1='34 Center St',  @Street2 =NULL, @City='Hamilton', @State='OH', @Zip='45011' 
GO
EXEC CreateUser  @FirstName='Simona', @LastName='Morasca', @Birthday='04/05/1981', @Interests='Painting', @Street1='3 Mcauley Dr',  @Street2 =NULL, @City='Ashland', @State='OH', @Zip='44805' 
GO
EXEC CreateUser  @FirstName='Mitsue', @LastName='Tollner', @Birthday='07/12/1981', @Interests=NULL, @Street1='7 Eads St',  @Street2 ='Apt 33k', @City='Chicago', @State='IL', @Zip='60632' 
GO
EXEC CreateUser  @FirstName='Leota', @LastName='Dilliard', @Birthday='09/04/1981', @Interests='Dancing, Reading, Writing', @Street1='7 W Jackson Blvd',  @Street2 =NULL, @City='San Jose', @State='CA', @Zip='95111' 
GO
EXEC CreateUser  @FirstName='Sage', @LastName='Wieser', @Birthday='07/09/1983', @Interests='Golf, Hiking', @Street1='5 Boston Ave #88',  @Street2 =NULL, @City='Sioux Falls', @State='SD', @Zip='57105' 
GO
EXEC CreateUser  @FirstName='Kris', @LastName='Marrier', @Birthday='11/08/1983', @Interests=NULL, @Street1='228 Runamuck Pl #2808',  @Street2 =NULL, @City='Baltimore', @State='MD', @Zip='21224' 
GO
EXEC CreateUser  @FirstName='Minna', @LastName='Amigon', @Birthday='07/08/1987', @Interests=NULL, @Street1='2371 Jerrold Ave',  @Street2 ='Apt 1a', @City='Kulpsville', @State='PA', @Zip='19443' 
GO
EXEC CreateUser  @FirstName='Abel', @LastName='Maclead', @Birthday='02/13/1991', @Interests=NULL, @Street1='37275 St  Rt 17m M',  @Street2 =NULL, @City='Middle Island', @State='NY', @Zip='11953' 
GO
EXEC CreateUser  @FirstName='Kiley', @LastName='Caldarera', @Birthday='03/12/1992', @Interests='Field Hockey, Softball, Swimming', @Street1='25 E 75th St #69',  @Street2 =NULL, @City='Los Angeles', @State='CA', @Zip='90034' 
GO
EXEC CreateUser  @FirstName='Graciela', @LastName='Ruta', @Birthday='02/12/1995', @Interests=NULL, @Street1='98 Connecticut Ave Nw',  @Street2 =NULL, @City='Chagrin Falls', @State='OH', @Zip='44023' 
GO

GO

GO
PRINT N'Update complete.';


GO
