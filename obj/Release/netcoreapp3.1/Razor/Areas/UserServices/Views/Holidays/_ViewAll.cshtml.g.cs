#pragma checksum "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\UserServices\Views\Holidays\_ViewAll.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "726ad77623f7929c61b6e49a2f8fc2d0d0321f2c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_UserServices_Views_Holidays__ViewAll), @"mvc.1.0.view", @"/Areas/UserServices/Views/Holidays/_ViewAll.cshtml")]
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
#line 1 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\UserServices\Views\_ViewImports.cshtml"
using Appli_Taxi;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\UserServices\Views\_ViewImports.cshtml"
using Appli_Taxi.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\UserServices\Views\_ViewImports.cshtml"
using Appli_Taxi.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\UserServices\Views\_ViewImports.cshtml"
using Appli_Taxi.Utility;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"726ad77623f7929c61b6e49a2f8fc2d0d0321f2c", @"/Areas/UserServices/Views/Holidays/_ViewAll.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3c0fb33f32f4e9797dadeff098754edc3ea8e84", @"/Areas/UserServices/Views/_ViewImports.cshtml")]
    public class Areas_UserServices_Views_Holidays__ViewAll : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Holiday>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info text-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("cursor:pointer"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("return jQueryAjaxDelete(this);"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"m-5\">\r\n    <table class=\"table table-striped border text-center table-hover\" id=\"example1\">\r\n        <thead>\r\n            <tr>\r\n                <th>");
#nullable restore
#line 6 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\UserServices\Views\Holidays\_ViewAll.cshtml"
               Write(Html.DisplayNameFor(m => m.DemandeDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 7 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\UserServices\Views\Holidays\_ViewAll.cshtml"
               Write(Html.DisplayNameFor(m => m.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 8 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\UserServices\Views\Holidays\_ViewAll.cshtml"
               Write(Html.DisplayNameFor(m => m.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>Personnel</th>\r\n                <th>");
#nullable restore
#line 10 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\UserServices\Views\Holidays\_ViewAll.cshtml"
               Write(Html.DisplayNameFor(m => m.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>Type de congé</th>\r\n                <th>Actions</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n\r\n");
#nullable restore
#line 17 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\UserServices\Views\Holidays\_ViewAll.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n");
#nullable restore
#line 20 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\UserServices\Views\Holidays\_ViewAll.cshtml"
                       var fullname = item.ApplicationUser.FirstName + " " + item.ApplicationUser.LastName;

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>");
#nullable restore
#line 21 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\UserServices\Views\Holidays\_ViewAll.cshtml"
                   Write(Html.DisplayFor(m => item.DemandeDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 22 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\UserServices\Views\Holidays\_ViewAll.cshtml"
                   Write(Html.DisplayFor(m => item.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 23 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\UserServices\Views\Holidays\_ViewAll.cshtml"
                   Write(Html.DisplayFor(m => item.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 24 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\UserServices\Views\Holidays\_ViewAll.cshtml"
                   Write(fullname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 25 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\UserServices\Views\Holidays\_ViewAll.cshtml"
                   Write(Html.DisplayFor(m => item.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 26 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\UserServices\Views\Holidays\_ViewAll.cshtml"
                   Write(Html.DisplayFor(m => item.HolidayType.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td style=\"width:150px\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "726ad77623f7929c61b6e49a2f8fc2d0d0321f2c10624", async() => {
                WriteLiteral("\r\n                            <div class=\"btn-group text-left\">\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "726ad77623f7929c61b6e49a2f8fc2d0d0321f2c10982", async() => {
                    WriteLiteral("<i class=\"fas fa-list-ul\"></i>");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 30 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\UserServices\Views\Holidays\_ViewAll.cshtml"
                                                          WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
#nullable restore
#line 33 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\UserServices\Views\Holidays\_ViewAll.cshtml"
                                 if(item.Status.Equals(SD.StatusInProcess))
                                 {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <a");
                BeginWriteAttribute("onclick", " onclick=\"", 1769, "\"", 1885, 4);
                WriteAttributeValue("", 1779, "showInPopup(\'", 1779, 13, true);
#nullable restore
#line 35 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\UserServices\Views\Holidays\_ViewAll.cshtml"
WriteAttributeValue("", 1792, Url.Action("CreateEdit","Holidays", new {id= item.Id}, Context.Request.Scheme), 1792, 79, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1871, "\',", 1871, 2, true);
                WriteAttributeValue(" ", 1873, "\'Modifier\')", 1874, 12, true);
                EndWriteAttribute();
                WriteLiteral("\r\n                                       class=\"btn btn-success text-white\" style=\"cursor:pointer\"><i class=\"far fa-edit\"></i></a>\r\n");
#nullable restore
#line 37 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\UserServices\Views\Holidays\_ViewAll.cshtml"
                                 }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <button type=\"submit\" class=\"btn btn-danger\"><i class=\"fas fa-trash\"></i></button>\r\n                            </div>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 28 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\UserServices\Views\Holidays\_ViewAll.cshtml"
                                                    WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 43 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\UserServices\Views\Holidays\_ViewAll.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Holiday>> Html { get; private set; }
    }
}
#pragma warning restore 1591
