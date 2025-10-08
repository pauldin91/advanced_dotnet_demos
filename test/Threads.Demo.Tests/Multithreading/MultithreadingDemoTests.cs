using Threads.Demo.Multithreading;

namespace Threads.Demo.Tests.MultithreadingDemo;

public class MultithreadingDemoTests
{
    private static readonly (int, int)[] _bounds = [(0, 10), (0, 100), (10, 100)];
    private static readonly int[] _tcs = [55, 5050, 4995];


    [Test]
    public void TestCalculateRangeSum_ShouldReturn_ExpectedResultBasedOnSeriesFormula()
    {
        for (var i = 0; i < _bounds.Length; i++)
        {
            var tc = MutlithreadingDemo.CalculateRangeSum(_bounds[i].Item1, _bounds[i].Item2);
            Assert.That(tc, Is.EqualTo(_tcs[i]));
        }
    }

    [Test]
    public void TestSumOfRangeUsingParallelFor_ShouldReturn_ExpectedResult()
    {
        for (var i = 0; i < _bounds.Length; i++)
        {
            var ar1 = MutlithreadingDemo.CalculateRangeSum(_bounds[i].Item1, _bounds[i].Item2);
            var tc1 = MutlithreadingDemo.SumOfRangeUsingParallelFor(_bounds[i].Item1, _bounds[i].Item2);
            Assert.That(tc1, Is.EqualTo(ar1));
        }
    }
}