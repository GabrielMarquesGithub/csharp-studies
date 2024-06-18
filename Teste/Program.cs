using System;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            // Teste  
            Console.WriteLine("Digite uma frase.");
            string frase = GetLine("Nenhuma frase foi escrita.");

            Console.WriteLine($"Essa foi a frase escrita: {frase}");

            // Calculadora
            try
            {
                Console.WriteLine("Digite um numero para ser somado.");
                int numero1 = int.Parse(GetLine("0"));

                Console.WriteLine("Digite outro numero para ser somado.");
                int numero2 = int.Parse(GetLine("0"));

                Console.WriteLine($"A soma dos numeros é: {Soma(numero1, numero2)}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao calcular: {e.Message}");
            }



        }

        private static int Soma(int a, int b)
        {
            return a + b;
        }

        private static string GetLine(string fallBack)
        {
            string? input = Console.ReadLine();
            return string.IsNullOrEmpty(input) ? fallBack : input;
        }
    }
}
