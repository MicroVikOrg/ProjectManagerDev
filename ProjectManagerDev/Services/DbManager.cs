using Microsoft.EntityFrameworkCore;
using ProjectManagerDev.Models;
using Task = System.Threading.Tasks.Task;

namespace ProjectManagerDev.Services
{
    public class DbManager<T> : IDbManager<T> where T : BaseEntity
    {

        private readonly IKafkaProducer _kafkaProducer;
        private ApplicationContext db;

        public DbManager(ApplicationContext context,IKafkaProducer kafka)
        {
            db = context;
            _kafkaProducer = kafka;
        }

        public async Task SaveAsync(T entity)
        {
            var typeName = entity.GetType().Name;
            var prop = (DbSet<BaseEntity>)db.GetType().GetProperty(typeName).GetValue(db);
            
            
           

  
        }

        public async Task<T> SaveAsync(T entity, IKafkaProducer kafkaProducer)
        {
            throw new NotImplementedException();
        }
    }
}
