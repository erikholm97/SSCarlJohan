CREATE TABLE [dbo].[Inventory]
(
    [ID] INT NOT NULL PRIMARY KEY IDENTITY,
    [ProductId] INT NOT NULL,
    [PurchasePrice] MONEY NOT NULL, 
    [Quantity] INT NOT NULL DEFAULT 1,    
    [PurchaseDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
)
