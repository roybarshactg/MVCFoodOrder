CREATE PROCEDURE [dbo].[spGetAll_Food]
AS
Begin
	
	Select [Id], [FoodName], [FoodPrice]
	From dbo.Food;

End