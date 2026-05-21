//atividade pag. 39 - 42

using System;
using System.Text;

public enum TerrainEnum
{
    GRASS,
    SAND,
    WATER,
    WALL
}

public static class TerrainEnumExtensions
{
    public static ConsoleColor GetColor(this TerrainEnum terrain)
    {
        switch (terrain)
        {
            case TerrainEnum.GRASS: return ConsoleColor.Green;
            case TerrainEnum.SAND: return ConsoleColor.Yellow;
            case TerrainEnum.WATER: return ConsoleColor.Blue;
            case TerrainEnum.WALL: return ConsoleColor.DarkGray;
            default: return ConsoleColor.Gray;
        }
    }

    public static char GetChar(this TerrainEnum terrain)
    {
        switch (terrain)
        {
            case TerrainEnum.GRASS: return '\u25A0'; // quadrado sólido
            case TerrainEnum.SAND: return '\u25CB'; // círculo vazio
            case TerrainEnum.WATER: return '\u2248'; // onda
            case TerrainEnum.WALL: return '\u25CF'; // círculo sólido
            default: return '?';
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        TerrainEnum[,] map =
        {
            { TerrainEnum.SAND, TerrainEnum.SAND, TerrainEnum.SAND, TerrainEnum.SAND, TerrainEnum.GRASS, TerrainEnum.GRASS, TerrainEnum.GRASS, TerrainEnum.GRASS, TerrainEnum.GRASS, TerrainEnum.GRASS },
            { TerrainEnum.WATER, TerrainEnum.WATER, TerrainEnum.WATER, TerrainEnum.WATER, TerrainEnum.WATER, TerrainEnum.WATER, TerrainEnum.WATER, TerrainEnum.WALL, TerrainEnum.WATER, TerrainEnum.WATER }
        };

        Console.OutputEncoding = Encoding.UTF8;

        for (int row = 0; row < map.GetLength(0); row++)
        {
            for (int column = 0; column < map.GetLength(1); column++)
            {
                Console.ForegroundColor = map[row, column].GetColor();
                Console.Write(map[row, column].GetChar() + " ");
            }
            Console.WriteLine();
        }

        Console.ForegroundColor = ConsoleColor.Gray;
    }
}
