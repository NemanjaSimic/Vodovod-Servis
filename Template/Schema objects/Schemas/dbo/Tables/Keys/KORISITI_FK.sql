﻿ALTER TABLE KORISTI
	ADD CONSTRAINT FK_ASS_5 
	FOREIGN KEY(EKIPA_ID_EK)
	REFERENCES EKIPA(ID_EK)