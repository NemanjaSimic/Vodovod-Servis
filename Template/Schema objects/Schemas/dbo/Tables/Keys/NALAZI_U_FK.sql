﻿ALTER TABLE NALAZI_U
	ADD CONSTRAINT NALAZI_U_DEO_OPREME_FK 
	FOREIGN KEY(DEO_OPREME_ID_TIP)
	REFERENCES DEO_OPREME(ID_TIP)