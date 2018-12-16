using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Repository;

namespace DAL.Fake.Repositories
{
    //not used
    public class HolderRepository : IRepository<DalHolder>
    {
        #region Constructors

        public HolderRepository()
        {
            Holders = new List<DalHolder>();
        }

        public HolderRepository(IEnumerable<DalHolder> holders)
        {
            Holders = new List<DalHolder>(holders);
        }

        #endregion

        #region Property

        public List<DalHolder> Holders { get; set; }

        #endregion

        #region IRepository Implementation

        public IEnumerable<DalHolder> GetAll()
        {
            return Holders;
        }

        public void Create(DalHolder holder)
        {
            if (holder == null)
            {
                throw new ArgumentNullException($"{nameof(holder)} cannot be null.");
            }

            this.Holders.Add(holder);
        }

        public void Delete(DalHolder holder)
        {
            this.Holders.Remove(holder);
        }

        public void Update(DalHolder holder)
        {
            for (int i = 0; i < Holders.Count; i++)
                if (Holders[i].HolderNumber == holder.HolderNumber)
                {
                    Holders[i] = holder;
                    break;
                }
        }

        public DalHolder GetByNumber(string number)
        {
            var result = Holders.SingleOrDefault(x => x.HolderNumber == number);

            if (result == null)
            {
                throw new InvalidOperationException($"{number} not found.");
            }

            return result;
        }

        #endregion
    }
}
