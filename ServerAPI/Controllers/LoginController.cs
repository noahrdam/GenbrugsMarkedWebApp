using Core.Model;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories.Interfaces;

namespace ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        ILoginRepository mRepo;

        public LoginController(ILoginRepository repo)
        {
            mRepo = repo;
        }

        [HttpPost]
        [Route("createaccount")]
        public void CreateAccount(User user)
        {
            mRepo.CreateAccount(user);
        }


        [HttpGet]
        [Route("verify")]
        public bool VerifyLogin([FromQuery] string username, [FromQuery] string password)
        {
            return mRepo.VerifyLogin(username, password);
        }

        [HttpGet]
        [Route("getuser")]
        public User GetUser([FromQuery] string username)
        {
            return mRepo.GetUser(username);
        }

    }
}

