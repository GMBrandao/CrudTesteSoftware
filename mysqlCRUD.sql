CREATE DATABASE CRUDTESTE;

USE CRUDTESTE;

CREATE TABLE Address(
    Id int NOT NULL AUTO_INCREMENT,
    Number int NOT NULL,
    Complement varchar(100) NOT NULL,
    ZipCode varchar(100) NOT NULL,
    Street varchar(100) NOT NULL,
    Neighborhood varchar(100) NOT NULL,
    City varchar(100) NOT NULL,
    State varchar(100) NOT NULL,

    CONSTRAINT PK_Address PRIMARY KEY(Id)
);

CREATE TABLE Person(
    Id int NOT NULL AUTO_INCREMENT,
    Cpf varchar(11) NOT NULL,
    Name varchar(100) NOT NULL,
    Gender char(1) NOT NULL,
    Phone varchar(15) NOT NULL,
    idAddress int NOT NULL,

    CONSTRAINT PK_Person PRIMARY KEY(Id),
    CONSTRAINT FK_Person_Address FOREIGN KEY (idAddress) REFERENCES Address(Id)
);