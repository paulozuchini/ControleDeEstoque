-- Inicio do Script a partir da master
USE master
GO

-- Criando Banco de Dados
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'controledeestoque')
	BEGIN
		CREATE DATABASE [controledeestoque]
	END;
GO
	-- Usando novo banco
	USE [controledeestoque]
GO

-- Criando Tabelas
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Users' and xtype='U')
BEGIN
    CREATE TABLE Users (
        Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
        FullName VARCHAR(100) NOT NULL,
		Email VARCHAR(100) NOT NULL UNIQUE,
		UserRole VARCHAR(50) NOT NULL,
		PasswordHash CHAR(60) NOT NULL
    )
END;