using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.BLL.DTO
{
    public class TransactionAdminSearchRequestDTO
    {
        [JsonProperty("dateFrom")]
        public DateTime DateFrom { get; set; }

        [JsonProperty("dateTo")]
        public DateTime DateTo { get; set; }
        [JsonProperty("currentPage")]
        public int CurrentPage { get; set; }
        [JsonProperty("confirmationCode")]
        public string ConfirmationCode { get; set; }


        public TransactionAdminSearchRequestDTO()
        {
            DateFrom = DateTime.UtcNow.AddDays(-1);
            DateTo = DateTime.UtcNow;
            CurrentPage = 1;


        }
    }
}
