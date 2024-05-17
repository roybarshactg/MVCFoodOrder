CREATE TABLE [dbo].[FoodOrder]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PersonName] NVARCHAR(50) NOT NULL, 
    [PesonAddress] NVARCHAR(50) NOT NULL, 
    [FoodId] INT NOT NULL, 
    [Quantity] INT NOT NULL, 
    [Total] MONEY NOT NULL
)
