namespace BLL.Interface.Services
{
    /// <summary>
    /// Interface for method of generating holder's identification number.
    /// </summary>
    public interface IHolderNumberGenerator
    {
        string GenerateHolderNumber();
    }
}
