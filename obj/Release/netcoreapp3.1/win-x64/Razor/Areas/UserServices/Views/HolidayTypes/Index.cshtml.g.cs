#pragma checksum "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\UserServices\Views\HolidayTypes\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e8d9da1dfa0725c45a54b44d32149e86e0e14c94"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_UserServices_Views_HolidayTypes_Index), @"mvc.1.0.view", @"/Areas/UserServices/Views/HolidayTypes/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e8d9da1dfa0725c45a54b44d32149e86e0e14c94", @"/Areas/UserServices/Views/HolidayTypes/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3c0fb33f32f4e9797dadeff098754edc3ea8e84", @"/Areas/UserServices/Views/_ViewImports.cshtml")]
    public class Areas_UserServices_Views_HolidayTypes_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<HolidayType>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\UserServices\Views\HolidayTypes\Index.cshtml"
  
    Layout = "~/Views/Shared/_AdminLTE.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""m-5"">
    <div class=""white-Background border p-2"">
        <div class=""row"">
            <div class=""col-md-6"">
                <h3 class=""text-info"">Liste des Types congés</h3>
            </div>
            <div class=""col-md-6 text-right"">
                <a");
            BeginWriteAttribute("onclick", " onclick=\"", 370, "\"", 495, 6);
            WriteAttributeValue("", 380, "showInPopup(\'", 380, 13, true);
#nullable restore
#line 12 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\UserServices\Views\HolidayTypes\Index.cshtml"
WriteAttributeValue("", 393, Url.Action("Create","HolidayTypes", null, Context.Request.Scheme), 393, 66, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 459, "\',", 459, 2, true);
            WriteAttributeValue("\r\n                ", 461, "\'type", 479, 23, true);
            WriteAttributeValue(" ", 484, "de", 485, 3, true);
            WriteAttributeValue(" ", 487, "congé\')", 488, 8, true);
            EndWriteAttribute();
            WriteLiteral("\r\n                   class=\"btn btn-primary text-white\" style=\"cursor:pointer\">\r\n                    <i class=\"fas fa-plus\"></i>&nbsp; Ajouter\r\n                </a>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
#nullable restore
#line 23 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\UserServices\Views\HolidayTypes\Index.cshtml"
 if (Model.Count() == 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-md-12\">\r\n        <h4 class=\"text-center text-danger pt-4\"> Aucun type de congé dans cette liste ... </h4>\r\n    </div>\r\n");
#nullable restore
#line 28 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\UserServices\Views\HolidayTypes\Index.cshtml"

}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div id=\"view-all\">\r\n        ");
#nullable restore
#line 33 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\UserServices\Views\HolidayTypes\Index.cshtml"
   Write(await Html.PartialAsync("_ViewAll"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 35 "C:\Users\Oujdi\Desktop\Projet C#\Projet C#\ASP.NET Core\Application-Taxi\Appli-taxi\Areas\UserServices\Views\HolidayTypes\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<HolidayType>> Html { get; private set; }
    }
}
#pragma warning restore 1591