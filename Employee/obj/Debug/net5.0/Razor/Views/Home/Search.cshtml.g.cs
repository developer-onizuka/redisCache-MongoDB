#pragma checksum "/home/vagrant/tests/redisCache-MongoDB/Employee/Views/Home/Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4ceddf030483674ce8c04836663d514120039053"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Search), @"mvc.1.0.view", @"/Views/Home/Search.cshtml")]
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
#line 1 "/home/vagrant/tests/redisCache-MongoDB/Employee/Views/_ViewImports.cshtml"
using Employee;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/vagrant/tests/redisCache-MongoDB/Employee/Views/_ViewImports.cshtml"
using Employee.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ceddf030483674ce8c04836663d514120039053", @"/Views/Home/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e34b09c5bebdb4ae05a509d36335bc47af3a9ad", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Employee.Models.EmployeeEntity>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Update", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ConfirmDelete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Search", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<h1>Search Employee</h1>\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4ceddf030483674ce8c04836663d5141200390534992", async() => {
                WriteLiteral("\n\n    <table border=\"1\" cellpadding=\"10\">\n        <tr>\n            <td>Employee ID :</td>\n            <td>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4ceddf030483674ce8c04836663d5141200390535359", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 10 "/home/vagrant/tests/redisCache-MongoDB/Employee/Views/Home/Search.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.EmployeeID);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"</td>
        </tr>
            <td colspan=""2"">
                <button type=""submit"">Search</button>
            </td>
        </tr>
    </table>

<br/ >
<h1>Search Result</h1>

    <table border=""1"" cellpadding=""10"">
        <tr>
            <td>Employee ID</td>
            <td>First Name</td>
            <td>Last Name</td>
            <td>Photo</td>
            <td>Face</td>
            <td>Edit</td>
            <td>Delete</td>
        </tr>
        <tr>
            <td>");
#nullable restore
#line 32 "/home/vagrant/tests/redisCache-MongoDB/Employee/Views/Home/Search.cshtml"
           Write(Model.EmployeeID);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n            <td>");
#nullable restore
#line 33 "/home/vagrant/tests/redisCache-MongoDB/Employee/Views/Home/Search.cshtml"
           Write(Model.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n            <td>");
#nullable restore
#line 34 "/home/vagrant/tests/redisCache-MongoDB/Employee/Views/Home/Search.cshtml"
           Write(Model.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n\n");
#nullable restore
#line 36 "/home/vagrant/tests/redisCache-MongoDB/Employee/Views/Home/Search.cshtml"
             if(Model.Image != null)
            {
                string base64String = Convert.ToBase64String(Model.Image);
        	var imgsrc = string.Format("data:image/jpeg;base64,{0}", base64String);

#line default
#line hidden
#nullable disable
                WriteLiteral("                <td> <img");
                BeginWriteAttribute("src", " src=\"", 1073, "\"", 1086, 1);
#nullable restore
#line 40 "/home/vagrant/tests/redisCache-MongoDB/Employee/Views/Home/Search.cshtml"
WriteAttributeValue("", 1079, imgsrc, 1079, 7, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("alt", " alt=\"", 1087, "\"", 1093, 0);
                EndWriteAttribute();
                WriteLiteral(" style=\"width: 120px; height: 180px;\"> </td>\n");
#nullable restore
#line 41 "/home/vagrant/tests/redisCache-MongoDB/Employee/Views/Home/Search.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <td> <img");
                BeginWriteAttribute("src", " src=\"", 1209, "\"", 1215, 0);
                EndWriteAttribute();
                BeginWriteAttribute("alt", " alt=\"", 1216, "\"", 1222, 0);
                EndWriteAttribute();
                WriteLiteral(" style=\"width: 120px; height: 180px;\"> </td>\n");
#nullable restore
#line 45 "/home/vagrant/tests/redisCache-MongoDB/Employee/Views/Home/Search.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("\n");
#nullable restore
#line 47 "/home/vagrant/tests/redisCache-MongoDB/Employee/Views/Home/Search.cshtml"
             if(Model.Face != null)
            {
                string base64String = Convert.ToBase64String(Model.Face);
        	var imgsrc = string.Format("data:image/jpeg;base64,{0}", base64String);

#line default
#line hidden
#nullable disable
                WriteLiteral("                <td> <img");
                BeginWriteAttribute("src", " src=\"", 1513, "\"", 1526, 1);
#nullable restore
#line 51 "/home/vagrant/tests/redisCache-MongoDB/Employee/Views/Home/Search.cshtml"
WriteAttributeValue("", 1519, imgsrc, 1519, 7, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("alt", " alt=\"", 1527, "\"", 1533, 0);
                EndWriteAttribute();
                WriteLiteral(" style=\"width: 120px; height: 180px;\"> </td>\n");
#nullable restore
#line 52 "/home/vagrant/tests/redisCache-MongoDB/Employee/Views/Home/Search.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <td> <img");
                BeginWriteAttribute("src", " src=\"", 1649, "\"", 1655, 0);
                EndWriteAttribute();
                BeginWriteAttribute("alt", " alt=\"", 1656, "\"", 1662, 0);
                EndWriteAttribute();
                WriteLiteral(" style=\"width: 120px; height: 180px;\"> </td>\n");
#nullable restore
#line 56 "/home/vagrant/tests/redisCache-MongoDB/Employee/Views/Home/Search.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("\n");
#nullable restore
#line 58 "/home/vagrant/tests/redisCache-MongoDB/Employee/Views/Home/Search.cshtml"
             if (!string.IsNullOrEmpty(@Model.Id))
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                 <td> ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4ceddf030483674ce8c04836663d51412003905311643", async() => {
                    WriteLiteral("Edit");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 60 "/home/vagrant/tests/redisCache-MongoDB/Employee/Views/Home/Search.cshtml"
                                                                     WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(" </td>\n                 <td> ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4ceddf030483674ce8c04836663d51412003905314118", async() => {
                    WriteLiteral("Delete");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 61 "/home/vagrant/tests/redisCache-MongoDB/Employee/Views/Home/Search.cshtml"
                                                                            WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(" </td>\n");
#nullable restore
#line 62 "/home/vagrant/tests/redisCache-MongoDB/Employee/Views/Home/Search.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                 <td>Edit</td>\n                 <td>Delete</td>\n");
#nullable restore
#line 67 "/home/vagrant/tests/redisCache-MongoDB/Employee/Views/Home/Search.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </tr>\n\n    </table>\n\n<br/ >\n<h1><font");
                BeginWriteAttribute("color", " color=\"", 2179, "\"", 2201, 1);
#nullable restore
#line 73 "/home/vagrant/tests/redisCache-MongoDB/Employee/Views/Home/Search.cshtml"
WriteAttributeValue("", 2187, ViewBag.Color, 2187, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 73 "/home/vagrant/tests/redisCache-MongoDB/Employee/Views/Home/Search.cshtml"
                            Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
                WriteLiteral("</font></h1>\n<h2><font");
                BeginWriteAttribute("color", " color=\"", 2241, "\"", 2263, 1);
#nullable restore
#line 74 "/home/vagrant/tests/redisCache-MongoDB/Employee/Views/Home/Search.cshtml"
WriteAttributeValue("", 2249, ViewBag.Color, 2249, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Elapsed Time: ");
#nullable restore
#line 74 "/home/vagrant/tests/redisCache-MongoDB/Employee/Views/Home/Search.cshtml"
                                          Write(ViewBag.Time);

#line default
#line hidden
#nullable disable
                WriteLiteral(" (ms)</font></h2>\n<br/ >\n\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Employee.Models.EmployeeEntity> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
