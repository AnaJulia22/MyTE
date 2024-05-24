 CREATE DATABASE DB_MYTE
 GO
 
 USE DB_MYTE
 GO 

CREATE TABLE TB_WBS(
	id INT IDENTITY(1,1),
	codigo VARCHAR(10) not null,
	descricao VARCHAR(100) not null,
	tipo SMALLINT not null, --1 chargeability 2 - non-chargeability
	PRIMARY KEY(id),
	CHECK(LEN(codigo) > 4 AND LEN(codigo) <10),
	CHECK(tipo=1 OR tipo=2)
)

CREATE TABLE TB_CARGOS(
	id INT IDENTITY(1,1),
	nomeCargo VARCHAR(100),
	PRIMARY KEY(id)
)

CREATE TABLE TB_COLABORADORES(
	cpf VARCHAR(11),
	id_cargo INT, 
	administrador BIT not null,
	PRIMARY KEY(cpf),
	FOREIGN KEY(id_cargo) REFERENCES TB_CARGOS(id),
	CHECK(LEN(cpf)=11)
) 

CREATE TABLE TB_REGISTRO_DIAS_HORAS(
	id int identity(1,1),
	data_registro DATETIME not null, --dia do registro
	id_wbs int not null,
	cpf varchar(11) not null,
	dia DATE not null, -- dia trabalhado
	horas INT not null, --quantas horas horas/dia
	PRIMARY KEY (id),
	FOREIGN KEY(id_wbs) references TB_WBS(id),
	FOREIGN KEY(cpf) references TB_COLABORADORES(cpf)
)

