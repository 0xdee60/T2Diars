
CREATE DATABASE PokemonDB

USE PokemonDB
go 

create table Entrenador(
    idEntrenador int primary key identity,
    nombres varchar(50),
    apellidos VARCHAR(50),
    fechaNac date,
    usuario varchar(50),
    passwd varchar(250)
)
drop table Entrenador
insert into "Entrenador" values(
    'Miguel','Aliaga','10/11/1998','admin','ky0MGWs71WJ/g1qG1VjHXZBKmXsOeQslnbHr2WoMLG0='
)
insert into "Entrenador" values(
    'Karl','Aliaga','10/12/1998','karl','ky0MGWs71WJ/g1qG1VjHXZBKmXsOeQslnbHr2WoMLG0='
)

create table Pokemon(
    idPokemon int primary key identity,
    nombres varchar(50),
    tipo VARCHAR(50),
    imagen VARCHAR(250)
)


DROP TABLE Pokemon

create table EntrenadorPokemon(
    idEntrenadorPokemon int primary key identity,
    fecha DATE,
    idEntrenador int,
    idPokemon int
)

DROP table EntrenadorPokemon


