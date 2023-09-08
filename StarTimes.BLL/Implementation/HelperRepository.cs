using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace StarTimes.BLL.Implementation
{
    public class HelperRepository
    {
        public static string DefaultOkMessage => "Request Processed Succesfully";
        public static string DefaultOkCode => Convert.ToInt32(HttpStatusCode.OK).ToString();

        public static string DefaultErrorCode => Convert.ToInt32(HttpStatusCode.InternalServerError).ToString();
        public static string BadRequestCode => Convert.ToInt32(HttpStatusCode.BadRequest).ToString();
        public static string NotFoundCode => Convert.ToInt32(HttpStatusCode.NotFound).ToString();

    }

}
