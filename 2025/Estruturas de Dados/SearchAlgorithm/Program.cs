using System;

class Program
{
    static void Main()
    {
        string[] vetor = { "Lucas", "2", "João", "8", "Pedro", "5", "10", "Carlos", "20", "Fernanda" };

        Console.Write("Digite o nome ou número que deseja buscar: ");
        string busca = Console.ReadLine();

        bool encontrado = false;
        int posicao = -1;

        for (int i = 0; i < vetor.Length; i++)
        {
            if (vetor[i].Equals(busca, StringComparison.OrdinalIgnoreCase))
            {
                encontrado = true;
                posicao = i;
                break;
            }
        }

        if (encontrado)
        {
            Console.WriteLine($"Valor encontrado na posição: {posicao}");
        }
        else
        {
            Console.WriteLine("Não encontrado.");
        }
    }
}
