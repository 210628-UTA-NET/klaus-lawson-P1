#pragma checksum "C:\Users\klaus\Documents\Revature\SAP1\SAWebUI\Views\Management\ProductManagement.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "df4d8334c4aa5d8a4cda8b521265230111681ff4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Management_ProductManagement), @"mvc.1.0.view", @"/Views/Management/ProductManagement.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df4d8334c4aa5d8a4cda8b521265230111681ff4", @"/Views/Management/ProductManagement.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a0873406fb5aadefe06f9488e67b9ac4eae7f16e", @"/Views/_ViewImports.cshtml")]
    public class Views_Management_ProductManagement : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SAWebUI.Models.ProductVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "createProduct", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-bottom:10px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n\r\n<div class=\"container p-3\">\r\n    <div class=\"row pt-4\">\r\n        <div class=\"col-6\">\r\n            <h2 class=\"display-4\">Product List</h2>\r\n        </div>\r\n        <div class=\"col-6 text-right\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "df4d8334c4aa5d8a4cda8b521265230111681ff44754", async() => {
                WriteLiteral(" Add new Product");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n");
#nullable restore
#line 14 "C:\Users\klaus\Documents\Revature\SAP1\SAWebUI\Views\Management\ProductManagement.cshtml"
     if (Model.Count() > 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <table class=""table table-striped table-hover"">
            <thead class=""text-center"">
                <tr>
                    <th scope=""col"">Product Id</th>
                    <th scope=""col"">Product Name</th>
                    <th scope=""col"">Unit Price</th>
                    <th scope=""col"">Description</th>
                    <th scope=""col"">Quantity Available</th>
                    <th scope=""col""></th>
                </tr>
            </thead>
            <tbody class=""text-center"">
");
#nullable restore
#line 28 "C:\Users\klaus\Documents\Revature\SAP1\SAWebUI\Views\Management\ProductManagement.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 31 "C:\Users\klaus\Documents\Revature\SAP1\SAWebUI\Views\Management\ProductManagement.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 32 "C:\Users\klaus\Documents\Revature\SAP1\SAWebUI\Views\Management\ProductManagement.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ProductName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 33 "C:\Users\klaus\Documents\Revature\SAP1\SAWebUI\Views\Management\ProductManagement.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ProductUnitPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 34 "C:\Users\klaus\Documents\Revature\SAP1\SAWebUI\Views\Management\ProductManagement.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ProductDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 35 "C:\Users\klaus\Documents\Revature\SAP1\SAWebUI\Views\Management\ProductManagement.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ProductAvailableQty));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
            WriteLiteral("                                ");
#nullable restore
#line 38 "C:\Users\klaus\Documents\Revature\SAP1\SAWebUI\Views\Management\ProductManagement.cshtml"
                           Write(Html.ActionLink("Edit", "EditProduct", "Management", new { p_productId = item.Id }, new { @style = "color:white;", @class = "btn btn-success mx-1" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 39 "C:\Users\klaus\Documents\Revature\SAP1\SAWebUI\Views\Management\ProductManagement.cshtml"
                           Write(Html.ActionLink("Delete", "DeleteProduct", "Management", new { p_productId = item.Id }, new { @style = "color:white;", @class = "btn btn-danger mx-1" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                           \r\n                                                \r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 44 "C:\Users\klaus\Documents\Revature\SAP1\SAWebUI\Views\Management\ProductManagement.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n            </tbody>\r\n        </table>\r\n");
#nullable restore
#line 50 "C:\Users\klaus\Documents\Revature\SAP1\SAWebUI\Views\Management\ProductManagement.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h3 class=\"display-4\">There is No Product at this moment</h3>\r\n");
#nullable restore
#line 54 "C:\Users\klaus\Documents\Revature\SAP1\SAWebUI\Views\Management\ProductManagement.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SAWebUI.Models.ProductVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
