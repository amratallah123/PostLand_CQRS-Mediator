using AutoMapper;
using MediatR;
using PostLand.Application.Contracts;
using PostLand.Domain;

namespace PostLand.Application.Features.Posts.Commands.CreatePost
{
    public class UpdatePostCommandHandler: IRequestHandler<UpdatePostCommand, Unit>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IPostRepository postRepository, IMapper mapper)         
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            Post post = _mapper.Map<Post>(request);
            await _postRepository.UpdateAsync(post);
            return Unit.Value;
        }
    }
}
