#pragma checksum "C:\Users\Administrador\Desktop\ISTEC\2ANO_2SEMESTRE\TI III\ProjetoTI\ProjetoGestor\ProjetoGestor\Views\Portal\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "42b682ce31bbdf1002e58aeb98d52c56b9989a77"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Portal_Index), @"mvc.1.0.view", @"/Views/Portal/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42b682ce31bbdf1002e58aeb98d52c56b9989a77", @"/Views/Portal/Index.cshtml")]
    public class Views_Portal_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Administrador\Desktop\ISTEC\2ANO_2SEMESTRE\TI III\ProjetoTI\ProjetoGestor\ProjetoGestor\Views\Portal\Index.cshtml"
  
    ViewData["Title"] = "Bem-Vindo à INFORENT";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- ======= Hero Section ======= -->
<section id=""hero"" class=""d-flex align-items-center"">
    <div class=""container position-relative"" data-aos=""fade-up"" data-aos-delay=""500"">
        <h1>Welcome to Inforent</h1>
        <h2>Your computer equipment rental management panel</h2>
");
#nullable restore
#line 12 "C:\Users\Administrador\Desktop\ISTEC\2ANO_2SEMESTRE\TI III\ProjetoTI\ProjetoGestor\ProjetoGestor\Views\Portal\Index.cshtml"
         if (ViewBag.ContaAtiva.NivelAcesso > 0) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <a href=""/Aluguer/Listar"" class=""btn-get-started scrollto"">Lista de Alugueres</a>
            <a href=""/Cliente/Listar"" class=""btn-get-started scrollto"" style=""margin-left:3%"">Lista de Clientes</a><br /><br />
            <a href=""/Funcionario/Listar"" class=""btn-get-started scrollto"">Lista de Funcionários</a>
            <a href=""/Produto/Listar"" class=""btn-get-started scrollto"" style=""margin-left:3%"">Lista de Produtos</a>
");
#nullable restore
#line 17 "C:\Users\Administrador\Desktop\ISTEC\2ANO_2SEMESTRE\TI III\ProjetoTI\ProjetoGestor\ProjetoGestor\Views\Portal\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
</section><!-- End Hero -->

<main id=""main"">

    <!-- ======= Why Us Section ======= -->
    <section id=""why-us"" class=""why-us"">
        <div class=""container"">

            <div class=""row"">

                <div class=""col-lg-4"" data-aos=""fade-up"">
                    <div class=""box"">
                        <span>01</span>
                        <h4>Liste</h4>
                        <p>Possibilidade de listar todos os alugueres registados</p>
                    </div>
                </div>

                <div class=""col-lg-4 mt-4 mt-lg-0"" data-aos=""fade-up"" data-aos-delay=""150"">
                    <div class=""box"">
                        <span>02</span>
                        <h4>Crie</h4>
                        <p>Possibilidade de criar/registar novos alugueres</p>
                    </div>
                </div>

                <div class=""col-lg-4 mt-4 mt-lg-0"" data-aos=""fade-up"" data-aos-delay=""300"">
                    <div class=""box"">
         ");
            WriteLiteral(@"               <span>03</span>
                        <h4>Edite</h4>
                        <p>Possibilidade de editar qualquer aluguer realizado</p>
                    </div>
                </div>

                <div class=""col-lg-4 mt-4 mt-lg-0"" data-aos=""fade-up"" data-aos-delay=""300"" style=""align-items: center;"">
                    <div class=""box"">
                        <span>&nbsp;</span>
                        <h4>&emsp;&emsp;</h4>
                        <p><br><br></p>
                    </div>
                </div>

                <div class=""col-lg-4 mt-4 mt-lg-0"" data-aos=""fade-up"" data-aos-delay=""300"" style=""align-items: center;"">
                    <div class=""box"">
                        <span>04</span>
                        <h4>Elimine</h4>
                        <p>Possibilidade de elimiar qualquer aluguer realizado que já não seja necessário</p>
                    </div>
                </div>

                <div class=""col-lg-4 mt-4 mt-lg-0"" data-ao");
            WriteLiteral(@"s=""fade-up"" data-aos-delay=""300"" style=""align-items: center;"">
                    <div class=""box"">
                        <span>&nbsp;</span>
                        <h4>&emsp;&emsp;</h4>
                        <p><br><br></p>
                    </div>
                </div>

            </div>

        </div>
    </section><!-- End Why Us Section -->
    <!-- ======= Team Section ======= -->
    <section id=""team"" class=""team"">
        <div class=""container"">

            <div class=""section-title"">
                <span>Desenvolvedor</span>
                <h2>Desenvolvedor</h2>
            </div>

            <div class=""row"" style=""justify-content: center;"">
                <div class=""col-lg-4 col-md-6 d-flex align-items-stretch"" data-aos=""zoom-in"">
                    <div class=""member"">
                        <img src=""/img/team/team-2.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 3836, "\"", 3842, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                        <h4>Diogo Alves</h4>
                        <span>Aluno de Licenciatura em Engenharia Informática</span>
                        <p>
                            Desenvolvedor da solução de gestão de alugueres de material Informático
                        </p>
                        <div class=""social"">
                            <a href=""https://twitter.com/diogoalves_02"" target=""_blank""><i class=""bi bi-twitter""></i></a>
                            <a href=""https://www.facebook.com/diogo.alves.71619533/"" target=""_blank""><i class=""bi bi-facebook""></i></a>
                            <a href=""https://www.instagram.com/diogoalves_02/"" target=""_blank""><i class=""bi bi-instagram""></i></a>
                            <a href=""https://www.linkedin.com/in/diogoalves2002/"" target=""_blank""><i class=""bi bi-linkedin""></i></a>
                        </div>
                    </div>
                </div>

            </div>

        </div>
    </section><!-- End Team Secti");
            WriteLiteral(@"on -->
    <!-- ======= Clients Section ======= -->
    <section id=""clients"" class=""clients"">
        <div class=""container"" data-aos=""zoom-in"">

            <div class=""row d-flex align-items-center"">

                <div class=""col-lg-2 col-md-4 col-6"">
                    <img src=""/img/clients/client-1.png"" class=""img-fluid""");
            BeginWriteAttribute("alt", " alt=\"", 5207, "\"", 5213, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                </div>\r\n\r\n                <div class=\"col-lg-2 col-md-4 col-6\">\r\n                    <img src=\"/img/clients/client-2.png\" class=\"img-fluid\"");
            BeginWriteAttribute("alt", " alt=\"", 5372, "\"", 5378, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                </div>\r\n\r\n                <div class=\"col-lg-2 col-md-4 col-6\">\r\n                    <img src=\"/img/clients/client-1.png\" class=\"img-fluid\"");
            BeginWriteAttribute("alt", " alt=\"", 5537, "\"", 5543, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                </div>\r\n\r\n                <div class=\"col-lg-2 col-md-4 col-6\">\r\n                    <img src=\"/img/clients/client-2.png\" class=\"img-fluid\"");
            BeginWriteAttribute("alt", " alt=\"", 5702, "\"", 5708, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                </div>\r\n\r\n                <div class=\"col-lg-2 col-md-4 col-6\">\r\n                    <img src=\"/img/clients/client-1.png\" class=\"img-fluid\"");
            BeginWriteAttribute("alt", " alt=\"", 5867, "\"", 5873, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                </div>\r\n\r\n                <div class=\"col-lg-2 col-md-4 col-6\">\r\n                    <img src=\"/img/clients/client-2.png\" class=\"img-fluid\"");
            BeginWriteAttribute("alt", " alt=\"", 6032, "\"", 6038, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                </div>\r\n\r\n            </div>\r\n\r\n        </div>\r\n    </section><!-- End Clients Section -->\r\n\r\n</main><!-- End #main -->\r\n");
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