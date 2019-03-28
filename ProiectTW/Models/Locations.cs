namespace ProiectTW.Models
{
    public class Locations
    {
        private UsersStoreContext context;

        public int ID { get; set; }

        public string CityName { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Description { get; set; }
    }
}
