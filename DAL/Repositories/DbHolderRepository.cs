using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM;
using ORM.Mappers;

namespace DAL.Repositories
{
    //not used
    public class DbHolderRepository : IRepository<DalHolder>
    {
        #region IRepository implementation

        public IEnumerable<DalHolder> GetAll()
        {
            using (var context = new AccountEntities())
            {
                foreach (var i in context.AccountHolders)
                {
                    yield return i.ToDalHolder();
                }
            }
        }

        public void Create(DalHolder holder)
        {
            if (holder == null)
            {
                throw new ArgumentNullException($"{nameof(holder)} cannot be null.");
            }

            using (var context = new AccountEntities())
            {
                context.AccountHolders.Add(holder.ToDbHolder());
                context.SaveChanges();
            }
        }

        public void Delete(DalHolder holder)
        {
            if (holder == null)
            {
                throw new ArgumentNullException($"{nameof(holder)} cannot be null.");
            }

            using (var context = new AccountEntities())
            {
                var dbHol = context.AccountHolders.SingleOrDefault(x => x.HolderNumber == holder.HolderNumber);

                if (dbHol == null)
                {
                    throw new InvalidOperationException($"{holder} is not found or ambiguous.");
                }

                context.AccountHolders.Remove(dbHol);
                context.SaveChanges();
            }
        }

        public void Update(DalHolder holder)
        {
            if (holder == null)
            {
                throw new ArgumentNullException($"{nameof(holder)} cannot be null.");
            }

            using (var context = new AccountEntities())
            {
                var dbHol = context.AccountHolders.SingleOrDefault(x => x.HolderNumber == holder.HolderNumber);

                if (dbHol == null)
                {
                    throw new InvalidOperationException($"{holder} not found or ambiguous.");
                }

                dbHol.Name = holder.FirstName;
                dbHol.Surname = holder.LastName;
                dbHol.Email = holder.Email;
                context.SaveChanges();
            }
        }

        public DalHolder GetByNumber(string number)
        {
            if (number == null)
            {
                throw new ArgumentNullException($"{nameof(number)} cannot be null.");
            }

            using (var context = new AccountEntities())
            {
                var dbHol = context.AccountHolders.SingleOrDefault(x => x.HolderNumber == number);

                if (dbHol == null)
                {
                    throw new InvalidOperationException($"{number} not found or ambiguous.");
                }

                return dbHol.ToDalHolder();
            }
        }

        #endregion
    }
}
