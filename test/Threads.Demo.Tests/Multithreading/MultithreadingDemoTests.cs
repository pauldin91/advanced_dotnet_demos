using Threads.Demo.Multithreading;

namespace Threads.Demo.Tests.MultithreadingDemo;

public class MultithreadingDemoTests
{
    private static int upperBound1 = 10;
    private static int upperBound2 = 100;
    
    
    
    [Test]
    public void TestCalculateRangeSum_ShouldReturn_ExpectedResultBasedOnSeriesFormula()
    {
        var tc1= MutlithreadingDemo.CalculateRangeSum(0, upperBound1);
        var tc2= MutlithreadingDemo.CalculateRangeSum(0, upperBound2);
        var tc3 = MutlithreadingDemo.CalculateRangeSum(upperBound1,upperBound2);
        Assert.That(tc1, Is.EqualTo(55));
        Assert.That(tc2, Is.EqualTo(5050));
        
        Assert.That(tc3, Is.EqualTo(4995));
    }
    
    [Test]
    public void TestSumOfRangeUsingParallelFor_ShouldReturn_ExpectedResult()
    {
        var ar1= MutlithreadingDemo.CalculateRangeSum(0, upperBound1);
        var ar2= MutlithreadingDemo.CalculateRangeSum(0, upperBound2);
        var ar3= MutlithreadingDemo.CalculateRangeSum(upperBound1, upperBound2);
        
        var tc1= MutlithreadingDemo.SumOfRangeUsingParallelFor(0, upperBound1);
        var tc2= MutlithreadingDemo.SumOfRangeUsingParallelFor(0, upperBound2);
        var tc3= MutlithreadingDemo.SumOfRangeUsingParallelFor(upperBound1, upperBound2);
        Assert.That(tc1, Is.EqualTo(ar1));
        Assert.That(tc2, Is.EqualTo(ar2));
        Assert.That(tc3, Is.EqualTo(ar3));
        
    }

    
}