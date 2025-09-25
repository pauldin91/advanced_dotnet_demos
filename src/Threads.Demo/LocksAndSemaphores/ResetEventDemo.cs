namespace Threads.LocksAndSemaphores.Demo;

public static class ResetEventDemo
{
    private static  AutoResetEvent _event = new(false);
    private static  ManualResetEventSlim _manualEvent = new(false);
    private static readonly Queue<string>  _incomingRequests = new();
    public static int Counter => _incomingRequests.Count;

    public class Producer(int processTime)
    {
        public void AutoProduce()
        {
            Thread.Sleep(processTime);
            _event.Set();
        }
        public void Produce()
        {
            while (true)
            {
                if (Counter<3)
                {
                    Thread.Sleep(processTime);
                    _manualEvent.Set();
                    _incomingRequests.Enqueue($"Request #{Counter.ToString()}");
                }
                else
                {
                    break;
                }

            }
        }
    }
    
    public class Consumer()
    {
        public void AutoConsume()
        {
            while (true)
            {
                _event.WaitOne();
                break;
            }
        }
        public void Consume()
        {
            while (true)
            {
                _manualEvent.Wait();
                
                if (Counter>0)
                    Console.WriteLine("Consumed " + _incomingRequests.Dequeue());
                else
                    break;
            }
        }
    }
}