using System;
using System.Collections.Generic;
using amazen_server.Models;
using Dapper;
using System.Data;

namespace amazen_server.Services
{
  public class WishlistsRepository
  {
    private readonly IDbConnection _db;
    private readonly string populateCreator = "SELECT wishlist.*, profile.* FROM wishlists wishlist INNER JOIN profiles profile ON wishlist.creatorId = profile.id";

    public WishlistsRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Wishlist> Get()
    {
      string sql = populateCreator;
      return _db.Query<Wishlist, Profile, Wishlist>(sql, (wishlist, profile) => { wishlist.Creator = profile; return wishlist; }, splitOn: "id");
    }

    internal Wishlist GetOne(int id)
    {
      string sql = "SELECT * FROM wishlists WHERE id = @Id";
      return _db.QueryFirstOrDefault<Wishlist>(sql, new { id });
    }

    public int Create(Wishlist newWishlist)
    {
      string sql = @"
      INSERT INTO wishlists
      (title, creatorId, isPublished)
      VALUES
      (@Title, @CreatorId, @IsPublished);";
      return _db.ExecuteScalar<int>(sql, newWishlist);
    }

    internal bool Delete(int id)
    {
      string sql = "DELETE FROM wishlists WHERE id = @id";
      int valid = _db.Execute(sql, new { id });
      return valid > 0;
    }

    internal void Edit(Wishlist wishlist)
    {
      string sql = @"
     UPDATE wishlists
     SET
     title = @Title,
     isPublished = @IsPublished
     Where id = @Id;";
      _db.Execute(sql, wishlist);
    }

    internal IEnumerable<Wishlist> GetWishlistsByProfile(string profileId)
    {
      string sql = "SELECT * FROM wishlists WHERE " + "'" + profileId + "'" + " = creatorId";
      return (List<Wishlist>)_db.Query(sql, new { profileId });
      throw new NotImplementedException();
    }
  }
}