using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class ConsoleRepositoryTests
    {
        [Fact]
        public void AddingTransactionToRepository()
        {
            bool isSuccedeed = true;

            Transaction transaction = CreateTransaction();
            TransactionRepository repository = new();

            try
            {
                repository.Add(transaction);
            }
            catch (Exception)
            {
                isSuccedeed = false;
            }

            Assert.True(isSuccedeed);
        }

        [Fact]
        public void AddingTransactionDuplicateToRepository_GettingArgumentException()
        {

            Transaction transaction1 = CreateTransaction();
            Transaction transaction2 = CreateTransaction();

            TransactionRepository repository = new();

            Assert.Throws<ArgumentException>(() =>
            {
                repository.Add(transaction1);
                repository.Add(transaction2);
            });

        }

        [Fact]
        public void GettingTransaction_id_10_ReturnNotNull()
        {


            TransactionRepository repository = new();
            repository.Add(CreateTransaction(10));
            Transaction transaction = repository.Get(10);

            Assert.NotNull(transaction);
        }

        [Fact]
        public void GettingTransaction_id_15_ThrowsArgumentException()
        {

            TransactionRepository repository = new();
            repository.Add(CreateTransaction(10));
            Assert.Throws<ArgumentException>(() => { repository.Get(15); });
        }

        private static Transaction CreateTransaction(int id = 10)
        {
            decimal amount = 12.2m;
            DateTime date = DateTime.Now;
            Transaction transaction = new(id, date, amount);
            return transaction;
        }
    }
}
