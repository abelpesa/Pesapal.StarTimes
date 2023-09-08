using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Pesapal.StarTimes.Portal.Models;
using RestSharp;
using StarTimes.Shared.ApiRequest;
using StarTimes.Shared.ApiResponse;
using StarTimes.Shared.Enums;

namespace Pesapal.StarTimes.Portal.Controllers
{
    public class StarTimesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(StarTimeCheckPackages starTimeCheckPackages)
        {

            string starTimesGetPackagesUrl = "Startimes/GetPackages";
            StarTimesReplaceablePackageRequest starTimesReplaceablePackageRequest = new StarTimesReplaceablePackageRequest();
            starTimesReplaceablePackageRequest.Service_code = starTimeCheckPackages.Service_code;

            string data = JsonConvert.SerializeObject(starTimesReplaceablePackageRequest);

            IRestResponse jsonResult = Utility.Utility.PostApiData(data, starTimesGetPackagesUrl, (int)HttpRequestMethods.POST);

            if (jsonResult.StatusCode == System.Net.HttpStatusCode.OK)
            {

                StarTimesApiReplaceablePackagesResponse starTimesApiReplaceablePackagesResponse = JsonConvert.DeserializeObject<StarTimesApiReplaceablePackagesResponse>(jsonResult.Content);
            

                 Dictionary<string, string> starTimesList = new Dictionary<string, string>();


                for (int i = 0; i < starTimesApiReplaceablePackagesResponse.Responses.Count; i++)
                {
                    starTimesList.Add(starTimesApiReplaceablePackagesResponse.Responses[i].Code, starTimesApiReplaceablePackagesResponse.Responses[i].Display_name);
                 
                }
                var myListItems = new List<SelectListItem>();

                myListItems.AddRange(starTimesList.Select(keyValuePair => new SelectListItem()
                {
                    Value = keyValuePair.Key,
                    Text = keyValuePair.Value
                }));

                var myList = new SelectList(myListItems);

              
                ViewBag.packageList = myListItems;
                ViewBag.verify = "data";

                return View("Pay");
            }


            
            else
            {

                return View();

            }


            return View();
        }

        public IActionResult Pay()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Pay(StarTimeRequest request)
        {

            string startimesRechargeUrl = "Startimes/CreateRecharge";

            StarTimesApiRechargeRequest starTimesApiRechargeRequest = new StarTimesApiRechargeRequest();
            starTimesApiRechargeRequest.Firstname = request.Firstname;
            starTimesApiRechargeRequest.Lastname = request.Lastname;
            starTimesApiRechargeRequest.Mobile = request.Mobile;
            starTimesApiRechargeRequest.New_package_code = request.New_package_code;
            starTimesApiRechargeRequest.Service_code = request.Service_code;
            starTimesApiRechargeRequest.Amount = request.Amount;
            starTimesApiRechargeRequest.Email = request.Email;
            

            string data = JsonConvert.SerializeObject(starTimesApiRechargeRequest);

            IRestResponse jsonResult = Utility.Utility.PostApiData(data, startimesRechargeUrl, (int)HttpRequestMethods.POST);
            if (jsonResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                StarTimesApiRechargeResponse starTimesApiRechargeResponse = JsonConvert.DeserializeObject<StarTimesApiRechargeResponse>(jsonResult.Content);

                ViewBag.Url = starTimesApiRechargeResponse.PaymentUrl;
                return View("Payment");
                

            }
            else
            {
                return View();

            }
            return View();
        }

        [HttpGet]
        public IActionResult PaymentStatus([FromQuery] TransactionCreateRequest request)
        {
           
            string transactionIpnType = request.OrderNotificationType;
            string transactionTrackingId = request.OrderTrackingId;
            string transactionMerchantRef = request.OrderMerchantReference;


            TransactionCreateRequest transactionCreateRequest = new TransactionCreateRequest();
            transactionCreateRequest.OrderMerchantReference = request.OrderMerchantReference;
            transactionCreateRequest.OrderNotificationType = request.OrderNotificationType;
            transactionCreateRequest.OrderTrackingId = request.OrderTrackingId;

            string getTransactionStatusUrl = "Startimes/GetTransactionStatus";
            string data = JsonConvert.SerializeObject(transactionCreateRequest);

            IRestResponse jsonResult = Utility.Utility.PostApiData(data, getTransactionStatusUrl, (int)HttpRequestMethods.POST);
            if (jsonResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                PaymentQueryApiResponse paymentQueryApiResponse = JsonConvert.DeserializeObject<PaymentQueryApiResponse>(jsonResult.Content);

                if (paymentQueryApiResponse.Status_code == (int)StatusCodes.Success)
                {
                    // ViewBag.Url = paymentQueryApiResponse.PaymentUrl;
                    ViewBag.Paymentmode = paymentQueryApiResponse.Payment_method;
                    ViewBag.TrackingID = transactionTrackingId;
                    ViewBag.Amount = paymentQueryApiResponse.Amount;
                    ViewBag.Status = paymentQueryApiResponse.Payment_status_description.ToUpper();
                    ViewBag.PaymentRef = paymentQueryApiResponse.Merchant_reference;
                    ViewBag.Reference = "";
                    ViewBag.InvoiceReference = "";
                    ViewBag.ConfirmationCode = paymentQueryApiResponse.Confirmation_code;
                }
               

                return View(paymentQueryApiResponse);


            }
            else
            {
                return View();

            }


            return View();
        }
        [HttpGet]
        public IActionResult PaymentStatusInfo([FromQuery] TransactionCreateRequest request)
        {
            return View("PaymentStatus");
        }

            public IActionResult Payment()
        {


            return View();

        }


    }
}
