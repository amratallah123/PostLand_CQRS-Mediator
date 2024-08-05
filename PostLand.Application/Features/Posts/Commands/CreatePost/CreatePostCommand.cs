using MediatR;
using PostLand.Application.Features.Posts.Queries.GetPostsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLand.Application.Features.Posts.Commands.CreatePost
{
    public class CreatePostCommand :IRequest<Guid>
    {
        public string Title { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Content { get; set; } = null!;
        public Guid CategoryId { get; set; }
    }
}
