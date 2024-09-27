using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjectManagerDev.Models;
using System.Reflection;
using Task = System.Threading.Tasks.Task;

namespace ProjectManagerDev.Services
{
    public class DbManager<T> : IDbManager<T> where T : BaseEntity
    {

        private readonly IKafkaProducer _kafkaProducer;
        private ApplicationContext db;

        public DbManager(ApplicationContext context, IKafkaProducer kafka)
        {
            db = context;
            _kafkaProducer = kafka;
        }

        public async Task SaveAsync(T entity)
        {
            
            var dbSet = (DbSet<T>)db.GetType().GetProperty(entity.GetType().Name).GetValue(db);
            await dbSet.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task SaveAsync(T entity, string topic)
        {
            var dbSet = (DbSet<T>)db.GetType().GetProperty(entity.GetType().Name).GetValue(db);
            
            await dbSet.AddAsync(entity);
            await db.SaveChangesAsync();
            await _kafkaProducer.ProduceMessage(topic, JsonConvert.SerializeObject(entity));

        }

        public async Task UpdateAsync(T entity)
        {
            var dbSet = (DbSet<T>)db.GetType().GetProperty(entity.GetType().Name).GetValue(db);
            dbSet.Update(entity);
            await db.SaveChangesAsync();

        }

        public async Task UpdateAsync(T entity, string topic)
        {
            var dbSet = (DbSet<T>)db.GetType().GetProperty(entity.GetType().Name).GetValue(db);
            dbSet.Update(entity);
            await db.SaveChangesAsync();
            await _kafkaProducer.ProduceMessage(topic, JsonConvert.SerializeObject(entity));
        }
    }
}
