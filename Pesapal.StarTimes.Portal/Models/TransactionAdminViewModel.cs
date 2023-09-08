using StarTimes.Shared.ApiRequest;
using StarTimes.Shared.ApiResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pesapal.StarTimes.Portal.Models
{
    public class TransactionAdminViewModel
    {

        public List<TransactionDetailsResponse> transactionDetailListResponse { get; set; }

        public TransactionAdminSearchRequest transactionAdminSearchRequest { get; set; }

        public TransactionAdminViewModel()
        {
            transactionAdminSearchRequest = new TransactionAdminSearchRequest()
            {

                DateTo = DateTime.Today,
                DateFrom = DateTime.Today.AddDays(-2)
            };
        
        }
    }
}
