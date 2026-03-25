using lizi_s_project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lizi_s_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public List<Users> Users = new List<Users>()
        {
            new Users("lizi","beraia",11),
            new Users("vazha","mikadze",12),

        };

        [HttpGet]

        public ActionResult GetUsers()
        {
            return Ok(Users);
        }
    }
}
