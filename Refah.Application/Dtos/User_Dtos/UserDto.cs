namespace Refah.Application.Dtos.User_Dtos
{
    public class UserDto
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? NonActiveDate { get; set; }
        public DateTime? ActiveDate { get; set; }
    }
}
