namespace Stumped.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string VIN { get; set; }
        public string LicenseNumber { get; set; }
        public string PlateNumber { get; set; }
        public DateTime LicenseExpiry { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }

}
