using System.Collections.Concurrent;

namespace Threads.Demo.TasksAndAsync;

public class ThreadUsageForAsyncTaskDemo
{
    private readonly ConcurrentQueue<string> _threadIds = new();
    public IReadOnlyCollection<string> Q =>  _threadIds;
    public async Task MainTaskAsync()
    {
        _threadIds.Enqueue($"#{Thread.CurrentThread.ManagedThreadId}. Before await in {nameof(MainTaskAsync)}");
        await SideTaskAsync();
        _threadIds.Enqueue($"#{Thread.CurrentThread.ManagedThreadId}. After 1st await in {nameof(MainTaskAsync)}");
        await Task.Delay(100);
        _threadIds.Enqueue($"#{Thread.CurrentThread.ManagedThreadId}. After 2nd await in {nameof(MainTaskAsync)}");
    }

    private async Task SideTaskAsync()
    {
        _threadIds.Enqueue($"#{Thread.CurrentThread.ManagedThreadId}. Before await in {nameof(SideTaskAsync)}");
        await Task.Delay(100);
        _threadIds.Enqueue($"#{Thread.CurrentThread.ManagedThreadId}. After 1st await in {nameof(SideTaskAsync)}");
        await Task.Delay(100);
        _threadIds.Enqueue($"#{Thread.CurrentThread.ManagedThreadId}. After 2nd await in {nameof(SideTaskAsync)}");
    }
}