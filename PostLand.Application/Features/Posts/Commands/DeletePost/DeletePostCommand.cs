using MediatR;
using PostLand.Application.Features.Posts.Queries.GetPostsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLand.Application.Features.Posts.Commands.CreatePost
{
    public class DeletePostCommand : IRequest<Unit>
    {
        public Guid PostId { get; set; }

    }
}
