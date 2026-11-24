<?php
declare(strict_types=1);

namespace Biblioteca\Infrastructure;

abstract class AbstractRepository implements RepositoryInterface
{
    public function __construct(protected \PDO $pdo)
    {
    }

    abstract protected function tabela(): string;

    /** @return string[] */
    abstract protected function colunas(): array;

    abstract protected function hidratar(array $linha): object;

    /** @return array<string, mixed> */
    abstract protected function extrair(object $entidade): array;

    abstract protected function identidade(object $entidade): ?int;

    abstract protected function definirIdentidade(object $entidade, int $id): void;

    public function buscar(int $id): ?object
    {
        $sql = sprintf('SELECT * FROM %s WHERE id = :id', $this->tabela());
        $stmt = $this->pdo->prepare($sql);
        $stmt->execute(['id' => $id]);

        $linha = $stmt->fetch(\PDO::FETCH_ASSOC);

        return $linha === false ? null : $this->hidratar($linha);
    }

    /** @return object[] */
    public function listar(): array
    {
        $sql = sprintf('SELECT * FROM %s ORDER BY id', $this->tabela());
        $stmt = $this->pdo->query($sql);

        return array_map(
            fn(array $linha): object => $this->hidratar($linha),
            $stmt->fetchAll(\PDO::FETCH_ASSOC)
        );
    }

    public function salvar(object $entidade): void
    {
        $dados = $this->extrair($entidade);
        $colunas = $this->colunas();

        if (array_keys($dados) !== $colunas) {
            throw new \LogicException('Mapeamento inconsistente entre colunas e dados extraídos.');
        }

        $id = $this->identidade($entidade);

        if ($id === null) {
            $nomes = implode(', ', $colunas);
            $marcadores = implode(', ', array_map(fn(string $c): string => ':' . $c, $colunas));
            $sql = sprintf('INSERT INTO %s (%s) VALUES (%s)', $this->tabela(), $nomes, $marcadores);

            $stmt = $this->pdo->prepare($sql);
            $stmt->execute($dados);

            $this->definirIdentidade($entidade, (int) $this->pdo->lastInsertId());
        } else {
            $atribuicoes = implode(', ', array_map(fn(string $c): string => "$c = :$c", $colunas));
            $sql = sprintf('UPDATE %s SET %s WHERE id = :id', $this->tabela(), $atribuicoes);

            $stmt = $this->pdo->prepare($sql);
            $stmt->execute($dados + ['id' => $id]);
        }
    }

    public function excluir(int $id): void
    {
        $sql = sprintf('DELETE FROM %s WHERE id = :id', $this->tabela());
        $stmt = $this->pdo->prepare($sql);
        $stmt->execute(['id' => $id]);
    }
}