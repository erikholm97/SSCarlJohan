CREATE PROCEDURE [dbo].[spSale_SaleReport]
	@param1 int = 0,
	@param2 int
AS
begin
select [s].[CashierId], [s].[SaleDate], [s].[SubTotal], [s].[Tax], [s].[Total], u.FirstName, u.LastName, u.EmailAddress from dbo.Sale as s
inner join [User] as u on u.Id = s.CashierId
end 
