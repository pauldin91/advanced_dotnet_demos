namespace Threads.Demo.Multithreading;

public class MutlithreadingDemo
{
    public static object _lock = new();
    /// <summary>
    /// This is a demo of parallel for usage.
    /// This particular function has O(n) complexity and can be simply solved using The CalculateRangeSum formula in O(1) time
    /// However it provides a simple example on how paraller for should be syntaxed
    /// </summary>
    /// <param name="lowerBound"></param>
    /// <param name="upperBound"></param>
    /// <returns></returns>
    public static int SumOfRangeUsingParallelFor(int lowerBound,int upperBound)
    {
        int sum1 = 0;
        
        Parallel.For(0, lowerBound+1, (i) =>
        {
            Interlocked.Add(ref sum1, i);

        });
        int sum2 = 0;
        Parallel.For(0, upperBound+1, (i) =>
        {
            Interlocked.Add(ref sum2, i);

        });

        return sum2-sum1;
    }
    public static int CalculateRangeSum(int  lowerBound, int upperBound)
    {
        return upperBound*(upperBound+1)/2 - lowerBound*(lowerBound+1)/2 ;
    }
}