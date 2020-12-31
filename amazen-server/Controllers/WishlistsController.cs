using System.Collections.Generic;
using amazen_server.Models;
using amazen_server.Services;
using Microsoft.AspNetCore.Mvc;
using CodeWorks.Auth0Provider;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace amazen_server.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class WishlistsController : ControllerBase
  {
    private readonly WishlistsService _ws;
    private readonly WishlistProductsService _wps;

    public WishlistsController(WishlistsService ws, WishlistProductsService wps)
    {
      _ws = ws;
      _wps = wps;
    }

    [HttpGet]
    [Authorize]
    public ActionResult<IEnumerable<Wishlist>> Get()
    {
      try
      {
        return Ok(_ws.Get());
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Wishlist> GetOne(int id)
    {
      try
      {
        return Ok(_ws.GetOne(id));
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpGet("{wishlistId}/wishlistproducts")]
    [Authorize]
    public ActionResult<IEnumerable<Product>> Get(int wishlistId)
    {
      try
      {
        return Ok(_wps.GetProductsByWishlistId(wishlistId));
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Wishlist>> Create([FromBody] Wishlist newWishlist)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newWishlist.creatorId = userInfo.Id;
        Wishlist created = _ws.Create(newWishlist);
        created.Creator = userInfo;
        return Ok(created);
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> Delete(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_ws.Delete(id, userInfo.Id));
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Wishlist>> Edit(int id, [FromBody] Wishlist wishlist)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        wishlist.Id = id;
        return Ok(_ws.Edit(wishlist, userInfo.Id));
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }



  }

}