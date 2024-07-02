// Tempo sem paralelismo: 61179 ms
// Tempo com paralelismo no loop externo: 9876 ms
// Tempo com paralelismo excessivo: 10584 ms

using System.Collections.Concurrent;
using System.Diagnostics;

class MatrixMultiplication
{
    static void Main()
    {
        int matARows = 3000;
        int matACols = 3000;
        int matBCols = 3000;

        double[,] matA = GenerateMatrix(matARows, matACols);
        double[,] matB = GenerateMatrix(matACols, matBCols);
        double[,] resultSequential = new double[matARows, matBCols];
        double[,] resultParallel = new double[matARows, matBCols];
        double[,] resultExcessiveParallel = new double[matARows, matBCols];

        // Multiplicação sem paralelismo
        Stopwatch stopwatch = Stopwatch.StartNew();
        MultiplyMatricesSequential(matA, matB, resultSequential);
        stopwatch.Stop();
        Console.WriteLine($"Tempo sem paralelismo: {stopwatch.ElapsedMilliseconds} ms");

        // Multiplicação com paralelismo no loop externo
        stopwatch.Restart();
        MultiplyMatricesParallel(matA, matB, resultParallel);
        stopwatch.Stop();
        Console.WriteLine($"Tempo com paralelismo no loop externo: {stopwatch.ElapsedMilliseconds} ms");

        // Multiplicação com paralelismo excessivo (loops externo e médio)
        stopwatch.Restart();
        MultiplyMatricesExcessiveParallel(matA, matB, resultExcessiveParallel);
        stopwatch.Stop();
        Console.WriteLine($"Tempo com paralelismo excessivo: {stopwatch.ElapsedMilliseconds} ms");


        // Multiplicação com paralelismo usando Partitioner
        stopwatch.Restart();
        MultiplyMatricesParallelWithPartitioner(matA, matB, resultExcessiveParallel);
        stopwatch.Stop();
        Console.WriteLine($"Tempo com paralelismo usando Partitioner: {stopwatch.ElapsedMilliseconds} ms");
    }

    static double[,] GenerateMatrix(int rows, int cols)
    {
        double[,] matrix = new double[rows, cols];
        Random rand = new Random();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = rand.NextDouble();
            }
        }
        return matrix;
    }

    static void MultiplyMatricesSequential(double[,] matA, double[,] matB, double[,] result)
    {
        int matARows = matA.GetLength(0);
        int matACols = matA.GetLength(1);
        int matBCols = matB.GetLength(1);

        for (int i = 0; i < matARows; i++)
        {
            for (int j = 0; j < matBCols; j++)
            {
                double temp = 0;
                for (int k = 0; k < matACols; k++)
                {
                    temp += matA[i, k] * matB[k, j];
                }
                result[i, j] = temp;
            }
        }
    }

    static void MultiplyMatricesParallel(double[,] matA, double[,] matB, double[,] result)
    {
        int matARows = matA.GetLength(0);
        int matACols = matA.GetLength(1);
        int matBCols = matB.GetLength(1);

        Parallel.For(0, matARows, i =>
        {
            for (int j = 0; j < matBCols; j++)
            {
                double temp = 0;
                for (int k = 0; k < matACols; k++)
                {
                    temp += matA[i, k] * matB[k, j];
                }
                result[i, j] = temp;
            }
        });
    }

    static void MultiplyMatricesParallelWithPartitioner(double[,] matA, double[,] matB, double[,] result)
    {
        int matARows = matA.GetLength(0);
        int matACols = matA.GetLength(1);
        int matBCols = matB.GetLength(1);

        Parallel.ForEach(Partitioner.Create(0, matARows), range =>
        {
            for (int i = range.Item1; i < range.Item2; i++)
            {
                for (int j = 0; j < matBCols; j++)
                {
                    double temp = 0;
                    for (int k = 0; k < matACols; k++)
                    {
                        temp += matA[i, k] * matB[k, j];
                    }
                    result[i, j] = temp;
                }
            }
        });
    }

    static void MultiplyMatricesExcessiveParallel(double[,] matA, double[,] matB, double[,] result)
    {
        int matARows = matA.GetLength(0);
        int matACols = matA.GetLength(1);
        int matBCols = matB.GetLength(1);

        Parallel.For(0, matARows, i =>
        {
            Parallel.For(0, matBCols, j =>
            {
                double temp = 0;
                for (int k = 0; k < matACols; k++)
                {
                    temp += matA[i, k] * matB[k, j];
                }
                result[i, j] = temp;
            });
        });
    }
}
