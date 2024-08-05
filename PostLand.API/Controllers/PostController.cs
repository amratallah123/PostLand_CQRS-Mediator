using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PostLand.API.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using PostLand.Application.Contracts;
    using PostLand.Application.Features.Posts.Commands.CreatePost;
    using PostLand.Application.Features.Posts.Queries.GetPostDetail;
    using PostLand.Application.Features.Posts.Queries.GetPostsList;
    using PostLand.Domain;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace YourNamespace.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class PostsController : ControllerBase
        {
            private readonly IMediator _mediator;

            public PostsController(IMediator mediator)
            {
                _mediator = mediator;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Post>>> GetAllPosts(bool includeCategory = false)
            {
                var dtos = await _mediator.Send(new GetPostsListQuery() { includeCategory = includeCategory });
                return Ok(dtos);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Post>> GetPostById(Guid id, bool includeCategory = false)
            {
                var post = await _mediator.Send(new GetPostDetailQuery() { PostId = id, includeCategory = includeCategory });
                if (post == null)
                {
                    return NotFound();
                }
                return Ok(post);
            }

            [HttpPost]
            public async Task<ActionResult<Post>> CreatePost([FromBody] CreatePostCommand createPostCommand)
            {
                var createdPost = await _mediator.Send(createPostCommand);
                return Ok();
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdatePost(UpdatePostCommand updatePostCommand)
            {


                await _mediator.Send(updatePostCommand);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeletePost(Guid id)
            {
                var deletePostCommand = new DeletePostCommand() { Id = id };
                var post = await _mediator.Send(deletePostCommand);

                return NoContent();
            }
        }
    }

}
