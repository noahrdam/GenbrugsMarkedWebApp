using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories.Interfaces;
using Core.Model;

namespace ServerAPI.Controllers
{
    [ApiController]
    [Route("api/ads")]
    public class AdsController : ControllerBase
    {
        private IAdsRepository mRepo;

        public AdsController(IAdsRepository repo)
        {
            mRepo = repo;
        }


        [HttpGet]
        [Route("getall")]
        public ActionResult<List<Advertisement>> GetAllAdvertisements()
        {
            return mRepo.GetAllAdvertisements();
        }

        
        [HttpGet]
        [Route("category/{category}")]
        public ActionResult<List<Advertisement>> GetAdvertisementsByCategory(string category)
        {
            return mRepo.GetAllByCategory(category);
        }

        
        [HttpGet]
        [Route("price")]
        public ActionResult<List<Advertisement>> GetAdvertisementsByPrice([FromQuery] double minPrice, [FromQuery] double maxPrice)
        {
            return mRepo.GetAdvertisementsByPrice(minPrice, maxPrice);
        }

        
        [HttpGet]
        [Route("status/{status}")]
        public ActionResult<List<Advertisement>> GetAdvertisementsByStatus(string status)
        {
            return mRepo.GetAdvertisementsByStatus(status);
        }

        
        [HttpGet]
        [Route("search")]
        public ActionResult<List<Advertisement>> GetAdvertisementsByDetails([FromQuery] string searchKeyword)
        {
            return mRepo.GetAdvertisementsByDetails(searchKeyword);
        }

        
        [HttpPost]
        public ActionResult<Advertisement> CreateAdvertisement([FromBody] Advertisement advertisement)
        {
            mRepo.CreateAdvertisement(advertisement);
            return CreatedAtAction(nameof(GetAllAdvertisements), new { id = advertisement.Id }, advertisement);
        }

        
    }
}