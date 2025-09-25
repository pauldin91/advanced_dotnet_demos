namespace Threads.LocksAndSemaphores.Demo;

public class ReadWriteLockDemo(int waitTime) : IDisposable
{
    private readonly ReaderWriterLockSlim _lock = new();
    private readonly Dictionary<int, string> _cache = new();
    
    public int Count => _cache.Count;
    public void Add(int key, string value)
    {
        bool lockTaken = false;
        try
        {
            _lock.EnterWriteLock();
            lockTaken = true;
            Thread.Sleep(waitTime);
            _cache[key] = value;

        }
        finally
        {
            if (lockTaken)
                _lock.ExitWriteLock();
        }
    }

    public string Get(int key)
    {
        bool lockTaken = false;
        
        try
        {
            _lock.EnterReadLock();
            lockTaken = true;
            _cache.TryGetValue(key, out var value);
            return value;
        }
        finally
        {
            if (lockTaken)
                _lock.ExitReadLock();
        }
    }

    public void Dispose()
    {
        _lock.Dispose();
    }
}