#pragma checksum "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Users\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "20258d0cc820ba327f010d30ee80f413d99a5c1e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_Edit), @"mvc.1.0.view", @"/Views/Users/Edit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Users/Edit.cshtml", typeof(AspNetCore.Views_Users_Edit))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20258d0cc820ba327f010d30ee80f413d99a5c1e", @"/Views/Users/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27db0e849dcff1b197e7fd078d6119c14b731212", @"/Views/_ViewImports.cshtml")]
    public class Views_Users_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SCore.Models.User>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(26, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Users\Edit.cshtml"
  
    ViewBag.Title = "Edit";

#line default
#line hidden
            BeginContext(64, 21, true);
            WriteLiteral("\r\n<h2>Edit</h2>\r\n\r\n\r\n");
            EndContext();
#line 10 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Users\Edit.cshtml"
 using (Html.BeginForm())
{
    //@Html.AntiForgeryToken()


#line default
#line hidden
            BeginContext(149, 82, true);
            WriteLiteral("    <div class=\"form-horizontal\">\r\n        <h4>User</h4>\r\n        <hr />\r\n        ");
            EndContext();
            BeginContext(232, 64, false);
#line 17 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Users\Edit.cshtml"
   Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(296, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(307, 33, false);
#line 18 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Users\Edit.cshtml"
   Write(Html.HiddenFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(340, 50, true);
            WriteLiteral("\r\n\r\n        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(391, 93, false);
#line 21 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Users\Edit.cshtml"
       Write(Html.LabelFor(model => model.Name, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(484, 55, true);
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(540, 93, false);
#line 23 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Users\Edit.cshtml"
           Write(Html.EditorFor(model => model.Name, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(633, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(652, 82, false);
#line 24 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Users\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Name, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(734, 86, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(821, 97, false);
#line 29 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Users\Edit.cshtml"
       Write(Html.LabelFor(model => model.LastName, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(918, 55, true);
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(974, 97, false);
#line 31 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Users\Edit.cshtml"
           Write(Html.EditorFor(model => model.LastName, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(1071, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(1090, 86, false);
#line 32 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Users\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.LastName, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(1176, 86, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(1263, 94, false);
#line 37 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Users\Edit.cshtml"
       Write(Html.LabelFor(model => model.Email, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(1357, 55, true);
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(1413, 94, false);
#line 39 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Users\Edit.cshtml"
           Write(Html.EditorFor(model => model.Email, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(1507, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(1526, 83, false);
#line 40 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Users\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Email, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(1609, 255, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-offset-2 col-md-10\">\r\n                <input type=\"submit\" value=\"Save\" class=\"btn btn-default\" />\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 51 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Users\Edit.cshtml"
}

#line default
#line hidden
            BeginContext(1867, 13, true);
            WriteLiteral("\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1881, 40, false);
#line 54 "C:\Users\User\source\repos\SCore\SCore.WEB\Views\Users\Edit.cshtml"
Write(Html.ActionLink("Back to List", "Index"));

#line default
#line hidden
            EndContext();
            BeginContext(1921, 12, true);
            WriteLiteral("\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SCore.Models.User> Html { get; private set; }
    }
}
#pragma warning restore 1591
