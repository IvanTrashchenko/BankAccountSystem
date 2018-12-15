namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Account
    {
        public int Id { get; set; }

        [Required] public string AccountNumber { get; set; }

        public int BonusPoints { get; set; }

        public decimal Balance { get; set; }

        public int AccountTypeId { get; set; }

        public int AccountHolderId { get; set; }

        public virtual AccountHolder AccountHolder { get; set; }

        public virtual AccountType AccountType { get; set; }
    }
}