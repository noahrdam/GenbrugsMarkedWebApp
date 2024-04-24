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
        [Route("delete/{AdvertisementId:int}")]
        public void DeleteById(int advertisementId)
        {
            mrepo.DeleteById(advertisementId);
        }

        // Endpoint to get all advertisements by a user's username
        [HttpGet]
        [Route("advertisements/{userName}")]
        public ActionResult<IEnumerable<Advertisement>> GetAdvertisementsByUserName(string userName)
        {
            var advertisements = mrepo.GetAdvertisementsByUserName(userName);
            if (advertisements == null || !advertisements.Any())
            {
                return NotFound("No advertisements found for the given user.");
            }

            return Ok(advertisements);
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
