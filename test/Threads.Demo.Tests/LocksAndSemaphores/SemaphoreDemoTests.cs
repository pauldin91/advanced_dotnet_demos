using System.Diagnostics;
using Threads.LocksAndSemaphores.Demo;

namespace Threads.Demo.LocksAndSemaphores.Tests;

public class SemaphoreDemoTests
{
    private const int ThreadNum = 100;
    private const int RequestProcessingSimulationTimeInMsecs = 200; 
    [Test]
    public void TestRequestSimulationWithNoLimit_ShouldAlways_HasUnpredictedQueuedRequests()
    {
        var sd = new SemaphoreDemo(RequestProcessingSimulationTimeInMsecs);
        var count = new List<int>();
        var threads = new List<Thread>();
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        Parallel.For(0, ThreadNum, (i, state) =>
        {
            var t = new Thread(() => sd.RequestSimulationWithNoLimit($"#{i}"));
            t.Start();
            count.Add(sd.Count);
            threads.Add(t);
        });
        threads.AsParallel().ForAll(t => t.Join());
        stopwatch.Stop();
        Assert.That(stopwatch.ElapsedMilliseconds, Is.GreaterThanOrEqualTo(RequestProcessingSimulationTimeInMsecs));
        Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThanOrEqualTo(RequestProcessingSimulationTimeInMsecs*2));
        Console.WriteLine($"Elapsed time is : {stopwatch.Elapsed}");
        Console.Write($"Threads in queue {string.Join(",",count)}\n");
    
    }
    [Test]
    public void TestRequestSimulation_ShouldAlways_HasNoMoreThan3QueuedRequests()
    {
        var expectedElapsed = RequestProcessingSimulationTimeInMsecs*ThreadNum/(3*1000)+1;
        var sd = new SemaphoreDemo(RequestProcessingSimulationTimeInMsecs);
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        Parallel.For(0, ThreadNum, (i, state) =>
        {
            var t = new Thread(() => sd.RequestSimulation($"#{i}"));
            t.Start();
            t.Join();
            Assert.That(sd.Count, Is.LessThanOrEqualTo(3));
        });
        stopwatch.Stop();
        Console.WriteLine($"Elapsed time is : {stopwatch.Elapsed}");
        Assert.That(stopwatch.ElapsedMilliseconds/1000, Is.GreaterThanOrEqualTo(expectedElapsed-1));
        Assert.That(stopwatch.ElapsedMilliseconds/1000, Is.LessThanOrEqualTo(expectedElapsed));
    }
}