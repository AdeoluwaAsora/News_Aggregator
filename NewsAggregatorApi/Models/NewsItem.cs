namespace NewsAggregatorApi.Models
{
    public class NewsItem
    {
        public int Id { get; set; }
        public string Headline { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
        public int UserId { get; set; }
        public User? User { get; set; } = null!;
    }
}