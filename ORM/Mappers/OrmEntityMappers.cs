using DAL.Interface.DTO;

namespace ORM.Mappers
{
    public static class OrmEntityMappers
    {
        #region Account mappers

        public static DalAccount ToDalAccount(this Account account)
        {
            return new DalAccount()
            {
                AccountNumber = account.AccountNumber,

                BonusPoints = account.BonusPoints,

                Balance = account.Balance,

                Type = account.AccountType.Id,

                Holder = account.AccountHolder.ToDalHolder()
            };
        }

        public static Account ToDbAccount(this DalAccount accountDto)
        {
            return new Account()
            {
                AccountNumber = accountDto.AccountNumber,

                BonusPoints = accountDto.BonusPoints,

                Balance = accountDto.Balance,

                AccountHolder = accountDto.Holder.ToDbHolder(),

                AccountTypeId = accountDto.Type
            };
        }

        #endregion

        #region Holder mappers

        public static DalHolder ToDalHolder(this AccountHolder holder)
        {
            return new DalHolder()
            {
                Email = holder.Email,
                FirstName = holder.Name,
                LastName = holder.Surname,
                HolderNumber = holder.HolderNumber
            };
        }

        public static AccountHolder ToDbHolder(this DalHolder holderDto)
        {
            return new AccountHolder()
            {
                Email = holderDto.Email,
                Name = holderDto.FirstName,
                Surname = holderDto.LastName,
                HolderNumber = holderDto.HolderNumber
            };
        }

        #endregion
    }
}