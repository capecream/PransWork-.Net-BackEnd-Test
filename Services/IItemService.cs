using Backend.Models;

namespace Backend.Services
{
    /// <summary>
    /// Interface ของ business logic (Application layer)
    /// Controller จะเรียกผ่าน interface นี้ ไม่เรียก Repository ตรงๆ
    /// </summary>
    public interface IItemService
    {
        Task<List<Item>> GetAllItemsAsync();
        Task<Item?> GetItemByIdAsync(int id);
        Task<Item> CreateItemAsync(Item item);
    }
}
