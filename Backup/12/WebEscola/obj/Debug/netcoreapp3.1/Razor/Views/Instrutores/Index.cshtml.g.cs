#pragma checksum "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "85ae0f0c32b17d89ed4e6d739c16c7f9a0a27788"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Instrutores_Index), @"mvc.1.0.view", @"/Views/Instrutores/Index.cshtml")]
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
#line 1 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\_ViewImports.cshtml"
using WebEscola;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\_ViewImports.cshtml"
using WebEscola.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85ae0f0c32b17d89ed4e6d739c16c7f9a0a27788", @"/Views/Instrutores/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bdf59f91627be88bd00481ccc276f87720b6e6d0", @"/Views/_ViewImports.cshtml")]
    public class Views_Instrutores_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebEscola.Models.ViewModels.InstrutorIndexData>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml"
  
    ViewData["Title"] = "Lista de Instrutores";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Instrutores</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "85ae0f0c32b17d89ed4e6d739c16c7f9a0a277884908", async() => {
                WriteLiteral("Adicionar Instrutor");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</p>

<table class=""table"">
    <thead>
        <tr>
            <th>
                Nome
            </th>
            <th>
                Sobrenome
            </th>
            <th>
                Contratação
            </th>
            <th>
                Escritório
            </th>
            <th>
                Cursos
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 35 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml"
         foreach (var item in Model.Instrutores)
        {
            string selectedRow = "";

            if (item.InstrutorID == (int?)ViewData["InstrutorID"])
            {
                selectedRow = "table-success";
            }


#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr");
            BeginWriteAttribute("class", " class=\"", 898, "\"", 918, 1);
#nullable restore
#line 44 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml"
WriteAttributeValue("", 906, selectedRow, 906, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <td>\r\n                    ");
#nullable restore
#line 46 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 49 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Sobrenome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 52 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Contratacao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
#nullable restore
#line 55 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml"
                     if (item.Escritorio != null)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml"
                   Write(item.Escritorio.Localizacao);

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml"
                                                    
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td>\r\n");
#nullable restore
#line 62 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml"
                   Write(item.CursosInstrutor.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "85ae0f0c32b17d89ed4e6d739c16c7f9a0a277889474", async() => {
                WriteLiteral("Editar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 66 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml"
                                           WriteLiteral(item.InstrutorID);

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
            WriteLiteral(" |\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "85ae0f0c32b17d89ed4e6d739c16c7f9a0a2778811658", async() => {
                WriteLiteral("Detalhes");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 67 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml"
                                              WriteLiteral(item.InstrutorID);

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
            WriteLiteral(" |\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "85ae0f0c32b17d89ed4e6d739c16c7f9a0a2778813848", async() => {
                WriteLiteral("Excluir");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 68 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml"
                                             WriteLiteral(item.InstrutorID);

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
            WriteLiteral(" |\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "85ae0f0c32b17d89ed4e6d739c16c7f9a0a2778816036", async() => {
                WriteLiteral("Selecionar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-InstrutorID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 69 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml"
                                                     WriteLiteral(item.InstrutorID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["InstrutorID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-InstrutorID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["InstrutorID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 72 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
#nullable restore
#line 76 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml"
 if (Model.Cursos != null)
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 77 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml"
     if (Model.Cursos.Count() > 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h3>Cursos atribuídos ao instrutor</h3>\r\n        <table class=\"table\">\r\n            <tr>\r\n                <th>Curso</th>\r\n                <th>Departamento</th>\r\n                <th></th>\r\n            </tr>\r\n\r\n");
#nullable restore
#line 87 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml"
             foreach (var item in Model.Cursos)
            {

                string selectedRow = "";

                if (item.CursoID == (int?)ViewData["CursoID"])
                {
                    selectedRow = "table-success";
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr");
            BeginWriteAttribute("class", " class=\"", 2642, "\"", 2662, 1);
#nullable restore
#line 96 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml"
WriteAttributeValue("", 2650, selectedRow, 2650, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <td>\r\n                        ");
#nullable restore
#line 98 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml"
                   Write(item.Titulo);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 101 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml"
                   Write(item.Departamento.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 104 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml"
                   Write(Html.ActionLink("Selecionar", "Index", new { cursoID = item.CursoID, instrutorID = (int)ViewData["InstrutorID"] }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 107 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </table>\r\n");
#nullable restore
#line 109 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 111 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml"
     if (Model.Matriculas != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h3>\r\n            Alunos deste curso\r\n        </h3>\r\n        <table class=\"table\">\r\n            <tr>\r\n                <th>Nome</th>\r\n                <th>Nascimento</th>\r\n            </tr>\r\n");
#nullable restore
#line 121 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml"
             foreach (var item in Model.Matriculas)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 125 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml"
                   Write(item.Aluno.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 128 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml"
                   Write(item.Aluno.Data.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 131 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </table>\r\n");
#nullable restore
#line 133 "D:\ProjetosCSharp\Mvc\ASP NET Core MVC\WebEscola\Views\Instrutores\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebEscola.Models.ViewModels.InstrutorIndexData> Html { get; private set; }
    }
}
#pragma warning restore 1591