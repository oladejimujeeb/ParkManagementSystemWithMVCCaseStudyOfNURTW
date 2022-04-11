using System.Collections.Generic;

namespace PackManagementSystem.DTOs.AdminDto
{
    public class AdminDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Password { get; set; }
    }

    public class AdminRequestModel
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Password { get; set; }
    }

    public class AdminResponseModel:BaseResponseModel
    {
        public AdminDto Data { get; set; }
    }

    public class AdminsResponseModel : BaseResponseModel
    {
        public IList<AdminDto>Data { get; set; }
    }
}