var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configura o pipeline de requisição HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Exibe uma página de exceção detalhada em desenvolvimento.
}
else
{
    app.UseExceptionHandler("/Error"); // Configura uma página de erro genérica para produção.
    app.UseHsts(); // Adiciona um cabeçalho HSTS.
}

app.UseHttpsRedirection(); // Redireciona todas as requisições HTTP para HTTPS.
app.UseStaticFiles(); // Permite o uso de arquivos estáticos.

app.UseRouting(); // Adiciona o middleware de roteamento.

app.UseAuthorization(); // Adiciona o middleware de autorização.

// Mapeia as Razor Pages para URLs.
app.MapRazorPages();

// Opcional: Adiciona rotas personalizadas se necessário.
// Certifique-se de que não há conflitos com as páginas Razor padrão.
app.MapGet("/custom-form", async context =>
{
    await context.Response.WriteAsync("Esta é uma rota personalizada para o formulário.");
});

app.Run();
