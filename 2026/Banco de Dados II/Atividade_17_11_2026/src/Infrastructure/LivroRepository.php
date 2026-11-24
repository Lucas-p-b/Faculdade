<?php
declare(strict_types=1);

namespace Biblioteca\Infrastructure;

use Biblioteca\Domain\Autor;
use Biblioteca\Domain\Livro;

final class LivroRepository extends AbstractRepository
{
    protected function tabela(): string
    {
        return 'livros';
    }

    protected function colunas(): array
    {
        return ['titulo', 'isbn', 'ano_publicacao'];
    }

    protected function hidratar(array $linha): Livro
    {
        $livro = new Livro(
            (string) $linha['titulo'],
            $linha['isbn'] !== null ? (string) $linha['isbn'] : null,
            $linha['ano_publicacao'] !== null ? (int) $linha['ano_publicacao'] : null
        );
        $livro->atribuirId((int) $linha['id']);

        return $livro;
    }

    protected function extrair(object $entidade): array
    {
        if (!$entidade instanceof Livro) {
            throw new \InvalidArgumentException('Esperada uma instância de Livro.');
        }

        return [
            'titulo' => $entidade->titulo(),
            'isbn' => $entidade->isbn(),
            'ano_publicacao' => $entidade->anoPublicacao(),
        ];
    }

    protected function identidade(object $entidade): ?int
    {
        if (!$entidade instanceof Livro) {
            throw new \InvalidArgumentException('Esperada uma instância de Livro.');
        }

        return $entidade->id();
    }

    protected function definirIdentidade(object $entidade, int $id): void
    {
        if (!$entidade instanceof Livro) {
            throw new \InvalidArgumentException('Esperada uma instância de Livro.');
        }

        $entidade->atribuirId($id);
    }

    /** @return Autor[] */
    public function autoresDoLivro(int $livroId): array
    {
        $sql = 'SELECT a.*
                FROM autores a
                INNER JOIN livros_autores la ON la.autor_id = a.id
                WHERE la.livro_id = :id
                ORDER BY a.nome';

        $stmt = $this->pdo->prepare($sql);
        $stmt->execute(['id' => $livroId]);

        return array_map(function (array $r): Autor {
            $autor = new Autor(
                (string) $r['nome'],
                $r['nacionalidade'] !== null ? (string) $r['nacionalidade'] : null
            );
            $autor->atribuirId((int) $r['id']);
            return $autor;
        }, $stmt->fetchAll(\PDO::FETCH_ASSOC));
    }

    public function associarAutor(int $livroId, int $autorId): void
    {
        $sql = 'INSERT INTO livros_autores (livro_id, autor_id) VALUES (:livro, :autor)';
        $stmt = $this->pdo->prepare($sql);
        $stmt->execute([
            'livro' => $livroId,
            'autor' => $autorId,
        ]);
    }

    public function desassociarAutores(int $livroId): void
    {
        $sql = 'DELETE FROM livros_autores WHERE livro_id = :livro';
        $stmt = $this->pdo->prepare($sql);
        $stmt->execute(['livro' => $livroId]);
    }
}