using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class ItensModel : PageModel
    {
        public List<string> Items { get; private set; }

        public void OnGet()
        {
            Items = new List<string> { "Item 1", "Item 2", "Item 3" };
        }
    }
}
