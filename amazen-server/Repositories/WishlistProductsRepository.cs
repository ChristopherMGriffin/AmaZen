using System.Collections.Generic;
using System.Data;
using Dapper;
using amazen_server.Models;

namespace amazen_server.Repositories
{
  public class WishlistProductsRepository
  {
    private readonly IDbConnection _db;

    public WishlistProductsRepository(IDbConnection db)
    {
      _db = db;
    }

    public int Create(WishlistProduct newWp)
    {
      string sql = @"
        INSERT INTO wishlistproducts
        (wishlistId, productId, creatorId)
        VALUES
        (@WishlistId, @ProductId, @CreatorId);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newWp);
    }

    internal IEnumerable<Product> GetProductsByWishlistId(int wishlistId)
    {
      string sql = @"
        SELECT product.*,
        wp.id as WishlistProductId,
        profile.*
        FROM wishlistproducts wp
        JOIN products product ON product.id = wp.productId
        JOIN profiles profile ON profile.id = product.creatorId
        WHERE wishlistId = @WishlistId;";
      return _db.Query<WishlistProductViewModel, Profile, WishlistProductViewModel>(sql, (product, profile) => { product.Creator = profile; return product; }, new { wishlistId }, splitOn: "id");
    }

    internal bool Delete(int id)
    {
      string sql = "DELETE from wishlistProducts WHERE id = @id";
      int valid = _db.Execute(sql, new { id });
      return valid > 0;
    }

    internal WishlistProduct Get(int id)
    {
      string sql = @"SELECT * from wishlistproducts WHERE id = @id";
      return _db.QueryFirstOrDefault<WishlistProduct>(sql, new { id });
    }
  }
}