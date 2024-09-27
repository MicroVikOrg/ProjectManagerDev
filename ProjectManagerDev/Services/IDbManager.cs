using ProjectManagerDev.Models;
using Task = System.Threading.Tasks.Task;

namespace ProjectManagerDev.Services
{
    public interface IDbManager<T> where T : BaseEntity
    {
        Task SaveAsync(T entity);
        
        Task SaveAsync(T entity, string topic);

        Task UpdateAsync(T entity);

        Task UpdateAsync(T entity, string topic);

  

    }
}
