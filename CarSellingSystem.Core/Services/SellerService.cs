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

        public async Task CreateAsync(string userId, string phoneNumber)
        {
            await repository.AddAsync(new Seller()
            { 
                UserId = userId,
                PhoneNumber = phoneNumber
            });

            await repository.SaveChangesAsync();
        }

        public async Task<bool> ExistByIdAsync(string userId)
        {
            return await repository.AllReadOnly<Seller>()
                  .AnyAsync(a => a.UserId == userId);
        }

        public async Task<int?> GetSellerIdAsync(string userId)
        {
            return (await repository.AllReadOnly<Seller>()
                .FirstOrDefaultAsync(s => s.UserId == userId))?.Id;
        }

        public async Task<bool> UserHasSellsAsync(string userId)
        {
            return await repository.AllReadOnly<Vehicle>()
                 .AnyAsync(v => v.BuyerId == userId);
        }

        public async Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber)
        {
            return await repository.AllReadOnly<Seller>()
                .AnyAsync(s => s.PhoneNumber == phoneNumber);
        }
    }
}
