namespace ORM
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AccountEntities : DbContext
    {
        public AccountEntities()
            : base("name=BankAccountDBEntities")
        {
        }

        public virtual DbSet<AccountHolder> AccountHolders { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountHolder>()
                .HasMany(e => e.Accounts)
                .WithRequired(e => e.AccountHolder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Balance)
                .HasPrecision(18, 4);

            modelBuilder.Entity<AccountType>()
                .HasMany(e => e.Accounts)
                .WithRequired(e => e.AccountType)
                .WillCascadeOnDelete(false);
        }
    }
}
