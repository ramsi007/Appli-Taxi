#pragma checksum "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Customer\Views\CreditNotes\_ViewAll.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "15a8202d32dbf1327ee5a313409b03c72a0f6e32"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Customer_Views_CreditNotes__ViewAll), @"mvc.1.0.view", @"/Areas/Customer/Views/CreditNotes/_ViewAll.cshtml")]
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
#line 1 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Customer\Views\_ViewImports.cshtml"
using Appli_Taxi;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Customer\Views\_ViewImports.cshtml"
using Appli_Taxi.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Customer\Views\_ViewImports.cshtml"
using Appli_Taxi.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Customer\Views\_ViewImports.cshtml"
using Appli_Taxi.Utility;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15a8202d32dbf1327ee5a313409b03c72a0f6e32", @"/Areas/Customer/Views/CreditNotes/_ViewAll.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3c0fb33f32f4e9797dadeff098754edc3ea8e84", @"/Areas/Customer/Views/_ViewImports.cshtml")]
    public class Areas_Customer_Views_CreditNotes__ViewAll : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CreditNote>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("return jQueryAjaxDelete(this);"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("<div class=\"m-5\">\r\n    <table class=\"table table-striped border table-hover\" id=\"example1\">\r\n        <thead>\r\n            <tr>\r\n                <th>Facture N° </th>\r\n                <th>Client</th>\r\n                <th>Date</th>\r\n                <th>");
#nullable restore
#line 9 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Customer\Views\CreditNotes\_ViewAll.cshtml"
               Write(Html.DisplayNameFor(m => m.Montant));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 10 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Customer\Views\CreditNotes\_ViewAll.cshtml"
               Write(Html.DisplayNameFor(m => m.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n\r\n");
#nullable restore
#line 16 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Customer\Views\CreditNotes\_ViewAll.cshtml"
             foreach (var item in Model)
             {
                var fullName = item.ApplicationUser.FirstName + " " + item.ApplicationUser.LastName;
                var dateCredit = item.NoteDate.ToShortDateString();

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n\r\n                    <td>");
#nullable restore
#line 22 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Customer\Views\CreditNotes\_ViewAll.cshtml"
                   Write(Html.DisplayFor(m => item.Bill.NumBill));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 23 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Customer\Views\CreditNotes\_ViewAll.cshtml"
                   Write(Html.DisplayFor(m => fullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 24 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Customer\Views\CreditNotes\_ViewAll.cshtml"
                   Write(Html.DisplayFor(m => dateCredit));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 25 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Customer\Views\CreditNotes\_ViewAll.cshtml"
                   Write(Html.DisplayFor(m => item.Montant));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 26 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Customer\Views\CreditNotes\_ViewAll.cshtml"
                   Write(Html.DisplayFor(m => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                    <td style=\"width:150px\">\r\n\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "15a8202d32dbf1327ee5a313409b03c72a0f6e328207", async() => {
                WriteLiteral("\r\n                            <div class=\"btn-group\">\r\n                                <a");
                BeginWriteAttribute("onclick", " onclick=\"", 1333, "\"", 1484, 6);
                WriteAttributeValue("", 1343, "showInPopup(\'", 1343, 13, true);
#nullable restore
#line 32 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Customer\Views\CreditNotes\_ViewAll.cshtml"
WriteAttributeValue("", 1356, Url.Action("Details","CreditNotes", new {id= item.Id}, Context.Request.Scheme), 1356, 79, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1435, "\',", 1435, 2, true);
                WriteAttributeValue("\r\n                            ", 1437, "\'Note", 1467, 35, true);
                WriteAttributeValue(" ", 1472, "de", 1473, 3, true);
                WriteAttributeValue(" ", 1475, "crédit\')", 1476, 9, true);
                EndWriteAttribute();
                WriteLiteral("\r\n                                   class=\"btn btn-info text-white\" style=\"cursor:pointer\"><i class=\"fas fa-list-ul\"></i></a>\r\n\r\n                                <a");
                BeginWriteAttribute("onclick", " onclick=\"", 1649, "\"", 1769, 7);
                WriteAttributeValue("", 1659, "showInPopup(\'", 1659, 13, true);
#nullable restore
#line 36 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Customer\Views\CreditNotes\_ViewAll.cshtml"
WriteAttributeValue("", 1672, Url.Action("Edit","CreditNotes", new {id= item.Id}, Context.Request.Scheme), 1672, 76, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1748, "\',", 1748, 2, true);
                WriteAttributeValue(" ", 1750, "\'Note", 1751, 6, true);
                WriteAttributeValue(" ", 1756, "de", 1757, 3, true);
                WriteAttributeValue(" ", 1759, "crédit", 1760, 7, true);
                WriteAttributeValue(" ", 1766, "\')", 1767, 3, true);
                EndWriteAttribute();
                WriteLiteral(@"
                                   class=""btn btn-success text-white"" style=""cursor:pointer""><i class=""far fa-edit""></i></a>

                                <button type=""submit"" class=""btn btn-danger""><i class=""fas fa-trash""></i></button>
                            </div>
                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 30 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Customer\Views\CreditNotes\_ViewAll.cshtml"
                                                    WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 45 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Customer\Views\CreditNotes\_ViewAll.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CreditNote>> Html { get; private set; }
    }
}
#pragma warning restore 1591
