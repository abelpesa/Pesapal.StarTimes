#pragma checksum "C:\Users\User\source\repos\Pesapal.StarTimes\Pesapal.StarTimes.Portal\Views\StarTimes\PaymentStatus.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ff2daa660ceba2565d94769c2c262fed7935d27d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_StarTimes_PaymentStatus), @"mvc.1.0.view", @"/Views/StarTimes/PaymentStatus.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\User\source\repos\Pesapal.StarTimes\Pesapal.StarTimes.Portal\Views\_ViewImports.cshtml"
using Pesapal.StarTimes.Portal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\source\repos\Pesapal.StarTimes\Pesapal.StarTimes.Portal\Views\_ViewImports.cshtml"
using Pesapal.StarTimes.Portal.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff2daa660ceba2565d94769c2c262fed7935d27d", @"/Views/StarTimes/PaymentStatus.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ce7088fa8854544d643bf52e075c47bb6bb996e", @"/Views/_ViewImports.cshtml")]
    public class Views_StarTimes_PaymentStatus : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<StarTimes.Shared.ApiResponse.PaymentQueryApiResponse>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\User\source\repos\Pesapal.StarTimes\Pesapal.StarTimes.Portal\Views\StarTimes\PaymentStatus.cshtml"
  
    ViewData["Title"] = "PaymentStatus";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Payment Status</h1>\r\n\r\n<div>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 13 "C:\Users\User\source\repos\Pesapal.StarTimes\Pesapal.StarTimes.Portal\Views\StarTimes\PaymentStatus.cshtml"
       Write(Html.DisplayNameFor(model => model.Payment_method));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 16 "C:\Users\User\source\repos\Pesapal.StarTimes\Pesapal.StarTimes.Portal\Views\StarTimes\PaymentStatus.cshtml"
       Write(Html.DisplayFor(model => model.Payment_method));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 19 "C:\Users\User\source\repos\Pesapal.StarTimes\Pesapal.StarTimes.Portal\Views\StarTimes\PaymentStatus.cshtml"
       Write(Html.DisplayNameFor(model => model.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 22 "C:\Users\User\source\repos\Pesapal.StarTimes\Pesapal.StarTimes.Portal\Views\StarTimes\PaymentStatus.cshtml"
       Write(Html.DisplayFor(model => model.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 25 "C:\Users\User\source\repos\Pesapal.StarTimes\Pesapal.StarTimes.Portal\Views\StarTimes\PaymentStatus.cshtml"
       Write(Html.DisplayNameFor(model => model.Created_date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 28 "C:\Users\User\source\repos\Pesapal.StarTimes\Pesapal.StarTimes.Portal\Views\StarTimes\PaymentStatus.cshtml"
       Write(Html.DisplayFor(model => model.Created_date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 31 "C:\Users\User\source\repos\Pesapal.StarTimes\Pesapal.StarTimes.Portal\Views\StarTimes\PaymentStatus.cshtml"
       Write(Html.DisplayNameFor(model => model.Confirmation_code));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 34 "C:\Users\User\source\repos\Pesapal.StarTimes\Pesapal.StarTimes.Portal\Views\StarTimes\PaymentStatus.cshtml"
       Write(Html.DisplayFor(model => model.Confirmation_code));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 37 "C:\Users\User\source\repos\Pesapal.StarTimes\Pesapal.StarTimes.Portal\Views\StarTimes\PaymentStatus.cshtml"
       Write(Html.DisplayNameFor(model => model.Payment_status_description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 40 "C:\Users\User\source\repos\Pesapal.StarTimes\Pesapal.StarTimes.Portal\Views\StarTimes\PaymentStatus.cshtml"
       Write(Html.DisplayFor(model => model.Payment_status_description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 43 "C:\Users\User\source\repos\Pesapal.StarTimes\Pesapal.StarTimes.Portal\Views\StarTimes\PaymentStatus.cshtml"
       Write(Html.DisplayNameFor(model => model.Message));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 46 "C:\Users\User\source\repos\Pesapal.StarTimes\Pesapal.StarTimes.Portal\Views\StarTimes\PaymentStatus.cshtml"
       Write(Html.DisplayFor(model => model.Message));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 49 "C:\Users\User\source\repos\Pesapal.StarTimes\Pesapal.StarTimes.Portal\Views\StarTimes\PaymentStatus.cshtml"
       Write(Html.DisplayNameFor(model => model.Payment_account));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 52 "C:\Users\User\source\repos\Pesapal.StarTimes\Pesapal.StarTimes.Portal\Views\StarTimes\PaymentStatus.cshtml"
       Write(Html.DisplayFor(model => model.Payment_account));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 55 "C:\Users\User\source\repos\Pesapal.StarTimes\Pesapal.StarTimes.Portal\Views\StarTimes\PaymentStatus.cshtml"
       Write(Html.DisplayNameFor(model => model.Call_back_url));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 58 "C:\Users\User\source\repos\Pesapal.StarTimes\Pesapal.StarTimes.Portal\Views\StarTimes\PaymentStatus.cshtml"
       Write(Html.DisplayFor(model => model.Call_back_url));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 61 "C:\Users\User\source\repos\Pesapal.StarTimes\Pesapal.StarTimes.Portal\Views\StarTimes\PaymentStatus.cshtml"
       Write(Html.DisplayNameFor(model => model.Status_code));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 64 "C:\Users\User\source\repos\Pesapal.StarTimes\Pesapal.StarTimes.Portal\Views\StarTimes\PaymentStatus.cshtml"
       Write(Html.DisplayFor(model => model.Status_code));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 67 "C:\Users\User\source\repos\Pesapal.StarTimes\Pesapal.StarTimes.Portal\Views\StarTimes\PaymentStatus.cshtml"
       Write(Html.DisplayNameFor(model => model.Merchant_reference));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 70 "C:\Users\User\source\repos\Pesapal.StarTimes\Pesapal.StarTimes.Portal\Views\StarTimes\PaymentStatus.cshtml"
       Write(Html.DisplayFor(model => model.Merchant_reference));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n   \r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 74 "C:\Users\User\source\repos\Pesapal.StarTimes\Pesapal.StarTimes.Portal\Views\StarTimes\PaymentStatus.cshtml"
       Write(Html.DisplayNameFor(model => model.Currency));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 77 "C:\Users\User\source\repos\Pesapal.StarTimes\Pesapal.StarTimes.Portal\Views\StarTimes\PaymentStatus.cshtml"
       Write(Html.DisplayFor(model => model.Currency));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 80 "C:\Users\User\source\repos\Pesapal.StarTimes\Pesapal.StarTimes.Portal\Views\StarTimes\PaymentStatus.cshtml"
       Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 83 "C:\Users\User\source\repos\Pesapal.StarTimes\Pesapal.StarTimes.Portal\Views\StarTimes\PaymentStatus.cshtml"
       Write(Html.DisplayFor(model => model.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StarTimes.Shared.ApiResponse.PaymentQueryApiResponse> Html { get; private set; }
    }
}
#pragma warning restore 1591
