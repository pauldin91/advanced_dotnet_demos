using System.Collections.Concurrent;
using System.Diagnostics;
using Threads.LocksAndSemaphores.Demo;

namespace Threads.Demo.LocksAndSemaphores.Tests;

public class ReadWriteLockDemoTests
{
    
    private const int WaitTime = 200;
    private const int ThreadNum = 3;

    [Test]
    public void TestAddToCache_ShouldWait_ForWriteToComplete()
    {
        var rwl = new ReadWriteLockDemo(WaitTime);
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var bag = new ConcurrentBag<Thread>();
        Parallel.For(0, ThreadNum, (i, state) =>
        {
            var w = new Thread(() => rwl.Add(i, $"Point {i}"));
            w.Start();
            bag.Add(w);
        });
        bag.AsParallel().ForAll(w => w.Join());
        stopwatch.Stop();
        
        Assert.That(stopwatch.ElapsedMilliseconds, Is.GreaterThanOrEqualTo(WaitTime*ThreadNum));
        Console.WriteLine(stopwatch.ElapsedMilliseconds);
    }
    
    [Test]
    public void TestAddToCache_ShouldNotWait_ForWriteToComplete()
    {
        var rwl = new ReadWriteLockDemo(WaitTime);
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var bag = new ConcurrentBag<Thread>();
        int key = 1;
        Parallel.For(0, ThreadNum, (i, state) =>
        {
            Thread w;
            if (i%2 == 1)
            {
                w = new Thread(() => rwl.Add(key, $"Point {i}"));
            }
            else
            {
                w = new Thread(() => rwl.Get(key));
            }

            w.Start();
            
            bag.Add(w);
        });
        bag.AsParallel().ForAll(w => w.Join());
        stopwatch.Stop();
        
        Assert.That(stopwatch.ElapsedMilliseconds, Is.GreaterThanOrEqualTo(WaitTime));
        Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThanOrEqualTo(WaitTime*(ThreadNum-1)));
        Console.WriteLine(stopwatch.ElapsedMilliseconds);
    }
}