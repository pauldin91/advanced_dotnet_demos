using System.Diagnostics;
using Threads.LocksAndSemaphores.Demo;

namespace Threads.Demo.LocksAndSemaphores.Tests;

public class ResetEventDemoTests
{
    [Test]
    public void TestConsume_ShouldAutoReset_EventAfterTimeElapsed()
    {
        var producer = new ResetEventDemo.Producer(100);
        var consumer = new ResetEventDemo.Consumer();
        var stopwatch = new Stopwatch();
        var p = new Thread(() =>
        {
            producer.AutoProduce();
        });
        var c = new Thread(() =>
        {
            consumer.AutoConsume();
        });
        stopwatch.Start();
        p.Start();
        p.Join();
        c.Start();
        c.Join();
        stopwatch.Stop();
        Assert.That(stopwatch.ElapsedMilliseconds, Is.GreaterThanOrEqualTo(100));
        Console.WriteLine($"Time Elapsed: {stopwatch.ElapsedMilliseconds}");
        
    }
    [Test]
    public void TestConsume_ShouldNotReset_EventAfterTimeElapsed()
    {
        var producer = new ResetEventDemo.Producer(100);
        var consumer = new ResetEventDemo.Consumer();
        var stopwatch = new Stopwatch();
        var p = new Thread(() =>
        {
            producer.Produce();
        });
        var c = new Thread(() =>
        {
            consumer.Consume();
        });
        stopwatch.Start();
        p.Start();
        p.Join();
        c.Start();
        c.Join();
        stopwatch.Stop();
        Assert.That(stopwatch.ElapsedMilliseconds, Is.GreaterThanOrEqualTo(100));
        Assert.That(ResetEventDemo.Counter, Is.EqualTo(0));
        Console.WriteLine($"Time Elapsed: {stopwatch.ElapsedMilliseconds}");
        
    }
}