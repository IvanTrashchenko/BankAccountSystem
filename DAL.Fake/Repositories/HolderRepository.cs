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
            return Holders.FirstOrDefault(x => x.Id == id);
        }

        public DalHolder GetByNumber(string number)
        {
            return Holders.FirstOrDefault(x => x.HolderNumber == number);
        }

        #endregion
    }
}
