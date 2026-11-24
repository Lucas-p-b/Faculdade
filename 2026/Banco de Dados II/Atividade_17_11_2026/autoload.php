<?php
declare(strict_types=1);

spl_autoload_register(function (string $classe): void {
    $prefixo = 'Biblioteca\\';
    $diretorioBase = __DIR__ . '/src/';

    if (!str_starts_with($classe, $prefixo)) {
        return;
    }

    $classeRelativa = substr($classe, strlen($prefixo));
    $arquivo = $diretorioBase . str_replace('\\', '/', $classeRelativa) . '.php';

    if (file_exists($arquivo)) {
        require_once $arquivo;
    }
});