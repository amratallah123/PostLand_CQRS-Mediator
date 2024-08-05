using AutoMapper;
using MediatR;
using PostLand.Application.Contracts;
using PostLand.Domain;

namespace PostLand.Application.Features.Posts.Commands.CreatePost
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, Unit>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public DeletePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {

            var post = _mapper.Map<Post>(request);

            await _postRepository.DeleteAsync(post);
            return Unit.Value;
        }
    }
}
