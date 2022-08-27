using ClassLibrary.Interfaces;
using EntityService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityService.Data
{
    public class EntityRepository : ITestObjectRepositry<Entity, Guid>
    {
        private readonly List<Entity> entities = new();
        private readonly object locker = new();
       
        public void Add(Entity obj)
        {
            if (entities.Any(t => t.Id == obj.Id))
            {
                throw new ArgumentException("Id duplication");
            }

            lock (locker)
            {
                entities.Add(obj);
            }
        }


        public Entity Get(Guid id)
        {
            Entity? entity = entities.FirstOrDefault(t => t.Id == id);
            if (entity is null)
            {
                throw new ArgumentException("Entity with such id is not present in the system");
            }
            return entity!;
        }

        public void Remove(Entity obj)
        {
            throw new NotImplementedException();
        }
    }
}
