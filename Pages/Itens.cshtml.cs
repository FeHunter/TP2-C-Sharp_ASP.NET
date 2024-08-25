using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;

namespace MyApp.Namespace
{
    public class ItensModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ItensModel(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public List<string> Items { get; private set; } = new List<string>();

        public void OnGet()
        {
            // Caminho do arquivo
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Data", "UserNames.txt");

            // Verifica se o arquivo existe
            if (System.IO.File.Exists(filePath))
            {
                // Lê todas as linhas e converte para lista
                Items = System.IO.File.ReadAllLines(filePath).ToList();
            }
            else
            {
                // Adiciona mensagem caso o arquivo não exista
                Items.Add("Lista vazia.");
            }
        }
    }
}
