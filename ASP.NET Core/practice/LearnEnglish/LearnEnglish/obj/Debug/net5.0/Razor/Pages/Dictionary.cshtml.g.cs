#pragma checksum "C:\Users\DOM\Desktop\ИЛЬЯ\HTML\C#\The-basis-of-ASP.NET\ASP.NET Core\practice\LearnEnglish\LearnEnglish\Pages\Dictionary.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ad05b38fb5e7f6cfd094e103f58e9fe9fabd44f5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(EmptyRazorPagesApp.Pages.Pages_Dictionary), @"mvc.1.0.razor-page", @"/Pages/Dictionary.cshtml")]
namespace EmptyRazorPagesApp.Pages
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
#line 1 "C:\Users\DOM\Desktop\ИЛЬЯ\HTML\C#\The-basis-of-ASP.NET\ASP.NET Core\practice\LearnEnglish\LearnEnglish\Pages\_ViewImports.cshtml"
using EmptyRazorPagesApp;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad05b38fb5e7f6cfd094e103f58e9fe9fabd44f5", @"/Pages/Dictionary.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"096d39a7a3d184fc0e9f8241fe782213141e8b94", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Dictionary : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/dictionary-style.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("target", new global::Microsoft.AspNetCore.Html.HtmlString("_self"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ad05b38fb5e7f6cfd094e103f58e9fe9fabd44f54948", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ad05b38fb5e7f6cfd094e103f58e9fe9fabd44f55210", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <title>Dictionary</title>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ad05b38fb5e7f6cfd094e103f58e9fe9fabd44f57126", async() => {
                WriteLiteral(@"
        <div class=""main-dictionary-panel"">
            <div class=""container"">
                <div class=""main-dictionary-panel__body"">
                    <div class=""header"">
                        <div class=""header__row"">
                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ad05b38fb5e7f6cfd094e103f58e9fe9fabd44f57655", async() => {
                    WriteLiteral("\r\n                                <input name=\"word\" class=\"textbox\" type=\"text\"");
                    BeginWriteAttribute("placeholder", " placeholder=\"", 548, "\"", 581, 4);
                    WriteAttributeValue("", 562, "Find", 562, 4, true);
                    WriteAttributeValue(" ", 566, "word", 567, 5, true);
                    WriteAttributeValue(" ", 571, "in", 572, 3, true);
#nullable restore
#line 15 "C:\Users\DOM\Desktop\ИЛЬЯ\HTML\C#\The-basis-of-ASP.NET\ASP.NET Core\practice\LearnEnglish\LearnEnglish\Pages\Dictionary.cshtml"
WriteAttributeValue(" ", 574, Model, 575, 6, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(">\r\n                                <input class=\"btn\" type=\"submit\" value=\"Find\">\r\n                                <input class=\"btn blue\" type=\"submit\" value=\"Add word\">\r\n");
                    WriteLiteral("                            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n\r\n                    <div class=\"word-information\">\r\n");
#nullable restore
#line 24 "C:\Users\DOM\Desktop\ИЛЬЯ\HTML\C#\The-basis-of-ASP.NET\ASP.NET Core\practice\LearnEnglish\LearnEnglish\Pages\Dictionary.cshtml"
                         if (!string.IsNullOrWhiteSpace(@Model.inputWord))
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <h3 class=\"title\">Вы хотите добавить новое слово в словарь (");
#nullable restore
#line 26 "C:\Users\DOM\Desktop\ИЛЬЯ\HTML\C#\The-basis-of-ASP.NET\ASP.NET Core\practice\LearnEnglish\LearnEnglish\Pages\Dictionary.cshtml"
                                                                                   Write(Model.inputWord);

#line default
#line hidden
#nullable disable
                WriteLiteral(")?</h3>\r\n");
#nullable restore
#line 27 "C:\Users\DOM\Desktop\ИЛЬЯ\HTML\C#\The-basis-of-ASP.NET\ASP.NET Core\practice\LearnEnglish\LearnEnglish\Pages\Dictionary.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\Users\DOM\Desktop\ИЛЬЯ\HTML\C#\The-basis-of-ASP.NET\ASP.NET Core\practice\LearnEnglish\LearnEnglish\Pages\Dictionary.cshtml"
                         if (@Model.Word != null)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <div class=\"word__translate\">\r\n                               <h3 class=\"title\">Translate</h3>\r\n                               <div class=\"translate__row\">\r\n                                 <p class=\"text\">");
#nullable restore
#line 33 "C:\Users\DOM\Desktop\ИЛЬЯ\HTML\C#\The-basis-of-ASP.NET\ASP.NET Core\practice\LearnEnglish\LearnEnglish\Pages\Dictionary.cshtml"
                                            Write(Model.Word.Value);

#line default
#line hidden
#nullable disable
                WriteLiteral("    →    ");
#nullable restore
#line 33 "C:\Users\DOM\Desktop\ИЛЬЯ\HTML\C#\The-basis-of-ASP.NET\ASP.NET Core\practice\LearnEnglish\LearnEnglish\Pages\Dictionary.cshtml"
                                                                      Write(Model.Word.Translate);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>
                               </div>
                           </div>
                           <div class=""word__transcription"">
                                <p class=""text"">Model.word.Transcription</p>
                           </div>
                           <div class=""word__examples"">
");
                WriteLiteral("                           </div>\r\n");
#nullable restore
#line 42 "C:\Users\DOM\Desktop\ИЛЬЯ\HTML\C#\The-basis-of-ASP.NET\ASP.NET Core\practice\LearnEnglish\LearnEnglish\Pages\Dictionary.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <h3 class=\"title\">Select word</h3>\r\n");
#nullable restore
#line 46 "C:\Users\DOM\Desktop\ИЛЬЯ\HTML\C#\The-basis-of-ASP.NET\ASP.NET Core\practice\LearnEnglish\LearnEnglish\Pages\Dictionary.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    </div>

                    <div class=""list-of-words"">
                        <div class=""list-of-words__header"">
                            <h3 class=""title"">Words in ''DictionaryTitle''</h3>
                        </div>
                        <div class=""list-of-words__list"">
                            <div class=""word-panel"">
                                <div class=""word-panel__row"">
                                    <a href=""#"" class=""black word-item"">○ Diffucult</a>
                                    <a href=""#"" class=""blue see-translate-btn"">Быстрый перевод</a>
                                </div>
                            </div>
                            <div class=""word-panel"">
                                <div class=""word-panel__row"">
                                    <a href=""#"" class=""black word-item"">○ Angry</a>
                                    <a href=""#"" class=""blue see-translate-btn"">Быстрый перевод</a>
                            ");
                WriteLiteral(@"    </div>
                            </div>
                            <div class=""word-panel"">
                                <div class=""word-panel__row"">
                                    <a href=""#"" class=""black word-item"">○ Fast</a>
                                    <a href=""#"" class=""blue see-translate-btn"">Быстрый перевод</a>
                                </div>
                            </div>
                            <div class=""word-panel"">
                                <div class=""word-panel__row"">
                                    <a href=""#"" class=""black word-item"">○ Subway</a>
                                    <a href=""#"" class=""blue see-translate-btn"">Быстрый перевод</a>
                                </div>
                            </div>
                            <div class=""word-panel"">
                                <div class=""word-panel__row"">
                                    <a href=""#"" class=""black word-item"">○ Current</a>
                ");
                WriteLiteral(@"                    <a href=""#"" class=""blue see-translate-btn"">Быстрый перевод</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LearnEnglish.Pages.DictionaryModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<LearnEnglish.Pages.DictionaryModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<LearnEnglish.Pages.DictionaryModel>)PageContext?.ViewData;
        public LearnEnglish.Pages.DictionaryModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
