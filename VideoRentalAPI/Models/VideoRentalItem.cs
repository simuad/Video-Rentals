
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

        public VideoRentalItem (VideoRentalItemRenter VideoRentalItemRenter) {
            
            this.Id = VideoRentalItemRenter.Id;
            this.Title = VideoRentalItemRenter.Title;
            this.Genre = VideoRentalItemRenter.Genre;
            this.ReleaseYear = VideoRentalItemRenter.ReleaseYear;
            this.Duration = VideoRentalItemRenter.Duration;
            this.Language = VideoRentalItemRenter.Language;
            this.Rating = VideoRentalItemRenter.Rating;
            this.RenterId = VideoRentalItemRenter.Renter.Id.ToString();
            this.IsRented = VideoRentalItemRenter.IsRented;
        }

        public VideoRentalItem () {
            
        }
    }
}
