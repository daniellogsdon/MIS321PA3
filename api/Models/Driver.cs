namespace api.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public DateTime DateHired { get; set; }
        public bool Deleted { get; set; }
        public string DriverToString()
        {
            return $"DriverID: {Id} \t Name:{Name} \t DateHired:{DateHired} \t Rating:{Rating} \t Deleted:{Deleted}";
        }
    }
}