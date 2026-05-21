using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, string> rastreios = new Dictionary<string, string>();
        bool continuar = true;

        Console.WriteLine("=== Sistema de Cadastro de Rastreio e Código de Barras ===\n");

        Console.Write("Quantos registros deseja inserir? ");
        int quantidade = int.Parse(Console.ReadLine());

        for (int i = 0; i < quantidade; i++)
        {
            Console.WriteLine($"\nCadastro {i + 1} de {quantidade}");

            Console.Write("Informe o código de rastreio: ");
            string rastreio = Console.ReadLine();

            if (rastreios.ContainsKey(rastreio))
            {
                Console.WriteLine("Este código de rastreio já está cadastrado. Tente outro.");
                i--; 
                continue;
            }

            Console.Write("Informe o código de barras da encomenda: ");
            string codigoBarras = Console.ReadLine();

            if (rastreios.ContainsValue(codigoBarras))
            {
                Console.WriteLine("Este código de barras já está vinculado a outro rastreio!");
                i--;
                continue;
            }

            rastreios.Add(rastreio, codigoBarras);

            Console.WriteLine("Cadastro realizado com sucesso!");
        }

        while (continuar)
        {
            Console.WriteLine("\n=== MENU DE CONSULTA ===");
            Console.WriteLine("1 - Buscar por código de rastreio");
            Console.WriteLine("2 - Buscar por código de barras");
            Console.WriteLine("3 - Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("\nDigite o código de rastreio: ");
                    string buscaRastreio = Console.ReadLine();

                    if (rastreios.ContainsKey(buscaRastreio))
                    {
                        Console.WriteLine($"Código de barras vinculado: {rastreios[buscaRastreio]}");
                    }
                    else
                    {
                        Console.WriteLine("Nenhum registro encontrado para este código de rastreio.");
                    }
                    break;

                case "2":
                    Console.Write("\nDigite o código de barras: ");
                    string buscaBarras = Console.ReadLine();

                    bool encontrado = false;

                    foreach (var item in rastreios)
                    {
                        if (item.Value == buscaBarras)
                        {
                            Console.WriteLine($"Código de rastreio correspondente: {item.Key}");
                            encontrado = true;
                            break;
                        }
                    }

                    if (!encontrado)
                    {
                        Console.WriteLine("Nenhum registro encontrado para este código de barras.");
                    }
                    break;

                case "3":
                    continuar = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }

        Console.WriteLine("\nPrograma encerrado. Obrigado por utilizar o sistema!");
    }
}
