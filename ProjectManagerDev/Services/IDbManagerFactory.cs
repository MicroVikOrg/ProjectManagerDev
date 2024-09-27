using ProjectManagerDev.Models;

namespace ProjectManagerDev.Services
{
    public interface IDbManagerFactory 
    {
        DbManager<T> GetDbManager<T>() where T : BaseEntity;

    }
}
