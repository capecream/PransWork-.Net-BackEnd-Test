using Backend.Models;

namespace Backend.Repositories
{

    public interface IItemRepository
    {
        Task<List<Item>> GetAllAsync();
        Task<Item?> GetByIdAsync(int id);
        Task<Item> AddAsync(Item item);

        Task<Item?> UpdateAsync(int id, Item item);

        Task<bool> DeleteAsync(int id);

        Task<int> DeleteManyAsync(List<int> ids);
    }
}
