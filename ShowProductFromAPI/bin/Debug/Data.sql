CREATE DATABASE APIIntegrationWPF
GO
USE APIIntegrationWPF
GO
CREATE TABLE Products
(
	Id INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(MAX) NOT NULL,
	Price DECIMAL(18,2) NOT NULL
)
GO	
INSERT INTO Products(Name,Price) VALUES (N'Kem dưỡng chống lão hóa DERMEDEN (Night Protocole Intense Night Cream)',150000)
GO
INSERT INTO Products(Name,Price) VALUES (N'Tinh chất tế bào gốc Oyoung Ampoule',150000)
GO
INSERT INTO Products(Name,Price) VALUES (N'Tế bào gốc Oyoung Ampoule',150000)
GO
INSERT INTO Products(Name,Price) VALUES (N' serum dưỡng mặt ban đêm Living Nature Advanced Renewal Night',150000)
GO