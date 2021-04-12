DROP PROCEDURE FBAdd
GO

CREATE PROCEDURE [dbo].[FBAdd]
		@Number int,
		@Wynik VARCHAR (50),
		@Data DATETIME,
		@Id int OUTPUT
AS 
		INSERT INTO DoBazy (Number, Wynik, Data) Values (@Number, @Wynik, @Data)
		SET @Id = @@IDENTITY