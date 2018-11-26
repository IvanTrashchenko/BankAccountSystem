namespace BLL.Interface.Services
{
    /// <summary>
    /// Interface for method of generating account's identification number.
    /// </summary>
    public interface IAccountNumberGenerator
    {
        string GenerateAccountNumber();
    }
}
