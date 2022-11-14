#pragma checksum "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\User\PersonalDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9fa0b1d97e6fd83cebdc4e8cd4110b5cf05ee192"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_PersonalDetails), @"mvc.1.0.view", @"/Views/User/PersonalDetails.cshtml")]
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
#line 1 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\_ViewImports.cshtml"
using ASP.NETFindle;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\_ViewImports.cshtml"
using ASP.NETFindle.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fa0b1d97e6fd83cebdc4e8cd4110b5cf05ee192", @"/Views/User/PersonalDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50a8dd4843e3e9f3dd035a23e2b3dcfce3137625", @"/Views/_ViewImports.cshtml")]
    public class Views_User_PersonalDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ASP.NETFindle.Models.User>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\User\PersonalDetails.cshtml"
  
    ViewData["Title"] = "Personal Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<h1>Your Personal Details</h1>\r\n\r\n");
#nullable restore
#line 9 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\User\PersonalDetails.cshtml"
   
    var currentUser = ViewData["currentUser"] as ASP.NETFindle.Models.User;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    <h2>Information</h2>\r\n    <div class=\"mt-2\">\r\n        <h3>Full name</h3>\r\n        <span>");
#nullable restore
#line 17 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\User\PersonalDetails.cshtml"
         Write(currentUser.Firstname);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 17 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\User\PersonalDetails.cshtml"
                                Write(currentUser.Lastname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n    </div>\r\n    <div class=\"mt-2\">\r\n        <h3>Email</h3>\r\n        <span>");
#nullable restore
#line 21 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\User\PersonalDetails.cshtml"
         Write(currentUser.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n    </div>\r\n    <div class=\"mt-2\">\r\n        <h3>Type</h3>\r\n        <span>");
#nullable restore
#line 25 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\User\PersonalDetails.cshtml"
         Write(currentUser.UserFunction);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n    </div>\r\n    <div class=\"mt-2\">\r\n        <h3>Profile</h3>\r\n        <span>");
#nullable restore
#line 29 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\User\PersonalDetails.cshtml"
         Write(currentUser.Profile);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n    </div>\r\n    <div class=\"mt-2\">\r\n        <h3>Status</h3>\r\n        <span>\r\n");
#nullable restore
#line 34 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\User\PersonalDetails.cshtml"
              
                if (@currentUser.Findable == true)
                {
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("You\'re searchable.");
#nullable restore
#line 37 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\User\PersonalDetails.cshtml"
                                                   
                }
                else
                {
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("You\'re not searchable.");
#nullable restore
#line 41 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\User\PersonalDetails.cshtml"
                                                       
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </span>
    </div>
    <div class=""mt-2"">
        <h3>Password</h3>
        <div id=""partial"" class=""mt-3"">

        </div>
        <button id=""submit"" class=""btn btn-outline-primary"">Change password</button>
    </div>
    <h2 class=""mt-3"">Search histories</h2>
    <span></span>
</div>

<script src=""//ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js""></script>

<script>
    var url = '");
#nullable restore
#line 60 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\User\PersonalDetails.cshtml"
          Write(Url.Action("GetChangePassword", "User"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
    $('#submit').on('click',function(e){
     e.preventDefault();
    $.ajax({
        type: ""POST"",
        url: url,
        data:$('form').serialize(),
    }).done(function (r) {
        $('#submit').hide();
       $('#partial').html(r);

    }).fail(function (e) {
        console.log(e.responseText);
    });
    });
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ASP.NETFindle.Models.User> Html { get; private set; }
    }
}
#pragma warning restore 1591