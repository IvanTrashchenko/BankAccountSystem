namespace DAL.Interface.DTO
{
    public class DalAccount : IEntity
    {
        public int Id { get; set; }

        public string AccountNumber { get; set; }

        public int BonusPoints { get; set; }

        public decimal Balance { get; set; }

        public DalAccountStatus Status { get; set; }

        public DalHolder Holder { get; set; }
    }
}
