using Threads.Demo.TasksAndAsync;

namespace Threads.Demo.Tests.TasksAndAsync;

public class ThreadUsageForAsyncTaskDemoTests
{
    [Test]
    public async Task TestMainTaskAsync_ShouldEnqueues_ProcessingThreads()
    {
        var demo = new ThreadUsageForAsyncTaskDemo();
        await demo.MainTaskAsync();
        var records = demo.Q.ToList();
        foreach (var record in records)
        {
            Console.WriteLine(record);
        }
        Assert.That(records[0].Split('.').First(),Is.EqualTo(records[1].Split('.').First()));
        //Usually true. In most cases all "after await" tasks are executed in same thread except
        //some cases where "after 2nd await" in main task is executed in 3rd thread 
        //Assert.That(records[2].Split('.').First(),Is.EqualTo(records[3].Split('.').First()));
    }
}