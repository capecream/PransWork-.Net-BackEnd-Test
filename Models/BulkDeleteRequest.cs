namespace Backend.Models
{
    /// <summary>
    /// ใช้รับ body ตอนเรียก endpoint ลบหลายรายการพร้อมกัน (bulk delete)
    /// เช่น { "ids": [1, 2, 3] }
    /// </summary>
    public class BulkDeleteRequest
    {
        public List<int> Ids { get; set; } = new();
    }
}
