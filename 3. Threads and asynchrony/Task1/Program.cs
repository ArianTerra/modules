using System.Diagnostics;

Random r = new Random();

// I increased array size to 10000000 elements. Note that takes approx. 155mb of RAM.
decimal[] arr = Enumerable.Range(0, 10000000).Select(_ => (decimal)r.NextDouble()).ToArray();

// Without optimization (approx.  355ms)
decimal sum = 0;
var sw = Stopwatch.StartNew();

foreach (var item in arr)
{
    sum += item;
}

sw.Stop();
var time = sw.ElapsedMilliseconds;
Console.WriteLine("Without optimization: " + time + "ms, sum: " + sum);

// Using multiple tasks (approx. 265ms)
// Here multiple tasks are created. Number of tasks (threads) corresponds to number of logical processors.
// Then each task sums all numbers in corresponding part of array.
var sw2 = Stopwatch.StartNew();
var sum2 = ParallelSum(arr, Environment.ProcessorCount);
sw2.Stop();
var time2 = sw2.ElapsedMilliseconds;
Console.WriteLine("Using multiple Task.Run(): " + time2 + "ms, sum: " + sum2);

Console.WriteLine($"Second method is {(1 - (double)time2 / time):P} faster");

static decimal ParallelSum(decimal[] array, int threads)
{
    decimal total = 0;
    decimal[] sums = new decimal[threads];
    Task[] tasks = new Task[threads];
    for (int i = 0; i < threads; i++)
    {
        int tmp = i;
        tasks[i] = Task.Run(() => SubArraySumTask(tmp, array, sums, threads));
    }

    Task.WaitAll(tasks);

    for (int i = 0; i < threads; i++)
    {
        total += sums[i];
    }

    return total;
}

static void SubArraySumTask(int id, decimal[] array, decimal[] sum, int threads)
{
    for (int i = id * (array.Length / threads); i < (id + 1) * array.Length / threads; i++)
    {
        sum[id] += array[i];
    }
}