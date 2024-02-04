using System;
namespace Application.Dtos.AuthorDtos
{

    public class GetAllAuthorsDto
    {

        public Guid AuthorId { get; set; }

        public string? AuthorName { get; set; }
    }
}

