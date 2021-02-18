using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorCSSJsisolation.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        IJSRuntime JSRuntime { get; set; }

        private Task<IJSObjectReference> _module;

        private Task<IJSObjectReference> Module => _module ??= JSRuntime.InvokeAsync<IJSObjectReference>("import", "./tools.js").AsTask();

        protected async Task SayHello()
        {
            var module = await Module;
            await module.InvokeVoidAsync("HelloWorld");
        }
    }
}
