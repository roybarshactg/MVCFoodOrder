If not exists(select * from dbo.Food)
Begin

	Insert into dbo.Food(FoodName, FoodPrice)
	Values('Chicker Burger',450),
		  ('Pizza',850),
		  ('Waffle Fries',350),
		  ('Submarine',400)
End
