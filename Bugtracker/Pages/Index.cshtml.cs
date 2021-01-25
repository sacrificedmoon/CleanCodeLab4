using Bugtracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bugtracker.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public IList<Bug> Bugs { get; set; }

        public async Task OnGetAsync()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var request = new System.Net.Http.HttpRequestMessage();
                request.RequestUri = new Uri("http://bugtrackerbackend/api/bug");
                var response = await client.SendAsync(request);
                if (response != null)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    JArray a = JArray.Parse(responseString);
                    Bugs = a.ToObject<IList<Bug>>();
                }
            }
        }
    }
}
