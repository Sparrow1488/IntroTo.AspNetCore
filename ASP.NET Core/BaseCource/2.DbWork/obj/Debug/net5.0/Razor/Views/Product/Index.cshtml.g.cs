#pragma checksum "C:\Users\Dom\Desktop\Репозитории\The-basis-of-ASP.NET\ASP.NET Core\BaseCource\2.DbWork\Views\Product\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ac249884fcfc15acf90ea7f8cb623471b2ddb278"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Index), @"mvc.1.0.view", @"/Views/Product/Index.cshtml")]
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
#line 1 "C:\Users\Dom\Desktop\Репозитории\The-basis-of-ASP.NET\ASP.NET Core\BaseCource\2.DbWork\Views\_ViewImports.cshtml"
using _2.DbWork;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Dom\Desktop\Репозитории\The-basis-of-ASP.NET\ASP.NET Core\BaseCource\2.DbWork\Views\_ViewImports.cshtml"
using _2.DbWork.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac249884fcfc15acf90ea7f8cb623471b2ddb278", @"/Views/Product/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a9d7033a28fc4d197d117ca4cda67b309a96da1", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Product>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n    <div class=\"container p-3\">\r\n        <div class=\"row pt-4\">\r\n            <div class=\"col-6\">\r\n                <h2 class=\"text-primary\">Of Products table</h2>\r\n            </div>\r\n            <div class=\"col-6 text-right\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ac249884fcfc15acf90ea7f8cb623471b2ddb2784413", async() => {
                WriteLiteral("\r\n                    Create new Product\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <br />\r\n\r\n");
#nullable restore
#line 16 "C:\Users\Dom\Desktop\Репозитории\The-basis-of-ASP.NET\ASP.NET Core\BaseCource\2.DbWork\Views\Product\Index.cshtml"
         if(Model.Count() > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <table class=""table table-bordered table-striped"" style=""width:100%"">
                <thead>
                    <tr>
                        <th>
                            Id
                        </th>
                        <th>
                            Products title
                        </th>
                        <th>
                            Price
                        </th>
                        <th>
                            Release date
                        </th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 36 "C:\Users\Dom\Desktop\Репозитории\The-basis-of-ASP.NET\ASP.NET Core\BaseCource\2.DbWork\Views\Product\Index.cshtml"
                     foreach (var prod in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td width=\"25%\">");
#nullable restore
#line 39 "C:\Users\Dom\Desktop\Репозитории\The-basis-of-ASP.NET\ASP.NET Core\BaseCource\2.DbWork\Views\Product\Index.cshtml"
                                       Write(prod.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td width=\"25%\">");
#nullable restore
#line 40 "C:\Users\Dom\Desktop\Репозитории\The-basis-of-ASP.NET\ASP.NET Core\BaseCource\2.DbWork\Views\Product\Index.cshtml"
                                       Write(prod.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td width=\"25%\">");
#nullable restore
#line 41 "C:\Users\Dom\Desktop\Репозитории\The-basis-of-ASP.NET\ASP.NET Core\BaseCource\2.DbWork\Views\Product\Index.cshtml"
                                       Write(prod.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td width=\"25%\">");
#nullable restore
#line 42 "C:\Users\Dom\Desktop\Репозитории\The-basis-of-ASP.NET\ASP.NET Core\BaseCource\2.DbWork\Views\Product\Index.cshtml"
                                       Write(prod.ReleseDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 44 "C:\Users\Dom\Desktop\Репозитории\The-basis-of-ASP.NET\ASP.NET Core\BaseCource\2.DbWork\Views\Product\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table> \r\n");
#nullable restore
#line 47 "C:\Users\Dom\Desktop\Репозитории\The-basis-of-ASP.NET\ASP.NET Core\BaseCource\2.DbWork\Views\Product\Index.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h2>Now products table is empty</h2>\r\n");
#nullable restore
#line 51 "C:\Users\Dom\Desktop\Репозитории\The-basis-of-ASP.NET\ASP.NET Core\BaseCource\2.DbWork\Views\Product\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
