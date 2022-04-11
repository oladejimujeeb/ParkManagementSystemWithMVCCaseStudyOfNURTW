using System.Collections.Generic;

namespace PackManagementSystem.Entities
{
    public class Driver:Person
    {
        public int Id{ get; set; }
        public string DriverId{ get; set; }
        public int ParkId { get; set; }
        public Park Park { get; set; }
        public virtual IList<Motor> Motors { get; set; } = new List<Motor>();
    }
}