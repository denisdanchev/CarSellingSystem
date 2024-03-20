using CarSellingSystem.Core.Contracts;
using CarSellingSystem.Infrastructure.Data.Common;
using CarSellingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarSellingSystem.Core.Services
{
    public class SellerService : ISellerService
    {
        private readonly IRepository repository;
        public SellerService(IRepository _repository)
        {
            repository = _repository;
        }

        public Task CreateAsync(string userId, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistByIdAsync(string userId)
        {
            return await repository.AllReadOnly<Seller>()
                  .AnyAsync(a => a.UserId == userId);
        }

        public Task<bool> UserHasSellsAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}
