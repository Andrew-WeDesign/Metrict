#pragma checksum "C:\Users\ace92\Documents\Develop\Metrict\Views\Dashboard\CampaignManageCampaignUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c4549bcadbc9d46e672c97f6867ec8d37a77b1ed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_CampaignManageCampaignUser), @"mvc.1.0.view", @"/Views/Dashboard/CampaignManageCampaignUser.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4549bcadbc9d46e672c97f6867ec8d37a77b1ed", @"/Views/Dashboard/CampaignManageCampaignUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99945052b75fd5138d85b542a997bbae47015463", @"/Views/_ViewImports.cshtml")]
    public class Views_Dashboard_CampaignManageCampaignUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Metrict.Models.CampaignViewModels.CampaignUserData>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CampaignActivateUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CampaignDeactivateUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CampaignRemoveUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\ace92\Documents\Develop\Metrict\Views\Dashboard\CampaignManageCampaignUser.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c4549bcadbc9d46e672c97f6867ec8d37a77b1ed5122", async() => {
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>CampaignManageCampaignUser</title>\r\n");
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c4549bcadbc9d46e672c97f6867ec8d37a77b1ed6202", async() => {
                WriteLiteral("\r\n    <h1>Manage Campaign Users: ");
#nullable restore
#line 15 "C:\Users\ace92\Documents\Develop\Metrict\Views\Dashboard\CampaignManageCampaignUser.cshtml"
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
#line 27 "C:\Users\ace92\Documents\Develop\Metrict\Views\Dashboard\CampaignManageCampaignUser.cshtml"
                     foreach (var item in Model.CampaignUsers)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\r\n                            <th class=\"tablecentering\">\r\n                                ");
#nullable restore
#line 31 "C:\Users\ace92\Documents\Develop\Metrict\Views\Dashboard\CampaignManageCampaignUser.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ApplicationUser.FullName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </th>\r\n                            <th class=\"tablecentering\">\r\n                                ");
#nullable restore
#line 34 "C:\Users\ace92\Documents\Develop\Metrict\Views\Dashboard\CampaignManageCampaignUser.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ApplicationUser.NormalizedEmail));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </th>\r\n                            <th class=\"tablecentering\">\r\n                                ");
#nullable restore
#line 37 "C:\Users\ace92\Documents\Develop\Metrict\Views\Dashboard\CampaignManageCampaignUser.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ApplicationUser.UserActive));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n");
#nullable restore
#line 40 "C:\Users\ace92\Documents\Develop\Metrict\Views\Dashboard\CampaignManageCampaignUser.cshtml"
                                 if (item.ApplicationUser.UserActive == false)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c4549bcadbc9d46e672c97f6867ec8d37a77b1ed9234", async() => {
                    WriteLiteral("\r\n                                        <input type=\"hidden\" id=\"campaignId\" name=\"campaignId\"");
                    BeginWriteAttribute("value", " value=\"", 1748, "\"", 1772, 1);
#nullable restore
#line 43 "C:\Users\ace92\Documents\Develop\Metrict\Views\Dashboard\CampaignManageCampaignUser.cshtml"
WriteAttributeValue("", 1756, item.CampaignId, 1756, 16, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" />\r\n                                        <input type=\"hidden\" id=\"applicationUsersId\" name=\"applicationUserId\"");
                    BeginWriteAttribute("value", " value=\"", 1887, "\"", 1918, 1);
#nullable restore
#line 44 "C:\Users\ace92\Documents\Develop\Metrict\Views\Dashboard\CampaignManageCampaignUser.cshtml"
WriteAttributeValue("", 1895, item.ApplicationUserId, 1895, 23, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" />\r\n                                        <input type=\"submit\" class=\'btn btn-success text-white buttonpad\' value=\"Activate User\" />\r\n                                    ");
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
#line 47 "C:\Users\ace92\Documents\Develop\Metrict\Views\Dashboard\CampaignManageCampaignUser.cshtml"

                                    //<a asp-action="ActivateUser" class='btn btn-success text-white'>Activate User</a>
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "C:\Users\ace92\Documents\Develop\Metrict\Views\Dashboard\CampaignManageCampaignUser.cshtml"
                                 if (item.ApplicationUser.UserActive == true)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c4549bcadbc9d46e672c97f6867ec8d37a77b1ed12852", async() => {
                    WriteLiteral("\r\n                                        <input type=\"hidden\" id=\"campaignId\" name=\"campaignId\"");
                    BeginWriteAttribute("value", " value=\"", 2561, "\"", 2585, 1);
#nullable restore
#line 53 "C:\Users\ace92\Documents\Develop\Metrict\Views\Dashboard\CampaignManageCampaignUser.cshtml"
WriteAttributeValue("", 2569, item.CampaignId, 2569, 16, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" />\r\n                                        <input type=\"hidden\" id=\"applicationUsersId\" name=\"applicationUserId\"");
                    BeginWriteAttribute("value", " value=\"", 2700, "\"", 2731, 1);
#nullable restore
#line 54 "C:\Users\ace92\Documents\Develop\Metrict\Views\Dashboard\CampaignManageCampaignUser.cshtml"
WriteAttributeValue("", 2708, item.ApplicationUserId, 2708, 23, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" />\r\n                                        <input type=\"submit\" class=\'btn btn-danger text-white buttonpad\' value=\"Deactivate User\" />\r\n                                    ");
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
#line 57 "C:\Users\ace92\Documents\Develop\Metrict\Views\Dashboard\CampaignManageCampaignUser.cshtml"

                                    //<a asp-action="DeactivateUser" class='btn btn-danger text-white'>Deactivate User</a>
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c4549bcadbc9d46e672c97f6867ec8d37a77b1ed16185", async() => {
                    WriteLiteral("\r\n                                    <input type=\"hidden\" id=\"campaignId\" name=\"campaignId\"");
                    BeginWriteAttribute("value", " value=\"", 3252, "\"", 3276, 1);
#nullable restore
#line 61 "C:\Users\ace92\Documents\Develop\Metrict\Views\Dashboard\CampaignManageCampaignUser.cshtml"
WriteAttributeValue("", 3260, item.CampaignId, 3260, 16, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" />\r\n                                    <input type=\"hidden\" id=\"applicationUsersId\" name=\"applicationUserId\"");
                    BeginWriteAttribute("value", " value=\"", 3387, "\"", 3418, 1);
#nullable restore
#line 62 "C:\Users\ace92\Documents\Develop\Metrict\Views\Dashboard\CampaignManageCampaignUser.cshtml"
WriteAttributeValue("", 3395, item.ApplicationUserId, 3395, 23, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" />\r\n                                    <input type=\"submit\" class=\'btn btn-danger text-white buttonpad\' value=\"Remove User\" />\r\n                                ");
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
                WriteLiteral("                            </th>\r\n                        </tr>\r\n");
#nullable restore
#line 69 "C:\Users\ace92\Documents\Develop\Metrict\Views\Dashboard\CampaignManageCampaignUser.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </thead>\r\n            </table>\r\n        </div>\r\n        <div class=\"col-3 offset-3\">\r\n            <a href=\"#\" onclick=\"BackToCampaigns()\" class=\"btn btn-danger form-control\">Back to my campaigns</a>\r\n        </div>\r\n    </div>\r\n\r\n");
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
            WriteLiteral("\r\n</html>\r\n");
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
