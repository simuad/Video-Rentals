using Newtonsoft.Json;

namespace VideoRentalAPI.Models
{
    public class RenterItemId
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("surname")]
        public string Surname { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("number")]
        public string Number { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }

        public RenterItemId(RenterItem renterItem){
            this.Id = renterItem.Id;
            this.Surname = renterItem.Surname;
            this.Name = renterItem.Name;
            this.Number = renterItem.Number;
            this.Email = renterItem.Email;
        }
    }
}
