#pragma checksum "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\Partials\SearchResults.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "df394bade1ee189b1d9321b007757eac09e235e8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Partials_SearchResults), @"mvc.1.0.view", @"/Views/Partials/SearchResults.cshtml")]
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
#nullable restore
#line 1 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\Partials\SearchResults.cshtml"
using System.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df394bade1ee189b1d9321b007757eac09e235e8", @"/Views/Partials/SearchResults.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50a8dd4843e3e9f3dd035a23e2b3dcfce3137625", @"/Views/_ViewImports.cshtml")]
    public class Views_Partials_SearchResults : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<System.Data.DataTable>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DisplayUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<style>\r\n    #searchResultsTable td:nth-of-type(6) {\r\n        display: none;\r\n    }\r\n\r\n    #searchResultsTable th:nth-of-type(6) {\r\n        display: none;\r\n    }\r\n</style>\r\n\r\n<h2>\r\n    Results\r\n</h2>\r\n\r\n\r\n");
#nullable restore
#line 20 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\Partials\SearchResults.cshtml"
 if (Model.Rows.Count != 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <span>");
#nullable restore
#line 22 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\Partials\SearchResults.cshtml"
     Write(Model.Rows.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" users found.</span>\r\n");
            WriteLiteral("    <table id=\"searchResultsTable\" class=\"table\">\r\n        <thead>\r\n            <tr>\r\n");
#nullable restore
#line 27 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\Partials\SearchResults.cshtml"
                 foreach (DataColumn column in Model.Columns)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <th scope=\"col\">");
#nullable restore
#line 29 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\Partials\SearchResults.cshtml"
                               Write(column.Caption);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 30 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\Partials\SearchResults.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 34 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\Partials\SearchResults.cshtml"
             foreach (DataRow row in Model.Rows)
             {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr scope=\"row\">\r\n                    <td>");
#nullable restore
#line 37 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\Partials\SearchResults.cshtml"
                   Write(row[0].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 38 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\Partials\SearchResults.cshtml"
                   Write(row[1].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 39 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\Partials\SearchResults.cshtml"
                   Write(row[2].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 40 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\Partials\SearchResults.cshtml"
                   Write(row[3].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n");
#nullable restore
#line 42 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\Partials\SearchResults.cshtml"
                     if (Convert.ToBoolean(row[4]) == true)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "df394bade1ee189b1d9321b007757eac09e235e87902", async() => {
                WriteLiteral("\r\n                                <input type=\"hidden\" id=\"targetId\" name=\"targetId\"");
                BeginWriteAttribute("value", " value=\"", 1232, "\"", 1250, 1);
#nullable restore
#line 46 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\Partials\SearchResults.cshtml"
WriteAttributeValue("", 1240, row["ID"], 1240, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                                <button class=\"btn btn-primary\" type=\"submit\">Find user</button>\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </td>\r\n");
#nullable restore
#line 50 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\Partials\SearchResults.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>User is not findable.</td>\r\n");
#nullable restore
#line 54 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\Partials\SearchResults.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tr>\r\n");
#nullable restore
#line 56 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\Partials\SearchResults.cshtml"
             }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 59 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\Partials\SearchResults.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <span>No results.</span>\r\n");
#nullable restore
#line 63 "D:\Program Files\findle\ASP.NETFindle\ASP.NETFindle\Views\Partials\SearchResults.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<System.Data.DataTable> Html { get; private set; }
    }
}
#pragma warning restore 1591