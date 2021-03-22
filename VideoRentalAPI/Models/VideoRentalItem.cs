
namespace VideoRentalAPI.Models
{
    public class VideoRentalItem
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public int Duration { get; set; }
        public string Language { get; set; }
        public string Rating { get; set; }
        public string RenterId { get; set; }
        public bool IsRented { get; set; }
    }
}
