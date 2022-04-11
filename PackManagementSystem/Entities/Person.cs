using System;

namespace PackManagementSystem.Entities
{
    public abstract class Person
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public DateTime Dob{ get; set; }
        public string Address { get; set; }
        public string PhoneNumber{ get; set; }
    }
}