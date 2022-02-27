#pragma checksum "C:\Users\ace92\Documents\Develop\Metrict\Views\Campaigns\ManageCampaignUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4b27f8f3ba3653a5ac7c115a96c2612a59f56963"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Campaigns_ManageCampaignUser), @"mvc.1.0.view", @"/Views/Campaigns/ManageCampaignUser.cshtml")]
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
#line 1 "C:\Users\ace92\Documents\Develop\Metrict\Views\_ViewImports.cshtml"
using Metrict;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ace92\Documents\Develop\Metrict\Views\_ViewImports.cshtml"
using Metrict.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b27f8f3ba3653a5ac7c115a96c2612a59f56963", @"/Views/Campaigns/ManageCampaignUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99945052b75fd5138d85b542a997bbae47015463", @"/Views/_ViewImports.cshtml")]
    public class Views_Campaigns_ManageCampaignUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Metrict.Models.CampaignViewModels.CampaignUserData>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ActivateUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeactivateUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RemoveUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 3 "C:\Users\ace92\Documents\Develop\Metrict\Views\Campaigns\ManageCampaignUser.cshtml"
  
    ViewData["Title"] = "ManageCampaignUser";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container vh100\">\r\n    <main role=\"main\" class=\"pb-3\">\r\n        <h1>Manage Campaign Users: ");
#nullable restore
#line 10 "C:\Users\ace92\Documents\Develop\Metrict\Views\Campaigns\ManageCampaignUser.cshtml"
                              Write(ViewBag.nameOfCampaign);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>

        <div class=""container row p-0 m-0"">
            <div class=""col-12 border p-3"">
                <table id=""DT_load"" class=""table table-striped table-bordered"" style=""width:100%"">
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Email</th>
                            <th>Active</th>
                            <th>Actions</th>
                        </tr>
");
#nullable restore
#line 22 "C:\Users\ace92\Documents\Develop\Metrict\Views\Campaigns\ManageCampaignUser.cshtml"
                         foreach (var item in Model.CampaignUsers)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <th class=\"tablecentering\">\r\n                                    ");
#nullable restore
#line 26 "C:\Users\ace92\Documents\Develop\Metrict\Views\Campaigns\ManageCampaignUser.cshtml"
                               Write(Html.DisplayFor(modelItem => item.ApplicationUser.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n                                <th class=\"tablecentering\">\r\n                                    ");
#nullable restore
#line 29 "C:\Users\ace92\Documents\Develop\Metrict\Views\Campaigns\ManageCampaignUser.cshtml"
                               Write(Html.DisplayFor(modelItem => item.ApplicationUser.NormalizedEmail));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n                                <th class=\"tablecentering\">\r\n                                    ");
#nullable restore
#line 32 "C:\Users\ace92\Documents\Develop\Metrict\Views\Campaigns\ManageCampaignUser.cshtml"
                               Write(Html.DisplayFor(modelItem => item.ApplicationUser.UserActive));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n");
#nullable restore
#line 35 "C:\Users\ace92\Documents\Develop\Metrict\Views\Campaigns\ManageCampaignUser.cshtml"
                                     if (item.ApplicationUser.UserActive == false)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4b27f8f3ba3653a5ac7c115a96c2612a59f569637715", async() => {
                WriteLiteral("\r\n                                            <input type=\"hidden\" id=\"campaignId\" name=\"campaignId\"");
                BeginWriteAttribute("value", " value=\"", 1836, "\"", 1860, 1);
#nullable restore
#line 38 "C:\Users\ace92\Documents\Develop\Metrict\Views\Campaigns\ManageCampaignUser.cshtml"
WriteAttributeValue("", 1844, item.CampaignId, 1844, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                                            <input type=\"hidden\" id=\"applicationUsersId\" name=\"applicationUserId\"");
                BeginWriteAttribute("value", " value=\"", 1979, "\"", 2010, 1);
#nullable restore
#line 39 "C:\Users\ace92\Documents\Develop\Metrict\Views\Campaigns\ManageCampaignUser.cshtml"
WriteAttributeValue("", 1987, item.ApplicationUserId, 1987, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                                            <input type=\"submit\" class=\'btn btn-success text-white buttonpad\' value=\"Activate User\" />\r\n                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 42 "C:\Users\ace92\Documents\Develop\Metrict\Views\Campaigns\ManageCampaignUser.cshtml"

                                        //<a asp-action="ActivateUser" class='btn btn-success text-white'>Activate User</a>
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\Users\ace92\Documents\Develop\Metrict\Views\Campaigns\ManageCampaignUser.cshtml"
                                     if (item.ApplicationUser.UserActive == true)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4b27f8f3ba3653a5ac7c115a96c2612a59f5696311229", async() => {
                WriteLiteral("\r\n                                            <input type=\"hidden\" id=\"campaignId\" name=\"campaignId\"");
                BeginWriteAttribute("value", " value=\"", 2677, "\"", 2701, 1);
#nullable restore
#line 48 "C:\Users\ace92\Documents\Develop\Metrict\Views\Campaigns\ManageCampaignUser.cshtml"
WriteAttributeValue("", 2685, item.CampaignId, 2685, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                                            <input type=\"hidden\" id=\"applicationUsersId\" name=\"applicationUserId\"");
                BeginWriteAttribute("value", " value=\"", 2820, "\"", 2851, 1);
#nullable restore
#line 49 "C:\Users\ace92\Documents\Develop\Metrict\Views\Campaigns\ManageCampaignUser.cshtml"
WriteAttributeValue("", 2828, item.ApplicationUserId, 2828, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                                            <input type=\"submit\" class=\'btn btn-danger text-white buttonpad\' value=\"Deactivate User\" />\r\n                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 52 "C:\Users\ace92\Documents\Develop\Metrict\Views\Campaigns\ManageCampaignUser.cshtml"

                                        //<a asp-action="DeactivateUser" class='btn btn-danger text-white'>Deactivate User</a>
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4b27f8f3ba3653a5ac7c115a96c2612a59f5696314458", async() => {
                WriteLiteral("\r\n                                        <input type=\"hidden\" id=\"campaignId\" name=\"campaignId\"");
                BeginWriteAttribute("value", " value=\"", 3388, "\"", 3412, 1);
#nullable restore
#line 56 "C:\Users\ace92\Documents\Develop\Metrict\Views\Campaigns\ManageCampaignUser.cshtml"
WriteAttributeValue("", 3396, item.CampaignId, 3396, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                                        <input type=\"hidden\" id=\"applicationUsersId\" name=\"applicationUserId\"");
                BeginWriteAttribute("value", " value=\"", 3527, "\"", 3558, 1);
#nullable restore
#line 57 "C:\Users\ace92\Documents\Develop\Metrict\Views\Campaigns\ManageCampaignUser.cshtml"
WriteAttributeValue("", 3535, item.ApplicationUserId, 3535, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                                        <input type=\"submit\" class=\'btn btn-danger text-white buttonpad\' value=\"Remove User\" />\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            WriteLiteral("                                </th>\r\n                            </tr>\r\n");
#nullable restore
#line 64 "C:\Users\ace92\Documents\Develop\Metrict\Views\Campaigns\ManageCampaignUser.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </thead>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </main>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Metrict.Models.CampaignViewModels.CampaignUserData> Html { get; private set; }
    }
}
#pragma warning restore 1591
