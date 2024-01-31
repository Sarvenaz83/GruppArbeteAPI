namespace Application.Dtos.AuthorDtos
{
    public class DeleteAuthorDto
    {
        public Guid AuthorId { get; set; }
        public string? AuthorName { get; set; }
        public string Message { get; set; }
    }
}
