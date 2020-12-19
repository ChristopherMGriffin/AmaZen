using System.Collections.Generic;
using amazen_server.Models;
using amazen_server.Services;
using Microsoft.AspNetCore.Mvc;

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
    }
}