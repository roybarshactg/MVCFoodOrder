CREATE PROCEDURE [dbo].[spInsert_Order]
	@Id int output,
	@PersonName nvarchar(50),
	@PesonAddress nvarchar(50),
	@FoodId int,
	@Quantity int,
	@Total int
AS
Begin

	Insert Into dbo.FoodOrder(PersonName, PesonAddress, FoodId, Quantity, Total)
	Values (@PersonName, @PesonAddress, @FoodId, @Quantity, @Total);
	Set @Id = SCOPE_IDENTITY();

End