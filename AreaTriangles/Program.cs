namespace AreaTriangles;

class Program
{
    static void Main()
    {
        Triangle triangle1 = new([10, 4, 5]);
        Triangle triangle2 = new([7.5, 4.5, 4.02]);
        Console.WriteLine($"Area do triangulo 1: {triangle1.GetArea()}");
        Console.WriteLine($"Area do triangulo 2: {triangle2.GetArea()}");
        Console.WriteLine($"Maior area: {Triangle.WhatIsBiggest([triangle1, triangle2])}");
        Teste();
    }

    static void Teste()
    {
        Console.WriteLine("Teste");
    }
}
