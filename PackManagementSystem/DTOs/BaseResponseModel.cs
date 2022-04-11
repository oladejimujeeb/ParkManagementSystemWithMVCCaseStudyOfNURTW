namespace PackManagementSystem.DTOs
{
    public abstract class BaseResponseModel
    {
        public string Message { get; set; }
        public bool Status { get; set; }
    }
}