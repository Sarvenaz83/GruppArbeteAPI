
namespace Application.Dtos.AuthorDtos
{
    public class CreateAuthorResponseDto
    {
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string Message { get; set; }
    }
}
