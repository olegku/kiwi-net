``` ini

BenchmarkDotNet=v0.10.11, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.125)
Processor=Intel Core i5-3337U CPU 1.80GHz (Ivy Bridge), ProcessorCount=4
Frequency=1753827 Hz, Resolution=570.1817 ns, Timer=TSC
.NET Core SDK=2.1.2
  [Host]     : .NET Core 2.0.3 (Framework 4.6.25815.02), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.3 (Framework 4.6.25815.02), 64bit RyuJIT


```
|                      Method |        Mean |      Error |    StdDev |      Median |
|---------------------------- |------------:|-----------:|----------:|------------:|
|                    ForLoop1 |    402.4 us |   9.059 us |  20.07 us |    394.4 us |
|                    ForLoop2 |    407.9 us |   8.156 us |  22.33 us |    398.9 us |
|                  ForeachKey |  4,578.4 us |  90.389 us | 190.66 us |  4,517.1 us |
| ForeachKeyValueDeconstruct1 |  7,625.2 us | 115.150 us | 102.08 us |  7,587.6 us |
| ForeachKeyValueDeconstruct2 |  7,556.1 us |  75.622 us |  63.15 us |  7,551.5 us |
|                 ForeachPair |  7,721.2 us |  97.674 us |  91.36 us |  7,740.9 us |
|          ForeachKeyGetValue | 18,871.7 us | 357.883 us | 334.76 us | 18,727.7 us |
