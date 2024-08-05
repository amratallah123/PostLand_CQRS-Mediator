using Microsoft.EntityFrameworkCore;
using PostLand.Application.Contracts;
using PostLand.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLand.Persistence
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(PostDbContext PostDbContext) : base(PostDbContext)
        {

        }

        public async Task<IReadOnlyList<Post>> GetAllPostsAsync(bool includeCategory)
        {
            List<Post> posts = new List<Post>();
            posts = includeCategory
                ? await _DbContext.posts.Include(x => x.Category).ToListAsync()
                : await _DbContext.posts.ToListAsync();
            return posts;
        }



        public async Task<Post> GetPostByIdAsync(Guid id, bool includeCategory)
        {

            var post = includeCategory
                 ? await _DbContext.posts.Include(x => x.Category).FirstOrDefaultAsync(p => p.Id == id)
                 : await GetByIdAsync(id);
            return post!;
        }
    }
}
