#pragma checksum "C:\Julieth\Pruebas\TestDeveloper.Services\TestDeveloper.Services.API\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cc9c6e00b50b26845c4597beddaeb15df55a08ce"
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
#line 1 "C:\Julieth\Pruebas\TestDeveloper.Services\TestDeveloper.Services.API\Views\_ViewImports.cshtml"
using TestDeveloper.Services.API;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Julieth\Pruebas\TestDeveloper.Services\TestDeveloper.Services.API\Views\_ViewImports.cshtml"
using TestDeveloper.Services.API.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc9c6e00b50b26845c4597beddaeb15df55a08ce", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86c6d2d5feccfe28c6337886cea046c3d8efa2c7", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Julieth\Pruebas\TestDeveloper.Services\TestDeveloper.Services.API\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">Administración de libros</h1>
    <!--<p>Learn about <a href=""https://docs.microsoft.com/aspnet/core"">building Web apps with ASP.NET Core</a>.</p>-->
</div>

<div style=""margin-top: 2%;"">
    <!-- Button trigger modal -->
    <button type=""button"" class=""btn btn-primary"" data-toggle=""modal"" data-target=""#AddAuthorModal"">
        Registrar Autor
    </button>

    <!-- Button trigger modal -->
    <button type=""button"" class=""btn btn-primary"" data-toggle=""modal"" data-target=""#AddBookModal"">
        Registrar libro
    </button>
</div>

<div style=""margin-top: 2%;"">
    <table id=""example"" class=""display"" style=""width:100%"">
        <thead>
            <tr>
                <th>BookId</th>
                <th>Titulo</th>
                <th>Año de publicación</th>
                <th>Número de páginas</th>
                <th>AuthorId</th>
                <th>Autor</th>
                <th>Acción</th>
            </tr>
        </t");
            WriteLiteral("head>\r\n    </table>\r\n</div>\r\n\r\n<!-- Modal Registrar Autor -->\r\n<div class=\"modal fade\" id=\"AddAuthorModal\" tabindex=\"-1\" aria-labelledby=\"exampleModalLabel\" aria-hidden=\"true\">\r\n    <div class=\"modal-dialog\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cc9c6e00b50b26845c4597beddaeb15df55a08ce4831", async() => {
                WriteLiteral(@"
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""exampleModalLabel"">Agregar autor</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">

                    <div class=""form-group"">
                        <label for=""authorFullname"">Nombre del autor</label>
                        <input type=""text"" class=""form-control"" id=""authorFullname"" placeholder=""Nombres y apellidos"" required>
                    </div>
                    <div class=""form-group"">
                        <label for=""authorBirthday"">Fecha de nacimiento</label>
                        <input type=""date"" class=""form-control"" id=""authorBirthday"" placeholder=""Fecha de nacimiento"" required>
                    </div>
                    <di");
                WriteLiteral(@"v class=""form-group"">
                        <label for=""authorCity"">Ciudad</label>
                        <input type=""text"" class=""form-control"" id=""authorCity"" placeholder=""Ciudad de procedencia"" required>
                    </div>
                    <div class=""form-group"">
                        <label for=""authorEmail"">Email</label>
                        <input type=""email"" class=""form-control"" id=""authorEmail"" placeholder=""name@example.com"" required>
                    </div>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Cerrar</button>
                    <button type=""submit"" class=""btn btn-primary"" id=""SaveAuthor"">Guardar</button>
                </div>
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<!-- Modal Registrar Libro -->\r\n<div class=\"modal fade\" id=\"AddBookModal\" tabindex=\"-1\" aria-labelledby=\"exampleModalLabel\" aria-hidden=\"true\">\r\n    <div class=\"modal-dialog\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cc9c6e00b50b26845c4597beddaeb15df55a08ce8262", async() => {
                WriteLiteral(@"
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""exampleModalLabel"">Agregar libro</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <div class=""form-group"">
                        <label for=""bookTitle"">Nombre del libro</label>
                        <input type=""text"" class=""form-control"" id=""bookTitle"" placeholder=""Nombre del libro"" required>
                    </div>
                    <div class=""form-group"">
                        <label for=""bookYear"">Año de publicación</label>
                        <input type=""text"" class=""form-control"" id=""bookYear"" placeholder=""Año de publicación"" required>
                    </div>
                    <div class=""form-group"">
      ");
                WriteLiteral(@"                  <label for=""bookNumberPages"">Número de páginas</label>
                        <input type=""number"" class=""form-control"" id=""bookNumberPages"" placeholder=""Número de páginas"" required>
                    </div>
                    <div class=""form-group"">
                        <label for=""bookAuthor"">Autor</label>
                        <select class=""form-control"" id=""bookAuthor"" required></select>
                    </div>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Cerrar</button>
                    <button type=""submit"" class=""btn btn-primary"" id=""SaveBook"">Guardar</button>
                </div>
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<!-- Modal Editar libro -->\r\n<div class=\"modal fade\" id=\"EditBookModal\" tabindex=\"-1\" aria-labelledby=\"exampleModalLabel\" aria-hidden=\"true\">\r\n    <div class=\"modal-dialog\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cc9c6e00b50b26845c4597beddaeb15df55a08ce11639", async() => {
                WriteLiteral(@"
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""exampleModalLabel"">Editar libro</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <input type=""hidden"" id=""EditbookId"" />
                    <div class=""form-group"">
                        <label for=""EditbookTitle"">Nombre del libro</label>
                        <input type=""text"" class=""form-control"" id=""EditbookTitle"" placeholder=""Nombre del libro"" required>
                    </div>
                    <div class=""form-group"">
                        <label for=""EditbookYear"">Año de publicación</label>
                        <input type=""text"" class=""form-control"" id=""EditbookYear"" placeholder=""Año de publicación"" required>
    ");
                WriteLiteral(@"                </div>
                    <div class=""form-group"">
                        <label for=""EditbookNumberPages"">Número de páginas</label>
                        <input type=""number"" class=""form-control"" id=""EditbookNumberPages"" placeholder=""Número de páginas"" required>
                    </div>
                    <div class=""form-group"">
                        <label for=""EditbookAuthor"">Autor</label>
                        <select class=""form-control"" id=""EditbookAuthor"" required></select>
                    </div>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                    <button type=""button"" class=""btn btn-primary"" id=""saveBookChanges"">Guardar</button>
                </div>
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    </div>
</div>

<!-- Modal borrar libro -->
<div class=""modal fade"" id=""DeleteBookModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""smallModalLabel"" aria-hidden=""false"">
    <div class=""modal-dialog modal-sm"">
        <input type=""hidden"" id=""DeleteBookId"" />
    </div>
</div>

");
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
