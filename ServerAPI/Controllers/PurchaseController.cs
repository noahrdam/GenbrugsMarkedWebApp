using Core.Model;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Controllers;
using ServerAPI.Repositories.Interfaces;

namespace HelloBlazor.Server.Controllers
{
    [ApiController]
    [Route("api/purchase")]
    public class PurchaseController : ControllerBase
    {
        private IPurchaseRepository mRepo;

        public PurchaseController(IPurchaseRepository repo)
        {
            mRepo = repo;
        }

        [HttpPost]
        [Route("makepurchase")]
        public void MakePurchase(Purchase purchase)
        {
            mRepo.MakePurchase(purchase);
        }

        [HttpGet]
        [Route("getall")]
        public List<Purchase> GetAllPurchases()
        {
            var list= mRepo.GetAllPurchases().ToList();
            return list;
        }

        [HttpGet]
        [Route("getbyusername/{username}")]
        public async Task<ActionResult<List<Purchase>>> GetPurchasesByUsername(string username)
        {
            var purchases = await mRepo.GetPurchasesByUsername(username);
            if (purchases == null || purchases.Count == 0)
            {
                return NotFound("No purchases found for the specified username.");
            }
            return purchases;
        }
    }
}
