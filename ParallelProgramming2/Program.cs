
using System.Collections.Concurrent;
using System.Diagnostics;

Stopwatch stopwatch = new();
List<long> numbers = getIntList(99999999);
long[] numbersArray = [.. numbers];

stopwatch.Start();
long sum = NormalSum(numbersArray);
stopwatch.Stop();
Console.WriteLine($"NormalSum: {sum}, Time: {stopwatch.ElapsedMilliseconds} ms");

stopwatch.Restart();
sum = ParallelSum(numbersArray);
stopwatch.Stop();
Console.WriteLine($"ParallelSum: {sum}, Time: {stopwatch.ElapsedMilliseconds} ms");

stopwatch.Restart();
sum = ParallelSumWithLocal(numbersArray);
stopwatch.Stop();
Console.WriteLine($"ParallelSumWithLocal: {sum}, Time: {stopwatch.ElapsedMilliseconds} ms");

stopwatch.Restart();
sum = ParallelSumWithPartition(numbersArray);
stopwatch.Stop();
Console.WriteLine($"ParallelSumWithPartition: {sum}, Time: {stopwatch.ElapsedMilliseconds} ms");

stopwatch.Restart();
sum = ParallelSumWithLocalWithPartition(numbersArray);
stopwatch.Stop();
Console.WriteLine($"ParallelSumWithLocalWithPartition: {sum}, Time: {stopwatch.ElapsedMilliseconds} ms");


static List<long> getIntList(long n)
{
    List<long> list = [];
    for (int i = 0; i < n; i++)
    {
        list.Add(i * 200);
    }
    return list;
}

static long NormalSum(params long[] a)
{
    long sum = 0;
    for (int i = 0; i < a.Length; i++)
    {
        sum += a[i];
    }
    return sum;
}

static long ParallelSum(params long[] a)
{
    long sum = 0;
    Parallel.For(0, a.Length, i =>
    {
        long localSum = a[i];
        Interlocked.Add(ref sum, localSum);
    });
    return sum;
}

static long ParallelSumWithLocal(params long[] a)
{
    long sum = 0;
    Parallel.For<long>(0, a.Length, () => 0, (i, loop, localSum) =>
    {
        localSum += a[i];
        return localSum;
    },
    localSum =>
    {
        Interlocked.Add(ref sum, localSum);
    });
    return sum;
}

static long ParallelSumWithPartition(params long[] a)
{
    long sum = 0;
    Parallel.ForEach(Partitioner.Create(0, a.Length), range =>
    {
        for (int i = range.Item1; i < range.Item2; i++)
        {
            long localSum = a[i];
            Interlocked.Add(ref sum, localSum);
        }
    });
    return sum;
}

static long ParallelSumWithLocalWithPartition(params long[] a)
{
    long sum = 0;
    Parallel.ForEach(Partitioner.Create(0, a.Length), range =>
    {
        long localSum = 0;
        for (int i = range.Item1; i < range.Item2; i++)
        {
            localSum += a[i];
        }
        Interlocked.Add(ref sum, localSum);
    });
    return sum;
}