CREATE PROCEDURE [dbo].[spInventory_GetAll]
	
AS
begin
    set nocount on;

	select [ID], [ProductId], [Quantity], [PurchasePrice], [PurchaseDate] from dbo.Inventory
end
