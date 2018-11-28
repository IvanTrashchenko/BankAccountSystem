using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Repository;

namespace DAL.Fake.Repositories
{
    //понадобится в дальнейшем?
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

        public DalHolder GetById(int id)
        {
            var result = Holders.FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                throw new InvalidOperationException($"Invalid {id}.");
            }

            return result;
        }

        public DalHolder GetByNumber(string number)
        {
            var result = Holders.FirstOrDefault(x => x.HolderNumber == number);

            if (result == null)
            {
                throw new InvalidOperationException($"{number} not found.");
            }

            return result;
        }

        public bool Contains(DalHolder holder)
        {
            foreach (var item in Holders)
            {
                if (item.Email == holder.Email)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}
