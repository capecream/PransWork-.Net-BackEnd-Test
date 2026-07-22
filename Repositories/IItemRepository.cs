using Backend.Models;

namespace Backend.Repositories
{

    public interface IItemRepository
    {
        Task<List<Item>> GetAllAsync();
        Task<Item?> GetByIdAsync(int id);
        Task<Item> AddAsync(Item item);

        /// <summary>แก้ไขข้อมูล คืนค่า null ถ้าไม่พบ id นั้น</summary>
        Task<Item?> UpdateAsync(int id, Item item);

        /// <summary>ลบ 1 รายการ คืนค่า true ถ้าลบสำเร็จ, false ถ้าไม่พบ id นั้น</summary>
        Task<bool> DeleteAsync(int id);

        /// <summary>ลบหลายรายการพร้อมกัน คืนค่าจำนวนที่ลบสำเร็จจริง</summary>
        Task<int> DeleteManyAsync(List<int> ids);
    }
}
