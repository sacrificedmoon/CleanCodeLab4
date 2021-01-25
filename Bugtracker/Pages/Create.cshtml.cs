using System.Net.Http;
using System.Threading.Tasks;
using Bugtracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;

namespace Bugtracker.Pages
{
    public class CreateModel : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty]
        public Bug Bug { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(
                "http://bugtrackerbackend/api/Bug", Bug);
                response.EnsureSuccessStatusCode();
            }
            return RedirectToPage("./Index");
        }
    }
}
