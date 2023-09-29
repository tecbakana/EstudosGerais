using MassTransit;

namespace GettingStarted;

public class Worker : BackgroundService
{
    readonly IBus _bus;

    public Worker(IBus bus)
    {
        _bus = bus;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _bus.Publish(new Message() { Text=$"Mensagem enviada às {DateTimeOffset.Now}"});
            await Task.Delay(1000, stoppingToken);
        }
    }
}
