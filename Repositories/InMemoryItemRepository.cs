using Backend.Models;

namespace Backend.Repositories
{

    public class InMemoryItemRepository : IItemRepository
    {
        private readonly List<Item> _items = new()
        {
            new Item { Id = 1, Name = "จัดซื้ออุปกรณ์สำนักงาน", Description = "สั่งซื้อกระดาษและหมึกพิมพ์", Category = "General" },
            new Item { Id = 2, Name = "ติดตามลูกค้า A", Description = "โทรติดตามผลการเสนอราคา", Category = "Follow-up" },
            new Item { Id = 3, Name = "แก้บั๊กระบบ Login", Description = "ผู้ใช้ล็อกอินไม่ได้บาง case", Category = "Urgent" },
        };

        private int _nextId = 4;

        public Task<List<Item>> GetAllAsync()
        {
            return Task.FromResult(_items.ToList());
        }

        public Task<Item?> GetByIdAsync(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            return Task.FromResult(item);
        }

        public Task<Item> AddAsync(Item item)
        {
            item.Id = _nextId++;
            _items.Add(item);
            return Task.FromResult(item);
        }
    }
}
