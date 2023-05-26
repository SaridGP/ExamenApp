CREATE DATABASE BdiExamen;


CREATE TABLE BdiExamen.dbo.tblExamen(
	idExamen INT PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(255),
	Descripcion VARCHAR(255)
);