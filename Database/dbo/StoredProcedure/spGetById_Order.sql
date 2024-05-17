CREATE PROCEDURE [dbo].[spGetById_Order]
	@Id int
AS
Begin
	
	Select [Id], [PersonName], [PesonAddress], [FoodId], [Quantity], [Total]
	From dbo.FoodOrder
	Where Id = @Id;

End
