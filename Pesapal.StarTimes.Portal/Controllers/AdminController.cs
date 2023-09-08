using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pesapal.StarTimes.Portal.Models;
using RestSharp;
using StarTimes.Shared.ApiRequest;
using StarTimes.Shared.ApiResponse;
using StarTimes.Shared.Enums;

namespace Pesapal.StarTimes.Portal.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            TransactionAdminViewModel transactionAdminViewModel = new TransactionAdminViewModel();
            string dateFrom = transactionAdminViewModel.transactionAdminSearchRequest.DateFrom.ToString();
            string dateTo = transactionAdminViewModel.transactionAdminSearchRequest.DateTo.ToString();
            DateTime convertedDateFrom;
            bool convertResult = DateTime.TryParseExact(dateFrom, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out convertedDateFrom);


            DateTime convertedDateTo;
            bool dateToConvertResult = DateTime.TryParseExact(dateTo, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out convertedDateTo);


            DateTime actualConvertedDateFrom;
            DateTime actualConvertedDateTo;
            if (!convertResult || !dateToConvertResult)
            {
                actualConvertedDateFrom = DateTime.Today;
                actualConvertedDateTo = Convert.ToDateTime(actualConvertedDateFrom).Add(new TimeSpan(0, 23, 59, 59, 59));
            }
            else
            {
                actualConvertedDateFrom = convertedDateFrom;
                actualConvertedDateTo = convertedDateTo.Add(new TimeSpan(0, 23, 59, 59, 59));
                //  isFilterTransaction = true;
            }
            if (actualConvertedDateTo < actualConvertedDateFrom)
            {
                DateTime updatedDate = actualConvertedDateFrom;
                actualConvertedDateFrom = actualConvertedDateTo;
                actualConvertedDateTo = updatedDate;

            }

            TransactionAdminSearchRequest transactionAdminSearch = new TransactionAdminSearchRequest();
            transactionAdminSearch.ConfirmationCode = transactionAdminViewModel.transactionAdminSearchRequest.ConfirmationCode;
            transactionAdminSearch.DateTo = actualConvertedDateTo;
            transactionAdminSearch.DateFrom = actualConvertedDateFrom;

            string transcactionsResourceUrl = "PesapalAdmin/GetTransactions";
            string data = JsonConvert.SerializeObject(transactionAdminSearch);

            IRestResponse jsonResult = Utility.Utility.PostApiData(data, transcactionsResourceUrl, (int)HttpRequestMethods.POST);
            if (jsonResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                TransactionDetailListResponse transactionDetailListResponse = JsonConvert.DeserializeObject<TransactionDetailListResponse>(jsonResult.Content);

                if (transactionDetailListResponse.TransactionDetailsResponses == null)
                {
                    transactionAdminViewModel.transactionDetailListResponse = transactionDetailListResponse.TransactionDetailsResponses;
                    return View("Index", transactionAdminViewModel);


                }
                else
                {
                    transactionAdminViewModel.transactionDetailListResponse = transactionDetailListResponse.TransactionDetailsResponses.OrderByDescending(a => a.Id).ToList();
                    return View("Index", transactionAdminViewModel);


                }


            }

            return View("Index", transactionAdminViewModel);
        }

        [HttpPost]
        public IActionResult Index(TransactionAdminViewModel transactionAdminViewModel, string dateFrom, string dateTo)
        {
            //TransactionAdminViewModel transactionAdminViewModel = new TransactionAdminViewModel();
           

            DateTime convertedDateFrom;
            bool convertResult = DateTime.TryParseExact(dateFrom, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out convertedDateFrom);


            DateTime convertedDateTo;
            bool dateToConvertResult = DateTime.TryParseExact(dateTo, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out convertedDateTo);


            DateTime actualConvertedDateFrom;
            DateTime actualConvertedDateTo;
            if (!convertResult || !dateToConvertResult)
            {
                actualConvertedDateFrom = DateTime.Today;
                actualConvertedDateTo = Convert.ToDateTime(actualConvertedDateFrom).Add(new TimeSpan(0, 23, 59, 59, 59));
            }
            else
            {
                actualConvertedDateFrom = convertedDateFrom;
                actualConvertedDateTo = convertedDateTo.Add(new TimeSpan(0, 23, 59, 59, 59));
                //  isFilterTransaction = true;
            }
            if (actualConvertedDateTo < actualConvertedDateFrom)
            {
                DateTime updatedDate = actualConvertedDateFrom;
                actualConvertedDateFrom = actualConvertedDateTo;
                actualConvertedDateTo = updatedDate;

            }

            TransactionAdminSearchRequest transactionAdminSearch = new TransactionAdminSearchRequest();
            transactionAdminSearch.ConfirmationCode = transactionAdminViewModel.transactionAdminSearchRequest.ConfirmationCode;
            transactionAdminSearch.DateTo = actualConvertedDateTo;
            transactionAdminSearch.DateFrom = actualConvertedDateFrom;

            string transcactionsResourceUrl = "PesapalAdmin/GetTransactions";
            string data = JsonConvert.SerializeObject(transactionAdminSearch);

            IRestResponse jsonResult = Utility.Utility.PostApiData(data, transcactionsResourceUrl, (int)HttpRequestMethods.POST);
            if (jsonResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                TransactionDetailListResponse transactionDetailListResponse = JsonConvert.DeserializeObject<TransactionDetailListResponse>(jsonResult.Content);

                if (transactionDetailListResponse.TransactionDetailsResponses == null)
                {
                    transactionAdminViewModel.transactionDetailListResponse = transactionDetailListResponse.TransactionDetailsResponses;
                    return View("Index",transactionAdminViewModel);


                }
                else
                {
                    transactionAdminViewModel.transactionDetailListResponse = transactionDetailListResponse.TransactionDetailsResponses.OrderByDescending(a => a.Id).ToList();
                    return View("Index", transactionAdminViewModel);


                }


            }

            return View("Index", transactionAdminViewModel);
        }
      
      
   


    }
}
