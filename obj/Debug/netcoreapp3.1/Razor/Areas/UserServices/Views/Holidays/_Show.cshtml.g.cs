#pragma checksum "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\UserServices\Views\Holidays\_Show.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fee53a433d5a7fcaee15b97e1910ba68082c50de"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_UserServices_Views_Holidays__Show), @"mvc.1.0.view", @"/Areas/UserServices/Views/Holidays/_Show.cshtml")]
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
#line 1 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\UserServices\Views\_ViewImports.cshtml"
using Appli_Taxi;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\UserServices\Views\_ViewImports.cshtml"
using Appli_Taxi.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\UserServices\Views\_ViewImports.cshtml"
using Appli_Taxi.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\UserServices\Views\_ViewImports.cshtml"
using Appli_Taxi.Utility;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fee53a433d5a7fcaee15b97e1910ba68082c50de", @"/Areas/UserServices/Views/Holidays/_Show.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3c0fb33f32f4e9797dadeff098754edc3ea8e84", @"/Areas/UserServices/Views/_ViewImports.cshtml")]
    public class Areas_UserServices_Views_Holidays__Show : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Holiday>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success text-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("cursor:pointer"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("font-weight-bolder ml-5"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("font-size: 20px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"col-md-12 m-4 text-center\">\r\n    <h4 class=\"text-info\">Liste des congés en attente</h4>\r\n</div>\r\n");
#nullable restore
#line 6 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\UserServices\Views\Holidays\_Show.cshtml"
 if (Model.Count() == 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-md-12\">\r\n        <h4 class=\"text-center text-danger pt-4 mt-5\" style=\"margin-bottom: 200px;\"> \r\n        Aucun congé en attente dans cette liste \r\n        </h4>\r\n    </div>\r\n");
#nullable restore
#line 13 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\UserServices\Views\Holidays\_Show.cshtml"

}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"m-5\">\r\n        <table class=\"table table-striped border text-center table-hover\" id=\"example1\">\r\n            <thead>\r\n                <tr>\r\n                    <th>");
#nullable restore
#line 21 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\UserServices\Views\Holidays\_Show.cshtml"
                   Write(Html.DisplayNameFor(m => m.DemandeDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th>");
#nullable restore
#line 22 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\UserServices\Views\Holidays\_Show.cshtml"
                   Write(Html.DisplayNameFor(m => m.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th>");
#nullable restore
#line 23 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\UserServices\Views\Holidays\_Show.cshtml"
                   Write(Html.DisplayNameFor(m => m.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th>Personnel</th>\r\n                    <th>Type de congé</th>\r\n                    <th>Status</th>\r\n                    <th>Actions</th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n\r\n");
#nullable restore
#line 32 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\UserServices\Views\Holidays\_Show.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n");
#nullable restore
#line 35 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\UserServices\Views\Holidays\_Show.cshtml"
                           var fullname = item.ApplicationUser.FirstName + " " + item.ApplicationUser.LastName;

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>");
#nullable restore
#line 36 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\UserServices\Views\Holidays\_Show.cshtml"
                       Write(Html.DisplayFor(m => item.DemandeDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 37 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\UserServices\Views\Holidays\_Show.cshtml"
                       Write(Html.DisplayFor(m => item.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 38 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\UserServices\Views\Holidays\_Show.cshtml"
                       Write(Html.DisplayFor(m => item.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 39 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\UserServices\Views\Holidays\_Show.cshtml"
                       Write(fullname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 40 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\UserServices\Views\Holidays\_Show.cshtml"
                       Write(Html.DisplayFor(m => item.HolidayType.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 41 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\UserServices\Views\Holidays\_Show.cshtml"
                       Write(Html.DisplayFor(m => item.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"width:150px\">\r\n                            <div class=\"btn-group\">\r\n");
#nullable restore
#line 44 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\UserServices\Views\Holidays\_Show.cshtml"
                                 if (item.Status.Equals(SD.StatusInProcess) && (User.IsInRole(SD.ManagerUser)))
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a");
            BeginWriteAttribute("onclick", " onclick=\"", 1868, "\"", 2054, 6);
            WriteAttributeValue("", 1878, "showInPopup(\'", 1878, 13, true);
#nullable restore
#line 46 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\UserServices\Views\Holidays\_Show.cshtml"
WriteAttributeValue("", 1891, Url.Action("ConfirmCancelHoliday","Holidays", new {confirmId= item.Id}, Context.Request.Scheme), 1891, 96, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1987, "\',", 1987, 2, true);
            WriteAttributeValue("\r\n                                        ", 1989, "\'Confirmer", 2031, 52, true);
            WriteAttributeValue(" ", 2041, "la", 2042, 3, true);
            WriteAttributeValue(" ", 2044, "demande\')", 2045, 10, true);
            EndWriteAttribute();
            WriteLiteral("\r\n                                       class=\"btn btn-info text-white\" style=\"cursor:pointer\">\r\n                                        Confirmer\r\n                                    </a>\r\n                                    <a");
            BeginWriteAttribute("onclick", " onclick=\"", 2284, "\"", 2471, 6);
            WriteAttributeValue("", 2294, "showInPopup(\'", 2294, 13, true);
#nullable restore
#line 51 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\UserServices\Views\Holidays\_Show.cshtml"
WriteAttributeValue("", 2307, Url.Action("ConfirmCancelHoliday","Holidays", new {cancelId= item.Id}, Context.Request.Scheme), 2307, 95, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2402, "\',", 2402, 2, true);
            WriteAttributeValue("\r\n                                            ", 2404, "\'Annuler", 2450, 54, true);
            WriteAttributeValue(" ", 2458, "la", 2459, 3, true);
            WriteAttributeValue(" ", 2461, "demande\')", 2462, 10, true);
            EndWriteAttribute();
            WriteLiteral("\r\n                                       class=\"btn btn-danger text-white\" style=\"cursor:pointer\">\r\n                                        Annuler\r\n                                    </a>\r\n");
#nullable restore
#line 56 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\UserServices\Views\Holidays\_Show.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\UserServices\Views\Holidays\_Show.cshtml"
                                 if (item.Status.Equals(SD.StatusInProcess) && (User.IsInRole(SD.EmployeeUser)))
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fee53a433d5a7fcaee15b97e1910ba68082c50de14254", async() => {
                WriteLiteral("\r\n                                        Détails\r\n                                    ");
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
#line 59 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\UserServices\Views\Holidays\_Show.cshtml"
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
            WriteLiteral("\r\n");
#nullable restore
#line 63 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\UserServices\Views\Holidays\_Show.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 67 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\UserServices\Views\Holidays\_Show.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n        <br />\r\n    </div>\r\n");
#nullable restore
#line 72 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\UserServices\Views\Holidays\_Show.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fee53a433d5a7fcaee15b97e1910ba68082c50de17671", async() => {
                WriteLiteral("Retour à la liste des Congés");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
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
