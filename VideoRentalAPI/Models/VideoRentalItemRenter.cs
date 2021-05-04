
namespace VideoRentalAPI.Models
{
    public class VideoRentalItemRenter
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public int Duration { get; set; }
        public string Language { get; set; }
        public string Rating { get; set; }
        public RenterItem Renter { get; set; }
        public bool IsRented { get; set; }

        public VideoRentalItemRenter(VideoRentalItem videoRentalItem){
            this.Id = videoRentalItem.Id;
            this.Title = videoRentalItem.Title;
            this.Genre = videoRentalItem.Genre;
            this.ReleaseYear = videoRentalItem.ReleaseYear;
            this.Duration = videoRentalItem.Duration;
            this.Language = videoRentalItem.Language;
            this.Rating = videoRentalItem.Rating;
            this.IsRented = videoRentalItem.IsRented;
        }
    }
}
