﻿ALTER TABLE NALAZI_U
ADD CONSTRAINT NALAZI_U_EKIPA_FK FOREIGN KEY
(
EKIPA_ID_EK
)
REFERENCES EKIPA
(
ID_EK
)