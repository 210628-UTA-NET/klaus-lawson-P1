#pragma checksum "C:\Users\klaus\Documents\Revature\SAP1\SAWebUI\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "af8f9b154d416910c54f9fff8c8a656973e7434c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\klaus\Documents\Revature\SAP1\SAWebUI\Views\_ViewImports.cshtml"
using SAWebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\klaus\Documents\Revature\SAP1\SAWebUI\Views\_ViewImports.cshtml"
using SAWebUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"af8f9b154d416910c54f9fff8c8a656973e7434c", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a0873406fb5aadefe06f9488e67b9ac4eae7f16e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\klaus\Documents\Revature\SAP1\SAWebUI\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\" style=\"width: 10000px;height: 800px; background-color:#E0FFFF;\">\r\n    <div class=\"text-center\"  background-color:antiquewhite\">\r\n        <h1 class=\"display-4\">\r\n            Welcome to our Store Home <b><em>\r\n");
#nullable restore
#line 9 "C:\Users\klaus\Documents\Revature\SAP1\SAWebUI\Views\Home\Index.cshtml"
     if (User.Identity.IsAuthenticated)
    {

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\klaus\Documents\Revature\SAP1\SAWebUI\Views\Home\Index.cshtml"
Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\klaus\Documents\Revature\SAP1\SAWebUI\Views\Home\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </em></b>\r\n        </h1>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
