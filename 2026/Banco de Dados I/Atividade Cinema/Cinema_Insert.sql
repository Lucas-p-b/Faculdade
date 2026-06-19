INSERT INTO PESSOA (NOME, NACIONALIDADE, DATA_NASCIMENTO)
VALUES
('Bruno Furlan', 'Brasileiro', '1996-01-19'),
('Lucas Piva Bellaver', 'Brasileiro', '2007-01-22'),
('Lucas Castanheiro', 'Brasileiro', '2005-09-01'),
('Mariana Souza', 'Brasileira', '1998-04-15'),
('Gabriel Oliveira', 'Brasileiro', '1994-07-21'),
('Ana Clara Silva', 'Brasileira', '2000-03-12'),
('Pedro Henrique', 'Brasileiro', '1995-11-08'),
('Juliana Martins', 'Brasileira', '1997-06-30'),
('Carlos Eduardo', 'Brasileiro', '1988-02-17'),
('Fernanda Costa', 'Brasileira', '1993-12-05'),
('Ricardo Alves', 'Brasileiro', '1987-09-09'),
('Patricia Gomes', 'Brasileira', '1991-05-28'),
('Joao Vitor', 'Brasileiro', '1999-08-11'),
('Camila Rocha', 'Brasileira', '1996-10-22'),
('Felipe Santos', 'Brasileiro', '1992-04-03'),
('Amanda Lima', 'Brasileira', '1998-01-14'),
('Thiago Pereira', 'Brasileiro', '1990-07-07'),
('Beatriz Carvalho', 'Brasileira', '1997-09-25'),
('Leonardo Dias', 'Brasileiro', '1989-11-19'),
('Larissa Melo', 'Brasileira', '2001-02-26'),
('Rafael Nunes', 'Brasileiro', '1994-12-18'),
('Isabela Ribeiro', 'Brasileira', '1999-05-16'),
('Gustavo Ferreira', 'Brasileiro', '1993-03-27'),
('Leticia Barbosa', 'Brasileira', '1995-08-20'),
('Matheus Araujo', 'Brasileiro', '1998-10-01'),
('Vanessa Teixeira', 'Brasileira', '1992-06-13'),
('Diego Rodrigues', 'Brasileiro', '1986-04-24'),
('Carolina Lopes', 'Brasileira', '1997-12-09'),
('Vinicius Moreira', 'Brasileiro', '1991-01-31'),
('Julia Fernandes', 'Brasileira', '2000-07-04');


INSERT INTO FILME (TITULO, GENERO, DURACAO)
VALUES
('Horizonte Final', 'Ficcao Cientifica', '02:15'),
('O Ultimo Codigo', 'Acao', '01:58'),
('Sombras da Cidade', 'Suspense', '02:04'),
('Amor em Paris', 'Romance', '01:47'),
('Aventura Perdida', 'Aventura', '02:11'),
('Noite de Terror', 'Terror', '01:52'),
('Operacao Secreta', 'Acao', '02:07'),
('Misterio no Lago', 'Drama', '01:55'),
('Reino das Estrelas', 'Fantasia', '02:20'),
('Velocidade Maxima', 'Acao', '01:49');


INSERT INTO ATOR (ID_PESSOA, ID_FILME)
VALUES
(1,1),(2,1),(3,1),
(4,2),(5,2),(6,2),
(7,3),(8,3),(9,3),
(10,4),(11,4),(12,4),
(13,5),(14,5),(15,5),
(16,6),(17,6),(18,6),
(19,7),(20,7),(21,7),
(22,8),(23,8),(24,8),
(25,9),(26,9),(27,9),
(28,10),(29,10),(30,10);


INSERT INTO DIRETOR (ID_PESSOA, ID_FILME)
VALUES
(1,10),(2,9),(3,8),
(4,7),(5,6),(6,5),
(7,4),(8,3),(9,2),
(10,1),(11,10),(12,9),
(13,8),(14,7),(15,6),
(16,5),(17,4),(18,3),
(19,2),(20,1),(21,10),
(22,9),(23,8),(24,7),
(25,6),(26,5),(27,4),
(28,3),(29,2),(30,1);