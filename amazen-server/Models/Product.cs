namespace amazen_server.Models
{
    public class Product
    {
    public string Title { get; set; }
    public bool IsAvailable { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public int Price { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
    }
}