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
      string sql = populateCreator + "WHERE isAvailable = 1";
      return _db.Query<Product, Profile, Product>(sql, (product, profile) => {product.Creator = profile; return product; }, splitOn: "id");
    }
  }
}