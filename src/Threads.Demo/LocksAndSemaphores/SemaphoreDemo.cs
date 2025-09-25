using System.Collections.Concurrent;

namespace Threads.LocksAndSemaphores.Demo;

public class SemaphoreDemo(int processTime) : IDisposable
{
    private readonly ConcurrentQueue<string> _queue = new();
    private readonly SemaphoreSlim _semaphore = new(3,maxCount:3);
    
    public int Count => _queue.Count;

    public void RequestSimulation(string item)
    {
        try
        {
            _semaphore.Wait();  
            ProcessRequest(item);
        }
        finally
        {
            _semaphore.Release();   
        }
    }

    public void RequestSimulationWithNoLimit(string item)
    {
        ProcessRequest(item);
    }
    private void ProcessRequest(string item)
    {
        _queue.Enqueue(item);
        Thread.Sleep(processTime);
        Console.WriteLine($"Request {item} has been processed");
        _queue.TryDequeue(out _);
    }

    public void Dispose()
    {
        _queue.Clear();
        _semaphore.Dispose();
    }
}