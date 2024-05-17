CREATE PROCEDURE [dbo].[spUpdate_Order]
	@Id int,
	@PersonName nvarchar(50),
	@PesonAddress nvarchar(50),
	@FoodId int,
	@Quantity int,
	@Total int
AS
Begin
	
	Update dbo.FoodOrder
	Set PersonName=@PersonName, PesonAddress=@PesonAddress, FoodId=@FoodId, Quantity=@Quantity, Total=@Total
	Where Id = @Id;

End
