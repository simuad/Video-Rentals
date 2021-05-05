using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using VideoRentalAPI.Models;
using Newtonsoft.Json;
using System;

namespace VideoRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoRentalItemsController : ControllerBase
    {
        private readonly VideoRentalContext _context;
        private readonly string path = "http://contacts:5000/contacts/";

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
                    RenterId = "12345",
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
                    RenterId = "87014",
                    IsRented = true
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
                    RenterId = "87014",
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

        // GET: api/VideoRentalItems/renter/
        [HttpGet("renter/{filter?}")]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetVideoRentalItemsRenter(bool filter = true)
        {
            if(filter){
                var videoRentalItems =  await _context.VideoRentalItems.ToListAsync();
                List<Object> videoRentalItemsRenters = new List<Object>();
                foreach(var item in videoRentalItems)
                {
                    RenterItem renter = null;
                    try
                    {
                        using (var httpClient = new HttpClient())
                        {
                            using (var response = await httpClient.GetAsync(path + item.RenterId))
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                renter = JsonConvert.DeserializeObject<RenterItem>(apiResponse);
                            }
                        }
                        
                        VideoRentalItemRenter itemWithRenter = new VideoRentalItemRenter(item);
                        itemWithRenter.Renter = renter;
                        videoRentalItemsRenters.Add(itemWithRenter);
                    }
                    catch (Exception exception) {
                        System.Diagnostics.Debug.WriteLine(exception);
                        videoRentalItemsRenters.Add(item);
                    }

                }
                return videoRentalItemsRenters;
            }
            else
            {
                return await _context.VideoRentalItems.ToListAsync();
            }
        }

        // GET: api/VideoRentalItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VideoRentalItem>> GetVideoRentalItem(long id)
        {
            var videoRentalItem = await _context.VideoRentalItems.FindAsync(id);

            if (videoRentalItem == null)
            {
                string message = $"Video rental item with id {id} does not exist!";
                return NotFound(message);
            }

            return videoRentalItem;
        }

        // GET: api/VideoRentalItems/5/renter
        [HttpGet("{id}/renter")]
        public async Task<ActionResult<dynamic>> GetVideoRentalItemRenter(long id)
        {
            var videoRentalItem = await _context.VideoRentalItems.FindAsync(id);

            if (videoRentalItem == null)
            {
                string message = $"Video rental item with id {id} does not exist!";
                return NotFound(message);
            }

            if (videoRentalItem.RenterId == null)
            {
                string message = $"Video rental item with id {id} does not have a renter.";
                return BadRequest(message);
            }

            RenterItem renter = null;
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(path + videoRentalItem.RenterId))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        renter = JsonConvert.DeserializeObject<RenterItem>(apiResponse);
                    }
                }
            }
            catch (Exception exception) {
                System.Diagnostics.Debug.WriteLine(exception);
                return videoRentalItem;
            }

            renter.Id = long.Parse(videoRentalItem.RenterId);
            VideoRentalItemRenter videoRentalItemRenter = new VideoRentalItemRenter(videoRentalItem);
            videoRentalItemRenter.Renter = renter;
            
            return videoRentalItemRenter;
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

        // PUT: api/VideoRentalItems/5/renter
        [HttpPut("{id}/renter")]
        public async Task<IActionResult> PutVideoRentalItemRenter(long id, RenterItem renterItem)
        {
            var videoRentalItem = await _context.VideoRentalItems.FindAsync(id);

            if (videoRentalItem == null)
            {
                string message = $"Video rental item with id {id} does not exist!";
                return NotFound(message);
            }
            
            string renterId = videoRentalItem.RenterId;

            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(renterItem);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync(path + renterId, httpContent))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
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

        // POST: api/VideoRentalItems/renter
        [HttpPost("renter")]
        public async Task<ActionResult<VideoRentalItemRenter>> PostVideoRentalItemRenter(VideoRentalItemRenter videoRentalItemRenter)
        {
            VideoRentalItem videoRentalItem = new VideoRentalItem(videoRentalItemRenter);
            _context.VideoRentalItems.Add(videoRentalItem);

            if(VideoRentalItemExists(videoRentalItem.Id))
            {
                return BadRequest("Error: An item with the same key already exists!");
            }

            RenterItem renterItem = videoRentalItemRenter.Renter;
            RenterItemId renterItemId = new RenterItemId(renterItem);

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(renterItemId);
                    var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync(path, httpContent))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception exception) {
                System.Diagnostics.Debug.WriteLine(exception);
                return StatusCode(503);
            }
            videoRentalItem.Id = videoRentalItem.Id;
            await _context.SaveChangesAsync();
            videoRentalItemRenter.Id = videoRentalItem.Id;
            return StatusCode(201, videoRentalItemRenter);
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

        // DELETE: api/VideoRentalItems/5/renter
        [HttpDelete("{id}/renter")]
        public async Task<IActionResult> DeleteVideoRentalItemRenter(long id)
        {
            var videoRentalItem = await _context.VideoRentalItems.FindAsync(id);
            
            if (videoRentalItem == null)
            {
                return NotFound();
            }

            string renterId = videoRentalItem.RenterId;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(path + renterId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            foreach(var item in _context.VideoRentalItems.Where(e => e.RenterId == renterId))
            {
                item.RenterId = null;
                item.IsRented = false;
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VideoRentalItemExists(long id)
        {
            return _context.VideoRentalItems.Any(e => e.Id == id);
        }
    }
}
