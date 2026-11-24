<?php
declare(strict_types=1);

namespace Biblioteca\Infrastructure;

final class Conexao
{
    public static function abrir(): \PDO
    {
        self::carregarEnvSeExistir(__DIR__ . '/../../.env');

        $host = getenv('DB_HOST') ?: '127.0.0.1';
        $nome = getenv('DB_NAME') ?: 'biblioteca_orm';
        $usuario = getenv('DB_USER') ?: 'biblioteca';
        $senha = getenv('DB_PASS') ?: '';

        $dsn = sprintf('mysql:host=%s;dbname=%s;charset=utf8mb4', $host, $nome);

        return new \PDO($dsn, $usuario, $senha, [
            \PDO::ATTR_ERRMODE => \PDO::ERRMODE_EXCEPTION,
            \PDO::ATTR_DEFAULT_FETCH_MODE => \PDO::FETCH_ASSOC,
            \PDO::ATTR_EMULATE_PREPARES => false,
        ]);
    }

    private static function carregarEnvSeExistir(string $caminho): void
    {
        if (!is_file($caminho)) {
            return;
        }

        $linhas = file($caminho, FILE_IGNORE_NEW_LINES | FILE_SKIP_EMPTY_LINES);
        if ($linhas === false) {
            return;
        }

        foreach ($linhas as $linha) {
            $linha = trim($linha);
            if ($linha === '' || str_starts_with($linha, '#') || !str_contains($linha, '=')) {
                continue;
            }

            [$chave, $valor] = explode('=', $linha, 2);
            $chave = trim($chave);
            $valor = trim($valor, " \t\n\r\0\x0B\"'");

            if (getenv($chave) === false) {
                putenv("$chave=$valor");
            }
        }
    }
}