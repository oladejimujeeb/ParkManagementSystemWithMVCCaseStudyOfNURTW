namespace PackManagementSystem.Entities
{
    public class Staff:Person
    {
        public int Id{ get; set; }
        public string RegNum{ get; set; }
        public int PackId{ get; set; }
        public Park Park{ get; set; }
    }
}