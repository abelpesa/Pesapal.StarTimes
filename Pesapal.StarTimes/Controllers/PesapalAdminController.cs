using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Description;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Pesapal.StarTimes.Model;
using StarTimes.BLL.DTO;
using StarTimes.BLL.Implementation;
using StarTimes.BLL.Interfaces;
using StarTimes.BLL.Utility;
using StarTimes.Shared.ApiRequest;
using StarTimes.Shared.ApiResponse;
using StarTimes.Shared.Enums;

namespace Pesapal.StarTimes.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PesapalAdminController : ControllerBase
    {
        IConfiguration _configuration;
        INotificationDetailService _notificationDetailService { get; set; }
        ISubscriberPaymentInfoService _subscriberPaymentInfoService { get; set; }
        ISubscriberTransactionDetailService _subscriberTransactionDetailService { get; set; }

        public PesapalAdminController(IConfiguration configuration, INotificationDetailService notificationDetailService, ISubscriberPaymentInfoService subscriberPaymentInfoService, ISubscriberTransactionDetailService subscriberTransactionDetailService)
        {
            _configuration = configuration;
            _notificationDetailService = notificationDetailService;
            _subscriberPaymentInfoService = subscriberPaymentInfoService;
            _subscriberTransactionDetailService = subscriberTransactionDetailService;
        }

        [ResponseType(typeof(BaseResponse))]
        [HttpPost]
        public async Task<IActionResult> CreateIpn()
        {


            //create an IPN
            string key = "";
            string pass = "";
            ApiCredentialsResponse apiCredentialsResponse = Utility.Utility.RequestConsumerKeys();
            key = apiCredentialsResponse.ConsumerKey;
            pass = apiCredentialsResponse.ConsumerSecret;

            string token = Utility.Utility.RequestApiToken(key, pass);

            var apiIPNurl = string.Concat(_configuration["Basehosting:baseurl"], _configuration["Basehosting:api3StarTimesIPN"]);


            ApiIpnRequest apiIpnRequest = new ApiIpnRequest();
            apiIpnRequest.Url = apiIPNurl;
            apiIpnRequest.Ipn_notification_type = "GET";
            //check if IPN is registered
            string notificationGuid = string.Empty;
            string dataIpn = JsonConvert.SerializeObject(apiIpnRequest);
            var registerIpn = _configuration["Basehosting:api3guidstring"];
            string resourceUrlIpn = registerIpn;

            string responseipn = Utility.Utility.PostApiDataAPI3(dataIpn, resourceUrlIpn, (int)HttpRequestMethods.POST, token);
            ApiIpnResponse apiIpnResponse = new ApiIpnResponse();
            try
            {
                apiIpnResponse = JsonConvert.DeserializeObject<ApiIpnResponse>(responseipn);

                if (apiIpnResponse.Status == Convert.ToInt32(HttpStatusCode.OK).ToString())
                {
                    notificationGuid = apiIpnResponse.Ipn_id;

                    NotificationDetailDTO notificationDetailDTO = new NotificationDetailDTO();
                    notificationDetailDTO.UniqueId = notificationGuid;
                    NotificationDTO notification = new NotificationDTO();
                    notification.UniqueId = notificationGuid;


                    MerchantNotificationApiCreateRequest merchantNotificationApiCreate = new MerchantNotificationApiCreateRequest();
                    merchantNotificationApiCreate.UniqueId = notificationGuid;

                    List<NotificationDetailDTO> detailDTO = await _notificationDetailService.GetAll();
                    NotificationDetailDTO resultNotification = new NotificationDetailDTO();

                    if (detailDTO != null)
                    {
                        for (int i = 0; i < detailDTO.Count; i++)
                        {
                            NotificationDetailDTO savedNotification = _notificationDetailService.GetById(detailDTO[i].Id);
                            savedNotification.UniqueId = notificationGuid;

                           resultNotification = await _notificationDetailService.Update(savedNotification);
                            
                        }

                    }
                    else
                    {
                        NotificationDetailDTO notificationDetail = Utility<NotificationDTO, NotificationDetailDTO>.MapEntity(notification);
                        resultNotification = await _notificationDetailService.Create(notificationDetailDTO);

                    }

                  


                    if (resultNotification == null)
                    {
                        return Ok(new BaseResponse
                        {
                            Message = "Ipn Created on API 3,Failed to Create Ipn in db",
                            Status = HelperRepository.DefaultOkCode,


                        });


                    }


                }
                /*check if it is already stored
                 * get the token
                 * send request to ipn list check
                 * loop through the list checking for the same url
                 * get the ipn and store the details
                 * */
                else
                {
                    TokenRequestApi tokenRequestApi = new TokenRequestApi();
                    tokenRequestApi.consumer_key = key;
                    tokenRequestApi.consumer_secret = pass;
                    string data = JsonConvert.SerializeObject(tokenRequestApi);
                    var listipn = _configuration["Basehosting:api3ipnlist"];
                    string listIpnValue = listipn;
                    string listresponseipn = Utility.Utility.PostApiDataAPI3(data, listIpnValue, (int)HttpRequestMethods.GET, token);
                    List<ApiIpnListResponse> apiIPNListResponse = new List<ApiIpnListResponse>();

                    try
                    {

                        apiIPNListResponse = JsonConvert.DeserializeObject<List<ApiIpnListResponse>>(listresponseipn);
                        if (apiIPNListResponse != null)
                        {
                            //check list


                            foreach (ApiIpnListResponse apiIPNList in apiIPNListResponse)
                            {
                                if (apiIPNList.Url.Equals(apiIPNurl) && apiIPNList.Ipn_notification_type_description.Equals("GET"))
                                {
                                    //get the IPN id
                                    notificationGuid = apiIPNList.Ipn_id;
                                    MerchantNotificationApiCreateRequest merchantNotificationApiCreate = new MerchantNotificationApiCreateRequest();
                                    merchantNotificationApiCreate.UniqueId = notificationGuid;

                                    NotificationDetailDTO notificationDetail = Utility<MerchantNotificationApiCreateRequest, NotificationDetailDTO>.MapEntity(merchantNotificationApiCreate);
                                    //search if exists
                                    List<NotificationDetailDTO> detailDTO = await _notificationDetailService.GetAll();

                                    if (detailDTO != null)
                                    {
                                        for (int i = 0; i < detailDTO.Count; i++)
                                        {
                                            NotificationDetailDTO savedNotification = _notificationDetailService.GetById(detailDTO[i].Id);
                                            savedNotification.UniqueId = notificationGuid;

                                            _notificationDetailService.Update(savedNotification);

                                        }

                                    }
                                    else
                                    {
                                        NotificationDetailDTO resultNotification = await _notificationDetailService.Create(notificationDetail);

                                    }


                                }

                            }

                        }



                    }
                    catch (Exception e)
                    {

                        return BadRequest(new BaseResponse
                        {
                            Message = "Ipn Created, not updated in database",
                            Status = HelperRepository.BadRequestCode,


                        });

                    }
                }




            }
            catch (Exception e)
            {
                return BadRequest(new BaseResponse
                {

                    Status = HelperRepository.BadRequestCode,
                    Message = "There was an issue in creating the ipn.",


                });
            }

            return Ok(new BaseResponse
            {

                Status = HelperRepository.DefaultOkCode,
                Message = "Ipn created on API3 and created in database.",


            });
        }

        //implement search via date - done
        //default todays transactions - done
        //enable search via date selection - done
        //enable search via confirmation code - done
        //enable search merchantreference - done
        //create total transaction month volume
        //create daily total volume
        //create hangfirejob to run monthly

        [ResponseType(typeof(TransactionDetailListResponse))]
        [HttpPost]
        public async Task<IActionResult> GetTransactions([FromBody] TransactionAdminSearchRequest request)
        {
            var responses = new List<TransactionDetailsResponse>();

            List<SubscriberTransactionDetailDTO> subscriberTransactionDetailDTOs = new List<SubscriberTransactionDetailDTO>();

            TransactionAdminSearchRequestDTO transactionAdminSearchRequestDTO = new TransactionAdminSearchRequestDTO();
            transactionAdminSearchRequestDTO.ConfirmationCode = request.ConfirmationCode;
            transactionAdminSearchRequestDTO.DateFrom = request.DateFrom;
            transactionAdminSearchRequestDTO.DateTo = request.DateTo;

            subscriberTransactionDetailDTOs = await _subscriberTransactionDetailService.GetAllData(transactionAdminSearchRequestDTO);

            int transactionCount = subscriberTransactionDetailDTOs.Count;
            List<TransactionDetailsResponse> transactionDetailsResponses = new List<TransactionDetailsResponse>(); 

            for (int i = 0; i< transactionCount; i++)
            {
                transactionDetailsResponses.Add(new TransactionDetailsResponse
                {
                    Id = subscriberTransactionDetailDTOs[i].Id,
                    ConfirmationCode = subscriberTransactionDetailDTOs[i].ConfirmationCode,
                    Status = subscriberTransactionDetailDTOs[i].Status,
                    SubscriberPaymentInfonId = subscriberTransactionDetailDTOs[i].SubscriberPaymentInfonId,
                    MerchantReference = subscriberTransactionDetailDTOs[i].MerchantReference,
                    PaymentMethod = subscriberTransactionDetailDTOs[i].PaymentMethod,
                    Posted = subscriberTransactionDetailDTOs[i].Posted,
                    TrackingId = subscriberTransactionDetailDTOs[i].TrackingId.ToString(),
                    Date = subscriberTransactionDetailDTOs[i].CreatedDate.ToString("yyyy-MM-dd"),
                    Amount = subscriberTransactionDetailDTOs[i].Amount,
                    Currency = subscriberTransactionDetailDTOs[i].Currency
                    
                });

            
            }

            TransactionDetailListResponse transactionDetailListResponse = new TransactionDetailListResponse();
            transactionDetailListResponse.TransactionDetailsResponses = transactionDetailsResponses;
            transactionDetailListResponse.Message = HelperRepository.DefaultOkMessage;
            transactionDetailListResponse.Status = HelperRepository.DefaultOkCode;


            return Ok(transactionDetailListResponse);


        }



    }
}

