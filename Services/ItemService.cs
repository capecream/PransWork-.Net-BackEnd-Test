using Backend.Models;
using Backend.Repositories;

namespace Backend.Services
{
    /// <summary>
    /// รวม business logic ไว้ที่นี่ (Application layer)
    /// เช่น validation, การกำหนดค่า default ก่อนบันทึก
    /// แยกออกจาก Controller เพื่อให้ทดสอบด้วย unit test ได้ง่าย
    /// โดยไม่ต้องพึ่งพา ASP.NET Core pipeline
    /// </summary>
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
            if (string.IsNullOrWhiteSpace(item.Name))
            {
                throw new ArgumentException("กรุณาระบุชื่อรายการ");
            }

            if (string.IsNullOrWhiteSpace(item.Category))
            {
                item.Category = "General";
            }

            return _repository.AddAsync(item);
        }
    }
}
