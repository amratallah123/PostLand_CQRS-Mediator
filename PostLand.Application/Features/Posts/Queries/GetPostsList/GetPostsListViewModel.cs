namespace PostLand.Application.Features.Posts.Queries.GetPostsList
{
    public class GetPostsListViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public CategoryDto Category { get; set; }
    }
}
