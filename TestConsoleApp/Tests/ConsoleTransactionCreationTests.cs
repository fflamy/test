using TestConsoleApp;

namespace Tests
{
    public class ConsoleTransactionCreationTests
    {
        [Fact]
        public void CreatingEmptyTransaction_GettingAnException()
        {
            Assert.Throws<InvalidDataException>(() => { Transaction transaction = new Transaction(); });

        }
        [Fact]
        public void CreatingTransaction_AmountOnly_GettingAnException()
        {
            decimal amount = 12.2m;

            Assert.Throws<InvalidDataException>(() => { Transaction transaction = new Transaction(amount: amount); });

        }
        [Fact]
        public void CreatingTransaction_DatetOnly_GettingAnException()
        {
            DateTime date = DateTime.Now;

            Assert.Throws<InvalidDataException>(() => { Transaction transaction = new Transaction(transactionDate: date); });

        }
        [Fact]
        public void CreatingTransaction_AllArguments_WithNegativeAmount_GettingAnException()
        {
            decimal amount = -12.2m;
            DateTime date = DateTime.Now;
            int id = 10;

            Assert.Throws<InvalidDataException>(() => { Transaction transaction = new Transaction(id, date, amount); });

        }
        [Fact]
        public void CreatingTransaction_AllArguments_WithNegativId_GettingAnException()
        {
            decimal amount = 12.2m;
            DateTime date = DateTime.Now;
            int id = -110;

            Assert.Throws<InvalidDataException>(() => { Transaction transaction = new Transaction(id, date, amount); });

        }
        [Fact]
        public void CreatingTransaction_AllArguments_ObjectIsNotNull()
        {
            decimal amount = 12.2m;
            DateTime date = DateTime.Now;
            int id = 10;

            Transaction transaction = new Transaction(id, date, amount);

            Assert.NotNull(transaction);

        }
    }
}