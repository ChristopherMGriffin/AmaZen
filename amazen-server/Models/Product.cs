namespace amazen_server.Models
{
    public class Product
    {
<<<<<<< HEAD
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public string creatorId { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public bool isAvailable { get; set; }
    }

    public class WishlistProductViewModel : Product
    {
        public int WishlistProductId { get; set; }
=======
    public string Title { get; set; }
    public bool IsAvailable { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public int Price { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
>>>>>>> b499577e810aa4d63a7c03199280ad990d09904e
    }
}