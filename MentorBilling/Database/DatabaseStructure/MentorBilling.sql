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
  activ boolean NOT NULL DEFAULT false
);

ALTER TABLE users.utilizatori OWNER TO postgres;

COMMENT ON TABLE users.utilizatori IS 'Tabela centrala pentru structura de utilizatori';
COMMENT ON COLUMN users.utilizatori.parola_autogenerata IS 'Parola autogenerata va fi folosita doar cand se uita parola si se doreste modificarea ei';

--#endregion Users Table

--#region Grupuri Table

CREATE TABLE users.grupuri (
  id bigserial PRIMARY KEY NOT NULL,
  denumire varchar NOT NULL DEFAULT (''),
  administrator_grup bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id),
  activ boolean NOT NULL DEFAULT false
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
  utilizator_id bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id),
  activ boolean NOT NULL DEFAULT false
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
  activ boolean NOT NULL DEFAULT false
);

ALTER TABLE users.drepturi OWNER TO postgres;

COMMENT ON TABLE users.drepturi IS 'Tabela de drepturi pentru program care va contine toate drepturile posibile din program';
COMMENT ON COLUMN users.drepturi.tip_drept IS 'Coloana va fi legata de un enum din program care da tipul de valoarea al coloanei';
COMMENT ON COLUMN users.drepturi.drept IS 'Coloana asta va contine denumirea dreptului folosita pentru afisare';

--#endregion Drepturi

--#region Drepturi Utilizatori

CREATE TABLE users.drepturi_utilizatori (
  id bigserial PRIMARY KEY NOT NULL,
  utilizator_id bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id), 
  drept_id bigint NOT NULL DEFAULT 0 REFERENCES users.drepturi(id),
  valoare_drept varchar NOT NULL DEFAULT (''),
  activ boolean NOT NULL DEFAULT false
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
  activ boolean NOT NULL DEFAULT false
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
  activ boolean NOT NULL DEFAULT false
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
  activ boolean NOT NULL DEFAULT false
);

ALTER TABLE users.abonamente OWNER TO postgres;

COMMENT ON TABLE users.abonamente IS 'Tabela aceasta va contine valori standard predefinite ale viitoarelor abonamente';
COMMENT ON COLUMN users.abonamente.perioada_plata IS 'Coloana aceasta va contine perioada de activitate a abonamentului in zile';
COMMENT ON COLUMN users.abonamente.dimensiune_maxima_grup IS 'Coloana aceasta va contine dimensiunea maxima admisa a grupului';
COMMENT ON COLUMN users.abonamente.valoare_lunara IS 'Coloana aceasta va contine valoarea lunara de baza a unui abonament. Aceasta poate suferi costuri aditionale.';

--#endregion Abonamente

--#region Abonamente Utilizatori

CREATE TABLE users.abonamente_utilizatori (
  id bigserial PRIMARY KEY NOT NULL,
  utilizator_id bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id),
  abonament_id bigint NOT NULL DEFAULT 0 REFERENCES users.abonamente(id),
  valoare_lunara double precision NOT NULL DEFAULT 0,
  ultima_plata timestamp without time zone NOT NULL DEFAULT ('now'::text)::timestamp without time zone,
  perioada_activa integer NOT NULL DEFAULT 30,
  dimensiune_maxima_grup integer NOT NULL DEFAULT 1,
  activ boolean NOT NULL DEFAULT false
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
  nr_registru_comert varchar NOT NULL DEFAULT (''),
  cod_fiscal varchar NOT NULL DEFAULT (''),
  capital_social double precision NOT NULL DEFAULT 0,
  sediul varchar NOT NULL DEFAULT (''),
  punct_lucru varchar NOT NULL DEFAULT (''),
  telefon varchar NOT NULL DEFAULT (''),
  email varchar NOT NULL DEFAULT (''),
  sigla bytea NOT NULL DEFAULT (''),
  utilizator_id bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id),
  activ boolean NOT NULL DEFAULT false
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
  cont varchar NOT NULL DEFAULT (''),
  banca varchar NOT NULL DEFAULT (''),
  activ boolean NOT NULL DEFAULT false
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
  utilizator_id bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id),
  activ boolean NOT NULL DEFAULT false
);

ALTER TABLE seller.delegati OWNER TO postgres;

COMMENT ON TABLE seller.delegati IS 'Tabela curenta contine toti delegatii unui utilizator';

--#endregion delegati

--#region Utilizatori Last Used

CREATE TABLE seller.utilizatori_last_used (
  id bigserial PRIMARY KEY NOT NULL,
  utilizator_id bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id),
  furnizori_last_used bigint NOT NULL DEFAULT 0 REFERENCES seller.furnizori(id),
  conturi_bancare_last_used bigint NOT NULL DEFAULT 0 REFERENCES seller.conturi_bancare_furnizori(id),
  delegati_last_used bigint NOT NULL DEFAULT 0 REFERENCES seller.delegati(id),
  activ boolean NOT NULL DEFAULT false
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
  activ boolean NOT NULL DEFAULT false
);

ALTER TABLE glossary.tari OWNER TO postgres;

COMMENT ON TABLE glossary.tari IS 'Tabela aceasta cuprinde nomenclatorul de tari din program. Nici un client nu o poate altera';

--#endregion Tari

--#region Judete

CREATE TABLE glossary.judete (
  id bigserial PRIMARY KEY NOT NULL,
  cod_judet VARCHAR(2) NOT NULL DEFAULT (''),
  den_judet VARCHAR NOT NULL DEFAULT (''),
  activ boolean NOT NULL DEFAULT false
);

ALTER TABLE glossary.judete OWNER TO postgres;

COMMENT ON TABLE glossary.judete IS 'Tabela aceasta cuprinde nomenclatorul de judete din program. Nici un client nu o poate altera';

--#endregion Judete

CREATE TABLE glossary.cote_tva (
  id bigserial PRIMARY KEY NOT NULL,
  cota varchar NOT NULL DEFAULT (''),
  tva numeric(2) NOT NULL DEFAULT 0,
  cod varchar NOT NULL DEFAULT (''),
  activ boolean NOT NULL DEFAULT true
);

ALTER TABLE glossary.cote_tva OWNER TO postgres;

COMMENT ON TABLE glossary.cote_tva IS 'Tabela aceasta cuprinde nomenclatorul de cote de tva din program. Nici un client nu o poate altera';

--#region Anaf Info

CREATE TABLE glossary.anaf_info (
  id SERIAL PRIMARY KEY NOT NULL,
  moment_initial timestamp without time zone NOT NULL DEFAULT ('01.01.1900'::text)::timestamp without time zone,
  moment_final timestamp without time zone,
  cod_fiscal varchar NOT NULL DEFAULT (''),
  info_file json
);

ALTER TABLE glossary.anaf_info OWNER TO postgres;

COMMENT ON TABLE glossary.anaf_info IS 'Tabela aceasta va contine pe perioade starile societatilor preluate de la anaf pe baza interogarilor clientilor';

--#endregion Anaf Info

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
  creator_plaja bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id),
  activ boolean NOT NULL DEFAULT false
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
  utilizator_id bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id),
  activ boolean NOT NULL DEFAULT false
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
  tip_setare integer NOT NULL DEFAULT 0,
  activ boolean NOT NULL DEFAULT false
);

ALTER TABLE settings.setari OWNER TO postgres;

COMMENT ON TABLE settings.setari IS 'Tabela aceasta va contine toate setarile programului la nivel de setare';
COMMENT ON COLUMN settings.setari.tip_setare IS 'Coloana aceasta va contine tipul de setare legata de un enum din program';

--#endregion Setari

--#region Setari Utilizatori

CREATE TABLE settings.setari_utilizatori (
  id bigserial PRIMARY KEY NOT NULL,
  utilizator_id bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori,
  setare_id bigint NOT NULL DEFAULT 0 REFERENCES settings.setari(id),
  valoare_setare varchar NOT NULL DEFAULT (''),
  activ boolean NOT NULL DEFAULT false
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
  utilizator_id bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id),
  cota_tva_id bigint NOT NULL DEFAULT 0 REFERENCES glossary.cote_tva(id),
  activ boolean NOT NULL DEFAULT true
);

ALTER TABLE settings.cote_tva_utilizatori OWNER TO postgres;

COMMENT ON TABLE settings.cote_tva_utilizatori IS 'Tabela aceasta va contine legatura intre glosarul de cote de tva si setarile specifice ale utilizatorului';
COMMENT ON COLUMN settings.cote_tva_utilizatori.indice_casa_marcat IS 'Coloana necesara pentru imprimarea bonului fiscal pe casa de marcat';

--ALTER TABLE "cote_tva_utilizatori" ADD FOREIGN KEY ("utilizator_id") REFERENCES "utilizatori" ("id");
--ALTER TABLE "cote_tva_utilizatori" ADD FOREIGN KEY ("cota_tva_id") REFERENCES "cote_tva" ("id");

--#endregion Cote TVA Utilizatori

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
  utilizator_id bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id),
  activ boolean NOT NULL DEFAULT false
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
  activ boolean NOT NULL DEFAULT false
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
  data_document timestamp NOT NULL DEFAULT ('now'),
  numar_aviz integer NOT NULL DEFAULT 0,
  utilizator_id bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id),
  creator_id bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id),
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
  utilizator_id bigint NOT NULL DEFAULT 0 REFERENCES users.utilizatori(id),
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
  data_expediere timestamp NOT NULL DEFAULT ('now'),
  activ boolean NOT NULL DEFAULT false
);

ALTER TABLE invoice.date_expeditie OWNER TO postgres;

COMMENT ON TABLE invoice.date_expeditie IS 'Tabela curenta contine datele de expeditie aferente unei facturi';

--ALTER TABLE "date_expeditie" ADD FOREIGN KEY ("utilizator_id") REFERENCES "utilizatori" ("id");
--ALTER TABLE "date_expeditie" ADD FOREIGN KEY ("delegat_id") REFERENCES "delegati" ("id");

--#endregion

--#endregion Invoice Schema