DROP PROCEDURE FBAdd
GO

CREATE PROCEDURE [dbo].[FBAdd]
		@Number int,
		@Wynik VARCHAR (50),
		@Data DATETIME,
		@Id int OUTPUT,
		@OwnerID VARCHAR (50)
AS 
		INSERT INTO DoBazy (Number, Wynik, Data, OwnerID) Values (@Number, @Wynik, @Data, @OwnerID)
		SET @Id = @@IDENTITY