using SQLite;

namespace CitiesUkrainMobileApp.Entities
{
    public class City
    {
        [AutoIncrement]
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public double DistanceToKyiv { get; set; }
        public long Population {  get; set; }
        public double Lat {  get; set; }
        public double Lng { get; set; }
    }
}
