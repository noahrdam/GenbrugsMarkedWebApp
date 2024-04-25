using Core.Model;


namespace ServerAPI.Repositories.Interfaces
{
    public interface IMyprofileRepository
    {
        // Tilføj en ny annonce til brugerens profil
        public void CreateAdvertisement(Advertisement advertisement);

        // Opdater en eksisterende annonce i brugerens profil

        public void UpdateAdvertisement(Advertisement ad);

        // Slet en annonce fra brugerens profil baseret på dens Id
        // void DeleteById(int AdvertisementId);
        public void DeleteById(int advertisementId);

        // Tilføj metoden for at hente alle annoncer for en given bruger
        public List<Advertisement> GetAdvertisementsByUserName(string username);
    }
}
