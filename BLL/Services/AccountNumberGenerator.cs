using System;
using BLL.Interface.Services;

namespace BLL.Services
{
    public class AccountNumberGenerator : IAccountNumberGenerator
    {
        public string GenerateAccountNumber() => Guid.NewGuid().ToString();
    }
}
