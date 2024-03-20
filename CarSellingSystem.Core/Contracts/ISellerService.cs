namespace CarSellingSystem.Core.Contracts
{
    public interface ISellerService
    {
        Task<bool> ExistByIdAsync(string userId);
        Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber);

        Task<bool> UserHasSellsAsync(string userId);
        Task CreateAsync(string userId, string phoneNumber);


    }
}
