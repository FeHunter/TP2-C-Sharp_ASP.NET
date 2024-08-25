using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // Este método é chamado pelo runtime. Use este método para adicionar serviços ao contêiner.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
    }

    // Este método é chamado pelo runtime. Use este método para configurar o pipeline de requisição HTTP.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        // Configurações de roteamento
        app.UseEndpoints(endpoints =>
        {
            // Roteamento padrão para Razor Pages
            endpoints.MapRazorPages();

            // Adiciona rotas personalizadas se necessário
            // Opcional, remova se não precisar
            endpoints.MapGet("/Form", async context =>
            {
                await context.Response.WriteAsync("Esta é uma rota personalizada para o formulário.");
            });

            // Exemplo de rota com parâmetros
            endpoints.MapGet("/Items/{id}", async context =>
            {
                var id = context.Request.RouteValues["id"];
                await context.Response.WriteAsync($"Você solicitou o item com ID: {id}");
            });
        });
    }
}
