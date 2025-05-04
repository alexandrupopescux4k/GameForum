namespace GameForum.Models
{
    public enum RequestStatus
    {
        Pending,
        Approved,
        Rejected
    }

    public class GameRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public User RequestedByUser { get; set; }
        public string RequestedByUserId { get; set; } 

        public RequestStatus Status { get; set; } = RequestStatus.Pending; // default is Pending

        public DateTime RequestedAt { get; set; } = DateTime.UtcNow; 
    }
}
