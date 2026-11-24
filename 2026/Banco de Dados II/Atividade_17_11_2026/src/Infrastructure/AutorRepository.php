<?php
declare(strict_types=1);

namespace Biblioteca\Infrastructure;

use Biblioteca\Domain\Autor;

final class AutorRepository extends AbstractRepository
{
    protected function tabela(): string
    {
        return 'autores';
    }

    protected function colunas(): array
    {
        return ['nome', 'nacionalidade'];
    }

    protected function hidratar(array $linha): Autor
    {
        $autor = new Autor(
            (string) $linha['nome'],
            $linha['nacionalidade'] !== null ? (string) $linha['nacionalidade'] : null
        );
        $autor->atribuirId((int) $linha['id']);

        return $autor;
    }

    protected function extrair(object $entidade): array
    {
        if (!$entidade instanceof Autor) {
            throw new \InvalidArgumentException('Esperada uma instância de Autor.');
        }

        return [
            'nome' => $entidade->nome(),
            'nacionalidade' => $entidade->nacionalidade(),
        ];
    }

    protected function identidade(object $entidade): ?int
    {
        if (!$entidade instanceof Autor) {
            throw new \InvalidArgumentException('Esperada uma instância de Autor.');
        }

        return $entidade->id();
    }

    protected function definirIdentidade(object $entidade, int $id): void
    {
        if (!$entidade instanceof Autor) {
            throw new \InvalidArgumentException('Esperada uma instância de Autor.');
        }

        $entidade->atribuirId($id);
    }
}