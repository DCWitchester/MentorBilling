using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace MentorBilling.Miscellaneous
{
    public class WindowDimensions
    {
        public Int32 Width { get; set; }
        public Int32 Height { get; set; }
    }
    public class BrowserServices
    {
        private readonly IJSRuntime _js;
        
        public BrowserServices(IJSRuntime jS)
        {
            _js = jS;
        }
        public async Task<WindowDimensions> GetDimensions()
        {
            return await _js.InvokeAsync<WindowDimensions>("getDimensions");
        }

    }
}
