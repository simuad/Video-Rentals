using Microsoft.EntityFrameworkCore;

namespace VideoRentalAPI.Models
{
    public class VideoRentalContext : DbContext
    {
        public VideoRentalContext
            (DbContextOptions<VideoRentalContext> options)
       : base(options)
        {
        }

        public DbSet<VideoRentalItem> VideoRentalItems { get; set; }

    }
}
