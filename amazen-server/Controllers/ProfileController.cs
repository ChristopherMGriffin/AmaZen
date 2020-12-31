    using System.Threading.Tasks;
    using amazen_server.Models;
    using amazen_server.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using CodeWorks.Auth0Provider;

    namespace amazen_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
    private readonly ProfilesService _ps;

        public ProfileController(ProfilesService ps)
            {
            _ps = ps;
            }

            [HttpGet]
            [Authorize]
            public async Task<ActionResult<Profile>> Get()
            {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_ps.GetOrCreateProfile(userInfo));
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
            }    

    }
}