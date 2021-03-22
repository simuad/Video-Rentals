using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoRentalAPI.Models;

namespace VideoRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoRentalItemsController : ControllerBase
    {
        private readonly VideoRentalContext _context;


        public VideoRentalItemsController(VideoRentalContext context)
        {
            _context = context;
            if (!_context.VideoRentalItems.Any())
            {
                _context.VideoRentalItems.Add(new VideoRentalItem
                {
                    Id = 1,
                    Title = "A Clockwork Orange",
                    Genre = "Crime",
                    ReleaseYear = 1971,
                    Duration = 136,
                    Language = "English",
                    Rating = "R",
                    IsRented = true
                });
                _context.VideoRentalItems.Add(new VideoRentalItem
                {
                    Id = 2,
                    Title = "Citizen Kane",
                    Genre = "Drama",
                    ReleaseYear = 1941,
                    Duration = 119,
                    Language = "English",
                    Rating = "PG",
                    IsRented = false
                });
                _context.VideoRentalItems.Add(new VideoRentalItem
                {
                    Id = 3,
                    Title = "Casablanca",
                    Genre = "Drama",
                    ReleaseYear = 1942,
                    Duration = 102,
                    Language = "English",
                    Rating = "PG",
                    IsRented = true
                });
                _context.SaveChanges();
            }
        }

        // GET: api/VideoRentalItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideoRentalItem>>> GetVideoRentalItems()
        {
            return await _context.VideoRentalItems.ToListAsync();
        }

        // GET: api/VideoRentalItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VideoRentalItem>> GetVideoRentalItem(long id)
        {
            var videoRentalItem = await _context.VideoRentalItems.FindAsync(id);

            if (videoRentalItem == null)
            {
                return NotFound();
            }

            return videoRentalItem;
        }

        // PUT: api/VideoRentalItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideoRentalItem(long id, VideoRentalItem videoRentalItem)
        {
            if (videoRentalItem.Id == 0)
            {
                videoRentalItem.Id = id;
            }

            if (id != videoRentalItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(videoRentalItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoRentalItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/VideoRentalItems
        [HttpPost]
        public async Task<ActionResult<VideoRentalItem>> PostVideoRentalItem(VideoRentalItem videoRentalItem)
        {
            _context.VideoRentalItems.Add(videoRentalItem);

            if(VideoRentalItemExists(videoRentalItem.Id))
            {
                return BadRequest("Error: An item with the same key already exists!");
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVideoRentalItem), new { id = videoRentalItem.Id }, videoRentalItem);
        }

        // DELETE: api/VideoRentalItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideoRentalItem(long id)
        {
            var videoRentalItem = await _context.VideoRentalItems.FindAsync(id);
            if (videoRentalItem == null)
            {
                return NotFound();
            }

            _context.VideoRentalItems.Remove(videoRentalItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VideoRentalItemExists(long id)
        {
            return _context.VideoRentalItems.Any(e => e.Id == id);
        }
    }
}
