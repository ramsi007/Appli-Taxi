#pragma checksum "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\Customer\Views\CreditNotes\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "706d9d00c7f8112dcfb7b8dbb167cbe07a33c671"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Customer_Views_CreditNotes_Index), @"mvc.1.0.view", @"/Areas/Customer/Views/CreditNotes/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"706d9d00c7f8112dcfb7b8dbb167cbe07a33c671", @"/Areas/Customer/Views/CreditNotes/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3c0fb33f32f4e9797dadeff098754edc3ea8e84", @"/Areas/Customer/Views/_ViewImports.cshtml")]
    public class Areas_Customer_Views_CreditNotes_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CreeditNote>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\Customer\Views\CreditNotes\Index.cshtml"
  
    Layout = "~/Views/Shared/_AdminLTE.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""m-5"">
    <div class=""white-Background border p-2"">
        <div class=""row"">
            <div class=""col-md-6"">
                <h3 class=""text-info"">Liste des Notes de crédit</h3>
            </div>
            <div class=""col-md-6 text-right"">
                <a");
            BeginWriteAttribute("onclick", " onclick=\"", 373, "\"", 508, 8);
            WriteAttributeValue("", 383, "showInPopup(\'", 383, 13, true);
#nullable restore
#line 12 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\Customer\Views\CreditNotes\Index.cshtml"
WriteAttributeValue("", 396, Url.Action("Create","CreditNotes", null, Context.Request.Scheme), 396, 65, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 461, "\',", 461, 2, true);
            WriteAttributeValue("\r\n                ", 463, "\'Créer", 481, 24, true);
            WriteAttributeValue(" ", 487, "une", 488, 4, true);
            WriteAttributeValue(" ", 491, "note", 492, 5, true);
            WriteAttributeValue(" ", 496, "de", 497, 3, true);
            WriteAttributeValue(" ", 499, "Crédit\')", 500, 9, true);
            EndWriteAttribute();
            WriteLiteral("\r\n                   class=\"btn btn-primary text-white\" style=\"cursor:pointer\">\r\n                    <i class=\"fas fa-plus\"></i>&nbsp; Ajouter\r\n                </a>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
#nullable restore
#line 23 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\Customer\Views\CreditNotes\Index.cshtml"
 if (Model.Count() == 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-md-12\">\r\n        <h4 class=\"text-center text-danger pt-4\"> Aucune note de crédit dans cette liste ... </h4>\r\n    </div>\r\n");
#nullable restore
#line 28 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\Customer\Views\CreditNotes\Index.cshtml"

}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div id=\"view-all\">\r\n        ");
#nullable restore
#line 33 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\Customer\Views\CreditNotes\Index.cshtml"
   Write(await Html.PartialAsync("_ViewAll"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 35 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\Customer\Views\CreditNotes\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CreeditNote>> Html { get; private set; }
    }
}
#pragma warning restore 1591