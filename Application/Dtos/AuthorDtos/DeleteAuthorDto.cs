using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.AuthorDtos
{
    public class DeleteAuthorDto
    {
        public Guid AuthorId { get; set; }
        public string? AuthorName { get; set; }
        public string Message { get; set; }
    }
}
