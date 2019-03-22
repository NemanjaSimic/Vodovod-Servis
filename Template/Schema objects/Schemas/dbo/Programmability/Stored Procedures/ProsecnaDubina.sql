CREATE PROCEDURE [dbo].[ProsecnaDubina]
 @id char(13), @avg decimal out
 as 
 begin
	declare @idEkipe varchar(10)
	declare @sum decimal
	declare @deo tinyint
	declare @counter decimal
	declare @temp tinyint

	set @sum = 0
	set @avg = 0


			select @idEkipe = EKIPA_ID_EK from RADNIIK where JMBG_ZAP = @id
			set @counter = 0
			set @avg = 0
			if @idEkipe is not null
			Begin
			DECLARE Deo_CURSOR CURSOR
				FOR SELECT DEO_OPREME_ID_TIP FROM NALAZI_U WHERE EKIPA_ID_EK = @idEkipe

				OPEN Deo_CURSOR;

				FETCH NEXT FROM Deo_CURSOR
				INTO @deo
				WHILE @@FETCH_STATUS = 0
				BEGIN
					if @deo is not null
					begin
					set @counter += 1
					SELECT @temp = DUBINA from DEO_OPREME where ID_TIP = @deo
					set @sum += CAST (@temp as decimal)
					FETCH NEXT FROM Deo_CURSOR INTO @deo
					end
				END
				set @avg = @sum / @counter
				CLOSE Deo_CURSOR;
				DEALLOCATE Deo_CURSOR
				end
end