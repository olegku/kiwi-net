``` ini

BenchmarkDotNet=v0.10.11, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.125)
Processor=Intel Core i5-3337U CPU 1.80GHz (Ivy Bridge), ProcessorCount=4
Frequency=1753827 Hz, Resolution=570.1817 ns, Timer=TSC
.NET Core SDK=2.1.2
  [Host]     : .NET Core 2.0.3 (Framework 4.6.25815.02), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.3 (Framework 4.6.25815.02), 64bit RyuJIT


```
|                      Method |      Mean |     Error |    StdDev |
|---------------------------- |----------:|----------:|----------:|
|                 ForeachPair |  78.21 us | 0.5377 us | 0.4767 us |
|                  ForeachKey |  63.20 us | 0.6250 us | 0.5219 us |
|          ForeachKeyGetValue | 274.96 us | 3.1838 us | 2.8224 us |
| ForeachKeyValueDeconstruct1 |  74.56 us | 1.2723 us | 1.1901 us |
| ForeachKeyValueDeconstruct2 | 108.98 us | 1.0501 us | 0.9823 us |
