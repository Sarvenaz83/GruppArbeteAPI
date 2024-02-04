namespace Application.Dtos.UserDtos
{
    public class GetAllUsersDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? SurName { get; set; }
        public string? TelephoneNumber { get; set; }
    }
}
