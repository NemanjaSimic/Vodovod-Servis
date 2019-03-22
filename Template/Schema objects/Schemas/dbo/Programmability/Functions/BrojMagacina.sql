CREATE FUNCTION [dbo].[BrojMagacina]
(
	@id char(13)
)
RETURNS INT
AS
BEGIN
	DECLARE @count INT
	DECLARE @idEkipe varchar(13)
	DECLARE @deo TINYINT
	DECLARE @sum INT
	set @sum = 0
	select @idEkipe = EKIPA_ID_EK from RADNIIK where JMBG_ZAP = @id
	IF @idEkipe is not null
		BEGIN
			SELECT @sum = COUNT(*) FROM NALAZI_U WHERE EKIPA_ID_EK = @idEkipe
		 END
	RETURN @sum
END
