﻿ALTER TABLE PRIMA
ADD CONSTRAINT PRIMA_PRIJAVLJUJE_FK FOREIGN KEY
(
PRIJAVLJUJE_KORISNIK_JMBG_KOR,
PRIJAVLJUJE_KVAR_ID_KVAR
)
REFERENCES PRIJAVLJUJE
(
KORISNIK_JMBG_KOR ,
KVAR_ID_KVAR
)