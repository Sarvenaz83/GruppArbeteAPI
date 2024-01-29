using Application.Commands.AuthorCommands.CreateAuthor;
using Application.Dtos.AuthorDtos;
using Domain.Models;
using Infrastructure.Repository.AuthorRepository;
using MediatR;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, CreateAuthorResponseDto>
{
    private readonly IAuthorRepository _authorRepository;

    public CreateAuthorCommandHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<CreateAuthorResponseDto> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        Author newAuthor = new()
        {
            AuthorId = Guid.NewGuid(),
            AuthorName = request.NewAuthor.AuthorName
        };

        await _authorRepository.CreateAuthorAsync(newAuthor);

        // Create and return the custom DTO with a message
        var createauthorResponseDto = new CreateAuthorResponseDto
        {
            AuthorId = newAuthor.AuthorId,
            AuthorName = newAuthor.AuthorName,
            Message = "Author successfully created. Now go and add some books!"
        };

        return createauthorResponseDto;
    }
}
