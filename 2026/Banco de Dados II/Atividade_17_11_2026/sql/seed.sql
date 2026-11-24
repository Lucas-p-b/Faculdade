USE biblioteca_orm;

INSERT INTO autores (nome, nacionalidade) VALUES
('Martin Fowler', 'Britânica'),
('Robert C. Martin', 'Estadunidense');

INSERT INTO livros (titulo, isbn, ano_publicacao) VALUES
('Patterns of Enterprise Application Architecture', '9780321127426', 2002);

INSERT INTO livros_autores (livro_id, autor_id) VALUES (1, 1);