CREATE PROCEDURE [dbo].[spSale_SaleReport]
AS
begin
select [s].[CashierId], [s].[SaleDate], [s].[SubTotal], [s].[Tax], [s].[Total], u.FirstName, u.LastName, u.EmailAddress from dbo.Sale as s
inner join [User] as u on u.Id = s.CashierId
end 
