namespace Backend.Models
{

    public class BulkDeleteRequest
    {
        public List<int> Ids { get; set; } = new();
    }
}
