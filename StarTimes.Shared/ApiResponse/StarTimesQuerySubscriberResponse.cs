using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.Shared.ApiResponse
{
    public class StarTimesQuerySubscriberResponse
    {
        [JsonProperty("subscriber_id")]
        public int Subscriber_id { get; set; }
        
        [JsonProperty("service_code")]
        public string Service_code { get; set; }
        [JsonProperty("customer_name")]
        public string Customer_name { get; set; }
        [JsonProperty("mobile")]
        public string Mobile { get; set; }
        [JsonProperty("contact_address")]
        public string Contact_address { get; set; }
        [JsonProperty("subscriber_status")]
        public string Subscriber_status { get; set; } 
        [JsonProperty("expiration_date")]
        public string Expiration_date { get; set; }
        [JsonProperty("basic_offer_display_name")]
        public string Basic_offer_display_name { get; set; }
        [JsonProperty("basic_offer_business_class")]
        public string Basic_offer_business_class { get; set; }
        [JsonProperty("other_info")]
        public string Other_info { get; set; }

    }
}
