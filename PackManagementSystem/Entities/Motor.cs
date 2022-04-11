using System.Collections.Generic;

namespace PackManagementSystem.Entities
{
    public class Motor
    {
        public int Id { get; set; }
        public string Carname { get; set; }
        public string CarType{ get; set; }
        public int NoOfSeater { get; set; }
        public string CarReg { get; set; }
        public int ParkId { get; set; }
        public Park Park { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public IList<Payment> Payments { get; set; } = new List<Payment>();

    }
}