/*
	Examen Miguel Soto Aguilar

*/

CREATE DATABASE examen2_MiguelSotoAguilar
GO
USE examen2_MiguelSotoAguilar
GO
CREATE TABLE usuarios
(
	usuario_id int identity(1,1) primary key,
	nombre varchar(50) not null,
	correoElectronico varchar(50),
	telefono varchar(15) unique

)
GO
CREATE TABLE tecnicos
(
	tecnico_id int identity(1,1) primary key,
	nombre varchar(50),
	especialidad varchar(50),
	

)

GO
CREATE TABLE equipos
(
	equipo_id int identity(1,1) primary key,
	tipoEquipo varchar(50) not null,
	modelo varchar(50),
	codigoUsuario int,
	CONSTRAINT fk_codigoUsuario foreign key (codigoUsuario) REFERENCES usuarios (usuario_id)

)
GO
CREATE TABLE reparaciones
(
	reparacion_id int identity(1,1) primary key,
	fechaSolicitud date CONSTRAINT df_fecha DEFAULT getdate(),
	estado char,
	codigoEquipo int,
	CONSTRAINT fk_codigoEquipo foreign key (codigoEquipo) REFERENCES equipos (equipo_id)

)
GO

CREATE TABLE detallesReparacion
(
	detalle_id int identity(1,1) primary key,
	fechaInicio datetime ,
	fechaFin datetime,
	descripcion varchar(50),
	codigoReparacion int,
	CONSTRAINT fk_codigoReparacion foreign key (codigoReparacion) REFERENCES reparaciones (reparacion_id)

)

GO
USE examen2_MiguelSotoAguilar
CREATE TABLE asignaciones
(
	asignacion_id int identity(1,1) primary key,
	fechaasignacion datetime,	
	codigoReparacionTecnico int,
	codigoTecnicoAsignacion int,
	CONSTRAINT fk_codigoReparacionTecnico foreign key (codigoReparacionTecnico) REFERENCES reparaciones (reparacion_id),
	CONSTRAINT fk_codigoTecnicoAsignacion foreign key (codigoTecnicoAsignacion) REFERENCES tecnicos (tecnico_id),

)


USE examen2_MiguelSotoAguilar
insert into usuarios values ('Jorge', 'j@gmail', '8888')
insert into usuarios values ('Lupe', 'l@gmail', '8881')
insert into usuarios values ('Roberto', 'r@gmail', '8882')

USE examen2_MiguelSotoAguilar
insert into equipos values ('televisor', 'lg', 1)
insert into equipos values ('celular', 'huawei', 2)
insert into equipos values ('laptop', 'acer', 3)

USE examen2_MiguelSotoAguilar
insert into tecnicos values ('Juan', 'electronica')
insert into tecnicos values ('Monica', 'electronica')
insert into tecnicos values ('Rogelio', 'electronica')



select * from tecnicos

/*Procedimientos almacenados Store procedures SP O PA*/
USE examen2_MiguelSotoAguilar
CREATE PROCEDURE CONSULTARUSUARIO
	AS
		BEGIN
			SELECT * FROM usuarios
		END

	EXEC CONSULTARUSUARIO

CREATE PROCEDURE CONSULTAREQUIPOS
	AS
		BEGIN
			SELECT * FROM equipos
		END

	EXEC CONSULTAREQUIPOS

CREATE PROCEDURE CONSULTARTECNICOS
	AS
		BEGIN
			SELECT * FROM tecnicos
		END

	EXEC CONSULTARTECNICOS



	/*Consultar con filtros*/

	CREATE PROCEDURE CONSULTARUSUARIO_FILTRO
	
	@CODIGO INT
	
	AS
		BEGIN
			SELECT * FROM usuarios WHERE usuario_id = @CODIGO
		END

	EXEC CONSULTARUSUARIO_FILTRO  1

	CREATE PROCEDURE CONSULTAREQUIPO_FILTRO
	
	@CODIGO INT
	
	AS
		BEGIN
			SELECT * FROM equipos WHERE equipo_id = @CODIGO
		END

	EXEC CONSULTAREQUIPO_FILTRO  3

	CREATE PROCEDURE CONSULTARTECNICO_FILTRO
	
	@CODIGO INT
	
	AS
		BEGIN
			SELECT * FROM tecnicos WHERE tecnico_id = @CODIGO
		END

	EXEC CONSULTARTECNICO_FILTRO  3


	CREATE PROCEDURE ACTUALIZAR_USUARIO
	@CODIGO
	@
	AS
		BEGIN
			UPDATE usuarios set 
		END

/*PARA EXAMEN*/

CREATE PROCEDURE INGRESAR_USUARIO

@NOMBRE varchar(50),
@CORREO_ELECTRONICO varchar(50),
@TELEFONO varchar(50)
AS
	BEGIN
		INSERT INTO usuarios (nombre, correoElectronico, telefono) VALUES (@NOMBRE, @CORREO_ELECTRONICO, @TELEFONO)
	END

EXEC INGRESAR_USUARIO Juan, juan@hotmail, 8833

CREATE PROCEDURE INGRESAR_TECNICO

@NOMBRE varchar(50),
@ESPECIALIDAD varchar(50)

AS
	BEGIN
		INSERT INTO tecnicos (nombre, especialidad) VALUES (@NOMBRE, @ESPECIALIDAD)
	END

EXEC INGRESAR_TECNICO Rafael, Telematica

CREATE PROCEDURE INGRESAR_EQUIPO

@TIPO_EQUIPO varchar(50),
@MODELO varchar(50),
@CODIGO_USUARIO INT

AS
	BEGIN
		INSERT INTO equipos (tipoEquipo, modelo, codigoUsuario) VALUES (@TIPO_EQUIPO, @MODELO, @CODIGO_USUARIO)
	END

EXEC INGRESAR_EQUIPO MICROONDAS, PANASONIC, 2

CREATE PROCEDURE BORRAR_USUARIO
@CODIGO int
AS
	BEGIN
		DELETE usuarios WHERE usuario_id = @CODIGO
	END

CREATE PROCEDURE BORRAR_EQUIPO
@CODIGO int
AS
	BEGIN
		DELETE equipos WHERE equipo_id = @CODIGO
	END


CREATE PROCEDURE BORRAR_TECNICO
@CODIGO int
AS
	BEGIN
		DELETE tecnicos WHERE tecnico_id = @CODIGO
	END



	
CREATE PROCEDURE MODIFICAR_USUARIO
@CODIGO int,
@NOMBRE varchar(50),
@CORREO_ELECTRONICO varchar(50),
@TELEFONO varchar(50)
AS
	BEGIN
		UPDATE usuarios SET nombre = @NOMBRE, correoElectronico = @CORREO_ELECTRONICO, telefono = @TELEFONO
		WHERE usuario_id = @CODIGO
	END

ALTER PROCEDURE MODIFICAR_USUARIO
@CODIGO int,
@NOMBRE varchar(50),
@CORREO_ELECTRONICO varchar(50),
@TELEFONO varchar(50)
AS
	BEGIN
		UPDATE usuarios SET nombre = @NOMBRE, correoElectronico = @CORREO_ELECTRONICO, telefono = @TELEFONO
		WHERE usuario_id = @CODIGO
	END

	EXEC MODIFICAR_USUARIO 2, RICARDO, ric@outlook, 83235343

CREATE PROCEDURE MODIFICAR_EQUIPO
@CODIGO int,
@TIPO_EQUIPO varchar(50),
@MODELO varchar(50),
@CODIGO_USUARIO int
AS
	BEGIN
		UPDATE equipos SET tipoEquipo = @TIPO_EQUIPO, modelo = @MODELO, codigoUsuario = @CODIGO_USUARIO
		WHERE equipo_id = @CODIGO
	END

	EXEC MODIFICAR_EQUIPO 4, Desktop, LENOVO, 1

CREATE PROCEDURE MODIFICAR_TECNICO
@CODIGO int,
@NOMBRE varchar(50),
@ESPECIALIDAD varchar(50)

AS
	BEGIN
		UPDATE tecnicos SET nombre = @NOMBRE, especialidad = @ESPECIALIDAD
		WHERE tecnico_id = @CODIGO
	END