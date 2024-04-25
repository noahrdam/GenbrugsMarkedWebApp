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
        [Route("create")]
        public void MakePurchase([FromBody] Purchase purchase)
        {
            mRepo.MakePurchase(purchase);
        }

        [HttpGet]
        [Route("getpurchases/{username}")]
        public List<Purchase> GetPurchasesByUsername(string username)
        {
            var purchases = mRepo.GetPurchasesByUsername(username);
            return purchases;
        }

    }
}
