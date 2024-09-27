using ProjectManagerDev.Models;

namespace ProjectManagerDev.Services
{
    public class DbManagerFactory : IDbManagerFactory
    {
        private readonly IKafkaProducer _producer;
        private ApplicationContext context;

        public DbManagerFactory(IKafkaProducer producer, ApplicationContext applicationContext)
        {
            _producer = producer;
            context = applicationContext;
        }


        public DbManager<T> GetDbManager<T>() where T : BaseEntity
        {
            return new DbManager<T>(context, _producer);
        }


    }
}
