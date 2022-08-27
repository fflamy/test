using EntityService.Data;
using EntityService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class ServiceRepositoryTests
    {
        [Fact]
        public void AddingEntityToRepository()
        {
            bool isSuccedeed = true;

            Entity transaction = CreateEntity(Guid.NewGuid());
            EntityRepository entity = new();

            try
            {
                entity.Add(transaction);
            }
            catch (Exception)
            {
                isSuccedeed = false;
            }

            Assert.True(isSuccedeed);
        }

        [Fact]
        public void AddingEntityDuplicateToRepository_GettingArgumentException()
        {
            Guid id = Guid.NewGuid();
            Entity transaction1 = CreateEntity(id);
            Entity transaction2 = CreateEntity(id);

            EntityRepository entity = new();

            Assert.Throws<ArgumentException>(() =>
            {
                entity.Add(transaction1);
                entity.Add(transaction2);
            });

        }

        [Fact]
        public void GettingEntity_id_10_ReturnNotNull()
        {
            Guid id = Guid.NewGuid();

            EntityRepository entity = new();
            entity.Add(CreateEntity(id));
            Entity transaction = entity.Get(id);

            Assert.NotNull(transaction);
        }

        [Fact]
        public void GettingEntity_id_15_ThrowsArgumentException()
        {
            Guid id = Guid.NewGuid();
            EntityRepository entity = new();
            entity.Add(CreateEntity(id));
            Assert.Throws<ArgumentException>(() => { entity.Get(Guid.NewGuid()); });
        }

        private static Entity CreateEntity(Guid id)
        {

            decimal amount = 12.2m;
            Entity entity = new()
            {
                Id = id,
                Amount = amount,
            };
            return entity;
        }

    }
}
