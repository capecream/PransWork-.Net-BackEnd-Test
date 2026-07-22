using Backend.Models;

namespace Backend.Repositories
{
    /// <summary>
    /// เก็บข้อมูลไว้ใน memory (List) เพื่อให้รันทดสอบได้ทันที
    /// โดยไม่ต้องติดตั้งหรือตั้งค่าฐานข้อมูลเพิ่ม
    /// ข้อมูลจะหายเมื่อ restart โปรแกรม — ถ้าต้องการ persist จริง
    /// ค่อยเปลี่ยนมาใช้ Entity Framework Core ทีหลังโดยแก้แค่ไฟล์นี้ไฟล์เดียว
    /// </summary>
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
