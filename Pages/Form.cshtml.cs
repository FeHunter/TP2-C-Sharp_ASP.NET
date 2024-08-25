using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace MyApp.Namespace
{
    public class FormModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FormModel(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        [Required(ErrorMessage = "User name is required")]
        [StringLength(100, ErrorMessage = "User name cannot exceed 100 characters")]
        public string UserName { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Retorna à página se a validação falhar.
            }

            // Se o ModelState for válido, podemos salvar o nome de usuário no arquivo.
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Data", "UserNames.txt");

            // Cria o diretório se não existir
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                writer.WriteLine(UserName);
            }

            // Depois de salvar
            return RedirectToPage("/Itens");
        }
    }
}
