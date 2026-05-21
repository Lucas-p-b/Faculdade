-- Criar DB
CREATE DATABASE GREENHOUSE;

-- Definir DB como padrão utilizável
USE GREENHOUSE;

-- Criar tabela
CREATE TABLE `PLANTS` (
`PLANTS_NAME` CHAR(30) NOT NULL,
`SENSOR_VALUE` FLOAT DEFAULT NULL,
`SENSOR_EVENT` TIMESTAMP NOT NULL
	DEFAULT CURRENT_TIMESTAMP
    ON UPDATE CURRENT_TIMESTAMP,
    PRIMARY KEY `PK_PLANTS` (`PLANTS_NAME`)
);

-- vISUALIZAR TODAS AS OCORRENCIAS EM PLANTS
-- Listar todos os registros de dados    
SELECT * FROM PLANTS;

-- Visualizar colunas específicas
SELECT PLANT_NAME, SENSOR_VALUE, SENSOR_EVENT;

-- Inserir dados na tabela/entidade plants
INSERT INTO PLANTS (PLANT_NAME, SENSOR_VALUE)
VALUES ('Rosa', 0.2319);

-- Inserir múltiplos registros de uma vez
INSERT INTO PLANTS (PLANT_NAME, SENSOR_VALUE)
VALUES
	('Cactus', 0.2411),
    ('Girassol', 0.3112),
    ('Orquídea', 0.4102),
    ('Lírio', 0.5566);
    
