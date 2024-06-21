using System.Text;

Console.WriteLine("Quantas pessoas?");
int n;
if (!int.TryParse(getLine(), out n))
{
    Console.WriteLine("Entrada padrão 1");
    n = 1;
}

float[] alturas = new float[n];
Console.WriteLine("Digite as alturas das pessoas:");

for (int i = 0; i < n; i++)
{
    Console.WriteLine($"Altura da pessoa n°{i + 1}:");
    if (!float.TryParse(getLine(), out alturas[i]))
    {
        Console.WriteLine("Entrada padrão 1.70");
        alturas[i] = 1.70f;
    }
}

StringBuilder stringAlturas = new();
foreach (var (altura, index) in alturas.Select((value, index) => (value, index)))
{
    stringAlturas.Append(altura);
    if (!(index == alturas.Length - 1))
    {
        stringAlturas.Append(", ");
    }
}
Console.WriteLine(stringAlturas);
Console.WriteLine(alturas.Average());

static string getLine(string? fallback = null)
{
    return Console.ReadLine() ?? fallback ?? "Linha vazia";
}
