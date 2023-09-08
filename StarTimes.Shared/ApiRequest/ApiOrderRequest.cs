using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.Shared.ApiRequest
{
    public class ApiOrderRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("callback_url")]
        public string Callback_url { get; set; }

        [JsonProperty("notification_id")]
        public string Notification_id { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }
        [JsonProperty("terms_and_conditions_id")]
        public string Terms_and_conditions_id { get; set; }

        [JsonProperty("billing_address")]
        public BillingAddress Billing_address { get; set; }

    }
    public class BillingAddress
    {

        [JsonProperty("phone_number")]
        public string Phone_number { get; set; }

        [JsonProperty("email_address")]
        public string Email_address { get; set; }

        [JsonProperty("country_code")]
        public string Country_code { get; set; }

        [JsonProperty("first_name")]
        public string First_name { get; set; }

        [JsonProperty("middle_name")]
        public string Middle_name { get; set; }

        [JsonProperty("last_name")]
        public string Last_name { get; set; }

        [JsonProperty("line_1")]
        public string Line_1 { get; set; }

        [JsonProperty("line_2")]
        public string Line_2 { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("postal_code")]
        public string Postal_code { get; set; }
        [JsonProperty("zip_code")]
        public string Zip_code { get; set; }


    }
}
