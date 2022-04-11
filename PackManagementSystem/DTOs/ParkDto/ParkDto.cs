using System.Collections.Generic;
using PackManagementSystem.Entities;

namespace PackManagementSystem.DTOs.ParkDto
{
    public class ParkDto
    {
        public int Id{ get; set; }
        public string ParkName{ get; set; }
        public double ParkPrice { get; set; }
    }

    public class ParkRequestModel
    {
        public string ParkName { get; set; }
        public double ParkPrice { get; set; }
        public virtual IList<Staff> Staffs { get; set; } = new List<Staff>();
        public virtual IList<Driver> Drivers { get; set; } = new List<Driver>();
        public virtual IList<Motor> Motors { get; set; } = new List<Motor>();
    }

    public class ParkResponseModel:BaseResponseModel
    {
        public ParkDto Data { get; set; }
    }

    public class ParksResponseModel : BaseResponseModel
    {
        public virtual IEnumerable <ParkDto> Data { get; set; } = new List<ParkDto>();
    }
}
