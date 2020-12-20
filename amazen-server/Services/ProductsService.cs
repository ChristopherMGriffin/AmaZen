using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using amazen_server.Models;
using amazen_server.Repositories;

namespace amazen_server.Services
{
    public class ProductsService
    {
    private readonly ProductsRepository _repo;

    public ProductsService(ProductsRepository repo)
        {
            _repo = repo;
        }

    public IEnumerable<Product> Get()
    {
      return _repo.Get();
    }

    public Product GetOne(int id)
    {
      return _repo.GetOne(id);
    }

    public Product Create(Product newProduct)
    {
      newProduct.Id = _repo.Create(newProduct);
      return newProduct;
    }

    public string Delete(int id, string userId)
    {
      Product product =_repo.GetOne(id);
      if (product == null)
      {
        throw new Exception("Product not found");
      }
      if (product.creatorId != userId)
      {
      throw new Exception("Unauthorized Action");
      }
      if (_repo.Delete(id))
      {
        return "Deleted Product";
      }
      return "Delete Unsuccessful";
    }

    internal Product Edit(Product product, string userId)
    {
      Product original = _repo.GetOne(product.Id);
      if (original == null)
      {
        throw new Exception("Invalid Id");
      }
      if (original.creatorId != userId)
      {
        throw new Exception("Unauthorized");
      }
      _repo.Edit(product);
      return _repo.GetOne(product.Id);
    }
  }
}