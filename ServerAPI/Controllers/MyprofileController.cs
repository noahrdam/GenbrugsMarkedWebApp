using Microsoft.AspNetCore.Mvc;
using Core.Model;
using ServerAPI.Repositories.Interfaces;
using ServerAPI.Repositories;


namespace ServerAPI.Controllers
{
    [ApiController]
    [Route("api/myprofile")]
    public class MyprofileController : ControllerBase
    {

        IMyprofileRepository mrepo;

        public MyprofileController(IMyprofileRepository repo)
        {
            mrepo = repo;
        }

        // Creates a new advertisement
        [HttpPost]
        [Route("createadvertisement")]
        public void CreateAdvertisement(Advertisement advertisement)
        {
            mrepo.CreateAdvertisement(advertisement);
        }

        [HttpDelete]
        [Route("delete/{advertisementId:int}")]
        public void DeleteById(int advertisementId)
        {
            mrepo.DeleteById(advertisementId);
        }

        // Endpoint to get all advertisements by a user's username
        [HttpGet]
        [Route("advertisements/{user}")]
        public List<Advertisement> GetAdvertisementsByUser(string user)
        {
            var advertisements = mrepo.GetAdvertisementsByUserName(user).ToList();
            return advertisements;
        }

        [HttpPut]
        [Route("updateadvertisement")]
        public IActionResult UpdateAdvertisement([FromBody]Advertisement ad)
        {
            mrepo.UpdateAdvertisement(ad);
            return Ok();
        }

        [HttpGet]
        [Route("stats/{username}")]
        public ActionResult<AdvertisementStats> GetAdvertisementStats(string username)
        {
            try
            {
                var stats = mrepo.GetUserAdvertisementStats(username);
                if (stats == null) return NotFound($"No stats found for user {username}.");
                return Ok(stats);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        /*
        // Constructor injects the repository through dependency injection
        public MyprofileController(IMyprofileRepository myprofileRepository)
        {
            myprofileRepository = myprofileRepository;
        }

        // PUT api/myprofile
        // Updates an existing advertisement
        [HttpPut]
        public IActionResult UpdateAdvertisement(Advertisement ad)
        {
            _myprofileRepository.UpdateAdvertisement(ad);
            return NoContent();
        }

      

        
        */

    }
}