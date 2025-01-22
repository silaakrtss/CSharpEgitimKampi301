using CSharpEgitimKampi301.DataAccsessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.DataAccsessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {

        KampContext context= new KampContext();
        private readonly DbSet<T> _object;

        public GenericRepository()
        {
            _object= context.Set<T>();
        }
        public void delete(T entity)
        {
            var deletedEntity= context.Entry<T>(entity);
            deletedEntity.State= EntityState.Deleted;
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
           return _object.ToList();
        }

        public T GetByI(int id)
        {
            return _object.Find(id);
        }

        public void insert(T entity)
        {
            var addedEntitiy = context.Entry<T>(entity);
            addedEntitiy.State= EntityState.Added;
            context.SaveChanges();
        }

        public void update(T entity)
        {
           var updateEntity= context.Entry<T>(entity);
            updateEntity.State= EntityState.Modified;
            context.SaveChanges();
        }
    }
}
