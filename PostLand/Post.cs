namespace PostLand.Domain
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Content { get; set; } = null!;
        public Category Category { get; set; } 
        public Guid CategoryId { get; set; }
    }
}
