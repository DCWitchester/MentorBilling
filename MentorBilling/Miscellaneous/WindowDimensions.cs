using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace MentorBilling.Miscellaneous
{
    public class BrowserServices
    {
        private readonly IJSRuntime _js;
        
        public BrowserServices(IJSRuntime jS)
        {
            _js = jS;
        }
        public async Task<Size> GetDimensions()
        {
            return await _js.InvokeAsync<Size>("getDimensions");
        }

    }
}
