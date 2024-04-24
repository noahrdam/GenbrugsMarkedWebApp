using Core.Model;
using System.Collections.Generic;

namespace ServerAPI.Repositories.Interfaces
{
    public interface IAdsRepository
    {
        List<Advertisement> GetAllAdvertisements();
        List<Advertisement> GetAllByCategory(string category);
        List<Advertisement> GetAdvertisementsByPrice(double minPrice, double maxPrice);
        List<Advertisement> GetAdvertisementsByStatus(string status);
        List<Advertisement> GetAdvertisementsByDetails(string searchKeyword);
        Task<List<Advertisement>> GetAdvertisementsSortedByDate();

        void CreateAdvertisement(Advertisement advertisement);
    }
}