using ClassLibrary;
using ClassLibrary.Interfaces;

namespace TestConsoleApp
{
    public class Transaction : BaseTestObject
    {

        public Transaction(int id = -1, DateTime transactionDate = default, decimal amount = -1)
        {
            Id = id;
            TransactionDate = transactionDate;
            Amount = amount;
            Validate();
        }

        protected override void Validate()
        {
            if (Amount < 0)
            {
                throw new InvalidDataException("Amount must be > 0");
            }
            if (TransactionDate == default)
            {
                throw new InvalidDataException("Insert Date, Please");
            }
            if (Id < 0)
            {
                throw new InvalidDataException("Id is nvalid");
            }
        }
    }
}