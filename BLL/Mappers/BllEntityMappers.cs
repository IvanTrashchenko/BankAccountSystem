using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class BllEntityMappers
    {
        #region Account mappers

        public static DalAccount ToDalAccount(this AccountEntity account)
        {
            return new DalAccount()
            {
                AccountNumber = account.AccountNumber,

                BonusPoints = account.BonusPoints,

                Balance = account.Balance,

                Status = account.Status.ToDalStatus(),

                Holder = account.Holder.ToDalHolder()
            };
        }

        public static AccountEntity ToBllAccount(this DalAccount accountDto)
        {
            return new AccountEntity()
            {
                AccountNumber = accountDto.AccountNumber,

                BonusPoints = accountDto.BonusPoints,

                Balance = accountDto.Balance,

                Status = accountDto.Status.ToBllStatus(),

                Holder = accountDto.Holder.ToBllHolder()
            };
        }

        #endregion

        #region Holder mappers

        public static DalHolder ToDalHolder(this HolderEntity holder)
        {
            return new DalHolder()
            {
                Email = holder.Email,
                FirstName = holder.FirstName,
                LastName = holder.LastName,
                HolderNumber = holder.HolderNumber
            };
        }

        public static HolderEntity ToBllHolder(this DalHolder holderDto)
        {
            return new HolderEntity()
            {
                Email = holderDto.Email,
                FirstName = holderDto.FirstName,
                LastName = holderDto.LastName,
                HolderNumber = holderDto.HolderNumber
            };
        }

        #endregion

        #region Status mappers

        //не нужны?

        public static AccountStatus ToBllStatus(this DalAccountStatus statusDto)
        {
            int temp = (int)statusDto;
            return (AccountStatus)temp;
        }

        public static DalAccountStatus ToDalStatus(this AccountStatus status)
        {
            int temp = (int)status;
            return (DalAccountStatus)temp;
        }

        #endregion
    }
}
