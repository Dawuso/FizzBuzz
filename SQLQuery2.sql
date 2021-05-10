DROP PROCEDURE FBAdd 
GO

CREATE PROCEDURE [dbo].[FBAdd]
		@Liczba INT,
		@Wynik VARCHAR (50),
		@Data DATETIME,
		@FBId int OUTPUT
AS
	INSERT INTO FB (Liczba, Wynik, Data) VALUES (@Liczba, @Wynik, @Data)
	SET @FBId = @@IDENTITY