namespace Application.Dtos.UserDtos
{
    public class NewUserDto
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string FirstName { get; set; }
        public required string SurName { get; set; }
        public required string Email { get; set; }
        public required string TelephoneNumber { get; set; }
    }
}