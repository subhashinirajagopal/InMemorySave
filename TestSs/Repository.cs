using System;
using System.Collections.Generic;

namespace TestSs
{
   public class Repository<T> : IRepository<T> where T : IStoreable
   {
        private List<T> entities;
        public Repository()
        {
            entities = new List<T>();
        }

        public IEnumerable<T> All()
        {
            return entities;
        }

        public void Save(T item)
        {
            entities.Add(item);
        }

        public void Update(int id, T item)
        {
            var entityToUpdate = FindById(id);
            entityToUpdate.Name = item.Name;
        }

        public T FindById(int id)
        {
            return entities.Find(match => match.Id.Equals(id));
        }

        public void Delete(int id)
        {
            var entityToDelete = FindById(id);
            entities.Remove(entityToDelete);
        }
    }
}