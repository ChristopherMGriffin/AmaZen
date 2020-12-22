using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using amazen_server.Models;
using amazen_server.Repositories;

namespace amazen_server.Services
{
    public class WishlistsService
    {
        private readonly WishlistsRepository _repo;

    public WishlistsService(WishlistsRepository repo)
        {
            _repo = repo;
        }

    public IEnumerable<Wishlist> Get()
    {
      return _repo.Get();
    }

    public Wishlist GetOne(int id)
    {
      return _repo.GetOne(id);
    }

    public Wishlist Create(Wishlist newWishlist)
    {
      newWishlist.Id = _repo.Create(newWishlist);
      return newWishlist;
    }

    public string Delete(int id, string userId)
    {
      Wishlist Wishlist =_repo.GetOne(id);
      if (Wishlist == null)
      {
        throw new Exception("Wishlist not found");
      }
      if (Wishlist.creatorId != userId)
      {
      throw new Exception("Unauthorized Action");
      }
      if (_repo.Delete(id))
      {
        return "Deleted Wishlist";
      }
      return "Delete Unsuccessful";
    }

    internal Wishlist Edit(Wishlist wishlist, string userId)
    {
      Wishlist original = _repo.GetOne(wishlist.Id);
      if (original == null)
      {
        throw new Exception("Invalid Id");
      }
      if (original.creatorId != userId)
      {
        throw new Exception("Unauthorized");
      }
      _repo.Edit(wishlist);
      return _repo.GetOne(wishlist.Id);
    }
    }
}