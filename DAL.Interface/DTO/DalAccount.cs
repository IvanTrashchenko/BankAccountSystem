namespace DAL.Interface.DTO
{
    public class DalAccount
    {
        public string AccountNumber { get; set; }

        public int BonusPoints { get; set; }

        public decimal Balance { get; set; }

        public int Type { get; set; }

        public DalHolder Holder { get; set; }
    }
}
