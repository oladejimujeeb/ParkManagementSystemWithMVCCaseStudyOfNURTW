using System.Collections.Generic;

namespace PackManagementSystem.Entities
{
    public class Park
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
        public double Price { get; set; }
        public virtual IList<Staff> Staffs { get; set; } = new List<Staff>();
        public virtual IList<Driver> Drivers { get; set; } = new List<Driver>();
        public virtual IList<Motor> Motors { get; set; } = new List<Motor>();
    }
}