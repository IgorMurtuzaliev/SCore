#pragma checksum "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Products\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8ed0db436f3a7ba97c23b9291fd76442bd4dc0c5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_Index), @"mvc.1.0.view", @"/Views/Products/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Products/Index.cshtml", typeof(AspNetCore.Views_Products_Index))]
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
#line 1 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\_ViewImports.cshtml"
using SCore.WEB;

#line default
#line hidden
#line 2 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\_ViewImports.cshtml"
using SCore.WEB.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ed0db436f3a7ba97c23b9291fd76442bd4dc0c5", @"/Views/Products/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27db0e849dcff1b197e7fd078d6119c14b731212", @"/Views/_ViewImports.cshtml")]
    public class Views_Products_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable< SCore.Models.Product>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(43, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Products\Index.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
            BeginContext(82, 29, true);
            WriteLiteral("\r\n<h2>Index</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(112, 39, false);
#line 10 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Products\Index.cshtml"
Write(Html.ActionLink("Create New", "Create"));

#line default
#line hidden
            EndContext();
            BeginContext(151, 67, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <tr>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(219, 40, false);
#line 15 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Products\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(259, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(303, 41, false);
#line 18 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Products\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
            EndContext();
            BeginContext(344, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(388, 47, false);
#line 21 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Products\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(435, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(479, 40, false);
#line 24 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Products\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
            EndContext();
            BeginContext(519, 49, true);
            WriteLiteral("\r\n        </th>\r\n        <th></th>\r\n    </tr>\r\n\r\n");
            EndContext();
#line 29 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Products\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(600, 36, true);
            WriteLiteral("    <tr>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(637, 39, false);
#line 32 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Products\Index.cshtml"
       Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
            EndContext();
            BeginContext(676, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(720, 40, false);
#line 35 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Products\Index.cshtml"
       Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
            EndContext();
            BeginContext(760, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(804, 46, false);
#line 38 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Products\Index.cshtml"
       Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
            EndContext();
            BeginContext(850, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(894, 39, false);
#line 41 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Products\Index.cshtml"
       Write(Html.DisplayFor(modelItem => item.Date));

#line default
#line hidden
            EndContext();
            BeginContext(933, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(977, 58, false);
#line 44 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Products\Index.cshtml"
       Write(Html.ActionLink("Edit", "Edit", new { id=item.ProductId }));

#line default
#line hidden
            EndContext();
            BeginContext(1035, 16, true);
            WriteLiteral(" |\r\n            ");
            EndContext();
            BeginContext(1052, 64, false);
#line 45 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Products\Index.cshtml"
       Write(Html.ActionLink("Details", "Details", new { id=item.ProductId }));

#line default
#line hidden
            EndContext();
            BeginContext(1116, 16, true);
            WriteLiteral(" |\r\n            ");
            EndContext();
            BeginContext(1133, 62, false);
#line 46 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Products\Index.cshtml"
       Write(Html.ActionLink("Delete", "Delete", new { id=item.ProductId }));

#line default
#line hidden
            EndContext();
            BeginContext(1195, 28, true);
            WriteLiteral("\r\n        </td>\r\n    </tr>\r\n");
            EndContext();
#line 49 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Products\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1226, 12, true);
            WriteLiteral("\r\n</table>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable< SCore.Models.Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591