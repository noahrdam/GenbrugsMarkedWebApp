using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories.Interfaces;
using Core.Model;
using MongoDB.Bson;
using static System.Net.WebRequestMethods;
using MongoDB.Driver;

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
        public List<Advertisement> GetAllAdvertisements()
        {
            return mRepo.GetAllAdvertisements();
        }

        
        [HttpGet]
        [Route("category/{category}")]
        public List<Advertisement> GetAdvertisementsByCategory(string category)
        {
            return mRepo.GetAllByCategory(category);
        }

        
        [HttpGet]
        [Route("price")]
        public List<Advertisement> GetAdvertisementsByPrice([FromQuery] double minPrice, [FromQuery] double maxPrice)
        {
            return mRepo.GetAdvertisementsByPrice(minPrice, maxPrice);
        }

        
        [HttpGet]
        [Route("status/{status}")]
        public List<Advertisement> GetAdvertisementsByStatus(string status)
        {
            return mRepo.GetAdvertisementsByStatus(status);
        }

        
        [HttpGet]
        [Route("search")]
        public List<Advertisement> GetAdvertisementsByDetails([FromQuery] string searchKeyword)
        {
            return mRepo.GetAdvertisementsByDetails(searchKeyword);
        }


        [HttpGet]
        [Route("get/{id}")]
        public Advertisement GetAdvertisementById(string id)
        {
           
                var advertisement = mRepo.GetAdvertisementById(new ObjectId(id));
                return advertisement;
        }

        [HttpPost]
        [Route("update")]
        public void UpdateAdvertisement([FromBody] Advertisement advertisement)
        {
            mRepo.UpdateAdvertisement(advertisement);
        }

        /*
        [HttpPost]
        public Advertisement CreateAdvertisement2([FromBody] Advertisement advertisement)

        {
            mRepo.CreateAdvertisement2(advertisement);
            return CreatedAtAction(nameof(GetAllAdvertisements), new { id = advertisement.Id }, advertisement);
        }*/


    }
}