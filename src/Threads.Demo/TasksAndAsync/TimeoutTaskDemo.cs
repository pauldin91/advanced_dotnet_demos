namespace Threads.Demo.TasksAndAsync;

public class TimeoutTaskDemo(int timeout)
{
    private readonly CancellationTokenSource _cts = new(timeout);

    public async Task<HeavyProcessResult> HeavyProcessThatCanHangAsync()
    {
        return await HeavyProcessAsync();
    }

    private async Task<HeavyProcessResult> HeavyProcessAsync()
    {
        await Task.Delay(TimeSpan.FromMilliseconds(timeout * 2), _cts.Token);
        return new HeavyProcessResult { Result = "Success" };
    }
}