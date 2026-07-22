using Backend.Models;

namespace Backend.Repositories
{
    /// <summary>
    /// Interface กำหนดว่า repository ต้องทำอะไรได้บ้าง
    /// Service layer จะเรียกผ่าน interface นี้ ไม่ผูกกับวิธีเก็บข้อมูลจริง
    /// ทำให้ในอนาคตเปลี่ยนจาก in-memory เป็นฐานข้อมูลจริงได้โดยไม่กระทบ layer อื่น
    /// </summary>
    public interface IItemRepository
    {
        Task<List<Item>> GetAllAsync();
        Task<Item?> GetByIdAsync(int id);
        Task<Item> AddAsync(Item item);
    }
}
