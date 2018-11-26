using System;
using BLL.Interface.Services;

namespace BLL.Services
{
    public class HolderNumberGenerator : IHolderNumberGenerator
    {
        public string GenerateHolderNumber() => Guid.NewGuid().ToString();
    }
}
