CREATE DATABASE IF NOT EXISTS biblioteca_orm
  CHARACTER SET utf8mb4
  COLLATE utf8mb4_unicode_ci;

USE biblioteca_orm;

CREATE TABLE IF NOT EXISTS livros (
    id INT AUTO_INCREMENT PRIMARY KEY,
    titulo VARCHAR(200) NOT NULL,
    isbn VARCHAR(13) UNIQUE,
    ano_publicacao INT NULL
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS autores (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(150) NOT NULL,
    nacionalidade VARCHAR(80) NULL
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS livros_autores (
    livro_id INT NOT NULL,
    autor_id INT NOT NULL,
    PRIMARY KEY (livro_id, autor_id),
    CONSTRAINT fk_livros_autores_livro
        FOREIGN KEY (livro_id) REFERENCES livros (id)
        ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT fk_livros_autores_autor
        FOREIGN KEY (autor_id) REFERENCES autores (id)
        ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS exemplares (
    id INT AUTO_INCREMENT PRIMARY KEY,
    livro_id INT NOT NULL,
    codigo_patrimonio VARCHAR(30) NOT NULL UNIQUE,
    status ENUM('disponivel', 'emprestado', 'manutencao') NOT NULL DEFAULT 'disponivel',
    CONSTRAINT fk_exemplares_livro
        FOREIGN KEY (livro_id) REFERENCES livros (id)
        ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB;