namespace ProjectManagerDev.Services
{
    public interface IKafkaProducer
    {
        Task ProduceMessage(string topic, string message);
    }
}
