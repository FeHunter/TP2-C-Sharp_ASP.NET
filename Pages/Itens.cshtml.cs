using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace MyApp.Namespace
{
    public class ItensModel : PageModel
    {
        public List<string> Items { get; private set; } = new List<string>();

        public void OnGet()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "UserNames.txt");

            if (System.IO.File.Exists(filePath))
            {
                Items = System.IO.File.ReadAllLines(filePath).ToList();
            }
            else
            {
                Items.Add("Lista vazia.");
            }
        }
    }
}
