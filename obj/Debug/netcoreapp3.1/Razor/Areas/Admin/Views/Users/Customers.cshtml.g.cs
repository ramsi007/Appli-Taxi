#pragma checksum "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Admin\Views\Users\Customers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "71542e1382495016fdb9e6eededc68b37845a805"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Users_Customers), @"mvc.1.0.view", @"/Areas/Admin/Views/Users/Customers.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71542e1382495016fdb9e6eededc68b37845a805", @"/Areas/Admin/Views/Users/Customers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3c0fb33f32f4e9797dadeff098754edc3ea8e84", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Users_Customers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ApplicationUser>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Account/Register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Identity", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Admin\Views\Users\Customers.cshtml"
  
    ViewData["Title"] = "Clients";
    Layout = "~/Views/Shared/_AdminLTE.cshtml";


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"m-5\">\r\n    <div class=\"white-Background border p-2\">\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 11 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Admin\Views\Users\Customers.cshtml"
             if (Model.Count() > 0)
            {
                string role = null;
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Admin\Views\Users\Customers.cshtml"
                 foreach (var item in Model)
                {
                    role = item.UserRole;
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Admin\Views\Users\Customers.cshtml"
                 
                if (role.Equals(SD.CustomerUser))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-md-6\">\r\n                        <h3 class=\"text-info\">Liste des clients</h3>\r\n                    </div>\r\n");
#nullable restore
#line 23 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Admin\Views\Users\Customers.cshtml"
                }
                else if (role.Equals(SD.VendorUser))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-md-6\">\r\n                        <h3 class=\"text-info\">Liste des fournisseurs</h3>\r\n                    </div>\r\n");
#nullable restore
#line 29 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Admin\Views\Users\Customers.cshtml"
                }
                else if (role.Equals(SD.EmployeeUser))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-md-6\">\r\n                        <h3 class=\"text-info\">Liste des employés</h3>\r\n                    </div>\r\n");
#nullable restore
#line 35 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Admin\Views\Users\Customers.cshtml"
                }
             }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-md-6 text-right\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "71542e1382495016fdb9e6eededc68b37845a8057497", async() => {
                WriteLiteral("\r\n                        <i class=\"fa fa-plus\"></i>&nbsp;Nouveau compte\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
#nullable restore
#line 47 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Admin\Views\Users\Customers.cshtml"
 if (Model.Count() == 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-md-12\">\r\n        <h4 class=\"text-center text-danger pt-4\"> Aucun compte dans cette liste ... </h4>\r\n    </div>\r\n");
#nullable restore
#line 52 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Admin\Views\Users\Customers.cshtml"

}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div id=\"view-all\">\r\n        ");
#nullable restore
#line 57 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Admin\Views\Users\Customers.cshtml"
   Write(await Html.PartialAsync("_ViewAll"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 59 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Appli-Taxi\Appli-Taxi\Areas\Admin\Views\Users\Customers.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ApplicationUser>> Html { get; private set; }
    }
}
#pragma warning restore 1591
