using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Description;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using StarTimes.BLL.DTO;
using StarTimes.BLL.Implementation;
using StarTimes.BLL.Interfaces;
using StarTimes.Shared.ApiRequest;
using StarTimes.Shared.ApiResponse;
using StarTimes.Shared.Enums;

namespace Pesapal.StarTimes.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StartimesController : ControllerBase
    {

        INotificationDetailService _notificationDetailService { get; set; }
        ISubscriberPaymentInfoService _subscriberPaymentInfoService { get; set; }
        ISubscriberTransactionDetailService _subscriberTransactionDetailService { get; set; }
        IConfiguration _configuration;

        static string _statusupdate, _paymentmode, _paymentref, _currency, _confirmationCode, _merchantref;
        static decimal _amount;

        public StartimesController(INotificationDetailService notificationDetailService, ISubscriberPaymentInfoService subscriberPaymentInfoService, ISubscriberTransactionDetailService subscriberTransactionDetailService, IConfiguration configuration)
        {
            _notificationDetailService = notificationDetailService;
            _subscriberPaymentInfoService = subscriberPaymentInfoService;
            _subscriberTransactionDetailService = subscriberTransactionDetailService;
            _configuration = configuration;



        }

        //1.
        //subscriber form load
        //load the details api with list - 1
        //display the form with the list - 1 return data - done

        //2.
        //enter the serial nunmber with amount
        //send to the recharge API   - 2
        //Check for validity  - 2a
        //if ok then call API3  - 2b
        //enter the data in the Database
        //return the API3 callback

        //3.
        //API3 ipn registration
        //register callback
        //save the callback to db
        //if exists override

        //4.
        //API 3 ipn callback
        // receives API 3 data with reference
        // matches the reference of the subscriber entry
        //save in database as paid
        //send to startimes

        //5.
        //admin
        //view all transactions
        //register ipn
        //actions for dashboard

        [ResponseType(typeof(StarTimesApiReplaceablePackagesResponse))]
        [HttpPost]
        public IActionResult GetPackages([FromBody] StarTimesReplaceablePackageRequest starTimesReplaceablePackageRequest)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(new StarTimesApiReplaceablePackagesResponse
                {
                    Message = "Invalid Request.",
                    Status = HelperRepository.BadRequestCode

                });
            }
            //confirm service code
            string starTimesSubscribersUrl = "subscribers/" + starTimesReplaceablePackageRequest.Service_code;
            string dataSubscriber = "";
            IRestResponse jsonResultSubscriber = Utility.Utility.PostApiData(dataSubscriber, starTimesSubscribersUrl, (int)HttpRequestMethods.GET);
            if (jsonResultSubscriber.StatusCode != System.Net.HttpStatusCode.OK)
            {

                return BadRequest(new StarTimesApiReplaceablePackagesResponse
                {
                    Message = "Invalid request. Unable to verify subscriber.",
                    Status = HelperRepository.BadRequestCode

                });

            }


            string starTimesGetPackagesUrl = "subscribers/" + starTimesReplaceablePackageRequest.Service_code + "/replaceable-packages";
            string data = "";

            IRestResponse jsonResult = Utility.Utility.PostApiData(data, starTimesGetPackagesUrl, (int)HttpRequestMethods.GET);
            StarTimesApiReplaceablePackagesResponse starTimesApiReplaceablePackagesResponse = new StarTimesApiReplaceablePackagesResponse();


            if (jsonResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                try
                {

                    List<StarTimesReplaceableItemResponse> starTimesReplaceableItemResponses = JsonConvert.DeserializeObject<List<StarTimesReplaceableItemResponse>>(jsonResult.Content);

                    for (int i = 0; i < starTimesReplaceableItemResponses.Count; i++)
                    {
                        StarTimesReplaceableItemResponse starTimesReplaceableItemResponse = new StarTimesReplaceableItemResponse();
                        starTimesReplaceableItemResponse.Code = starTimesReplaceableItemResponses[i].Code;
                        starTimesReplaceableItemResponse.Description = starTimesReplaceableItemResponses[i].Description;
                        starTimesReplaceableItemResponse.Display_name = starTimesReplaceableItemResponses[i].Display_name;

                        // starTimesApiReplaceablePackagesResponse.Responses.Add(starTimesReplaceableItemResponse);

                    }
                    starTimesApiReplaceablePackagesResponse.Responses = starTimesReplaceableItemResponses;
                    starTimesApiReplaceablePackagesResponse.Message = HelperRepository.DefaultOkMessage;
                    starTimesApiReplaceablePackagesResponse.Status = HelperRepository.DefaultOkCode;

                    return Ok(starTimesApiReplaceablePackagesResponse);
                }
                catch (Exception e)
                {



                }



            }

            return BadRequest(new StarTimesApiReplaceablePackagesResponse
            {
                Message = "Error Processing request",
                Status = HelperRepository.BadRequestCode


            });


        }


        [ResponseType(typeof(StarTimesApiRechargeResponse))]
        [HttpPost]
        public async Task<IActionResult> CreateRecharge([FromBody] StarTimesApiRechargeRequest starTimesRechargeRequest)
        {
            Random rnd = new Random();
            Guid guid = Guid.NewGuid();
            string referenceGenerated = guid.ToString();

            if (!ModelState.IsValid)
            {

                return BadRequest(new StarTimesApiRechargeResponse
                {
                    Message = "Invalid Request.",
                    Status = HelperRepository.BadRequestCode


                });
            }

            //confirm service code
            string starTimesSubscribersUrl = "subscribers/" + starTimesRechargeRequest.Service_code;
            string data = "";
            IRestResponse jsonResult = Utility.Utility.PostApiData(data, starTimesSubscribersUrl, (int)HttpRequestMethods.GET);
            StarTimesQuerySubscriberResponse starTimesQuerySubscriberResponse = new StarTimesQuerySubscriberResponse();
            if (jsonResult.StatusCode == System.Net.HttpStatusCode.OK)
            {

                starTimesQuerySubscriberResponse = JsonConvert.DeserializeObject<StarTimesQuerySubscriberResponse>(jsonResult.Content);



            }
            else
            {

                StarTimesErrorResponse errorResponse = JsonConvert.DeserializeObject<StarTimesErrorResponse>(jsonResult.Content);


                return BadRequest(new StarTimesApiRechargeResponse
                {
                    Message = "" + errorResponse.ErrorMessage,
                    Status = HelperRepository.BadRequestCode


                });



            }

            //create the subsciber data

            SubscriberPaymentInfoDTO subscriberPaymentInfoDTO = new SubscriberPaymentInfoDTO();
            subscriberPaymentInfoDTO.Mobile = starTimesRechargeRequest.Mobile;
            subscriberPaymentInfoDTO.Reference = "PP" + referenceGenerated;
            subscriberPaymentInfoDTO.ServiceCode = starTimesRechargeRequest.Service_code;
            subscriberPaymentInfoDTO.SubsciberId = starTimesQuerySubscriberResponse.Subscriber_id.ToString();
            subscriberPaymentInfoDTO.SubscriberStatus = starTimesQuerySubscriberResponse.Subscriber_status;
            subscriberPaymentInfoDTO.CustomerName = starTimesQuerySubscriberResponse.Customer_name;
            subscriberPaymentInfoDTO.ContactAddress = starTimesQuerySubscriberResponse.Contact_address;
            subscriberPaymentInfoDTO.BasicOfferDisplayName = starTimesQuerySubscriberResponse.Basic_offer_display_name;
            subscriberPaymentInfoDTO.BasicOfferBusinessClass = starTimesQuerySubscriberResponse.Basic_offer_business_class;
            subscriberPaymentInfoDTO.NewPackageCode = starTimesRechargeRequest.New_package_code;
            subscriberPaymentInfoDTO.Firstname = starTimesRechargeRequest.Firstname;
            subscriberPaymentInfoDTO.Lastname = starTimesRechargeRequest.Lastname;
            subscriberPaymentInfoDTO.Email = starTimesRechargeRequest.Email;
            subscriberPaymentInfoDTO.MobileNumber = starTimesRechargeRequest.Mobile;
            subscriberPaymentInfoDTO.Amount = starTimesRechargeRequest.Amount;


            SubscriberPaymentInfoDTO subscriberPaymentInfo = await _subscriberPaymentInfoService.Create(subscriberPaymentInfoDTO);

            List<NotificationDetailDTO> notificationDetailDTO = await _notificationDetailService.GetAll();
            if (notificationDetailDTO[0].UniqueId != null)
            {
                if (subscriberPaymentInfo != null)
                {
                    ApiCredentialsResponse apiCredentialsResponse = Utility.Utility.RequestConsumerKeys();
                    string key = apiCredentialsResponse.ConsumerKey;
                    string pass = apiCredentialsResponse.ConsumerSecret;

                    string tokenApi = Utility.Utility.RequestApiToken(key, pass);

                    ApiOrderRequest apiOrderRequest = new ApiOrderRequest();
                    apiOrderRequest.Id = "PP" + referenceGenerated;
                    apiOrderRequest.Currency = "KES";
                    apiOrderRequest.Amount = starTimesRechargeRequest.Amount;
                    apiOrderRequest.Description = string.Concat("link |", "PP" + referenceGenerated);
                    apiOrderRequest.Callback_url = _configuration["Basehosting:appurl"] + _configuration["Basehosting:frontEndCallBackUrl"]; //To be updated with redirect page or product download page
                    apiOrderRequest.Notification_id = notificationDetailDTO[0].UniqueId;
                    // apiOrderRequest.Notification_id = "dbe1ac30-e0bc-4098-a8ec-de387a2452bc";


                    BillingAddress billingAddress = new BillingAddress();
                    billingAddress.Phone_number = starTimesRechargeRequest.Mobile;
                    billingAddress.Email_address = starTimesRechargeRequest.Email;
                    billingAddress.Country_code = "";
                    billingAddress.First_name = starTimesRechargeRequest.Firstname;
                    billingAddress.Middle_name = "";
                    billingAddress.Last_name = starTimesRechargeRequest.Lastname;
                    billingAddress.Line_1 = "";
                    billingAddress.Line_2 = "";
                    billingAddress.City = "";
                    billingAddress.State = "";
                    billingAddress.Postal_code = "";
                    billingAddress.Zip_code = "";

                    apiOrderRequest.Billing_address = billingAddress;

                    string dataApi = JsonConvert.SerializeObject(apiOrderRequest);
                    string submitorder = _configuration["Basehosting:api3submitorder"];
                    string resourceUrl = submitorder;
                    string response = Utility.Utility.PostApi3Data(dataApi, resourceUrl, (int)HttpRequestMethods.POST, tokenApi);

                    SubmitOrderResponse orderResponse = JsonConvert.DeserializeObject<SubmitOrderResponse>(response);

                    if (orderResponse.Status == HelperRepository.DefaultOkCode)
                    {
                        return Ok(new StarTimesApiRechargeResponse
                        {
                            Message = "Success",
                            Status = HelperRepository.DefaultOkCode,
                            PaymentUrl = orderResponse.Redirect_url
                        });
                    }

                }


            }







            string info = string.Empty;

            //send recharfing
            return BadRequest(new StarTimesApiRechargeResponse
            {
                Message = "Bad Request",
                Status = HelperRepository.BadRequestCode

            });


        }


        [ResponseType(typeof(ApiIpnReceivedResponse))]
        [HttpGet]
        public async Task<IActionResult> CreateTransaction([FromQuery] TransactionCreateRequest req)
        {
            string consumerKey, consumerSecret = string.Empty;
            if (!ModelState.IsValid)
            {

                return BadRequest(new ApiIpnReceivedResponse
                {
                    Status = 404

                });
            }


            ApiCredentialsResponse apiCredentialsResponse = Utility.Utility.RequestConsumerKeys();
            consumerKey = apiCredentialsResponse.ConsumerKey;
            consumerSecret = apiCredentialsResponse.ConsumerSecret;


            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path, false);
            var root = configBuilder.Build();
            var apiTransactionStatus = root.GetSection("Basehosting:api3transactionstatus");
            string apiPaymentStatusResponse = "";

            try
            {

                string token = Utility.Utility.RequestApiToken(consumerKey, consumerSecret);
                dynamic Querypayment = new ExpandoObject();
                Querypayment.orderTrackingId = req.OrderTrackingId;
                string data = JsonConvert.SerializeObject(Querypayment);
                string transactionstatus = apiTransactionStatus.Value;

                string resourceUrl = transactionstatus + "orderTrackingId=" + req.OrderTrackingId;
                apiPaymentStatusResponse = Utility.Utility.PostApi3Data(data, resourceUrl, (int)HttpRequestMethods.GET, token);

                PaymentQueryApiResponse paymentQueryApiResponse = JsonConvert.DeserializeObject<PaymentQueryApiResponse>(apiPaymentStatusResponse);

                if (paymentQueryApiResponse.Status == Convert.ToInt32(HttpStatusCode.OK).ToString())
                {
                    SubscriberPaymentInfoDTO subscriberPaymentInfoDTO = await _subscriberPaymentInfoService.SearchClientAsync(a => a.Reference.Equals(req.OrderMerchantReference));
                    //proceed with the steps

                    SubscriberTransactionDetailDTO subscriberTransactionDetailDTO = new SubscriberTransactionDetailDTO();

                    subscriberTransactionDetailDTO.ConfirmationCode = paymentQueryApiResponse.Confirmation_code;
                    subscriberTransactionDetailDTO.MerchantReference = paymentQueryApiResponse.Merchant_reference;
                    subscriberTransactionDetailDTO.PaymentMethod = paymentQueryApiResponse.Payment_method;
                    subscriberTransactionDetailDTO.TrackingId = Guid.Parse(req.OrderTrackingId);
                    subscriberTransactionDetailDTO.Status = paymentQueryApiResponse.Payment_status_description;
                    subscriberTransactionDetailDTO.SubscriberPaymentInfonId = subscriberPaymentInfoDTO.Id;
                    subscriberTransactionDetailDTO.Currency = paymentQueryApiResponse.Currency;
                    subscriberTransactionDetailDTO.Amount = paymentQueryApiResponse.Amount;
                    


                    SubscriberTransactionDetailDTO subscriberTransactionCheck = await _subscriberTransactionDetailService.SearchClientAsync(a => a.MerchantReference.Equals(req.OrderMerchantReference));

                    if (subscriberTransactionCheck == null)
                    {
                        SubscriberTransactionDetailDTO subscriberTransactionDetail = await _subscriberTransactionDetailService.Create(subscriberTransactionDetailDTO);


                        if (subscriberTransactionDetail != null)
                        {
                            StarTimesRechargeRequest starTimesRechargeRequest = new StarTimesRechargeRequest();
                            starTimesRechargeRequest.Amount = paymentQueryApiResponse.Amount.ToString();
                            starTimesRechargeRequest.Mobile = subscriberPaymentInfoDTO.Mobile;
                            starTimesRechargeRequest.Serial_no = req.OrderMerchantReference;
                            starTimesRechargeRequest.Transaction_time = subscriberTransactionDetail.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss");
                            starTimesRechargeRequest.Service_code = subscriberPaymentInfoDTO.ServiceCode;
                            starTimesRechargeRequest.New_package_code = subscriberPaymentInfoDTO.NewPackageCode;

                            if (paymentQueryApiResponse.Payment_status_description.Equals(PaymentStatus.Completed.ToString()))
                            {
                                string starTimesRechargingUrl = "recharging";
                                string dataStarTimes = JsonConvert.SerializeObject(starTimesRechargeRequest);
                                IRestResponse jsonResultRecharge = Utility.Utility.PostApiData(dataStarTimes, starTimesRechargingUrl, (int)HttpRequestMethods.POST);
                                if (jsonResultRecharge.StatusCode == System.Net.HttpStatusCode.OK)
                                {
                                    StarTimesRechargeResponse starTimesRechargeResponse = JsonConvert.DeserializeObject<StarTimesRechargeResponse>(jsonResultRecharge.Content);

                                    SubscriberTransactionDetailDTO subscriberTransaction = await _subscriberTransactionDetailService.SearchClientAsync(a => a.TrackingId.Equals(Guid.Parse(req.OrderTrackingId)));
                                    subscriberTransaction.Posted = 1;

                                    SubscriberTransactionDetailDTO transactionDetailDTO = await _subscriberTransactionDetailService.Update(subscriberTransaction);

                                    return Ok((new ApiIpnReceivedResponse
                                    {
                                        Status = 200,
                                        OrderMerchantReference = req.OrderMerchantReference,
                                        OrderNotificationType = req.OrderNotificationType,
                                        OrderTrackingId = req.OrderTrackingId


                                    }));


                                }
                                else
                                {
                                    StarTimesErrorResponse errorResponse = JsonConvert.DeserializeObject<StarTimesErrorResponse>(jsonResultRecharge.Content);


                                    return Ok((new ApiIpnReceivedResponse
                                    {
                                        Status = 200,
                                        OrderMerchantReference = req.OrderMerchantReference,
                                        OrderNotificationType = req.OrderNotificationType,
                                        OrderTrackingId = req.OrderTrackingId


                                    }));


                                }

                            }
                            else
                            {
                                return Ok((new ApiIpnReceivedResponse
                                {
                                    Status = 200,
                                    OrderMerchantReference = req.OrderMerchantReference,
                                    OrderNotificationType = req.OrderNotificationType,
                                    OrderTrackingId = req.OrderTrackingId


                                }));


                            }





                        }


                    }
                    else
                    {
                        if (subscriberTransactionCheck.Posted == (int)StarTimePostStatus.NotPosted)
                        {
                            StarTimesRechargeRequest starTimesRechargeRequest = new StarTimesRechargeRequest();
                            starTimesRechargeRequest.Amount = paymentQueryApiResponse.Amount.ToString();
                            starTimesRechargeRequest.Mobile = subscriberPaymentInfoDTO.Mobile;
                            starTimesRechargeRequest.Serial_no = req.OrderMerchantReference;
                            starTimesRechargeRequest.Transaction_time = subscriberTransactionCheck.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss");
                            starTimesRechargeRequest.Service_code = subscriberPaymentInfoDTO.ServiceCode;
                            starTimesRechargeRequest.New_package_code = subscriberPaymentInfoDTO.NewPackageCode;

                            if (paymentQueryApiResponse.Payment_status_description.Equals(PaymentStatus.Completed.ToString()))
                            {
                                string starTimesRechargingUrl = "recharging";
                                string dataStarTimes = JsonConvert.SerializeObject(starTimesRechargeRequest);
                                IRestResponse jsonResultRecharge = Utility.Utility.PostApiData(dataStarTimes, starTimesRechargingUrl, (int)HttpRequestMethods.POST);
                                if (jsonResultRecharge.StatusCode == System.Net.HttpStatusCode.OK)
                                {
                                    StarTimesRechargeResponse starTimesRechargeResponse = JsonConvert.DeserializeObject<StarTimesRechargeResponse>(jsonResultRecharge.Content);

                                    SubscriberTransactionDetailDTO subscriberTransaction = await _subscriberTransactionDetailService.SearchClientAsync(a => a.TrackingId.Equals(Guid.Parse(req.OrderTrackingId)));
                                    subscriberTransaction.Posted = 1;

                                    SubscriberTransactionDetailDTO transactionDetailDTO = await _subscriberTransactionDetailService.Update(subscriberTransaction);

                                    return Ok((new ApiIpnReceivedResponse
                                    {
                                        Status = 200,
                                        OrderMerchantReference = req.OrderMerchantReference,
                                        OrderNotificationType = req.OrderNotificationType,
                                        OrderTrackingId = req.OrderTrackingId


                                    }));


                                }
                                else
                                {
                                    StarTimesErrorResponse errorResponse = JsonConvert.DeserializeObject<StarTimesErrorResponse>(jsonResultRecharge.Content);


                                    return Ok((new ApiIpnReceivedResponse
                                    {
                                        Status = 200,
                                        OrderMerchantReference = req.OrderMerchantReference,
                                        OrderNotificationType = req.OrderNotificationType,
                                        OrderTrackingId = req.OrderTrackingId


                                    }));


                                }


                            }
                        }
                    }
                }
                else
                {
                    //error occurred
                    //log error
                    return BadRequest(new ApiIpnReceivedResponse
                    {
                        Status = 400

                    });

                }



            }
            catch (Exception e)
            {
                string mess = e.Message;
                string exce = e.StackTrace;

            }



            return BadRequest(
                new BaseResponse
                {
                    Message = "Request Received",
                    Status = HelperRepository.BadRequestCode

                }
                );



        }

        [ResponseType(typeof(PaymentQueryApiResponse))]
        public async Task<IActionResult> GetTransactionStatus([FromBody] TransactionCreateRequest request)
        {
            ApiCredentialsResponse apiCredentialsResponse = Utility.Utility.RequestConsumerKeys();
            string consumerKey = apiCredentialsResponse.ConsumerKey;
            string consumerSecret = apiCredentialsResponse.ConsumerSecret;


            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path, false);
            var root = configBuilder.Build();
            var apiTransactionStatus = root.GetSection("Basehosting:api3transactionstatus");
            string apiPaymentStatusResponse = "";

            try
            {

                string token = Utility.Utility.RequestApiToken(consumerKey, consumerSecret);


                dynamic Querypayment = new ExpandoObject();
                Querypayment.orderTrackingId = request.OrderTrackingId;

                string data = JsonConvert.SerializeObject(Querypayment);
                string transactionstatus = apiTransactionStatus.Value;

                string resourceUrl = transactionstatus + "orderTrackingId=" + request.OrderTrackingId;
                apiPaymentStatusResponse = Utility.Utility.PostApi3Data(data, resourceUrl, (int)HttpRequestMethods.GET, token);

                PaymentQueryApiResponse paymentQueryApiResponse = JsonConvert.DeserializeObject<PaymentQueryApiResponse>(apiPaymentStatusResponse);


                if (paymentQueryApiResponse.Status == Convert.ToInt32(HttpStatusCode.OK).ToString())
                {
                    SubscriberPaymentInfoDTO subscriberPaymentInfoDTO = await _subscriberPaymentInfoService.SearchClientAsync(a => a.Reference.Equals(request.OrderMerchantReference));
                    //proceed with the steps

                    SubscriberTransactionDetailDTO subscriberTransactionDetailDTO = new SubscriberTransactionDetailDTO();

                    subscriberTransactionDetailDTO.ConfirmationCode = paymentQueryApiResponse.Confirmation_code;
                    subscriberTransactionDetailDTO.MerchantReference = paymentQueryApiResponse.Merchant_reference;
                    subscriberTransactionDetailDTO.PaymentMethod = paymentQueryApiResponse.Payment_method;
                    subscriberTransactionDetailDTO.TrackingId = Guid.Parse(request.OrderTrackingId);
                    subscriberTransactionDetailDTO.Status = paymentQueryApiResponse.Payment_status_description;
                    subscriberTransactionDetailDTO.SubscriberPaymentInfonId = subscriberPaymentInfoDTO.Id;
                    subscriberTransactionDetailDTO.Currency = paymentQueryApiResponse.Currency;
                    subscriberTransactionDetailDTO.Amount = paymentQueryApiResponse.Amount;

                    SubscriberTransactionDetailDTO subscriberTransactionCheck = await _subscriberTransactionDetailService.SearchClientAsync(a => a.MerchantReference.Equals(request.OrderMerchantReference));
                    if (subscriberTransactionCheck == null)
                    {
                        SubscriberTransactionDetailDTO subscriberTransactionDetail = await _subscriberTransactionDetailService.Create(subscriberTransactionDetailDTO);


                        if (subscriberTransactionDetail != null)
                        {
                            StarTimesRechargeRequest starTimesRechargeRequest = new StarTimesRechargeRequest();
                            starTimesRechargeRequest.Amount = paymentQueryApiResponse.Amount.ToString();
                            starTimesRechargeRequest.Mobile = subscriberPaymentInfoDTO.Mobile;
                            starTimesRechargeRequest.Serial_no = request.OrderMerchantReference;
                            starTimesRechargeRequest.Transaction_time = subscriberTransactionDetail.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss");
                            starTimesRechargeRequest.Service_code = subscriberPaymentInfoDTO.ServiceCode;
                            starTimesRechargeRequest.New_package_code = subscriberPaymentInfoDTO.NewPackageCode;


                            if (paymentQueryApiResponse.Payment_status_description.Equals(PaymentStatus.Completed.ToString()))
                            {
                                string starTimesRechargingUrl = "recharging";
                                string dataStarTimes = JsonConvert.SerializeObject(starTimesRechargeRequest);
                                IRestResponse jsonResultRecharge = Utility.Utility.PostApiData(dataStarTimes, starTimesRechargingUrl, (int)HttpRequestMethods.POST);
                                if (jsonResultRecharge.StatusCode == System.Net.HttpStatusCode.OK)
                                {
                                    StarTimesRechargeResponse starTimesRechargeResponse = JsonConvert.DeserializeObject<StarTimesRechargeResponse>(jsonResultRecharge.Content);

                                    //if ok add status that transaction has been posted to startimes
                                    SubscriberTransactionDetailDTO subscriberTransaction = await _subscriberTransactionDetailService.SearchClientAsync(a => a.TrackingId.Equals(Guid.Parse(request.OrderTrackingId)));
                                    subscriberTransaction.Posted = 1;

                                    SubscriberTransactionDetailDTO transactionDetailDTO = await _subscriberTransactionDetailService.Update(subscriberTransaction);


                                }
                                else
                                {
                                    StarTimesErrorResponse errorResponse = JsonConvert.DeserializeObject<StarTimesErrorResponse>(jsonResultRecharge.Content);

                                    //Add status that is not updated


                                }



                            }




                        }


                    }
                    else
                    {

                        if (subscriberTransactionCheck.Posted == (int)StarTimePostStatus.NotPosted)
                        {
                            StarTimesRechargeRequest starTimesRechargeRequest = new StarTimesRechargeRequest();
                            starTimesRechargeRequest.Amount = paymentQueryApiResponse.Amount.ToString();
                            starTimesRechargeRequest.Mobile = subscriberPaymentInfoDTO.Mobile;
                            starTimesRechargeRequest.Serial_no = request.OrderMerchantReference;
                            starTimesRechargeRequest.Transaction_time = subscriberTransactionCheck.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss");
                            starTimesRechargeRequest.Service_code = subscriberPaymentInfoDTO.ServiceCode;
                            starTimesRechargeRequest.New_package_code = subscriberPaymentInfoDTO.NewPackageCode;


                            if (paymentQueryApiResponse.Payment_status_description.Equals(PaymentStatus.Completed.ToString()))
                            {
                                string starTimesRechargingUrl = "recharging";
                                string dataStarTimes = JsonConvert.SerializeObject(starTimesRechargeRequest);
                                IRestResponse jsonResultRecharge = Utility.Utility.PostApiData(dataStarTimes, starTimesRechargingUrl, (int)HttpRequestMethods.POST);
                                if (jsonResultRecharge.StatusCode == System.Net.HttpStatusCode.OK)
                                {
                                    StarTimesRechargeResponse starTimesRechargeResponse = JsonConvert.DeserializeObject<StarTimesRechargeResponse>(jsonResultRecharge.Content);

                                    //if ok add status that transaction has been posted to startimes
                                    SubscriberTransactionDetailDTO subscriberTransaction = await _subscriberTransactionDetailService.SearchClientAsync(a => a.TrackingId.Equals(Guid.Parse(request.OrderTrackingId)));
                                    subscriberTransaction.Posted = 1;

                                    SubscriberTransactionDetailDTO transactionDetailDTO = await _subscriberTransactionDetailService.Update(subscriberTransaction);


                                }
                                else
                                {
                                    StarTimesErrorResponse errorResponse = JsonConvert.DeserializeObject<StarTimesErrorResponse>(jsonResultRecharge.Content);

                                    //Add status that is not updated


                                }


                            }

                        }

                      
                    }
                  
                }

                return Ok(paymentQueryApiResponse);


            }
            catch (Exception e)
            {
                PaymentQueryApiResponse paymentQueryApiResponse = new PaymentQueryApiResponse();
                paymentQueryApiResponse.Status = HelperRepository.DefaultErrorCode;
                paymentQueryApiResponse.Message = "Error";

                return NotFound(paymentQueryApiResponse);

            

            }



        }
        public static bool GetQueryPaymentV3(string merchantRef, string transactionTrackingID, string merchantConsumer, string merchantSecret)
        {

            string reference = merchantRef;
            string pesapalTrackingId = transactionTrackingID;

            string ConsumerKey = merchantConsumer;
            string ConsumerSecret = merchantSecret;

            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path, false);
            var root = configBuilder.Build();
            var apiTransactionStatus = root.GetSection("Basehosting:api3transactionstatus");


            try
            {

                string token = Utility.Utility.RequestApiToken(ConsumerKey, ConsumerSecret);


                dynamic Querypayment = new ExpandoObject();
                Querypayment.orderTrackingId = pesapalTrackingId;

                string data = JsonConvert.SerializeObject(Querypayment);
                string transactionstatus = apiTransactionStatus.Value;

                string resourceUrl = transactionstatus + "orderTrackingId=" + pesapalTrackingId;
                string response = Utility.Utility.PostApi3Data(data, resourceUrl, (int)HttpRequestMethods.GET, token);

                PaymentQueryApiResponse paymentQueryApiResponse = JsonConvert.DeserializeObject<PaymentQueryApiResponse>(response);


                _statusupdate = paymentQueryApiResponse.Payment_status_description;
                _paymentmode = paymentQueryApiResponse.Payment_method;
                _paymentref = paymentQueryApiResponse.Merchant_reference;
                _amount = paymentQueryApiResponse.Amount;
                _confirmationCode = paymentQueryApiResponse.Confirmation_code;
                _merchantref = paymentQueryApiResponse.Merchant_reference;
                _currency = paymentQueryApiResponse.Currency;

                _statusupdate = _statusupdate.ToUpper();

            }
            catch (Exception e)
            {
                string mess = e.Message;
                string exce = e.StackTrace;

                return false;
            }

            return true;






        }


    }
}
