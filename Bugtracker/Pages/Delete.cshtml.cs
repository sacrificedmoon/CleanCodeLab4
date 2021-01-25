using System;
using System.Threading.Tasks;
using Bugtracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Bugtracker.Pages
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Bug Bug { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var client = new System.Net.Http.HttpClient())
            {
                var request = new System.Net.Http.HttpRequestMessage();
                request.RequestUri = new Uri("http://bugtrackerbackend/api/bug/" + id);
                var response = await client.SendAsync(request);
                var responseString = await response.Content.ReadAsStringAsync();
                Bug = JsonConvert.DeserializeObject<Bug>(responseString);
            }

            if (Bug == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (Bug != null)
            {
                using (var client = new System.Net.Http.HttpClient())
                {
                    var requestUri = new Uri("http://bugtrackerbackend/api/bug/" + id);
                    var response = await client.DeleteAsync(requestUri);
                }
            }

            return RedirectToPage("./Index");
        }

    }
}
