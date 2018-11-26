namespace DAL.Interface.DTO
{
    public class DalHolder : IEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string HolderNumber { get; set; }
    }
}
