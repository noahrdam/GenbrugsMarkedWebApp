using Core.Model;

namespace ServerAPI.Repositories.Interfaces
{
    public interface IPurchaseRepository
    {
        void MakePurchase(Purchase purchase);
        List<Purchase> GetAllPurchases();
    }
}
