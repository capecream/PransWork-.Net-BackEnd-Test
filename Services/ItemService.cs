using Backend.Models;
using Backend.Repositories;

namespace Backend.Services
{

    public class ItemService : IItemService
    {
        private readonly IItemRepository _repository;

        public ItemService(IItemRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Item>> GetAllItemsAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Item?> GetItemByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<Item> CreateItemAsync(Item item)
        {
            ValidateItem(item);
            return _repository.AddAsync(item);
        }

        public Task<Item?> UpdateItemAsync(int id, Item item)
        {
            ValidateItem(item);
            return _repository.UpdateAsync(id, item);
        }

        public Task<bool> DeleteItemAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<int> DeleteItemsAsync(List<int> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                throw new ArgumentException("กรุณาระบุ id ที่ต้องการลบอย่างน้อย 1 รายการ");
            }
            return _repository.DeleteManyAsync(ids);
        }

        private static void ValidateItem(Item item)
        {
            if (string.IsNullOrWhiteSpace(item.Name))
            {
                throw new ArgumentException("กรุณาระบุชื่อรายการ");
            }

            if (string.IsNullOrWhiteSpace(item.Category))
            {
                item.Category = "General";
            }
        }
    }
}
