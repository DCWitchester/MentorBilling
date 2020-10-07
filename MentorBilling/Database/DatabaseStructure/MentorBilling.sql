--Database Create Syntax
CREATE DATABASE "MentorBilling" WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'English_United States.1252' LC_CTYPE = 'English_United States.1252';

--Initial Database Presets
SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--#region Users Schema
CREATE SCHEMA users AUTHORIZATION postgres;

--#region Users Table

CREATE TABLE users.utilizatori (
  id bigserial PRIMARY KEY NOT NULL,
  nume_utilizator varchar NOT NULL DEFAULT ('') UNIQUE,
  email varchar NOT NULL DEFAULT ('') UNIQUE,
  parola varchar NOT NULL DEFAULT (''),
  parola_autogenerata varchar NOT NULL DEFAULT (''),
  nume varchar NOT NULL DEFAULT (''),
  prenume varchar NOT NULL DEFAULT (''),
  sysadmin boolean NOT NULL DEFAULT false,
  activ boolean NOT NULL DEFAULT true
);

ALTER TABLE users.utilizatori OWNER TO postgres;

COMMENT ON TABLE users.utilizatori IS 'Tabela centrala pentru structura de utilizatori';
COMMENT ON COLUMN users.utilizatori.parola_autogenerata IS 'Parola autogenerata va fi folosita doar cand se uita parola si se doreste modificarea ei';

INSERT INTO users.utilizatori(id,nume_utilizator,parola,sysadmin) VALUES(0,'M3nt0r','10careeste2',true);

--#endregion Users Table

--#region Grupuri Table

CREATE TABLE users.grupuri (
  id bigserial PRIMARY KEY NOT NULL,
  denumire varchar NOT NULL DEFAULT (''),
  administrator_grup bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id) ON DELETE CASCADE,
  activ boolean NOT NULL DEFAULT true
);

ALTER TABLE users.grupuri OWNER TO postgres;

COMMENT ON TABLE users.grupuri IS 'Tabela centrala pentru structura de grupuri, folosita pentru a grupa n-utilizatori';
COMMENT ON COLUMN users.grupuri.administrator_grup IS 'Administratorul grupului va fi cel de care legam facturile, clienti, firmele si alte inregistrari';

--ALTER TABLE "grupuri" ADD FOREIGN KEY ("administrator_grup") REFERENCES "utilizatori" ("id");

--#endregion Grupuri Table

--#region Grupuri Utilizatori Table

CREATE TABLE users.grupuri_utilizatori (
  id bigserial PRIMARY KEY NOT NULL,
  grup_id bigint NOT NULL DEFAULT 0 REFERENCES users.grupuri(id),
  utilizator_id bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id) ON DELETE CASCADE,
  activ boolean NOT NULL DEFAULT true
);

ALTER TABLE users.grupuri_utilizatori OWNER TO postgres;

COMMENT ON TABLE users.grupuri_utilizatori IS 'Tabela de legatura intre grupuri si utilizatori';

--ALTER TABLE "grupuri_utilizatori" ADD FOREIGN KEY ("grup_id") REFERENCES "grupuri" ("id");
--ALTER TABLE "grupuri_utilizatori" ADD FOREIGN KEY ("utilizator_id") REFERENCES "utilizatori" ("id");

--#endregion Grupuri Utilizatori Table

--#region Drepturi

CREATE TABLE users.drepturi (
  id bigserial PRIMARY KEY NOT NULL,
  drept varchar NOT NULL DEFAULT (''),
  tip_drept integer NOT NULL DEFAULT 0,
  activ boolean NOT NULL DEFAULT true
);

ALTER TABLE users.drepturi OWNER TO postgres;

COMMENT ON TABLE users.drepturi IS 'Tabela de drepturi pentru program care va contine toate drepturile posibile din program';
COMMENT ON COLUMN users.drepturi.tip_drept IS 'Coloana va fi legata de un enum din program care da tipul de valoarea al coloanei';
COMMENT ON COLUMN users.drepturi.drept IS 'Coloana asta va contine denumirea dreptului folosita pentru afisare';

--#endregion Drepturi

--#region Drepturi Utilizatori

CREATE TABLE users.drepturi_utilizatori (
  id bigserial PRIMARY KEY NOT NULL,
  utilizator_id bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id) ON DELETE CASCADE, 
  drept_id bigint NOT NULL DEFAULT 0 REFERENCES users.drepturi(id),
  valoare_drept varchar NOT NULL DEFAULT (''),
  activ boolean NOT NULL DEFAULT true
);

ALTER TABLE users.drepturi_utilizatori OWNER TO postgres;

COMMENT ON TABLE users.drepturi_utilizatori IS 'Tabela de legatura intre tabela de drepturi si cea de utilizatori';
COMMENT ON COLUMN users.drepturi_utilizatori.valoare_drept IS 'Coloana asta va contine valoare efectiva a dreptului relativ la coloana de tip_drept din tabela de drepturi';


--ALTER TABLE "drepturi_utilizatori" ADD FOREIGN KEY ("utilizator_id") REFERENCES "utilizatori" ("id");
--ALTER TABLE "drepturi_utilizatori" ADD FOREIGN KEY ("drept_id") REFERENCES "drepturi" ("id");

--#endregion Drepturi Utilizatori

--#region Clase Drepturi Predefinite

CREATE TABLE users.clase_drepturi_predefinite (
  id bigserial PRIMARY KEY NOT NULL,
  denumire varchar NOT NULL DEFAULT (''),
  activ boolean NOT NULL DEFAULT true
);

ALTER TABLE users.clase_drepturi_predefinite OWNER TO postgres;

COMMENT ON TABLE users.clase_drepturi_predefinite IS 'Tabela aceasta va contine niste clase predefinite de drepturi pentru accesul in program';

--#endregion Clase Drepturi Predefinite

--#region Clase Drepturi

CREATE TABLE users.clase_drepturi (
  id bigserial PRIMARY KEY NOT NULL,
  drept_id bigint NOT NULL DEFAULT 0 REFERENCES users.drepturi(id),
  clasa_id bigint NOT NULL DEFAULT 0 references users.clase_drepturi_predefinite(id),
  valoare_drept varchar NOT NULL DEFAULT (''),
  activ boolean NOT NULL DEFAULT true
);

ALTER TABLE users.clase_drepturi OWNER TO postgres;

COMMENT ON TABLE users.clase_drepturi IS 'Tabela de legatura intre tabela users.clase_drepturi_predefinite si tabela drepturi';
COMMENT ON COLUMN users.clase_drepturi.valoare_drept IS 'Coloana asta va contine valoare efectiva a dreptului relativ la coloana de tip_drept din tabela de drepturi';

--ALTER TABLE "clase_drepturi" ADD FOREIGN KEY ("drept_id") REFERENCES "drepturi" ("id");
--ALTER TABLE "clase_drepturi" ADD FOREIGN KEY ("clasa_id") REFERENCES "clase_drepturi_predefinite" ("id");

--#endregion Clase Drepturi

--#region Abonamente

CREATE TABLE users.abonamente (
  id bigserial PRIMARY KEY NOT NULL,
  denumire varchar NOT NULL DEFAULT (''),
  valoare_lunara double precision NOT NULL DEFAULT 0,
  explicatii varchar NOT NULL DEFAULT (''),
  perioada_plata integer NOT NULL DEFAULT 30,
  dimensiune_maxima_grup integer NOT NULL DEFAULT 1,
  activ boolean NOT NULL DEFAULT true
);

ALTER TABLE users.abonamente OWNER TO postgres;

COMMENT ON TABLE users.abonamente IS 'Tabela aceasta va contine valori standard predefinite ale viitoarelor abonamente';
COMMENT ON COLUMN users.abonamente.perioada_plata IS 'Coloana aceasta va contine perioada de activitate a abonamentului in zile';
COMMENT ON COLUMN users.abonamente.dimensiune_maxima_grup IS 'Coloana aceasta va contine dimensiunea maxima admisa a grupului';
COMMENT ON COLUMN users.abonamente.valoare_lunara IS 'Coloana aceasta va contine valoarea lunara de baza a unui abonament. Aceasta poate suferi costuri aditionale.';

INSERT INTO users.abonamente(id,denumire,activ) VALUES(0,'Utilizator inactiv',false);
INSERT INTO users.abonamente(denumire,activ) VALUES('Utilizator de trial',false);
INSERT INTO users.abonamente(denumire,activ) VALUES('Utilizator de grup',false);

--#endregion Abonamente

--#region Abonamente Utilizatori

CREATE TABLE users.abonamente_utilizatori (
  id bigserial PRIMARY KEY NOT NULL,
  utilizator_id bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id) ON DELETE CASCADE,
  abonament_id bigint NOT NULL DEFAULT 0 REFERENCES users.abonamente(id),
  valoare_lunara double precision NOT NULL DEFAULT 0,
  ultima_plata timestamp without time zone NOT NULL DEFAULT ('now'::text)::timestamp without time zone,
  perioada_activa integer NOT NULL DEFAULT 30,
  dimensiune_maxima_grup integer NOT NULL DEFAULT 1,
  activ boolean NOT NULL DEFAULT true,
  UNIQUE(utilizator_id,abonament_id)
);

ALTER TABLE users.abonamente_utilizatori OWNER TO postgres;

COMMENT ON TABLE users.abonamente_utilizatori IS 'Tabela de legatura intre tabela de abonamente si tabela de utilizatori';
COMMENT ON COLUMN users.abonamente_utilizatori.valoare_lunara IS 'Coloana aceasta va contine valoare efectiva de plata a utilizatorului curent';
COMMENT ON COLUMN users.abonamente_utilizatori.ultima_plata IS 'Coloana aceasta va contine data efectiva a ultimei plati pe abonamentul curent';
COMMENT ON COLUMN users.abonamente_utilizatori.dimensiune_maxima_grup IS 'Coloana aceasta va contine dimensiunea maxima admisa a grupului';
COMMENT ON COLUMN users.abonamente_utilizatori.perioada_activa IS 'Coloana aceasta va contine perioada e activitate pentru abonamentul curent de la ultima plata in numar de zile';

--ALTER TABLE "abonamente_utilizatori" ADD FOREIGN KEY ("utilizator_id") REFERENCES "utilizatori" ("id");
--ALTER TABLE "abonamente_utilizatori" ADD FOREIGN KEY ("abonament_id") REFERENCES "abonamente" ("id");

--#endregion Users Schema

--#region Seller Schema

CREATE SCHEMA seller AUTHORIZATION postgres;

---#region Furnizori

CREATE TABLE seller.furnizori (
  id bigserial PRIMARY KEY NOT NULL,
  denumire varchar NOT NULL DEFAULT (''),
  nr_registru_comert varchar NOT NULL DEFAULT ('') UNIQUE,
  cod_fiscal varchar NOT NULL DEFAULT ('') UNIQUE,
  capital_social double precision NOT NULL DEFAULT 0,
  sediul varchar NOT NULL DEFAULT (''),
  punct_lucru varchar NOT NULL DEFAULT (''),
  telefon varchar NOT NULL DEFAULT (''),
  email varchar NOT NULL DEFAULT (''),
  sigla bytea NOT NULL DEFAULT (''),
  utilizator_id bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id) ON DELETE CASCADE,
  activ boolean NOT NULL DEFAULT true
);

ALTER TABLE seller.furnizori OWNER TO postgres;

COMMENT ON TABLE seller.furnizori IS 'Tabela aceasta va contine toate societatile pentru care un utilizator poate emite facturi';
COMMENT ON COLUMN seller.furnizori.sigla IS 'Coloana aceasta va contine sigla societatii ca array de biti';

--ALTER TABLE "furnizori" ADD FOREIGN KEY ("utilizator_id") REFERENCES "utilizatori" ("id");

--#endregion Furnizori

--#region Conturi Bancare Furnizori

CREATE TABLE seller.conturi_bancare_furnizori (
  id bigserial PRIMARY KEY NOT NULL,
  furnizor_id bigint NOT NULL DEFAULT 0 REFERENCES seller.furnizori(id),
  cont varchar NOT NULL DEFAULT ('') UNIQUE,
  banca varchar NOT NULL DEFAULT (''),
  activ boolean NOT NULL DEFAULT true
);

ALTER TABLE seller.conturi_bancare_furnizori OWNER TO postgres;

COMMENT ON TABLE seller.conturi_bancare_furnizori IS 'Tabela aceasta va contine toate conturile bancare aferente unei anume societati';

--ALTER TABLE "conturi_bancare_furnizori" ADD FOREIGN KEY ("furnizor_id") REFERENCES "furnizori" ("id");

--#endregion Conturi Bancare Furnizori

--#region Delegati

CREATE TABLE seller.delegati (
  id bigserial PRIMARY KEY NOT NULL,
  denumire varchar NOT NULL DEFAULT (''),
  serie_buletin varchar NOT NULL DEFAULT (''),
  numar_buletin varchar NOT NULL DEFAULT (''),
  eliberator_buletin varchar NOT NULL DEFAULT (''),
  mijloc_transport varchar NOT NULL DEFAULT (''),
  numar_mijloc_transpot varchar NOT NULL DEFAULT (''),
  utilizator_id bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id) ON DELETE CASCADE,
  activ boolean NOT NULL DEFAULT true
);

ALTER TABLE seller.delegati OWNER TO postgres;

COMMENT ON TABLE seller.delegati IS 'Tabela curenta contine toti delegatii unui utilizator';

--#endregion delegati

--#region Utilizatori Last Used

CREATE TABLE seller.utilizatori_last_used (
  id bigserial PRIMARY KEY NOT NULL,
  utilizator_id bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id) ON DELETE CASCADE,
  furnizori_last_used bigint NOT NULL DEFAULT 0 REFERENCES seller.furnizori(id),
  conturi_bancare_last_used bigint NOT NULL DEFAULT 0 REFERENCES seller.conturi_bancare_furnizori(id),
  delegati_last_used bigint NOT NULL DEFAULT 0 REFERENCES seller.delegati(id),
  activ boolean NOT NULL DEFAULT true
);

ALTER TABLE seller.utilizatori_last_used OWNER TO postgres;

COMMENT ON TABLE seller.utilizatori_last_used IS 'Tabela curenta va contine toate setarile legate de ultima factura pentru autocomplete';

--ALTER TABLE "utilizatori_last_used" ADD FOREIGN KEY ("utilizator_id") REFERENCES "utilizatori" ("id");
--ALTER TABLE "utilizatori_last_used" ADD FOREIGN KEY ("furnizori_last_used") REFERENCES "furnizori" ("id");
--ALTER TABLE "utilizatori_last_used" ADD FOREIGN KEY ("conturi_bancare_last_used") REFERENCES "conturi_bancare_furnizori" ("id");
--ALTER TABLE "utilizatori_last_used" ADD FOREIGN KEY ("delegati_last_used") REFERENCES "delegati" ("id");

--#endregion Utilizatori Last Used

--#endregion Furnizori Schema

--#region Glossary Schema

CREATE SCHEMA glossary AUTHORIZATION postgres;

--#region Tari

CREATE TABLE glossary.tari (
  id bigserial PRIMARY KEY NOT NULL,
  cod_tara_iso2 VARCHAR(2) NOT NULL DEFAULT (''),
  cod_tara_iso3 VARCHAR(3) NOT NULL DEFAULT (''),
  cod_tara_iso_m49 VARCHAR(3) NOT NULL DEFAULT (''),
  den_tara_ro VARCHAR NOT NULL DEFAULT (''),
  den_tara_en VARCHAR NOT NULL DEFAULT (''),
  activ boolean NOT NULL DEFAULT true
);

--Owner Alter
ALTER TABLE glossary.tari OWNER TO postgres;

--Comments
COMMENT ON TABLE glossary.tari IS 'Tabela aceasta cuprinde nomenclatorul de tari din program. Nici un client nu o poate altera';

-- Inserts
INSERT INTO glossary.tari (id, cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES (0, 'NO', 'NON', '000', 'NONE', 'NONE');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('AF', 'AFG', '004', 'Afganistan', 'Afghanistan');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('ZA', 'ZAF', '710', 'Africa de Sud', 'South Africa');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('AL', 'ALB', '008', 'Albania', 'Albania');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('DZ', 'DZA', '012', 'Algeria', 'Algeria');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('AD', 'AND', '020', 'Andora', 'Andorra');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('AO', 'AGO', '024', 'Angola', 'Angola');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('AI', 'AIA', '660', 'Anguilla', 'Anguilla');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('AQ', 'ATA', '010', 'Antarctica', 'Antarctic');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('AG', 'ATG', '028', 'Antigua si Barbuda', 'Antigua and Barbuda');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('AN', 'ANT', '530', 'Antilele Olandeze', 'Netherlands Antilles');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('SA', 'SAU', '682', 'Arabia Saudita', 'Saudi Arabia');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('AR', 'ARG', '032', 'Argentina', 'Argentine');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('AM', 'ARM', '051', 'Armenia', 'Armenia');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('AW', 'ABW', '533', 'Aruba', 'Aruba');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('AU', 'AUS', '036', 'Australia', 'Australia');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('AT', 'AUT', '040', 'Austria', 'Austria');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('AZ', 'AZE', '031', 'Azerbaidjan', 'Azerbaijan');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('BS', 'BHS', '044', 'Bahamas', 'Bahamas');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('BH', 'BHR', '048', 'Bahrain', 'Bahrain');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('BD', 'BGD', '050', 'Bangladesh', 'Bangladesh');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('BB', 'BRB', '052', 'Barbados', 'Barbados');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('BY', 'BLR', '112', 'Belarus', 'Belarus');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('BE', 'BEL', '056', 'Belgia', 'Belgium');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('BZ', 'BLZ', '084', 'Belize', 'Belize');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('BJ', 'BEN', '204', 'Benin', 'Benin');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('BM', 'BMU', '060', 'Bermude', 'Bermuda');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('BT', 'BTN', '064', 'Bhutan', 'Bhutan');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('BO', 'BOL', '068', 'Bolivia', 'Bolivia');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('BA', 'BIH', '070', 'Bosnia si Hertegovina', 'Bosnia and Herzegovina');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('BW', 'BWA', '072', 'Botswana', 'Botswana');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('BV', 'BVT', '074', 'Bouvet', 'Bouvet');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('BR', 'BRA', '076', 'Brazilia', 'Brazil');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('BN', 'BRN', '096', 'Brunei Darussalam', 'Brunei Darussalam');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('BG', 'BGR', '100', 'Bulgaria', 'Bulgaria');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('BF', 'BFA', '854', 'Burkina Faso', 'Burkina Faso');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('BI', 'BDI', '108', 'Burundi', 'Burundi');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('KH', 'KHM', '116 ', 'Cambogia', 'Cambodia');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('CM', 'CMR', '120', 'Camerun', 'Cameroon');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('CA', 'CAN', '124', 'Canada', 'Canada');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('CV', 'CPV', '132', 'Capul Verde', 'Cape Verde');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('KY', 'KYM', '136', 'Cayman', 'Cayman');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('CZ', 'CZE', '203', 'Cehia', 'Czech Republic');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('CF', 'CAF', '140', 'Republica Centrafricana', 'Central African Republic');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('CL', 'CHL', '152', 'Chile', 'Chile');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('CN', 'CHN', '156', 'China', 'China');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('CX', 'CXR', '162', 'Christmas', 'Christmas');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('TD', 'TCD', '148', 'Ciad', 'Chad');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('CY', 'CYP', '196', 'Cipru', 'Cyprus');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('CC', 'CCK', '166', 'Insulele Cocos', 'Cocos Islands');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('CO', 'COL', '170', 'Columbia', 'Colombia');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('KM', 'COM', '174', 'Comore', 'Comoros');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('CD', 'COD', '180', 'Congo', 'Congo');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('CK', 'COK', '184', 'Cook', 'Cook Island');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('KR', 'KOR', '410', 'Coreea de sud', ' South Korea');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('KP', 'PRK', '408', 'Coreea de nord', 'North Korea');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('CR', 'CRI', '188', 'Costa Rica', 'Costa Rica');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('CI', 'CIV', '384', 'Coasta de fildes', 'Ivory Coast');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('HR', 'HRV', '191', 'Croatia', 'Croatia');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('CU', 'CUB', '192', 'Cuba', 'Cuba');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('DK', 'DNK', '208', 'Danemarca', 'Danemark');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('DJ', 'DJI', '262', 'Djibouti', 'Djibouti');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('DM', 'DMA', '212', 'Dominica', 'Dominica');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('DO', 'DOM', '214', 'Republica Dominicana', 'Dominican Republic');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('EC', 'ECU', '218', 'Ecuador', 'Ecuador');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('EG', 'EGY', '818', 'Egipt', 'Egypt');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('SV', 'SLV', '222', 'El Salvador', 'Egypt');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('CH', 'CHE', '756', 'Elvetia', 'Switzerland');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('AE', 'ARE', '784', 'Emiratele Arabe Unite', 'United Arab Emirates');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('ER', 'ERI', '232', 'Eritrea', 'Eritrea');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('EE', 'EST', '233', 'Estonia', 'Estonia');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('ET', 'ETH', '231', 'Etiopia', 'Ethiopia');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('FK', 'FLK', '238', 'Insulele Falkland', 'Falkland Islands');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('FO', 'FRO', '234', 'Insulele Feroe', 'Faroe Islands');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('FJ', 'FJI', '242', 'Fiji', 'Fiji');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('PH', 'PHL', '608', 'Filipine', 'Philippines');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('FR', 'FRA', '250', 'Franta', 'France');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('GA', 'GAB', '266', 'Gabon', 'Gabon');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('GM', 'GMB', '270', 'Gambia', 'Gambia');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('GE', 'GEO', '268', 'Georgia', 'Georgia');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('GS', 'SGS', '239', 'Georgia de Sud si Insulele Sandwich de Sud ', 'South Georgia and the South Sandwich Islands');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('DE', 'DEU', '276', 'Germania', 'Germany');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('GH', 'GHA', '288', 'Ghana', 'Ghana');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('GI', 'GIB', '292', 'Gibraltar', 'Gibraltar');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('GR', 'GRC', '300', 'Grecia', 'Greece');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('GD', 'GRD', '308', 'Grenada', 'Grenada Island');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('GL', 'GRL', '304', 'Groenlanda', 'Greenland');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('GP', 'GLP', '312', 'Guadelupa', 'Guadeloupe');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('GU', 'GUM', '316', 'Guam', 'Guam');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('GT', 'GTM', '320', 'Guatemala', 'Guatemala');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('GW', 'GNB', '624', 'Guineea-Bissau', 'Guinea-Bissau');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('GQ', 'GNQ', '226', 'Guineea Ecuatoriala', 'Equatorial Guinea');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('GY', 'GUY', '328', 'Guyana', 'Guyana');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('GF', 'GUF', '254', 'Guyana Franceza', 'French Guiana');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('HT', 'HTI', '332', 'Haiti', 'Haiti');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('HM', 'HMD', '334', 'Insulele Heard si McDonald', 'Heard Island and McDonald Island');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('HN', 'HND', '340', 'Honduras', 'Honduras');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('HK', 'HKG', '344', 'Hong Kong', 'Hong Kong');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('IN', 'IND', '356', 'India', 'India');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('ID', 'IDN', '360', 'Indonezia', 'Indonesia');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('UM', 'UMI', '581', 'Insulele mici periferice ale Statelor Unite', 'United States Minor Outlying Islands');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('VG', 'VGB', '092', 'Insulele virgine Britanice', 'British Virgin Islands');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('VI', 'VIR', '850', 'Insulele virgine Americane', ' United States Virgin Islands');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('JO', 'JOR', '400', 'Iordania', 'Jordan');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('IR', 'IRN', '364', 'Iran', 'Iran');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('IQ', 'IRQ', '368', 'Iraq', 'Iraq');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('IE', 'IRL', '372', 'Irlanda', 'Ireland');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('IS', 'ISL', '352', 'Islanda', 'Iceland');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('IL', 'ISR', '376', 'Israel', 'Israel');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('IT', 'ITA', '380', 'Italia', 'Italy');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('YU', 'YUG', '891', 'Iugoslavia', 'Yugoslavia');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('JM', 'JAM', '388', 'Jamaica', 'Jamaica');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('JP', 'JPN', '392', 'Japonia', 'Japan');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('KZ', 'KAZ', '398', 'Kazahstan', 'Kazakhstan');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('KE', 'KEN', '404', 'Kenya', 'Kenya');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('KG', 'KGZ', '417', 'Kirghizia', 'Kyrgyzstan');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('KI', 'KIR', '296', 'Kiribati', 'Kiribati');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('LA', 'LAO', '418', 'Laos', 'Laos');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('LS', 'LSO', '426', 'Lesotho', 'Lesotho');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('LV', 'LVA', '428', 'Letonia', 'Latvia');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('LB', 'LBN', '422', 'Liban', 'Lebanon');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('LR', 'LBR', '430', 'Liberia', 'Liberia');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('LY', 'LBY', '434', 'Jamahiria Araba Libiana', 'Libyan Arab Jamahiriya');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('LI', 'LIE', '438', 'Liechtenstein', 'Liechtenstein');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('LT', 'LTU', '440', 'Lituania', 'Lithuania');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('LU', 'LUX', '442', 'Luxemburg', 'Luxembourg');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('MO', 'MAC', '446', 'Macao', 'Macao');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('MK', 'MKD', '807', 'Macedonia', 'Macedonia');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('MG', 'MDG', '450', 'Madagascar', 'Madagascar');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('MW', 'MWI', '454', 'Malawi', 'Malawi');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('MY', 'MYS', '458', 'Malaysia', 'Malaysia');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('MV', 'MDV', '462', 'Maldive', 'Maldives');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('ML', 'MLI', '466', 'Mali', 'Mali');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('MT', 'MLT', '470', 'Malta', 'Malta');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('GB', 'GBR', '826', 'Marea Britanie', 'Great Britain');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('MP', 'MNP', '580', 'Insulele Mariane de Nord', 'Northern Mariana Islands');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('MA', 'MAR', '504', 'Maroc', 'Morocco');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('MH', 'MHL', '584', 'Insulele Marshall', 'Marshall Islands');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('MQ', 'MTQ', '474', 'Martinica', 'Martinique');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('MR', 'MRT', '478', 'Mauritania', 'Mauritania');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('MU', 'MUS', '480', 'Mauritius', 'Mauritius');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('YT', 'MYT', '175', 'Mayotte', 'Mayotte');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('MX', 'MEX', '484', 'Mexic', 'Mexico');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('FM', 'FSM', '583', 'Statele Federate ale Microneziei', 'Federated States of Micronesia');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('MD', 'MDA', '498', 'Moldova', 'Moldavia');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('MC', 'MCO', '492', 'Monaco', 'Monaco');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('MN', 'MNG', '496', 'Mongolia', 'Mongolia');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('MS', 'MSR', '500', 'Montserrat', 'Montserrat');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('MZ', 'MOZ', '508', 'Mozambic', 'Mozambique');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('MM', 'MMR', '104', 'Myanmar', 'Myanmar');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('NA', 'NAM', '516', 'Namibia', 'Namibia');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('NR', 'NRU', '520', 'Nauru', 'Nauru');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('NP', 'NPL', '524', 'Nepal', 'Nepal');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('NI', 'NIC', '558', 'Nicaragua', 'Nicaragua');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('NE', 'NER', '562', 'Niger', 'Niger');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('NG', 'NGA', '566', 'Nigeria', 'Nigeria');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('NU', 'NIU', '570', 'Niue', 'Niue');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('NF', 'NFK', '574', 'Insula Norfolk', 'Norfolk Island');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('NO', 'NOR', '578', 'Norvegia', 'Norway');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('NC', 'NCL', '540', 'Noua Caledonie', 'New Caledonia');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('NZ', 'NZL', '554', 'Noua Zeelanda', 'New Zealand');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('NL', 'NLD', '528', 'Olanda', 'Netherlands');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('OM', 'OMN', '512', 'Oman', 'Oman');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('PK', 'PAK', '586', 'Pakistan', 'Pakistan');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('PW', 'PLW', '585', 'Palau', 'Palau');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('PA', 'PAN', '591', 'Panama', 'Panama');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('PG', 'PNG', '598', 'Papua-Noua-Guinee', 'Papua New Guinea');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('PY', 'PRY', '600', 'Paraguay', 'Paraguay');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('PE', 'PER', '604', 'Peru', 'Peru');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('PN', 'PCN', '612', 'Pitcairn', 'Pitcairn Islands');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('PF', 'PYF', '258', 'Polinezia Franceza', 'French Polynesia');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('PL', 'POL', '616', 'Polonia', 'Poland');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('PT', 'PRT', '620', 'Portugalia', 'Portugal');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('PR', 'PRI', '630', 'Puerto Rico', 'Puerto Rico');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('QA', 'QAT', '634', 'Qatar', 'Qatar');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('RE', 'REU', '638', 'Reunion', 'Reunion');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('RO', 'ROM', '642', 'Romania', 'Romania');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('RU', 'RUS', '643', 'Rusia', 'Russia');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('RW', 'RWA', '646', 'Rwanda', 'Rwanda');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('EH', 'ESH', '732', 'Sahara Occidentala', 'Western Sahara');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('PM', 'SPM', '666', 'Saint Pierre si Miquelon', 'Saint Pierre and Miquelon');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('WS', 'WSM', '882', 'Samoa', 'Samoa');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('AS', 'ASM', '016', 'Samoa Americana', 'American Samoa');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('SM', 'SMR', '674', 'San Marino', 'San Marino');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('ST', 'STP', '678', 'Sao Tome si Principe', 'Sao Tome and Principe');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('SN', 'SEN', '686', 'Senegal', 'Senegal');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('SC', 'SYC', '690', 'Seychelles', 'Seychelles');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('SH', 'SHN', '654', 'Sfanta Elena', 'Saint Helena');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('LC', 'LCA', '662', 'Sfanta Lucia', 'Saint Lucia');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('KN', 'KNA', '659', 'Sfantul Cristofor si Nevis', 'Saint Kitts and Nevis');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('VA', 'VAT', '336', 'Stat Vatican', 'Vatican State');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('VC', 'VCT', '670', 'Sfantul Vicentiu si Grenadine', 'Saint Vincent and the Grenadines');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('SL', 'SLE', '694', 'Sierra Leone', 'Sierra Leone');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('SG', 'SGP', '702', 'Singapore', 'Singapore');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('SY', 'SYR', '760', 'Siria', 'Syria');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('SK', 'SVK', '703', 'Slovacia', 'Slovakia');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('SI', 'SVN', '705', 'Slovenia', 'Slovenia');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('SB', 'SLB', '090', 'Insulele Solomon', 'Solomon Islands');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('SO', 'SOM', '706', 'Somalia', 'Somalia');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('ES', 'ESP', '724', 'Spania', 'Spain');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('LK', 'LKA', '144', 'Sirlanka', 'Sri Lanka');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('US', 'USA', '840', 'Statele Unite ale Americii', 'United States of America');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('SD', 'SDN', '736', 'Sudan', 'Sudan');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('SE', 'SWE', '752', 'Suedia', 'Sweden');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('SR', 'SUR', '740', 'Surinam', 'Suriname');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('SJ', 'SJM', '744', 'Svalbard si Jan Mayen', 'Svalbard and Jan Mayen');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('SZ', 'SWZ', '748', 'Swaziland', 'Swaziland');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('TJ', 'TJK', '762', 'Tadjikistan', 'Tadjikistan');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('TW', 'TWN', '158', 'Taiwan', 'Taiwan');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('TZ', 'TZA', '834', 'Tanzania', 'Tanzania');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('TF', 'ATF', '260', 'Teritoriile Australe Franceze', 'French Southern Territories');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('IO', 'IOT', '086', 'Teritoriul Britanic din Oceanul Indian ', 'British Indian Ocean Territory');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('TH', 'THA', '764', 'Thailanda', 'Thailand');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('TP', 'TMP', '624', 'Timorul de Est ', 'East Timor');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('TG', 'TGO', '768', 'Tago', 'Tago');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('TK', 'TKL', '772', 'Tokelau', 'Tokelau');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('TO', 'TON', '776', 'Tonga', 'Tonga');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('TT', 'TTO', '780', 'Trinidad-Tobago', 'Trinidad and Tobago');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('TN', 'TUN', '788', 'Tunisia', 'Tunisia');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('TR', 'TUR', '792', 'Turcia', 'Turkey');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('TM', 'TKM', '795', 'Turkmenistan', 'Turkmenistan');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('TC', 'TCA', '796', 'Insulele Turks si Caicos', 'Turks and Caicos Islands');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('UA', 'UKR', '804', 'Ucraina', 'Ukraine');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('UG', 'UGA', '800', 'Uganda', 'Uganda');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('HU', 'HUN', '348', 'Ungaria', 'Hungary');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('UY', 'URY', '858', 'Uruguay', 'Uruguay');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('UZ', 'UZB', '860', 'Uzbekistan', 'Uzbekistan');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('VU', 'VUT', '548', 'Vanuatu', 'Vanuatu');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('VE', 'VEN', '862', 'Venezuela', 'Venezuela');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('VN', 'VNM', '704', 'Vietnam', 'Vietnam');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('WF', 'WLF', '876', 'Wallis si Futuna', 'Wallis and Futuna');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('YE', 'YEM', '887', 'Yemen', 'Yemen');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('ZM', 'ZMB', '894', 'Zambia', 'Zambia');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('ZW', 'ZWE', '716', 'Zimbabwe', 'Zimbabwe');
INSERT INTO glossary.tari (cod_tara_iso2, cod_tara_iso3, cod_tara_iso_m49, den_tara_ro, den_tara_en) VALUES ('TV', 'TUV', '798', 'Tuvalu', 'Tuvalu');

--#endregion Tari

--#region Judete

CREATE TABLE glossary.judete (
  id bigserial PRIMARY KEY NOT NULL,
  cod_judet VARCHAR(2) NOT NULL DEFAULT (''),
  den_judet VARCHAR NOT NULL DEFAULT (''),
  activ boolean NOT NULL DEFAULT true
);

ALTER TABLE glossary.judete OWNER TO postgres;

COMMENT ON TABLE glossary.judete IS 'Tabela aceasta cuprinde nomenclatorul de judete din program. Nici un client nu o poate altera';

--Inserts
INSERT INTO glossary.judete (id, cod_judet, den_judet) VALUES (0, 'NO', 'NONE');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('AB', 'Alba');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('AG', 'Arges');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('AR', 'Arad');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('B', 'Bucuresti');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('BC', 'Bacau');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('BH', 'Bihor');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('BN', 'Bistrita Nasaud');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('BR', 'Braila');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('BT', 'Botosani');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('BV', 'Brasov');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('BZ', 'Buzau');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('CJ', 'Cluj');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('CL', 'Calarasi');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('CS', 'Caras-Severin');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('CT', 'Constanta');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('CV', 'Covasna');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('DB', 'Dambovita');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('DJ', 'Dolj');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('GJ', 'Gorj');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('GL', 'Galati');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('GR', 'Giurgiu');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('HD', 'Hunedoara');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('HR', 'Harghita');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('IF', 'Ilfov');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('IL', 'Ialomita');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('IS', 'Iasi');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('MH', 'Mehedinti');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('MM', 'Maramures');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('MS', 'Mures');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('NT', 'Neamt');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('OT', 'Olt');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('PH', 'Prahova');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('SB', 'Sibiu');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('SJ', 'Salaj');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('SM', 'Satu-Mare');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('SV', 'Suceava');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('TL', 'Tulcea');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('TM', 'Timis');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('TR', 'Teleorman');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('VL', 'Valcea');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('VN', 'Vrancea');
INSERT INTO glossary.judete (cod_judet, den_judet) VALUES ('VS', 'Vaslui');

--#endregion Judete

CREATE TABLE glossary.cote_tva (
  id bigserial PRIMARY KEY NOT NULL,
  cota varchar NOT NULL DEFAULT (''),
  tva numeric(2) NOT NULL DEFAULT 0,
  indice_casa_marcat varchar NOT NULL DEFAULT (''),
  cod varchar NOT NULL DEFAULT (''),
  activ boolean NOT NULL DEFAULT true
);

ALTER TABLE glossary.cote_tva OWNER TO postgres;

COMMENT ON TABLE glossary.cote_tva IS 'Tabela aceasta cuprinde nomenclatorul de cote de tva din program. Nici un client nu o poate altera';
COMMENT ON COLUMN glossary.cote_tva.indice_casa_marcat IS 'Coloana aceasta va cuprinde valoarea default a indicelui casei de marcat';

INSERT INTO glossary.cote_tva(id,cota,tva,indice_casa_marcat,cod) VALUES(0,'0',0,'7','Neplatitor');
INSERT INTO glossary.cote_tva(cota,tva,indice_casa_marcat,cod) VALUES('A',19,'1','Cota A');
INSERT INTO glossary.cote_tva(cota,tva,indice_casa_marcat,cod) VALUES('B',9,'2','Cota B');
INSERT INTO glossary.cote_tva(cota,tva,indice_casa_marcat,cod) VALUES('C',5,'3','Cota 5');
INSERT INTO glossary.cote_tva(cota,tva,indice_casa_marcat,cod) VALUES('D',0,'4','Scutit');

--#region Anaf Info

CREATE TABLE glossary.anaf_info (
  id bigserial PRIMARY KEY NOT NULL,
  moment_initial timestamp without time zone NOT NULL DEFAULT ('01.01.1900'::text)::timestamp without time zone,
  moment_final timestamp without time zone,
  cod_fiscal varchar NOT NULL DEFAULT (''),
  info_file json
);

ALTER TABLE glossary.anaf_info OWNER TO postgres;

COMMENT ON TABLE glossary.anaf_info IS 'Tabela aceasta va contine pe perioade starile societatilor preluate de la anaf pe baza interogarilor clientilor';

--#endregion Anaf Info

--#region Forme Juridice

CREATE TABLE glossary.forme_juridice (
    id bigserial NOT NULL PRIMARY KEY,
    cod VARCHAR DEFAULT '' NOT NULL,
    denumire VARCHAR DEFAULT '' NOT NULL
);

COMMENT ON TABLE glossary.forme_juridice IS 'Tabela aceasta va contine toate formele juridice posibile. Momentan nu va fi folosit.';

ALTER TABLE glossary.forme_juridice OWNER TO postgres;

INSERT INTO glossary.forme_juridice (id, cod, denumire) VALUES (0, 'NAN', 'None');
INSERT INTO glossary.forme_juridice (cod, denumire) VALUES ('AFJ', 'Alte forme juridice');
INSERT INTO glossary.forme_juridice (cod, denumire) VALUES ('ASF', 'Asociatie familiala');
INSERT INTO glossary.forme_juridice (cod, denumire) VALUES ('CON', 'Concesiune');
INSERT INTO glossary.forme_juridice (cod, denumire) VALUES ('CRL', 'Soc civila profesionala cu pers juridica si raspundere limitata(SPRL)');
INSERT INTO glossary.forme_juridice (cod, denumire) VALUES ('INC', 'Inchiriere');
INSERT INTO glossary.forme_juridice (cod, denumire) VALUES ('LOC', 'Locatie de gestiune');
INSERT INTO glossary.forme_juridice (cod, denumire) VALUES ('OC1', 'Organizatie cooperatista mestesugareasca');
INSERT INTO glossary.forme_juridice (cod, denumire) VALUES ('OC2', 'Organizatie cooperatista de consum');
INSERT INTO glossary.forme_juridice (cod, denumire) VALUES ('OC3', 'Organizatie cooperatista de credit');
INSERT INTO glossary.forme_juridice (cod, denumire) VALUES ('PFA', 'Persoana fizica independenta');
INSERT INTO glossary.forme_juridice (cod, denumire) VALUES ('RA', 'Regie autonoma');
INSERT INTO glossary.forme_juridice (cod, denumire) VALUES ('SA', 'Societate comerciala pe actiuni');
INSERT INTO glossary.forme_juridice (cod, denumire) VALUES ('SCS', 'Societate comerciala in comandita simpla');
INSERT INTO glossary.forme_juridice (cod, denumire) VALUES ('SNC', 'Societate comerciala in nume colectiv');
INSERT INTO glossary.forme_juridice (cod, denumire) VALUES ('SPI', 'Societate profesionala practicieni in insolventa');
INSERT INTO glossary.forme_juridice (cod, denumire) VALUES ('SRL', 'Societate comerciala cu raspundere limitata');
INSERT INTO glossary.forme_juridice (cod, denumire) VALUES ('URL', 'Intreprindere profesionala unipersonala cu raspundere limitata(IPURL)');

--#endregion Forme Juridice

--#region Institutii Bancare

CREATE TABLE glossary.institutii_bancare (
    id bigserial NOT NULL PRIMARY KEY,
    denumire VARCHAR DEFAULT '' NOT NULL,
    cod_swift VARCHAR(8) DEFAULT '' NOT NULL,
    cod_iban VARCHAR(4) DEFAULT '' NOT NULL
);

COMMENT ON TABLE glossary.institutii_bancare IS 'Tabela aceasta va contine toate institutiile bancare folosite pe teritoriul Romaniei';
COMMENT ON COLUMN glossary.institutii_bancare.cod_swift IS 'Codul swift sau cod BIC reprezinta codul unic de identificare al unei banci la nivel international';
COMMENT ON COLUMN glossary.institutii_bancare.cod_iban IS 'In general primele 4 caractere ale codului BIC folosite pentru identificarea codului IBAN';

INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('BANCA NATIONALA A ROMANIEI','NBORROBU','NBOR');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('ABN AMRO BANK ROMANIA','ABNAROBU','ABNA');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('ALPHA BANK ROMANIA SA','BUCUROBU','BUCU');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('ANGLO ROMANIAN BANK LTD','ARBLROBU','ARBL');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('ATE BANK ROMANIA SA','MINDROBU','MIND');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('BANC POST SA','BPOSROBU','BPOS');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('BANCA COMERCIALA CARPATICA SA','CARPRO22','CARP');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('BANCA COMERCIALA ROMANA SA','RNCBROBU','RNCB');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('BANCA CR FIRENZE ROMANIA SA','DAROROBU','DARO');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('BANCA DI ROMA SPA ITALIA - SUCURSALA BUCURESTI','BROMROBU','BROM');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('BANCA ITALO ROMENA SPA','BITRROBU','BITR');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('BANCA ROMANA PENTRU DEZVOLTARE','BRDEROBU','BRDE');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('BANCA ROMANEASCA SA','BRMAROBU','BRMA');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('BANCA TRANSILVANIA SA','BTRLRO22','BTRL');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('BANK LEUMI ROMANIA SA','DAFBRO22','DAFB');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('BLOM BANK EGYPT SAE EGYPT - SUCURSALA ROMANIA','MIRBROBU','MIRB');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('CASA DE ECONOMII SI CONSEMNATIUNI CEC SA','CECEROBU','CECE');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('CITIBANK ROMANIA SA','CITIROBU','CITI');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('CREDIT COOP CASA CENTRALA','CRCOROBU','CRCO');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('CREDIT EUROPE BANK (ROMANIA) SA','FNNBROBU','FNNB');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('EGNATIA BANK (ROMANIA) SA','EGNAROBX','EGNA');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('EMPORIKI BANK-ROMANIA SA','BSEAROBU','BSEA');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('EXIMBANK ROMANIA','EXIMROBU','EXIM');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('GARANTIBANK INTERNATIONAL NV - SUCURSALA ROMANIA','UGBIROBU','UGBI');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('HVB BANCA PENTRU LOCUINTE','HVBLROBU','HVBL');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('ING BANK NV','INGBROBU','INGB');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('LIBRA BANK SA','BRELROBU','BREL');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('MKB ROMEXTERRA BANK SA','CRDZROBU','CRDZ');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('OTP BANK ROMANIA SA','BNRBROBU','BNRB');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('PIRAEUS BANK ROMANIA SA','PIRBROBU','PIRB');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('PORSCHE BANK ROMANIA SA','PORLROBU','PORL');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('PROCREDIT BANK','MIROROBU','MIRO');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('RAIFFEISEN BANCA PT LOCUINTE SA','RZBLROBU','RZBL');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('RAIFFEISEN BANK SA','RZBRROBU','RZBR');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('ROMANIAN INTERNATIONAL BANK SA','ROINROBU','ROIN');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('SANPAOLO IMI BANK ROMANIA SA','WBANRO22','WBAN');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('TRANSFOND SA','TRFDROBU','TRFD');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('TREZORERIA STATULUI','TREZROBU','TREZ');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('UNICREDIT TIRIAC BANK SA','BACXROBU','BACX');
INSERT INTO glossary.institutii_bancare(denumire,cod_swift,cod_iban) VALUES('VOLKSBANK ROMANIA SA','VBBUROBU','VBBU');

--#endregion Institutii Bancare

--#endregion Glossary Schema

--#region Settings Schema

CREATE SCHEMA settings AUTHORIZATION postgres;

--#region Plaje Documente

CREATE TABLE settings.plaje_documente (
  id bigserial PRIMARY KEY NOT NULL,
  valoare_initiala integer NOT NULL DEFAULT 0,
  valoare_finala integer NOT NULL DEFAULT 0,
  valoare_curenta integer NOT NULL DEFAULT 0,
  serie varchar NOT NULL DEFAULT (''),
  tip_document integer NOT NULL DEFAULT 0,
  creator_plaja bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id) ON DELETE CASCADE,
  activ boolean NOT NULL DEFAULT true
);

ALTER TABLE settings.plaje_documente OWNER TO postgres;

COMMENT ON TABLE settings.plaje_documente IS 'Tabela aceasta va contine plajele de documente(facturi,chitante) create de un utilizator';
COMMENT ON COLUMN settings.plaje_documente.creator_plaja IS 'Coloana aceasta va contine creatorul plajei. Va fi folosit in cazul in care utilizatorul nu va apartine niciunui grup.';
COMMENT ON COLUMN settings.plaje_documente.valoare_curenta IS 'Coloana aceasta va contine valoarea curenta a plajei. Se incrementeaza la fiecare document';

--#endregion Plaje Documente

--#region Utilizatori Plaje

CREATE TABLE settings.utilizatori_plaje (
  id bigserial PRIMARY KEY NOT NULL,
  plaje_document_id bigint NOT NULL DEFAULT 0 REFERENCES settings.plaje_documente(id),
  utilizator_id bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id) ON DELETE CASCADE,
  activ boolean NOT NULL DEFAULT true
);

ALTER TABLE settings.utilizatori_plaje OWNER TO postgres;

COMMENT ON TABLE settings.utilizatori_plaje IS 'Tabela aceasta este tabela de legatura intre tabelele de utilizatori si cea de plaje';

--ALTER TABLE "utilizatori_plaje" ADD FOREIGN KEY ("plaje_document_id") REFERENCES "plaje_documente" ("id");
--ALTER TABLE "utilizatori_plaje" ADD FOREIGN KEY ("utilizator_id") REFERENCES "utilizatori" ("id");

--#endregion Utilizatori Plaje

--#region Setari

CREATE TABLE settings.setari (
  id bigserial PRIMARY KEY NOT NULL,
  setare varchar NOT NULL DEFAULT (''),
  tip_date_setare integer NOT NULL DEFAULT 0,
  tip_input_setare integer NOT NULL DEFAULT 0,
  valoare_initiala varchar NOT NULL DEFAULT (''),
  placeholder varchar NOT NULL DEFAULT (''),
  tooltip varchar NOT NULL DEFAULT (''),
  activ boolean NOT NULL DEFAULT true
);

ALTER TABLE settings.setari OWNER TO postgres;

COMMENT ON TABLE settings.setari IS 'Tabela aceasta va contine toate setarile programului la nivel de setare';
COMMENT ON COLUMN settings.setari.setare IS 'Setare va fi textul afisat utilizatorului final';
COMMENT ON COLUMN settings.setari.tip_date_setare IS 'Coloana aceasta va contine tipul de date al setarii legata de un enum din program (Pentru informatii suplimentare verificati SettingDataTypes enum in proiect)';
COMMENT ON COLUMN settings.setari.tip_input_setare IS 'Coloana aceasta va contine tipul obiectului de input pentru aceasta setare legat de un enum din program (Pentru informatii suplimentare verificati SettingInputTypes enum in proiect)';
COMMENT ON COLUMN settings.setari.valoare_initiala IS 'Valoarea initiala a setari se va salva ca string: base value for all types';
COMMENT ON COLUMN settings.setari.placeholder IS 'Folosit pentru afisarea in pagina de setari pentru anumite tipuri de date';
COMMENT ON COLUMN settings.setari.tooltip IS 'Folosit pentru afisarea in pagina de setari a tooltipuri aditionale';

INSERT INTO settings.setari(setare,tip_date_setare,tip_input_setare,valoare_initiala) 
    VALUES('Se doreste gestionarea societatilor(Furnizori)?',4,3,'false');
INSERT INTO settings.setari(setare,tip_date_setare,tip_input_setare,valoare_initiala) 
    VALUES('Tipul de iso pentru tara?',1,7,'false');
INSERT INTO settings.setari(setare,tip_date_setare,tip_input_setare,valoare_initiala) 
    VALUES('Tipul de nume pentru tara?',1,7,'false');
--#endregion Setari

--#region Setari Utilizatori

CREATE TABLE settings.setari_utilizatori (
  id bigserial PRIMARY KEY NOT NULL,
  utilizator_id bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id) ON DELETE CASCADE,
  setare_id bigint NOT NULL DEFAULT 0 REFERENCES settings.setari(id),
  valoare_setare varchar NOT NULL DEFAULT (''),
  activ boolean NOT NULL DEFAULT true
);

ALTER TABLE settings.setari_utilizatori OWNER TO postgres;

COMMENT ON TABLE settings.setari_utilizatori IS 'Tabela aceasta va contine toate setarile aferente utilizatorilor la nivel de valoare';
COMMENT ON COLUMN settings.setari_utilizatori.valoare_setare IS 'Coloana aceasta va contine valoarea efectiva a setari pentru utilizatorul selectat';

--ALTER TABLE "setari_utilizatori" ADD FOREIGN KEY ("utilizator_id") REFERENCES "utilizatori" ("id");
--ALTER TABLE "setari_utilizatori" ADD FOREIGN KEY ("serae_id") REFERENCES "setari" ("id");

--#endregion Setari Utilizatori

--#region Cote TVA Utilizatori

CREATE TABLE settings.cote_tva_utilizatori (
  id bigserial PRIMARY KEY NOT NULL,
  indice_casa_marcat varchar NOT NULL DEFAULT 0,
  utilizator_id bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id) ON DELETE CASCADE,
  cota_tva_id bigint NOT NULL DEFAULT 0 REFERENCES glossary.cote_tva(id),
  activ boolean NOT NULL DEFAULT true
);

ALTER TABLE settings.cote_tva_utilizatori OWNER TO postgres;

COMMENT ON TABLE settings.cote_tva_utilizatori IS 'Tabela aceasta va contine legatura intre glosarul de cote de tva si setarile specifice ale utilizatorului';
COMMENT ON COLUMN settings.cote_tva_utilizatori.indice_casa_marcat IS 'Coloana necesara pentru imprimarea bonului fiscal pe casa de marcat';

--ALTER TABLE "cote_tva_utilizatori" ADD FOREIGN KEY ("utilizator_id") REFERENCES "utilizatori" ("id");
--ALTER TABLE "cote_tva_utilizatori" ADD FOREIGN KEY ("cota_tva_id") REFERENCES "cote_tva" ("id");

--#endregion Cote TVA Utilizatori

--#region Meniu Utilizator

CREATE TABLE settings.meniu_utilizator(
    id bigserial PRIMARY KEY NOT NULL,
    utilizator_id bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id) ON DELETE CASCADE,
    inregistrare_meniu int NOT NULL DEFAULT 0,
    activ boolean NOT NULL DEFAULT true
);

ALTER TABLE settings.meniu_utilizator OWNER TO postgres;

COMMENT ON TABLE settings.meniu_utilizator IS 'Tabela aceasta va contine inregistrarea specifica a utilizatorului';
COMMENT ON COLUMN settings.meniu_utilizator.inregistrare_meniu IS 'Vom mentine legatura intre enumul din program si cel din baza';

--#endregion Meniu Utilizator

--#endregion Settings Schema

--#region Buyer Schema

CREATE SCHEMA buyer AUTHORIZATION postgres;

--#region Cumparatori

CREATE TABLE buyer.cumparatori (
  id bigserial PRIMARY KEY NOT NULL,
  cod_partener varchar NOT NULL DEFAULT (''),
  denumire varchar NOT NULL DEFAULT (''),
  nr_registru_comert varchar NOT NULL DEFAULT (''),
  cod_fiscal varchar NOT NULL DEFAULT (''),
  sediul varchar NOT NULL DEFAULT (''),
  tara bigint NOT NULL DEFAULT 0 REFERENCES glossary.tari(id),
  judetul bigint NOT NULL DEFAULT 0 REFERENCES glossary.judete(id),
  utilizator_id bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id) ON DELETE CASCADE,
  activ boolean NOT NULL DEFAULT true
);

ALTER TABLE buyer.cumparatori OWNER TO postgres;

COMMENT ON TABLE buyer.cumparatori IS 'Tabela aceasta va cuprinde lista completa de cumparatori pentru un anume client';

--ALTER TABLE "cumparatori" ADD FOREIGN KEY ("tara") REFERENCES "tari" ("id");
--ALTER TABLE "cumparatori" ADD FOREIGN KEY ("judetul") REFERENCES "judete" ("id");
--ALTER TABLE "cumparatori" ADD FOREIGN KEY ("utilizator_id") REFERENCES "utilizatori" ("id");

--#endregion Cumparatori

--#region Conturi Bancare Cumparatori

CREATE TABLE buyer.conturi_bancare_cumparatori (
  id bigserial PRIMARY KEY NOT NULL,
  cumparatori_id bigint NOT NULL DEFAULT 0 REFERENCES buyer.cumparatori(id),
  cont varchar NOT NULL DEFAULT (''),
  banca varchar NOT NULL DEFAULT (''),
  activ boolean NOT NULL DEFAULT true
);

ALTER TABLE buyer.conturi_bancare_cumparatori OWNER TO postgres;

COMMENT ON TABLE buyer.conturi_bancare_cumparatori IS 'Tabela aceasta va cuprinde toate conturile bancare ale unui cumparator';

--ALTER TABLE "conturi_bancare_cumparatori" ADD FOREIGN KEY ("cumparatori_id") REFERENCES "cumparatori" ("id");

--#endregion Conturi Bancare Cumparatori

--#endregion Buyer Schema

--#region Invoice Schema

CREATE SCHEMA invoice AUTHORIZATION postgres;

--#region Factura

CREATE TABLE invoice.factura (
  id bigserial PRIMARY KEY NOT NULL,
  serie_document varchar NOT NULL DEFAULT (''),
  numar_documet integer NOT NULL DEFAULT 0,
  data_document timestamp without time zone NOT NULL DEFAULT ('now'::text)::timestamp without time zone,
  numar_aviz integer NOT NULL DEFAULT 0,
  utilizator_id bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id) ON DELETE CASCADE,
  creator_id bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id) ON DELETE CASCADE,
  tva_incasare boolean NOT NULL DEFAULT false,
  total_valoare double precision NOT NULL DEFAULT 0,
  total_tva double precision NOT NULL DEFAULT 0,
  activ boolean NOT NULL DEFAULT true
);

ALTER TABLE invoice.factura OWNER TO postgres;

COMMENT ON TABLE invoice.factura IS 'Tabela aceasta va contine toate facturile unui utilizator';
COMMENT ON COLUMN invoice.factura.creator_id IS 'Coloana aceasta va contine utilizatorul care a creat acest document. Folositor doar in cazul grupurilor';

--ALTER TABLE "factura" ADD FOREIGN KEY ("utilizator_id") REFERENCES "utilizatori" ("id");
--ALTER TABLE "factura" ADD FOREIGN KEY ("creator_id") REFERENCES "utilizatori" ("id");

--#endregion Factura

--#region Produse

CREATE TABLE invoice.produse (
  id bigserial PRIMARY KEY NOT NULL,
  cod_produs varchar NOT NULL DEFAULT (''),
  denumire varchar NOT NULL DEFAULT (''),
  unitate_masura varchar NOT NULL DEFAULT (''),
  pret_unitar double precision NOT NULL DEFAULT 0,
  cota_tva_id bigint NOT NULL DEFAULT 0 REFERENCES glossary.cote_tva(id),
  utilizator_id bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id) ON DELETE CASCADE,
  activ boolean NOT NULL DEFAULT true
);

ALTER TABLE invoice.produse OWNER TO postgres;

COMMENT ON TABLE invoice.produse IS 'Tabela aceasta va contine toate produsele unui utilizator. Tabela aceasta exista doar in cazul in care unii clienti vor vrea';

--ALTER TABLE "produse" ADD FOREIGN KEY ("cota_tva") REFERENCES "cote_tva" ("id");

--#endregion Produse

--#region Factura Detalii

CREATE TABLE invoice.factura_detalii (
  id bigserial PRIMARY KEY NOT NULL,
  produs_id bigint NOT NULL DEFAULT 0 REFERENCES invoice.produse(id),
  cantitate double precision NOT NULL DEFAULT 0,
  pret_unitar double precision NOT NULL DEFAULT 0,
  activ boolean NOT NULL DEFAULT true
);

ALTER TABLE invoice.factura_detalii OWNER TO postgres;

COMMENT ON TABLE invoice.factura_detalii IS 'Tabela aceasta va cuprinde toate detaliile aferente unei facturi';

--ALTER TABLE "factura_detalii" ADD FOREIGN KEY ("produs_id") REFERENCES "produse" ("id");

--#endregion Factura Detalii

--#region date_expeditie

CREATE TABLE invoice.date_expeditie (
  id bigserial PRIMARY KEY NOT NULL,
  factura_id bigint NOT NULL DEFAULT 0 REFERENCES invoice.factura(id),
  delegat_id bigint NOT NULL DEFAULT 0 REFERENCES seller.delegati(id),
  data_expediere timestamp without time zone NOT NULL DEFAULT ('now'::text)::timestamp without time zone,
  activ boolean NOT NULL DEFAULT true
);

ALTER TABLE invoice.date_expeditie OWNER TO postgres;

COMMENT ON TABLE invoice.date_expeditie IS 'Tabela curenta contine datele de expeditie aferente unei facturi';

--ALTER TABLE "date_expeditie" ADD FOREIGN KEY ("utilizator_id") REFERENCES "utilizatori" ("id");
--ALTER TABLE "date_expeditie" ADD FOREIGN KEY ("delegat_id") REFERENCES "delegati" ("id");

--#endregion

--#endregion Invoice Schema

--#region Log Schema

CREATE SCHEMA log AUTHORIZATION postgres;

--#region User Log Table

CREATE TABLE log.log_utilizatori (
    id bigserial PRIMARY KEY NOT NULL,
    utilizator_id bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id) ON DELETE CASCADE,
    ip_logare varchar NOT NULL DEFAULT (''),
    ora_logare timestamp without time zone NOT NULL DEFAULT ('now'::text)::timestamp without time zone,
    logged boolean NOT NULL DEFAULT false,
    date_logare json NOT NULL DEFAULT ('{}')
);

ALTER TABLE log.log_utilizatori OWNER TO postgres;

COMMENT ON TABLE log.log_utilizatori IS 'Tabela curenta contine toate logarile si delogari utilizatorilor';

--#endregion User Log Table

--#region Action Log Table

CREATE TABLE log.log_actiuni (
    id bigserial PRIMARY KEY NOT NULL,
    ip_actiune varchar NOT NULL DEFAULT (''),
    ora_actiune timestamp without time zone NOT NULL DEFAULT ('now'::text)::timestamp without time zone,
    actiune varchar NOT NULL DEFAULT (''),
    comanda varchar NOT NULL DEFAULT (''),
    utilizator_id bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id) ON DELETE CASCADE
);

ALTER TABLE log.log_actiuni OWNER TO postgres;

COMMENT ON TABLE log.log_actiuni IS 'Tabela curenta va contine toate actiunile unui anume utilizator';

--#endregion Action Log Table

--#endregion Log Schema