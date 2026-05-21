using BubbleSort;

Console.WriteLine("Ordenação com Bubble Sort");
Console.WriteLine("");

string[] arrStr = new string[] { "B", "D", "A", "C" };

foreach (var str in arrStr) Console.Write($"[{str}] ");

var arrOrdered = BubbleSort.BubbleSort.Sort<string>(arrStr);

Console.WriteLine("");
Console.WriteLine("Vetor Ordenado");
Console.WriteLine("");
foreach (var str in arrOrdered) Console.Write($"[{str}] ");
