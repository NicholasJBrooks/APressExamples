#pragma checksum "C:\Users\NIck Brooks\Documents\GitHub\APressExamples\WorkingWithVisualStudio\WorkingWithVisualStudio\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1d4642c38e4a0472ec0b336dc1eee00c3d0e7f98"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
#line 2 "C:\Users\NIck Brooks\Documents\GitHub\APressExamples\WorkingWithVisualStudio\WorkingWithVisualStudio\Views\_ViewImports.cshtml"
using System.Collections.Generic;

#line default
#line hidden
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\NIck Brooks\Documents\GitHub\APressExamples\WorkingWithVisualStudio\WorkingWithVisualStudio\Views\_ViewImports.cshtml"
using WorkingWithVisualStudio.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d4642c38e4a0472ec0b336dc1eee00c3d0e7f98", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e496ad5f93538733c884b41c53853ff25e1bbe1", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Product>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(29, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\NIck Brooks\Documents\GitHub\APressExamples\WorkingWithVisualStudio\WorkingWithVisualStudio\Views\Home\Index.cshtml"
      
        ViewBag.Tittle = "Working With Visual Studio";
    

#line default
#line hidden
            BeginContext(102, 138, true);
            WriteLiteral("    <h3>Products</h3>\r\n    <table>\r\n        <thead>\r\n            <tr><th>Name</th><th>Price</th></tr>\r\n        </thead>\r\n        <tbody>\r\n");
            EndContext();
#line 12 "C:\Users\NIck Brooks\Documents\GitHub\APressExamples\WorkingWithVisualStudio\WorkingWithVisualStudio\Views\Home\Index.cshtml"
             foreach (Product product in Model)
            {

#line default
#line hidden
            BeginContext(304, 46, true);
            WriteLiteral("                <tr>\r\n                    <td>");
            EndContext();
            BeginContext(351, 12, false);
#line 15 "C:\Users\NIck Brooks\Documents\GitHub\APressExamples\WorkingWithVisualStudio\WorkingWithVisualStudio\Views\Home\Index.cshtml"
                   Write(product.Name);

#line default
#line hidden
            EndContext();
            BeginContext(363, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(396, 21, false);
#line 16 "C:\Users\NIck Brooks\Documents\GitHub\APressExamples\WorkingWithVisualStudio\WorkingWithVisualStudio\Views\Home\Index.cshtml"
                    Write($"{product.Price:c2}");

#line default
#line hidden
            EndContext();
            BeginContext(418, 30, true);
            WriteLiteral("</td>\r\n                </tr>\r\n");
            EndContext();
#line 18 "C:\Users\NIck Brooks\Documents\GitHub\APressExamples\WorkingWithVisualStudio\WorkingWithVisualStudio\Views\Home\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(463, 32, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
