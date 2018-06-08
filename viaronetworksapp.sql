/*
  Author: Kevin Lorenzo ( Software Developer )
*/

USE master;

DROP DATABASE IF EXISTS viaronetworksapp;

CREATE DATABASE viaronetworksapp;

GO

USE viaronetworksapp;

CREATE TABLE Alumno (
  id INTEGER IDENTITY(1, 1),
  nombre VARCHAR(50),
  apellidos VARCHAR(50),
  genero CHAR(1),
  fechaNacimiento DATETIME,
  PRIMARY KEY (id)
);

CREATE TABLE Profesor (
  id INTEGER IDENTITY(1, 1),
  nombre VARCHAR(50),
  apellidos VARCHAR(50),
  genero CHAR(1),
  PRIMARY KEY (id)
);

CREATE TABLE Grado (
  id INTEGER IDENTITY(1, 1),
  nombre VARCHAR(50),
  profesorID INTEGER,
  PRIMARY KEY (id),
  FOREIGN KEY(profesorID) REFERENCES Profesor(id)
);

CREATE TABLE AlumnoGrado (
  id INTEGER IDENTITY(1, 1),
  alumnoID INTEGER,
  gradoID INTEGER,
  seccion VARCHAR(10),
  PRIMARY KEY (id),
  FOREIGN KEY(alumnoID) REFERENCES Alumno(id),
  FOREIGN KEY(gradoID) REFERENCES Grado(id)
);

GO

-- TABLE Alumno: Stored Procedures

CREATE PROCEDURE spAlumnoCreate 
	@nombre VARCHAR(50), 
	@apellidos VARCHAR(50), 
	@genero VARCHAR(1), 
	@fechaNacimiento DATETIME
AS
	INSERT INTO Alumno(nombre, apellidos, genero, fechaNacimiento) 
		VALUES(@nombre, @apellidos, @genero, @fechaNacimiento);
GO

CREATE PROCEDURE spAlumnoGetAll
AS
	SELECT * FROM Alumno;
GO

CREATE PROCEDURE spAlumnoGetByID @id INTEGER
AS
	SELECT * FROM Alumno WHERE id = @id;
GO

CREATE PROCEDURE spAlumnoUpdateByID 
	@id INTEGER, 
	@nombre VARCHAR(50), 
	@apellidos VARCHAR(50), 
	@genero VARCHAR(1), 
	@fechaNacimiento DATETIME
AS
	UPDATE Alumno SET 
		nombre = @nombre, 
		apellidos = @apellidos, 
		genero = @genero, 
		fechaNacimiento = @fechaNacimiento 
		WHERE id = @id;
GO

CREATE PROCEDURE spAlumnoDeleteByID @id INTEGER
AS
	DELETE Alumno WHERE id = @id;
GO

-- TABLE Profesor: Stored Procedures

CREATE PROCEDURE spProfesorCreate
	@nombre VARCHAR(50), 
	@apellidos VARCHAR(50), 
	@genero VARCHAR(1)
AS
	INSERT INTO Profesor(nombre, apellidos, genero) 
		VALUES(@nombre, @apellidos, @genero);
GO

CREATE PROCEDURE spProfesorGetAll
AS
	SELECT * FROM Profesor;
GO

CREATE PROCEDURE spProfesorGetByID @id INTEGER
AS
	SELECT * FROM Profesor WHERE id = @id;
GO

CREATE PROCEDURE spProfesorUpdateByID 
	@id INTEGER, 
	@nombre VARCHAR(50), 
	@apellidos VARCHAR(50), 
	@genero VARCHAR(1)
AS
	UPDATE Profesor SET 
		nombre = @nombre, 
		apellidos = @apellidos, 
		genero = @genero 
		WHERE id = @id;
GO

CREATE PROCEDURE spProfesorDeleteByID @id INTEGER
AS
	DELETE Profesor WHERE id = @id;
GO

-- TABLE Grado: Stored Procedures

CREATE PROCEDURE spGradoCreate 
	@nombre VARCHAR(50), 
	@profesorID INTEGER
AS
	INSERT INTO Grado(nombre, profesorID) 
		VALUES(@nombre, @profesorID);
GO

CREATE PROCEDURE spGradoGetAll
AS
	SELECT * FROM Grado;
GO

CREATE PROCEDURE spGradoGetByID @id INTEGER
AS
	SELECT * FROM Grado WHERE id = @id;
GO

CREATE PROCEDURE spGradoUpdateByID 
	@id INTEGER, 
	@nombre VARCHAR(50), 
	@profesorID INTEGER
AS
	UPDATE Grado SET 
		nombre = @nombre, 
		profesorId = @profesorID 
		WHERE id = @id;
GO

CREATE PROCEDURE spGradoDeleteByID @id INTEGER
AS
	DELETE Grado WHERE id = @id;
GO

-- TABLE AlumnoGrado: Stored Procedures

CREATE PROCEDURE spAlumnoGradoCreate 
	@alumnoID INTEGER, 
	@gradoID INTEGER, 
	@seccion VARCHAR(10)
AS
	INSERT INTO AlumnoGrado(alumnoID, gradoID, seccion) 
		VALUES(@alumnoID, @gradoID, @seccion);
GO

CREATE PROCEDURE spAlumnoGradoGetAll
AS
	SELECT * FROM AlumnoGrado;
GO

CREATE PROCEDURE spAlumnoGradoGetByID @id INTEGER
AS
	SELECT * FROM AlumnoGrado WHERE id = @id;
GO

CREATE PROCEDURE spAlumnoGradoUpdateByID 
	@id INTEGER, 
	@alumnoID INTEGER, 
	@gradoID INTEGER, 
	@seccion VARCHAR(10)
AS
	UPDATE AlumnoGrado SET 
		alumnoID = @alumnoID, 
		gradoID = @gradoID, 
		seccion = @seccion 
		WHERE id = @id;
GO

CREATE PROCEDURE spAlumnoGradoDeleteByID @id INTEGER
AS
	DELETE AlumnoGrado WHERE id = @id;
GO