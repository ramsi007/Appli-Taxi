#pragma checksum "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Admin\Views\Taxes\_ViewAll.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5a93b2540a5fa6a4ff1eae34539ccb2e56b5cd26"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Taxes__ViewAll), @"mvc.1.0.view", @"/Areas/Admin/Views/Taxes/_ViewAll.cshtml")]
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
#line 1 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Admin\Views\_ViewImports.cshtml"
using Appli_Taxi;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Admin\Views\_ViewImports.cshtml"
using Appli_Taxi.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Admin\Views\_ViewImports.cshtml"
using Appli_Taxi.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Admin\Views\_ViewImports.cshtml"
using Appli_Taxi.Utility;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a93b2540a5fa6a4ff1eae34539ccb2e56b5cd26", @"/Areas/Admin/Views/Taxes/_ViewAll.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3c0fb33f32f4e9797dadeff098754edc3ea8e84", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Taxes__ViewAll : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Tax>>
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
            WriteLiteral("<table  id=\"example1\" class=\"table table-striped table-bordered\" style=\"width:100%\">\r\n    <thead>\r\n        <tr>\r\n            <th>");
#nullable restore
#line 5 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Admin\Views\Taxes\_ViewAll.cshtml"
           Write(Html.DisplayNameFor(m => m.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 6 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Admin\Views\Taxes\_ViewAll.cshtml"
           Write(Html.DisplayNameFor(m => m.Discount));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 11 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Admin\Views\Taxes\_ViewAll.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 14 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Admin\Views\Taxes\_ViewAll.cshtml"
               Write(Html.DisplayFor(m => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 15 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Admin\Views\Taxes\_ViewAll.cshtml"
               Write(Html.DisplayFor(m => item.Discount));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                <td style=\"width:150px\">\r\n                    <div class=\"btn-group\">\r\n                        <a");
            BeginWriteAttribute("onclick", " onclick=\"", 623, "\"", 732, 4);
            WriteAttributeValue("", 633, "showInPopup(\'", 633, 13, true);
#nullable restore
#line 19 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Admin\Views\Taxes\_ViewAll.cshtml"
WriteAttributeValue("", 646, Url.Action("Details","Taxes", new {id= item.Id}, Context.Request.Scheme), 646, 73, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 719, "\',", 719, 2, true);
            WriteAttributeValue(" ", 721, "\'Details\')", 722, 11, true);
            EndWriteAttribute();
            WriteLiteral("\r\n                           class=\"btn btn-info text-white\" style=\"cursor:pointer\"><i class=\"fas fa-list-ul\"></i></a>\r\n\r\n                        <a");
            BeginWriteAttribute("onclick", " onclick=\"", 881, "\"", 988, 4);
            WriteAttributeValue("", 891, "showInPopup(\'", 891, 13, true);
#nullable restore
#line 22 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Admin\Views\Taxes\_ViewAll.cshtml"
WriteAttributeValue("", 904, Url.Action("Edit","Taxes", new {id= item.Id}, Context.Request.Scheme), 904, 70, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 974, "\',", 974, 2, true);
            WriteAttributeValue(" ", 976, "\'Modifier\')", 977, 12, true);
            EndWriteAttribute();
            WriteLiteral("\r\n                           class=\"btn btn-success text-white\" style=\"cursor:pointer\"><i class=\"far fa-edit\"></i></a>\r\n\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a93b2540a5fa6a4ff1eae34539ccb2e56b5cd268430", async() => {
                WriteLiteral("\r\n                            <button type=\"submit\" class=\"btn btn-danger\"><i class=\"fas fa-trash\"></i></button>\r\n                        ");
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
#line 25 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Admin\Views\Taxes\_ViewAll.cshtml"
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
            WriteLiteral("\r\n                    </div>\r\n                </td>\r\n\r\n            </tr>\r\n");
#nullable restore
#line 32 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Admin\Views\Taxes\_ViewAll.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n\r\n</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Tax>> Html { get; private set; }
    }
}
#pragma warning restore 1591
