using System.Diagnostics;
using Threads.Demo.TasksAndAsync;

namespace Threads.Demo.Tests.TasksAndAsync;

public class TimeoutTaskDemoTests
{
    private const int Timeout = 500;
    [Test]
    public async Task TestHeavyProcessThatCanHang_ShouldBeCanceled_AfterSpecifiedTimeout()
    {
        var tot = new TimeoutTaskDemo(Timeout);
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        Assert.ThrowsAsync<TaskCanceledException>(async () => await tot.HeavyProcessThatCanHangAsync() );
        stopwatch.Stop();
        Assert.That(stopwatch.ElapsedMilliseconds,Is.GreaterThanOrEqualTo( Timeout));
        Assert.That(stopwatch.ElapsedMilliseconds,Is.LessThan( Timeout*2));
    }

}