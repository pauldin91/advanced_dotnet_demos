namespace Threads.Demo.TasksAndAsync;

public class TimeoutTaskDemo(int timeout)
{
    private readonly CancellationTokenSource _cts= new(timeout);

    public async Task<HeavyProcessResult> HeavyProcessThatCanHangAsync()
    {
        return await HeavyProcessAsync(_cts.Token);
    }

    private async Task<HeavyProcessResult> HeavyProcessAsync(CancellationToken token)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(timeout * 2),_cts.Token);
        return new HeavyProcessResult{Result= "Success"};
    }

}