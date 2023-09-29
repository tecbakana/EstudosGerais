using MassTransit;

namespace GettingStarted
{
    public interface IConsumer
    {
        public ILogger<MessageConsumer> _logger { get; set; }
        public void MessageConsumer(ILogger<MessageConsumer> logger);
        public Task Consume(ConsumeContext<Message> context);
    }
}
