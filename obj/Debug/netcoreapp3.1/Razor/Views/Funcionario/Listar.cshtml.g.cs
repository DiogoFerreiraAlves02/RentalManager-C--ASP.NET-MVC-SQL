#pragma checksum "C:\Users\Administrador\Desktop\ISTEC\2ANO_2SEMESTRE\TI III\ProjetoTI\ProjetoGestor\ProjetoGestor\Views\Funcionario\Listar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "83e8981fc38a4adb896db2a10f6c387fc8981fd9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Funcionario_Listar), @"mvc.1.0.view", @"/Views/Funcionario/Listar.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"83e8981fc38a4adb896db2a10f6c387fc8981fd9", @"/Views/Funcionario/Listar.cshtml")]
    public class Views_Funcionario_Listar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Administrador\Desktop\ISTEC\2ANO_2SEMESTRE\TI III\ProjetoTI\ProjetoGestor\ProjetoGestor\Views\Funcionario\Listar.cshtml"
  
    ViewData["Title"] = "Listagem de Funcionários";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<main id=""main"">

    <!-- ======= Services Section ======= -->
    <section id=""services"" class=""services"">
        <div class=""container"">

            <div class=""section-title"">
                <span>Funcionários</span>
                <h2>Funcionários</h2>
            </div>
            <div class=""row"">
");
#nullable restore
#line 18 "C:\Users\Administrador\Desktop\ISTEC\2ANO_2SEMESTRE\TI III\ProjetoTI\ProjetoGestor\ProjetoGestor\Views\Funcionario\Listar.cshtml"
                   var listaFuncionarios = @Model;
                    foreach (var funcionario in listaFuncionarios) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <div class=""col-lg-4 col-md-6 align-items-stretch"" data-aos=""fade-up"">
                            <div class=""icon-box"">
                                <div class=""icon""><i class='bx bxs-user-detail'></i></div>
                                <h4><a");
            BeginWriteAttribute("href", " href=\"", 833, "\"", 878, 2);
            WriteAttributeValue("", 840, "/Funcionario/Consultar/", 840, 23, true);
#nullable restore
#line 23 "C:\Users\Administrador\Desktop\ISTEC\2ANO_2SEMESTRE\TI III\ProjetoTI\ProjetoGestor\ProjetoGestor\Views\Funcionario\Listar.cshtml"
WriteAttributeValue("", 863, funcionario.Id, 863, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 23 "C:\Users\Administrador\Desktop\ISTEC\2ANO_2SEMESTRE\TI III\ProjetoTI\ProjetoGestor\ProjetoGestor\Views\Funcionario\Listar.cshtml"
                                                                                Write(funcionario.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h4>\r\n                                <p>Funcionário Nr: <b>");
#nullable restore
#line 24 "C:\Users\Administrador\Desktop\ISTEC\2ANO_2SEMESTRE\TI III\ProjetoTI\ProjetoGestor\ProjetoGestor\Views\Funcionario\Listar.cshtml"
                                                 Write(funcionario.NrFuncionario);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 27 "C:\Users\Administrador\Desktop\ISTEC\2ANO_2SEMESTRE\TI III\ProjetoTI\ProjetoGestor\ProjetoGestor\Views\Funcionario\Listar.cshtml"
                    }
                

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n\r\n    </section><!-- End Services Section -->\r\n\r\n</main><!-- End #main -->\r\n");
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
