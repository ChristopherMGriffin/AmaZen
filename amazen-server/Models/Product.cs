namespace amazen_server.Models
{
  public class Product
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string Size { get; set; }
    public decimal Price { get; set; }
    public string creatorId { get; set; }
    public int Likes { get; set; }
    public int Id { get; set; }
    public int Dislikes { get; set; }
    public bool IsAvailable { get; set; }
    public Profile Creator { get; set; }
  }

  public class WishlistProductViewModel : Product
  {
    public int WishlistProductId { get; set; }
  }
}