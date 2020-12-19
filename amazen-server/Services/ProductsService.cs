using System;
using System.Collections.Generic;
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
  }
}