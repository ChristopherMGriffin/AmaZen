namespace amazen_server.Models
{
  public class Wishlist
  {
    public int Id { get; set; }
    public string creatorId { get; set; }
    public string Title { get; set; }
    public bool IsPublished { get; set; }
    public Profile Creator { get; set; }

  }
}