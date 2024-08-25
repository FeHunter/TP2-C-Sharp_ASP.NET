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

            // Caminho do arquivo
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Data", "UserNames.txt");

            // Verifica o caminho do arquivo
            System.Diagnostics.Debug.WriteLine($"File path: {filePath}");

            // Cria o diretório se não existir
            string directoryPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                System.Diagnostics.Debug.WriteLine($"Directory created: {directoryPath}");
            }

            // Salva o nome de usuário no arquivo
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, append: true))
                {
                    writer.WriteLine(UserName);
                    System.Diagnostics.Debug.WriteLine($"User name saved: {UserName}");
                }
            }
            catch (IOException ex)
            {
                // Loga o erro se não puder escrever no arquivo
                System.Diagnostics.Debug.WriteLine($"Error writing to file: {ex.Message}");
                ModelState.AddModelError("", "Error saving data. Please try again.");
                return Page();
            }

            // Depois de salvar, redireciona para a página de itens
            return RedirectToPage("/Itens");
        }
    }
}
