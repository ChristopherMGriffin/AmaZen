using System.Collections.Generic;
using amazen_server.Models;
using amazen_server.Services;
using Microsoft.AspNetCore.Mvc;
using CodeWorks.Auth0Provider;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace amazen_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
    private readonly ProductsService _ps;

    public ProductsController(ProductsService ps)
        {
            _ps = ps;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                return Ok(_ps.Get());
            }
            catch (System.Exception e)
            {
                
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Product> GetOne(int id)
        {
            try
            {
                return Ok(_ps.GetOne(id));
            }
            catch (System.Exception e)
            {
                
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Product>> Create([FromBody] Product newProduct)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newProduct.creatorId = userInfo.Id;
                Product created = _ps.Create(newProduct);
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
                return Ok(_ps.Delete(id, userInfo.Id));
            }
            catch (System.Exception e)
            {
                
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Product>> Edit(int id, [FromBody] Product product)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                product.Id = id;
                return Ok(_ps.Edit(product, userInfo.Id));
            }
            catch (System.Exception e)
            {
                
                return BadRequest(e.Message);
            }
        }
        


    }
}