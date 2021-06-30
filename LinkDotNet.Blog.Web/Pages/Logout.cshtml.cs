using System.Threading.Tasks;
using LinkDotNet.Blog.Web.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LinkDotNet.Blog.Web.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly ILoginManager loginManager;

        public LogoutModel(ILoginManager loginManager)
        {
            this.loginManager = loginManager;
        }

        public async Task OnGet()
        {
            await loginManager.SignOutAsync();
        }
    }
}
