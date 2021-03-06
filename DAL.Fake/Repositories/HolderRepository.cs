﻿using System;
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
            if (holders == null)
            {
                throw new ArgumentNullException($"{nameof(holders)} cannot be null.");
            }

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
            if (holder == null)
            {
                throw new ArgumentNullException($"{nameof(holder)} cannot be null.");
            }

            this.Holders.Remove(holder);
        }

        public void Update(DalHolder holder)
        {
            if (holder == null)
            {
                throw new ArgumentNullException($"{nameof(holder)} cannot be null.");
            }

            var resHol = Holders.SingleOrDefault(x => x.HolderNumber == holder.HolderNumber);

            if (resHol == null)
            {
                throw new InvalidOperationException($"{holder} not found.");
            }

            resHol.FirstName = holder.FirstName;
            resHol.FirstName = holder.LastName;
            resHol.FirstName = holder.Email;
        }

        public DalHolder GetByNumber(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                throw new ArgumentException($"{nameof(number)} cannot be null or empty.");
            }

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
