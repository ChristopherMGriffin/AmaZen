namespace amazen_server.Models
{
    public class WishlistProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int WishlistId { get; set; }
        public string CreatorId { get; set; }
    }
}