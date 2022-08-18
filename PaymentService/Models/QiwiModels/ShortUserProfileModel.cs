using Newtonsoft.Json;

namespace PaymentService.Models.QiwiModels
{
    public class ShortUserProfileModel
    {
        [JsonProperty("birthDate")]
        public string BirthDate { get; set; } = "";
        [JsonProperty("firstName")]
        public string FirstName { get; set; } = "";
        [JsonProperty("middleName")]
        public string MiddleName { get; set; } = "";
        [JsonProperty("lastName")]
        public string LastName { get; set; } = "";
        [JsonProperty("passport")]
        public string Passport { get; set; } = "";
        [JsonProperty("inn")]
        public string INN { get; set; } = "";
        [JsonProperty("snils")]
        public string SNILS { get; set; } = "";
        [JsonProperty("oms")]
        public string OMS { get; set; } = "";
    }
}
