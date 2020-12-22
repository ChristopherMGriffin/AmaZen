using System;
using System.Collections.Generic;
using amazen_server.Models;
using Dapper;
using System.Data;

namespace amazen_server.Services
{
  public class ProductsRepository
  {
    private readonly IDbConnection _db;
    private readonly string populateCreator = "SELECT product.*, profile.* FROM products product INNER JOIN profiles profile ON product.creatorId = profile.id";

    public ProductsRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Product> Get()
    {
      string sql = populateCreator + " WHERE isAvailable = 1";
      return _db.Query<Product, Profile, Product>(sql, (product, profile) => { product.Creator = profile; return product; }, splitOn: "id");
    }

    internal Product GetOne(int id)
    {
      string sql = "SELECT * FROM products WHERE id = @Id";
      return _db.QueryFirstOrDefault<Product>(sql, new { id });
    }

    public int Create(Product newProduct)
    {
      string sql = @"
      INSERT INTO products
      (title, description, image, size, price, creatorId, isAvailable)
      VALUES
      (@Title, @Description, @Image, @Size, @Price, @CreatorId, @IsAvailable);";
      return _db.ExecuteScalar<int>(sql, newProduct);
    }

    internal bool Delete(int id)
    {
      string sql = "DELETE FROM products WHERE id = @id";
      int valid = _db.Execute(sql, new { id });
      return valid > 0;
    }

    internal void Edit(Product product)
    {
      string sql = @"
     UPDATE products
     SET
     title = @Title,
     description = @Description,
     size = @Size,
     price = @Price,
     image = @Image
     Where id = @Id;";
      _db.Execute(sql, product);
    }
  }
}