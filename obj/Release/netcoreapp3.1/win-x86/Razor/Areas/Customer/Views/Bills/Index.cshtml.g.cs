#pragma checksum "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\Customer\Views\Bills\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dfb94772d0bacf8f298aaff5516ebe066873560a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Customer_Views_Bills_Index), @"mvc.1.0.view", @"/Areas/Customer/Views/Bills/Index.cshtml")]
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
#line 1 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\Customer\Views\_ViewImports.cshtml"
using Appli_Taxi;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\Customer\Views\_ViewImports.cshtml"
using Appli_Taxi.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\Customer\Views\_ViewImports.cshtml"
using Appli_Taxi.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\Customer\Views\_ViewImports.cshtml"
using Appli_Taxi.Utility;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dfb94772d0bacf8f298aaff5516ebe066873560a", @"/Areas/Customer/Views/Bills/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3c0fb33f32f4e9797dadeff098754edc3ea8e84", @"/Areas/Customer/Views/_ViewImports.cshtml")]
    public class Areas_Customer_Views_Bills_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Bill>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_CreateButtonPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\Customer\Views\Bills\Index.cshtml"
  
    Layout = "~/Views/Shared/_AdminLTE.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"m-5\">\r\n    <div class=\"white-Background border p-2\">\r\n        <div class=\"row\">\r\n            <div class=\"col-md-6\">\r\n                <h3 class=\"text-info\">LISTE DES FACTURES</h3>\r\n            </div>\r\n");
#nullable restore
#line 14 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\Customer\Views\Bills\Index.cshtml"
             if (User.IsInRole(SD.ManagerUser) || User.IsInRole(SD.VendorUser))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-md-6 text-right\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dfb94772d0bacf8f298aaff5516ebe066873560a5008", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n");
#nullable restore
#line 19 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\Customer\Views\Bills\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
#nullable restore
#line 25 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\Customer\Views\Bills\Index.cshtml"
 if (Model.Count() == 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"white-Background m-5 text-center\">\r\n        <h3 class=\"text-center text-danger p-5\">\r\n            AUCUNE FACTURE DANS CETTE LISTE ... !\r\n        </h3>\r\n    </div>\r\n");
#nullable restore
#line 32 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\Customer\Views\Bills\Index.cshtml"

}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div id=\"view-all\">\r\n        ");
#nullable restore
#line 37 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\Customer\Views\Bills\Index.cshtml"
   Write(await Html.PartialAsync("_ViewAll"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 39 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\Customer\Views\Bills\Index.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n");
            }
            );
            WriteLiteral("\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Bill>> Html { get; private set; }
    }
}
#pragma warning restore 1591