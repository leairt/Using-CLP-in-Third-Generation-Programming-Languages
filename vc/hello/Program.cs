 
using System.Diagnostics;

// stopwatch start
Stopwatch stopWatch = new Stopwatch();

stopWatch.Start();

// Console.WriteLine("Result: " + Brojke.solve(new int[] {8, 2, 1, 9, 15, 75}, 404));
// Console.WriteLine("Result: " + Brojke.solve(new int[] {25, 50, 75, 100, 3, 6}, 952));
Console.WriteLine("Result: " + Brojke.generate());

// stopwatch stop
stopWatch.Stop();
Console.WriteLine("Elapsed: " + stopWatch.ElapsedMilliseconds + "ms");
// Console.WriteLine(Brojke.solve(new int[] {2, 17, 453451, 566579, 5675615, 465456}, 1742343));
