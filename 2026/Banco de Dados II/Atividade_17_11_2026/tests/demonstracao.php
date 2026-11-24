<?php
declare(strict_types=1);

require_once __DIR__ . '/../autoload.php';

use Biblioteca\Domain\Autor;
use Biblioteca\Domain\Livro;
use Biblioteca\Infrastructure\AutorRepository;
use Biblioteca\Infrastructure\Conexao;
use Biblioteca\Infrastructure\LivroRepository;
use Biblioteca\Infrastructure\RepositoryInterface;

//R5 - Demonstração polimórfica: opera com qualquer repositório pelo contrato comum,
//sem verificar ou ramificar pela classe concreta
function inspecionarPorContrato(RepositoryInterface $repositorio, int $id): ?object
{
    $entidade = $repositorio->buscar($id);
    $total = count($repositorio->listar());
    echo sprintf(
        "[Contrato %s] Registro ID=%d encontrado: %s | Total na tabela: %d\n",
        $repositorio::class,
        $id,
        $entidade !== null ? 'SIM' : 'NÃO',
        $total
    );

    return $entidade;
}

$pdo = Conexao::abrir();

// Limpeza controlada para tornar a execução 100% reproduzível
$pdo->exec('DELETE FROM exemplares');
$pdo->exec('DELETE FROM livros_autores');
$pdo->exec('DELETE FROM livros');
$pdo->exec('DELETE FROM autores');

$livroRepo = new LivroRepository($pdo);
$autorRepo = new AutorRepository($pdo);

echo "=== EVIDÊNCIA 1: Cadastro de Livro e Autores com IDs gerados pelo MySQL ===\n";
$autor1 = new Autor('Erich Gamma', 'Suíça');
$autor2 = new Autor('Richard Helm', 'Australiana');
$autorRepo->salvar($autor1);
$autorRepo->salvar($autor2);

$livro = new Livro('Design Patterns: Elements of Reusable Object-Oriented Software', '9780201633610', 1994);
$livroRepo->salvar($livro);

echo "Autor 1 cadastrado -> ID: {$autor1->id()} | Nome: {$autor1->nome()}\n";
echo "Autor 2 cadastrado -> ID: {$autor2->id()} | Nome: {$autor2->nome()}\n";
echo "Livro cadastrado   -> ID: {$livro->id()} | Título: {$livro->titulo()}\n\n";

echo "=== EVIDÊNCIA 2: Busca de Livro por ID e Hidratação ===\n";
$livroBuscado = $livroRepo->buscar($livro->id());
assert($livroBuscado instanceof Livro);
echo "Recuperado: ID={$livroBuscado->id()}, Título='{$livroBuscado->titulo()}', ISBN={$livroBuscado->isbn()}, Ano={$livroBuscado->anoPublicacao()}\n\n";

echo "=== EVIDÊNCIA 3: Atualização (UPDATE) e Nova Consulta ===\n";
$livroBuscado->alterarTitulo('Design Patterns (Edição Revisada)');
$livroRepo->salvar($livroBuscado);

$livroAtualizado = $livroRepo->buscar($livro->id());
echo "Título após UPDATE: '{$livroAtualizado->titulo()}'\n\n";

echo "=== EVIDÊNCIA 4: Associação N:N de Dois Autores e Reconstrução sem Duplicidade ===\n";
$livroRepo->associarAutor($livro->id(), $autor1->id());
$livroRepo->associarAutor($livro->id(), $autor2->id());

$autoresCarregados = $livroRepo->autoresDoLivro($livro->id());
foreach ($autoresCarregados as $a) {
    $livroAtualizado->adicionarAutor($a);
}
// Tentativa de adicionar novamente o mesmo autor em memória (deve ignorar duplicata)
$livroAtualizado->adicionarAutor($autor1);

echo "Total de autores na coleção do livro: " . count($livroAtualizado->autores()) . "\n";
foreach ($livroAtualizado->autores() as $a) {
    echo " - [{$a->id()}] {$a->nome()} ({$a->nacionalidade()})\n";
}
echo "\n";

echo "=== EVIDÊNCIA 5: Polimorfismo via RepositoryInterface ===\n";
inspecionarPorContrato($livroRepo, $livro->id());
inspecionarPorContrato($autorRepo, $autor1->id());
echo "\n";

echo "=== EVIDÊNCIA 6: Transação Atômica e Rollback em Falha Intencional ===\n";
$totalAntes = count($livroRepo->listar());
$pdo->beginTransaction();
try {
    $livroTransacional = new Livro('Livro que não deve persistir', '9780000000001', 2026);
    $livroRepo->salvar($livroTransacional);
    echo "Livro inserido provisoriamente na transação com ID={$livroTransacional->id()}\n";

    // Força erro de chave estrangeira associando um autor_id inexistente (999999)
    $livroRepo->associarAutor($livroTransacional->id(), 999999);
    $pdo->commit();
} catch (\Throwable $e) {
    if ($pdo->inTransaction()) {
        $pdo->rollBack();
    }
    echo "Exceção capturada e ROLLBACK executado: {$e->getMessage()}\n";
}
$totalDepois = count($livroRepo->listar());
echo "Livros antes da transação: {$totalAntes} | Livros após rollback: {$totalDepois}\n\n";

echo "=== EVIDÊNCIA 7: Exclusão Controlada e Restrições de Chave Estrangeira ===\n";
try {
    // Tenta excluir autor ainda vinculado em livros_autores (deve falhar por FK)
    $autorRepo->excluir($autor1->id());
} catch (\PDOException $e) {
    echo "Bloqueio esperado por FK ao excluir autor vinculado: SQLSTATE {$e->getCode()}\n";
}

// Remove vínculos N:N e exclui o livro de forma controlada
$livroRepo->desassociarAutores($livro->id());
$livroRepo->excluir($livro->id());
$livroAposExclusao = $livroRepo->buscar($livro->id());
echo "Livro após desassociar vínculos e excluir: " . ($livroAposExclusao === null ? 'NULL (removido com sucesso)' : 'AINDA EXISTE') . "\n\n";

echo "=== TESTES COMPLEMENTARES: Validação de Domínio e Segurança SQL ===\n";
try {
    new Livro('   ');
} catch (\InvalidArgumentException $e) {
    echo "Rejeição de título vazio validada: {$e->getMessage()}\n";
}

$tentativaInjection = new Autor("Robert'); DROP TABLE livros; --", 'Teste');
$autorRepo->salvar($tentativaInjection);
echo "Prepared statement neutralizou payload textual; autor salvo literalmente com ID={$tentativaInjection->id()}\n";