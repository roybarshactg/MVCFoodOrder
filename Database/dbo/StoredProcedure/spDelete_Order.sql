CREATE PROCEDURE [dbo].[spDelete_Order]
	@Id int
AS
Begin

	Delete From dbo.FoodOrder
	Where Id = @Id;

End
