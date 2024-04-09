CREATE TABLE Customers(
    CustomerID int NOT NULL UNIQUE,
    CustomerName varchar(255),
    TotalSales float,
    TotalReturns float
);