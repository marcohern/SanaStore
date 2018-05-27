CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [CustomerId] INT NOT NULL, 
    [Total] DECIMAL(18, 2) NOT NULL, 
    [RecordedDate] DATETIME NOT NULL, 
    [Status] NVARCHAR(32) NOT NULL, 
    CONSTRAINT [FK_Orders_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [Customers]([Id])
)
