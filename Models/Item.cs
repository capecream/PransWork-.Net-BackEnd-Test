namespace Backend.Models
{
    /// <summary>
    /// Entity หลักของระบบ ตรงกับ Item model ฝั่ง Flutter
    /// (Domain layer: เก็บแค่โครงสร้างข้อมูล ไม่มี logic ธุรกิจ)
    /// </summary>
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = "General";
    }
}
