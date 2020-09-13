#pragma checksum "E:\Repos\Metrict\Metrict\Views\Campaigns\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9911fb75636a2f800039bd29d8fff54db15de8eb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Campaigns_Dashboard), @"mvc.1.0.view", @"/Views/Campaigns/Dashboard.cshtml")]
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
#line 1 "E:\Repos\Metrict\Metrict\Views\_ViewImports.cshtml"
using Metrict;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Repos\Metrict\Metrict\Views\_ViewImports.cshtml"
using Metrict.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9911fb75636a2f800039bd29d8fff54db15de8eb", @"/Views/Campaigns/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99945052b75fd5138d85b542a997bbae47015463", @"/Views/_ViewImports.cshtml")]
    public class Views_Campaigns_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Metrict.Models.Campaign>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\Repos\Metrict\Metrict\Views\Campaigns\Dashboard.cshtml"
  
    ViewData["Title"] = "Dashboard";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9911fb75636a2f800039bd29d8fff54db15de8eb3392", async() => {
                WriteLiteral("\r\n    <script src=\"https://cdn.jsdelivr.net/npm/chart.js@2.8.0\"></script>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9911fb75636a2f800039bd29d8fff54db15de8eb4439", async() => {
                WriteLiteral("\r\n    <div class=\"container vh100\">\r\n        <main role=\"main\" class=\"pb-3\">\r\n            <h1>Dashboard</h1>\r\n\r\n            <p>\r\n                Current user count: ");
#nullable restore
#line 17 "E:\Repos\Metrict\Metrict\Views\Campaigns\Dashboard.cshtml"
                               Write(ViewBag.userCount);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </p>\r\n\r\n            <p>\r\n                Data for week starting: ");
#nullable restore
#line 21 "E:\Repos\Metrict\Metrict\Views\Campaigns\Dashboard.cshtml"
                                   Write(ViewBag.dateTimeWeekStart);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </p>\r\n\r\n            <p>\r\n                Number of reports counted: ");
#nullable restore
#line 25 "E:\Repos\Metrict\Metrict\Views\Campaigns\Dashboard.cshtml"
                                      Write(ViewBag.reportDataCount);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </p>\r\n\r\n            <a");
                BeginWriteAttribute("href", " href=\"", 609, "\"", 658, 2);
                WriteAttributeValue("", 616, "/Campaigns/ManageCampaignUser?id=", 616, 33, true);
#nullable restore
#line 28 "E:\Repos\Metrict\Metrict\Views\Campaigns\Dashboard.cshtml"
WriteAttributeValue("", 649, Model.Id, 649, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\'btn btn-success text-white\' style=\'cursor:pointer; width:100px;\'>\r\n                Manage Members\r\n            </a>\r\n            <a");
                BeginWriteAttribute("href", " href=\"", 798, "\"", 844, 2);
                WriteAttributeValue("", 805, "/Campaigns/NewCampaignUser?id=", 805, 30, true);
#nullable restore
#line 31 "E:\Repos\Metrict\Metrict\Views\Campaigns\Dashboard.cshtml"
WriteAttributeValue("", 835, Model.Id, 835, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
                Add New Members
            </a>

            <div id=""chart_container"">
                <canvas id=""bar_chart"">
                </canvas>
            </div>
        </main>
    </div>

    <script>

        var reportData = ");
#nullable restore
#line 44 "E:\Repos\Metrict\Metrict\Views\Campaigns\Dashboard.cshtml"
                    Write(Html.Raw(Json.Serialize(ViewBag.reportData)));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        var lbls = ");
#nullable restore
#line 45 "E:\Repos\Metrict\Metrict\Views\Campaigns\Dashboard.cshtml"
              Write(Html.Raw(Json.Serialize(ViewBag.colNames)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";

        var ctx = document.getElementById('bar_chart').getContext('2d');
        var barChart = new Chart(ctx, {
            type: 'bar',
            data: {
                labels: lbls,
                datasets: [{
                    label: ""Number of Activities"",
                    data: reportData,
                    backgroundColor: [""rgba(242,166,54,.5)"", ""rgba(145,65,72,.5)"", ""rgba(74,25,92,.5)""],
                    borderColor: [[""rgba(242,166,54)"", ""rgba(145,65,72)"", ""rgba(74,25,92)""]],
                    borderWidth: 1
                }]
            }
        });

    </script>


");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Metrict.Models.Campaign> Html { get; private set; }
    }
}
#pragma warning restore 1591