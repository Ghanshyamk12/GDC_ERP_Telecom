#pragma checksum "C:\Users\SHYAM\source\repos\GDC_ERP_Telecom\Telecom.WebUI\Views\Invoice\InvoiceTab\_PrintOptions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9e8086d8f18660a410198d9679a9e2c586e6f4e5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Invoice_InvoiceTab__PrintOptions), @"mvc.1.0.view", @"/Views/Invoice/InvoiceTab/_PrintOptions.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Invoice/InvoiceTab/_PrintOptions.cshtml", typeof(AspNetCore.Views_Invoice_InvoiceTab__PrintOptions))]
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
#line 1 "C:\Users\SHYAM\source\repos\GDC_ERP_Telecom\Telecom.WebUI\Views\_ViewImports.cshtml"
using Telecom.WebUI;

#line default
#line hidden
#line 2 "C:\Users\SHYAM\source\repos\GDC_ERP_Telecom\Telecom.WebUI\Views\_ViewImports.cshtml"
using Telecom.WebUI.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e8086d8f18660a410198d9679a9e2c586e6f4e5", @"/Views/Invoice/InvoiceTab/_PrintOptions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93726e5a21062e1d0aa59e60c900e50f87c9af04", @"/Views/_ViewImports.cshtml")]
    public class Views_Invoice_InvoiceTab__PrintOptions : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Telecom.Application.ViewModels.InvoicingSelectionViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(188, 84, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-sm-6\">\r\n        <b>Print Type</b>\r\n        ");
            EndContext();
            BeginContext(273, 187, false);
#line 8 "C:\Users\SHYAM\source\repos\GDC_ERP_Telecom\Telecom.WebUI\Views\Invoice\InvoiceTab\_PrintOptions.cshtml"
   Write(Html.DropDownListFor(x=>x.SelectedInvoiceOption,new SelectList(Model.InvoiceOption,"Value","Text"),
               htmlAttributes:new {@class="form-control",id= "InvoiceCallPrintType" }));

#line default
#line hidden
            EndContext();
            BeginContext(460, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(471, 91, false);
#line 10 "C:\Users\SHYAM\source\repos\GDC_ERP_Telecom\Telecom.WebUI\Views\Invoice\InvoiceTab\_PrintOptions.cshtml"
   Write(Html.ValidationMessageFor(x => x.SelectedInvoiceOption, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(562, 1290, true);
            WriteLiteral(@"
    </div>
    <div class=""col-sm-6"">
        <input type=""checkbox"" checked=""checked"" name=""CallsData"" value=""Exclude Mobile"" id=""CallsData""/> 
        <label for=""CallsData""><b>Exclude Mobile</b></label>
    </div>
</div>
<br />
<div class=""container"" style=""background-color:aliceblue"">
    <div class=""row"">
        <div class=""col-md-4"">
        </div>
        <div class=""col-md-8"">
            <div class=""tab"">
                <div id=""priorityscroll"">
                    <ul class=""nav nav-tabs tab"" id=""MyTabs"">
                        <li id=""liSelection"" class=""active""><a class=""active"" role=""tab"" data-toggle=""tab"" href=""#tabInvoiceMemo"">Invoice Memo</a></li>
                        <li id=""liInvoiceOptions"" class=""""><a role=""tab"" data-toggle=""tab"" href=""#tabInvoiceMemoPrefix"">Invoice Memo/Prefix</a></li>
                    </ul>
                    <div class=""tab-content tabs"">
                        <div role=""tabpanel"" id=""tabInvoiceMemo"" class=""tab-pane fade active show"">
 ");
            WriteLiteral(@"                       </div>
                        <div role=""tabpanel"" id=""tabInvoiceMemoPrefix"" class=""tab-pane fade"">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Telecom.Application.ViewModels.InvoicingSelectionViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
