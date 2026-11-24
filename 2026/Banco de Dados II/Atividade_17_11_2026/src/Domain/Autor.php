<?php
declare(strict_types=1);

namespace Biblioteca\Domain;

final class Autor
{
    private ?int $id = null;
    private string $nome;
    private ?string $nacionalidade;

    public function __construct(string $nome, ?string $nacionalidade = null)
    {
        if (trim($nome) === '') {
            throw new \InvalidArgumentException('Nome do autor é obrigatório.');
        }

        $this->nome = trim($nome);
        $this->nacionalidade = $nacionalidade !== null ? trim($nacionalidade) : null;
    }

    public function id(): ?int
    {
        return $this->id;
    }

    public function atribuirId(int $id): void
    {
        if ($id <= 0 || ($this->id !== null && $this->id !== $id)) {
            throw new \LogicException('Identidade do autor inválida ou já definida.');
        }

        $this->id = $id;
    }

    public function nome(): string
    {
        return $this->nome;
    }

    public function nacionalidade(): ?string
    {
        return $this->nacionalidade;
    }
}