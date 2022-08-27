using ClassLibrary;

namespace EntityService.Models
{
    public class Entity : BaseTestObject<Guid>
    {
        public DateTime OperationDate { get; set; }
        public Entity()
        {
            this.Id = Guid.NewGuid();
            this.OperationDate = DateTime.Now;
        }
        protected override void Validate()
        {
            if (Amount < 0)
            {
                throw new InvalidDataException("Amount must be > 0");
            }
        }
    }
}
