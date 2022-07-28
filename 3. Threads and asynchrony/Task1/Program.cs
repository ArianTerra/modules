using System.Diagnostics;

Random r = new Random();

decimal[] arr = Enumerable.Range(0, 1000000).Select(_ => (decimal)r.NextDouble()).ToArray();
decimal sum = 0;

var sw = Stopwatch.StartNew();

foreach (var item in arr)
{
    sum += item;
}

sw.Stop();
Console.WriteLine(sw.ElapsedMilliseconds);