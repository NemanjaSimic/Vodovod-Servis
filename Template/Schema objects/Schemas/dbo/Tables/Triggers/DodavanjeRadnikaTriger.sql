CREATE TRIGGER [DodavanjeRadnikaTriger]
		ON [dbo].RADNIIK
	FOR  UPDATE
	AS
	BEGIN
	declare @oldVal varchar(10), @newVal varchar(10)
	declare @oldNum int

	select @oldVal = EKIPA_ID_EK from deleted
	select @newVal = EKIPA_ID_EK from inserted
	if @oldVal is null
	begin
		set @oldVal = ''
	end
	if @newVal is null
	begin
		set @newVal = ''
	end
	if (@oldVal not like @newVal)
	BEGIN
			if ( @newVal like '')
				BEGIN			
				select @oldNum = BR_RAD from EKIPA where ID_EK = @oldVal
				update EKIPA set BR_RAD = @oldNum - 1 where ID_EK = @oldVal
				END
			else if (@oldVal like '')
				BEGIN
				select @oldNum = BR_RAD from EKIPA where ID_EK = @newVal
				update EKIPA set BR_RAD = @oldNum + 1 where ID_EK = @newVal
				END
	END
END