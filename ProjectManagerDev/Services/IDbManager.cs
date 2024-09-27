using ProjectManagerDev.Models;
using Task = System.Threading.Tasks.Task;

namespace ProjectManagerDev.Services
{
    public interface IDbManager <T> where T : BaseEntity
    {

        Task SaveAsync(T entity);

        Task<T> SaveAsync(T entity, IKafkaProducer kafkaProducer);


    }
}
