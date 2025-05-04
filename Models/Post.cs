namespace GameForum.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public User Author { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }

        public int? GameId { get; set; } 
        public Game Game { get; set; }

        public List<Vote> Votes { get; set; }
        public List<Reply> Replies { get; set; }  
    }
}
