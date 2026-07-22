using Backend.Models;

namespace Backend.Repositories
{

    public interface IItemRepository
    {
        Task<List<Item>> GetAllAsync();
        Task<Item?> GetByIdAsync(int id);
        Task<Item> AddAsync(Item item);
    }
}
