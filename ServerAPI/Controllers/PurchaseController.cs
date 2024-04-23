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
    }
}
