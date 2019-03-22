CREATE PROCEDURE [dbo].[BrojRezervisanihDelova]
    @id CHAR(13),
	@sum INT out
AS
	BEGIN
	DECLARE @count INT
	DECLARE @idEkipe varchar(13)
	DECLARE @deo TINYINT

	SET @sum = 0

	select @idEkipe = EKIPA_ID_EK from RADNIIK where JMBG_ZAP = @id
	IF @idEkipe is not null
		BEGIN
			DECLARE Deo_CURSOR CURSOR
			FOR SELECT DEO_OPREME_ID_TIP FROM NALAZI_U WHERE EKIPA_ID_EK = @idEkipe

			OPEN Deo_CURSOR;

			FETCH NEXT FROM Deo_CURSOR
			INTO @deo;
			WHILE @@FETCH_STATUS = 0
			BEGIN
				SET @sum += 1;
				FETCH NEXT FROM Deo_CURSOR INTO @deo
			END;

			CLOSE Deo_CURSOR;
			DEALLOCATE Deo_CURSOR;
		 END
END