using ClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    public class TransactionRepository : ITestObjectRepositry<Transaction>
    {
        private List<Transaction> transactions = new List<Transaction>();
        /// <summary>
        /// Adding transaction to inner collection
        /// </summary>
        /// <param name="obj">transaction</param>
        /// <exception cref="ArgumentException">If id is duplicated</exception>
        public void Add(Transaction obj)
        {
            if(transactions.Any(t=>t.Id == obj.Id))
            {
                throw new ArgumentException("Id duplication");
            }
            transactions.Add(obj);
        }
        /// <summary>
        /// Getting transaction by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Transaction from inner collection</returns>
        /// <exception cref="ArgumentException">If id is not present</exception>
        public Transaction Get(int id)
        {
            Transaction? transaction = transactions.FirstOrDefault(t => t.Id == id);
            if(transaction is null)
            {
                throw new ArgumentException("Transaction with such id is not present in the system");
            }
            return transaction!;
        }

        public void Remove(Transaction obj)
        {
            throw new NotImplementedException();
        }
    }
}
